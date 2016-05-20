using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Reads saved game files.
    /// </summary>
    public static class SavedGameFileReader
    {
        /// <summary>
        /// Reads a saved game file.
        /// </summary>
        /// <param name="path">Path to saved game.</param>
        /// <returns>SavedGame with drivers and results.</returns>
        public static SavedGame ReadSavedGame(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);

            int numberOfRacesCompleted = GetNumberOfRacesCompleted(bytes);
            List<SavedGameDriver> drivers = ParseDrivers(bytes, numberOfRacesCompleted);

            var savedGame = new SavedGame(drivers, numberOfRacesCompleted);

            return savedGame;
        }

        private static int GetNumberOfRacesCompleted(byte[] bytes)
        {
            int races = bytes[26] + 1;
            return races;
        }

        private static List<SavedGameDriver> ParseDrivers(byte[] bytes, int racesCompleted)
        {
            var drivers = new List<SavedGameDriver>();

            for (int driverIndex = 0; driverIndex < Constants.NumberOfDrivers; driverIndex++)
            {
                int position = 2094 + driverIndex * SavedGameFileConstants.DriverNameLength;
                var name = GetNameAtPosition(bytes, position);

                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                var driver = new SavedGameDriver
                {
                    Name = name,
                    Results = GetDriverResults(bytes, driverIndex, racesCompleted)
                };

                drivers.Add(driver);
            }

            return drivers;
        }

        private static string GetNameAtPosition(byte[] nameData, int position)
        {
            byte[] nameBytes = nameData.Skip(position).TakeWhile(b => b != 0).ToArray();
            string name = Encoding.ASCII.GetString(nameBytes);

            return name;
        }

        private static List<int> GetDriverResults(byte[] bytes, int driverIndex, int racesCompleted)
        {
            var results = new List<int>();

            for (int i = 0; i <= racesCompleted - 1; i++)
            {
                int resultPosition = SavedGameFileConstants.ResultsStartPoint + (SavedGameFileConstants.RacesPerSeason * driverIndex) + i;
                int result = bytes[resultPosition];

                results.Add(result);
            }

            return results;
        }
    }

    internal static class SavedGameFileConstants
    {
        internal const int DriverNameLength = 24;
        internal const int ResultsStartPoint = 828;
        internal const int RacesPerSeason = 16;
    }
}
