using System.Text;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData;

/// <summary>
/// Reads saved game files.
/// </summary>
public class SavedGameFileReader
{
    /// <summary>
    /// Reads a saved game file.
    /// </summary>
    /// <param name="path">Path to saved game.</param>
    /// <returns>SavedGame with drivers and results.</returns>
    public SavedGame Read(string path)
    {
        if (path == null) { throw new ArgumentNullException(nameof(path)); }
        if (!File.Exists(path)) { throw new FileNotFoundException($"Could not find saved game file '{path}'."); }

        using var reader = new BinaryReader(StreamProvider.Invoke(path));
        byte[] bytes = reader.ReadAllBytes();

        int numberOfRacesCompleted = GetNumberOfRacesCompleted(bytes);
        SavedGameDriverList drivers = ParseDrivers(bytes, numberOfRacesCompleted);

        var savedGame = new SavedGame(drivers, numberOfRacesCompleted);

        return savedGame;
    }

    private static int GetNumberOfRacesCompleted(byte[] bytes)
    {
        int races = bytes[26] + 1;
        return races;
    }

    private static SavedGameDriverList ParseDrivers(byte[] bytes, int racesCompleted)
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

        return new SavedGameDriverList(drivers);
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

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
}

internal static class SavedGameFileConstants
{
    internal const int DriverNameLength = 24;
    internal const int ResultsStartPoint = 828;
    internal const int RacesPerSeason = 16;
}
