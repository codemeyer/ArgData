using System;
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
            ValidateFile(path);

            byte[] nameData = File.ReadAllBytes(path);

            var drivers = ParseDrivers(nameData);
            var teams = ParseTeams(nameData);

            return new NameFile(drivers, teams);
        }

        private void ValidateFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 1484)
            {
                throw new Exception($"The file '{path}' does not appear to be a name file.");
            }
        }

        private NameFileDriverList ParseDrivers(byte[] nameData)
        {
            var drivers = new NameFileDriverList();

            for (int driverIndex = 0; driverIndex < Constants.NumberOfDrivers; driverIndex++)
            {
                int position = driverIndex * DriverNameLength;
                var name = GetNameAtPosition(nameData, position);

                drivers[driverIndex].Name = name;
            }

            return drivers;
        }

        private NameFileTeamList ParseTeams(byte[] nameData)
        {
            var teams = new NameFileTeamList();

            for (int teamIndex = 0; teamIndex < Constants.NumberOfTeams; teamIndex++)
            {
                int position = 960 + (teamIndex * TeamNameLength);
                string name = GetNameAtPosition(nameData, position);

                int enginePosition = position + 260;
                string engine = GetNameAtPosition(nameData, enginePosition);

                teams[teamIndex].Name = name;
                teams[teamIndex].Engine = engine;
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
        public void Write(string path, NameFileDriverList drivers, NameFileTeamList teams)
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

        private void WriteDrivers(FileStream namesFile, NameFileDriverList drivers)
        {
            foreach (var driver in drivers)
            {
                string driverName = driver.Name.PadRight(DriverNameLength, '\0');
                byte[] nameBytes = Encoding.ASCII.GetBytes(driverName);
                namesFile.Write(nameBytes, 0, DriverNameLength);
            }
        }

        private void WriteTeams(FileStream namesFile, NameFileTeamList teams)
        {
            foreach (var team in teams)
            {
                string teamName = team.Name.PadRight(TeamNameLength, '\0');
                byte[] teamNameBytes = Encoding.ASCII.GetBytes(teamName);
                namesFile.Write(teamNameBytes, 0, TeamNameLength);
            }
        }

        private void WriteEngines(FileStream namesFile, NameFileTeamList teams)
        {
            foreach (var team in teams)
            {
                string engineName = team.Engine.PadRight(TeamNameLength, '\0');
                byte[] engineNameBytes = Encoding.ASCII.GetBytes(engineName);
                namesFile.Write(engineNameBytes, 0, TeamNameLength);
            }
        }
    }
}
