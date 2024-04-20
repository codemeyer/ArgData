using ArgData.Entities;
using ArgData.IO;

namespace ArgData;

/// <summary>
/// Reads damage settings.
/// </summary>
public class DamageSettingsReader
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a DamageSettingsReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>DamageSettingsReader.</returns>
    public DamageSettingsReader(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a DamageSettingsReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>DamageSettingsReader.</returns>
    public static DamageSettingsReader For(GpExeFile exeFile)
    {
        return new DamageSettingsReader(exeFile);
    }

    /// <summary>
    /// Reads damage settings.
    /// </summary>
    /// <returns>DamageSettings.</returns>
    public DamageSettings Read()
    {
        var settings = new DamageSettings();

        using var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath));

        reader.BaseStream.Position = _exeFile.GetRetireAfterHittingWallPosition();
        settings.RetireAfterHittingWall = reader.ReadInt16();

        reader.BaseStream.Position = _exeFile.GetRetireAfterHittingOtherCarPosition();
        settings.RetireAfterHittingOtherCar = reader.ReadInt16();

        reader.BaseStream.Position = _exeFile.GetDamageAfterHittingWallPosition();
        settings.DamageAfterHittingWall = reader.ReadInt16();

        reader.BaseStream.Position = _exeFile.GetDamageAfterHittingOtherCarPosition();
        settings.DamageAfterHittingOtherCar = reader.ReadInt16();

        reader.BaseStream.Position = _exeFile.GetYellowFlagsForStationaryCarsAfterSecondsPosition();
        settings.YellowFlagsForStationaryCarsAfterSeconds = Convert.ToByte(reader.ReadUInt16() / 1000);

        reader.BaseStream.Position = _exeFile.GetRetiredCarsRemovedAfterSecondsPosition();
        settings.RetiredCarsRemovedAfterSeconds = Convert.ToByte(reader.ReadUInt16() / 1000);

        return settings;
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
}

/// <summary>
/// Writes damage settings.
/// </summary>
public class DamageSettingsWriter
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a DamageSettingsWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to write to.</param>
    /// <returns>DamageSettingsWriter.</returns>
    public DamageSettingsWriter(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a DamageSettingsWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to write to.</param>
    /// <returns>DamageSettingsWriter.</returns>
    public static DamageSettingsWriter For(GpExeFile exeFile)
    {
        return new DamageSettingsWriter(exeFile);
    }

    /// <summary>
    /// Writes damage settings to the EXE.
    /// </summary>
    /// <param name="settings">DamageSettings to write.</param>
    public void Write(DamageSettings settings)
    {
        if (settings == null) { throw new ArgumentNullException(nameof(settings)); }

        if (!settings.IsValid)
            throw new ArgumentOutOfRangeException(nameof(settings), "One or more damage settings are invalid.");

        using var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath));
        writer.BaseStream.Position = _exeFile.GetRetireAfterHittingWallPosition();
        writer.Write(settings.RetireAfterHittingWall);

        writer.BaseStream.Position = _exeFile.GetRetireAfterHittingOtherCarPosition();
        writer.Write(settings.RetireAfterHittingOtherCar);

        writer.BaseStream.Position = _exeFile.GetDamageAfterHittingWallPosition();
        writer.Write(settings.DamageAfterHittingWall);

        writer.BaseStream.Position = _exeFile.GetDamageAfterHittingOtherCarPosition();
        writer.Write(settings.DamageAfterHittingOtherCar);

        ushort yellowValue = Convert.ToUInt16(settings.YellowFlagsForStationaryCarsAfterSeconds * 1000);
        writer.BaseStream.Position = _exeFile.GetYellowFlagsForStationaryCarsAfterSecondsPosition();
        writer.Write(yellowValue);

        ushort removedValue = Convert.ToUInt16(settings.RetiredCarsRemovedAfterSeconds * 1000);
        writer.BaseStream.Position = _exeFile.GetRetiredCarsRemovedAfterSecondsPosition();
        writer.Write(removedValue);
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
}
