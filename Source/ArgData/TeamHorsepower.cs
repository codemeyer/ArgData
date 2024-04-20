using ArgData.IO;
using ArgData.Validation;

namespace ArgData;

/// <summary>
/// Read the horsepower values of teams in a GP.EXE file.
/// </summary>
public class TeamHorsepowerReader
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a TeamHorsepowerReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>TeamHorsepowerReader.</returns>
    public TeamHorsepowerReader(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a TeamHorsepowerReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>TeamHorsepowerReader.</returns>
    public static TeamHorsepowerReader For(GpExeFile exeFile)
    {
        return new TeamHorsepowerReader(exeFile);
    }

    /// <summary>
    /// Reads the horsepower value of the team at the specified index.
    /// </summary>
    /// <param name="teamIndex">Index of team to read horsepower value for.</param>
    /// <returns>Team horsepower value.</returns>
    public int ReadTeamHorsepower(int teamIndex)
    {
        TeamIndexValidator.Validate(teamIndex);

        using var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath));
        reader.BaseStream.Position = _exeFile.GetTeamHorsepowerPosition(teamIndex);

        ushort horsepower = reader.ReadUInt16();

        return horsepower;
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
}

/// <summary>
/// Writes horsepower values of teams to a GP.EXE file.
/// </summary>
public class TeamHorsepowerWriter
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a TeamHorsepowerWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to write to.</param>
    /// <returns>TeamHorsepowerWriter.</returns>
    public TeamHorsepowerWriter(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a TeamHorsepowerWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to write to.</param>
    /// <returns>TeamHorsepowerWriter.</returns>
    public static TeamHorsepowerWriter For(GpExeFile exeFile)
    {
        return new TeamHorsepowerWriter(exeFile);
    }

    /// <summary>
    /// Writes the horsepower value for the team at the specified index.
    /// </summary>
    /// <param name="teamIndex">Index of team to read horsepower value for.</param>
    /// <param name="horsepower">Horsepower value to write.</param>
    public void WriteTeamHorsepower(int teamIndex, int horsepower)
    {
        TeamIndexValidator.Validate(teamIndex);

        using var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath));
        writer.BaseStream.Position = _exeFile.GetTeamHorsepowerPosition(teamIndex);
        writer.Write((ushort)horsepower);
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
}
