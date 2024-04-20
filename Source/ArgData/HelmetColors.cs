﻿using ArgData.Entities;
using ArgData.IO;

namespace ArgData;

/// <summary>
/// Reads driver helmet colors.
/// </summary>
public class HelmetColorReader
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a HelmetColorReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>HelmetColorReader.</returns>
    public HelmetColorReader(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a HelmetColorReader for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>HelmetColorReader.</returns>
    public static HelmetColorReader For(GpExeFile exeFile)
    {
        return new HelmetColorReader(exeFile);
    }

    /// <summary>
    /// Reads the colors of all the helmets in the file.
    /// </summary>
    /// <returns>HelmetList object with the colors of all the helmets.</returns>
    public HelmetList ReadHelmetColors()
    {
        using var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath));
        var list = new HelmetList();

        for (int i = 0; i < Constants.NumberOfDrivers; i++)
        {
            reader.BaseStream.Position = _exeFile.GetHelmetColorsPosition(i);
            int bytesToRead = _exeFile.GetHelmetColorsPositionByteCountToRead(i);
            byte[] helmetBytes = reader.ReadBytes(bytesToRead);

            list.GetByDriverNumber(Convert.ToByte(i + 1)).SetColors(helmetBytes);
        }

        return list;
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
}

/// <summary>
/// Writes driver helmet colors.
/// </summary>
public class HelmetColorWriter
{
    private readonly GpExeFile _exeFile;

    /// <summary>
    /// Creates a HelmetColorWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>HelmetColorWriter.</returns>
    public HelmetColorWriter(GpExeFile exeFile)
    {
        _exeFile = exeFile ?? throw new ArgumentNullException(nameof(exeFile));
    }

    /// <summary>
    /// Creates a HelmetColorWriter for the specified GP.EXE file.
    /// </summary>
    /// <param name="exeFile">GpExeFile to read from.</param>
    /// <returns>HelmetColorWriter.</returns>
    public static HelmetColorWriter For(GpExeFile exeFile)
    {
        return new HelmetColorWriter(exeFile);
    }

    /// <summary>
    /// Writes the colors of all the helmets in the file.
    /// </summary>
    /// <param name="helmetList">HelmetList.</param>
    public void WriteHelmetColors(HelmetList helmetList)
    {
        if (helmetList == null) { throw new ArgumentNullException(nameof(helmetList)); }

        int helmetIndex = 0;

        var allHelmetBytes = new List<byte>();

        foreach (Helmet helmet in helmetList)
        {
            byte[] helmetBytes = helmet.GetColorsToWriteToFile(helmetIndex, _exeFile.ExeInfo.IsDecompressed);

            allHelmetBytes.AddRange(helmetBytes);

            helmetIndex++;
        }

        using var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath));
        writer.BaseStream.Position = _exeFile.GetHelmetColorsPosition(0);
        writer.Write(allHelmetBytes.ToArray());
    }

    /// <summary>
    /// Default FileStream provider. Can be overridden in tests.
    /// </summary>
    internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
}
