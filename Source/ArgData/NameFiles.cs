using System.Text;
using ArgData.Entities;
using ArgData.Internals;
using ArgData.IO;

namespace ArgData;

/// <summary>
/// Reads a name file from disk.
/// </summary>
public class NameFileReader
{
    /// <summary>
    /// Read a name file.
    /// </summary>
    /// <param name="path">Path to file.</param>
    /// <returns>NameFile with teams, engines and driver names.</returns>
    public NameFile Read(string path)
    {
        ValidateFile(path);

        using var reader = new BinaryReader(StreamProvider.Invoke(path));
        byte[] nameData = reader.ReadAllBytes();

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

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
}


/// <summary>
/// Writes a name file to disk.
/// </summary>
public class NameFileWriter
{
    /// <summary>
    /// Write name file.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="drivers">List of drivers, where index indicates driver number.</param>
    /// <param name="teams">List of teams.</param>
    public void Write(string path, NameFileDriverList drivers, NameFileTeamList teams)
    {
        var byteList = new ByteList();

        foreach (var driver in drivers)
        {
            string driverName = PadTruncate(driver.Name, NameFileConstants.DriverNameLength);
            byte[] nameBytes = Encoding.ASCII.GetBytes(driverName);

            byteList.AddBytes(nameBytes);
        }

        foreach (var team in teams)
        {
            string teamName = PadTruncate(team.Name, NameFileConstants.TeamNameLength);
            byte[] teamNameBytes = Encoding.ASCII.GetBytes(teamName);

            byteList.AddBytes(teamNameBytes);
        }

        foreach (var team in teams)
        {
            string engineName = PadTruncate(team.Engine, NameFileConstants.TeamNameLength);
            byte[] engineNameBytes = Encoding.ASCII.GetBytes(engineName);
            byteList.AddBytes(engineNameBytes);
        }

        var checksum = new ChecksumCalculator().Calculate(byteList.GetBytes());

        using var writer = new BinaryWriter(StreamProvider.Invoke(path));
        writer.Write(byteList.GetBytes());
        writer.Write((ushort)checksum.Checksum1);
        writer.Write((ushort)checksum.Checksum2);
    }

    private static string PadTruncate(string value, int wantedLength)
    {
        var trimmedValue = value.Length < wantedLength
            ? value
            : value.Substring(0, wantedLength - 1);

        return trimmedValue.PadRight(wantedLength, '\0');
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
}

internal static class NameFileConstants
{
    internal const int DriverNameLength = 24;
    internal const int TeamNameLength = 13;
}