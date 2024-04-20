namespace ArgData;

/// <summary>
/// Contains details such as version number for a GP.EXE file.
/// </summary>
public class GpExeInfo
{
    /// <summary>
    /// Gets whether the file is a known GP.EXE file or not.
    /// </summary>
    public bool IsKnownExeVersion { get; internal set; }

    /// <summary>
    /// Gets the version of the executable as a GpExeVersionInfo enum.
    /// </summary>
    public GpExeVersionInfo Version { get; internal set; }

    /// <summary>
    /// Gets whether editing this GP.EXE file is supported by ArgData.
    /// </summary>
    public bool IsEditingSupported { get; internal set; }

    /// <summary>
    /// Gets whether the GP.EXE is decompressed.
    /// </summary>
    public bool IsDecompressed { get; internal set; }
}
