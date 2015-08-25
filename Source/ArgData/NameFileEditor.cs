using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Reads or writes a name file.
    /// </summary>
    public class NameFileEditor
    {
        private const int DriverNameLength = 24;
        private const int TeamNameLength = 13;

        /// <summary>
        /// Read a name file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>NameFile with teams, engines and driver names.</returns>
        public NameFile Read(string path)
        {
            // TODO: check that this is a name file
            byte[] nameData = File.ReadAllBytes(path);

            var drivers = ParseDrivers(nameData);
            var teams = ParseTeams(nameData);

            return new NameFile(drivers, teams);
        }

        private List<Driver> ParseDrivers(byte[] nameData)
        {
            var drivers = new List<Driver>();

            for (int driverIndex = 0; driverIndex < Constants.NumberOfDrivers; driverIndex++)
            {
                int position = driverIndex * DriverNameLength;
                var name = GetNameAtPosition(nameData, position);

                drivers.Add(new Driver { Name = name });
            }

            return drivers;
        }

        private List<Team> ParseTeams(byte[] nameData)
        {
            var teams = new List<Team>();

            for (int teamIndex = 0; teamIndex < Constants.NumberOfTeams; teamIndex++)
            {
                int position = 960 + (teamIndex * TeamNameLength);
                string name = GetNameAtPosition(nameData, position);

                int enginePosition = position + 260;
                string engine = GetNameAtPosition(nameData, enginePosition);

                var team = new Team
                {
                    Name = name,
                    Engine = engine
                };
                teams.Add(team);
            }

            return teams;
        }

        private static string GetNameAtPosition(byte[] nameData, int position)
        {
            byte[] nameBytes = nameData.Skip(position).TakeWhile(b => b != 0).ToArray();
            string name = Encoding.ASCII.GetString(nameBytes);

            return name;
        }

        /// <summary>
        /// Write name file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="drivers">List of drivers, where index indicates driver number.</param>
        /// <param name="teams">List of teams.</param>
        public void Write(string path, IList<Driver> drivers, IList<Team> teams)
        {
            FileStream namesFile = File.Create(path);

            WriteDrivers(namesFile, drivers);
            WriteTeams(namesFile, teams);
            WriteEngines(namesFile, teams);

            namesFile.Write(new byte[4] { 0, 0, 0, 0}, 0, 4);

            namesFile.Close();
            namesFile.Dispose();

            ChecksumCalculator.UpdateChecksum(path);
        }

        private void WriteDrivers(FileStream namesFile, IList<Driver> drivers)
        {
            // TODO: do not manipulate the list
            while (drivers.Count < Constants.NumberOfDrivers)
            {
                drivers.Add(new Driver { Name = "Spare" });
            }

            foreach (var driver in drivers)
            {
                string driverName = driver.Name.PadRight(DriverNameLength, '\0');
                byte[] nameBytes = Encoding.ASCII.GetBytes(driverName);
                namesFile.Write(nameBytes, 0, DriverNameLength);
            }
        }

        private void WriteTeams(FileStream namesFile, IList<Team> teams)
        {
            // TODO: do not manipulate the list
            while (teams.Count < Constants.NumberOfTeams)
            {
                teams.Add(new Team { Name = "Spare", Engine = "Spare" });
            }

            foreach (var team in teams)
            {
                string teamName = team.Name.PadRight(TeamNameLength, '\0');
                byte[] teamNameBytes = Encoding.ASCII.GetBytes(teamName);
                namesFile.Write(teamNameBytes, 0, TeamNameLength);
            }
        }

        private void WriteEngines(FileStream namesFile, IList<Team> teams)
        {
            // TODO: do not manipulate the list
            while (teams.Count < Constants.NumberOfTeams)
            {
                teams.Add(new Team { Name = "Spare", Engine = "Spare" });
            }

            foreach (var team in teams)
            {
                string engineName = team.Engine.PadRight(TeamNameLength, '\0');
                byte[] engineNameBytes = Encoding.ASCII.GetBytes(engineName);
                namesFile.Write(engineNameBytes, 0, TeamNameLength);
            }
        }
    }
}
