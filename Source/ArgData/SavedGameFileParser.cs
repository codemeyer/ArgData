using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgData
{
    public class SavedGameFileParser
    {
        private const int DriverNameLength = 24;
        private const int ResultsStartPoint = 828;
        private const int RacesPerSeason = 16;

        public SavedGame Parse(byte[] bytes)
        {
            var savedGame = new SavedGame();

            savedGame.NumberOfRacesCompleted = GetNumberOfRacesCompleted(bytes);
            savedGame.Drivers = ParseDrivers(bytes, savedGame.NumberOfRacesCompleted);

            return savedGame;
        }

        private int GetNumberOfRacesCompleted(byte[] bytes)
        {
            int races = bytes[26] + 1;
            return races;
        }

        private List<Driver> ParseDrivers(byte[] bytes, int racesCompleted)
        {
            var drivers = new List<Driver>();

            for (int driverIndex = 0; driverIndex <= 34; driverIndex++)
            {
                int position = 2094 + driverIndex * DriverNameLength;
                var name = GetNameAtPosition(bytes, position);

                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                var driver = new Driver
                                    {
                                        Name = name
                                    };

                driver.Results = GetDriverResults(bytes, driverIndex, racesCompleted);

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

        private List<int> GetDriverResults(byte[] bytes, int driverIndex, int racesCompleted)
        {
            var results = new List<int>();

            for (int i = 0; i <= racesCompleted - 1; i++)
            {
                int resultPosition = ResultsStartPoint + (RacesPerSeason * driverIndex) + i;
                int result = bytes[resultPosition];

                results.Add(result);
            }
            
            return results;
        }
    }
}