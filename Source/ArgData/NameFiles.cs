using System;
using System.IO;
using System.Linq;
using System.Text;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Reads a name file from disk.
    /// </summary>
    public static class NameFileReader
    {
        /// <summary>
        /// Read a name file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>NameFile with teams, engines and driver names.</returns>
        public static NameFile Read(string path)
        {
            ValidateFile(path);

            byte[] nameData = File.ReadAllBytes(path);

            var drivers = ParseDrivers(nameData);
            var teams = ParseTeams(nameData);

            return new NameFile(drivers, teams);
        }

        private static void ValidateFile(string path)
        {
            if (!File.Exists(path)) { throw new FileNotFoundException("Could not find name file", path); }

            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 1484)
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a name file.");
            }
        }

        private static NameFileDriverList ParseDrivers(byte[] nameData)
        {
            var drivers = new NameFileDriverList();

            for (int driverIndex = 0; driverIndex < Constants.NumberOfDrivers; driverIndex++)
            {
                int position = driverIndex * NameFileConstants.DriverNameLength;
                var name = GetNameAtPosition(nameData, position);

                drivers[driverIndex].Name = name;
            }

            return drivers;
        }

        private static NameFileTeamList ParseTeams(byte[] nameData)
        {
            var teams = new NameFileTeamList();

            for (int teamIndex = 0; teamIndex < Constants.NumberOfTeams; teamIndex++)
            {
                int position = 960 + (teamIndex * NameFileConstants.TeamNameLength);
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
    }


    /// <summary>
    /// Writes a name file to disk.
    /// </summary>
    public static class NameFileWriter
    {
        /// <summary>
        /// Write name file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="drivers">List of drivers, where index indicates driver number.</param>
        /// <param name="teams">List of teams.</param>
        public static void Write(string path, NameFileDriverList drivers, NameFileTeamList teams)
        {
            using (FileStream namesFile = File.Create(path))
            {
                WriteDrivers(namesFile, drivers);
                WriteTeams(namesFile, teams);
                WriteEngines(namesFile, teams);

                namesFile.Write(new byte[4] { 0, 0, 0, 0 }, 0, 4);
            }

            ChecksumCalculator.UpdateChecksum(path);
        }

        private static void WriteDrivers(FileStream namesFile, NameFileDriverList drivers)
        {
            foreach (var driver in drivers)
            {
                string driverName = PadTruncate(driver.Name, NameFileConstants.DriverNameLength);
                byte[] nameBytes = Encoding.ASCII.GetBytes(driverName);
                namesFile.Write(nameBytes, 0, NameFileConstants.DriverNameLength);
            }
        }

        private static void WriteTeams(FileStream namesFile, NameFileTeamList teams)
        {
            foreach (var team in teams)
            {
                string teamName = PadTruncate(team.Name, NameFileConstants.TeamNameLength);
                byte[] teamNameBytes = Encoding.ASCII.GetBytes(teamName);
                namesFile.Write(teamNameBytes, 0, NameFileConstants.TeamNameLength);
            }
        }

        private static void WriteEngines(FileStream namesFile, NameFileTeamList teams)
        {
            foreach (var team in teams)
            {
                string engineName = PadTruncate(team.Engine, NameFileConstants.TeamNameLength);
                byte[] engineNameBytes = Encoding.ASCII.GetBytes(engineName);
                namesFile.Write(engineNameBytes, 0, NameFileConstants.TeamNameLength);
            }
        }

        private static string PadTruncate(string value, int wantedLength)
        {
            var trimmedValue = value.Length < wantedLength
                ? value
                : value.Substring(0, wantedLength - 1);

            return trimmedValue.PadRight(wantedLength, '\0');
        }
    }

    internal static class NameFileConstants
    {
        internal const int DriverNameLength = 24;
        internal const int TeamNameLength = 13;
    }
}
