namespace ArgData.Entities;

/// <summary>
/// Offsets into the track file. These are updated automatically when the track is saved.
/// </summary>
public class TrackOffsets
{
    /// <summary>
    /// Gets the base offset value.
    /// </summary>
    public short BaseOffset { get; internal set; }

    /// <summary>
    /// Gets the Unknown2 value.
    ///
    /// In the original tracks, this value is always identical to Unknown4.
    /// </summary>
    public short Unknown2 { get; internal set; }

    /// <summary>
    /// Gets the Unknown3 value.
    /// </summary>
    public short Unknown3 { get; internal set; }

    /// <summary>
    /// Gets the Unknown4 value.
    ///
    /// In the original tracks, this value is always identical to Unknown2.
    /// </summary>
    public short Unknown4 { get; internal set; }

    /// <summary>
    /// Gets the offset position of the file checksum.
    /// </summary>
    public short ChecksumPosition { get; internal set; }

    /// <summary>
    /// Gets the offset position of object data.
    /// </summary>
    public short ObjectData { get; internal set; }

    /// <summary>
    /// Gets the offset position of track section header and data.
    /// </summary>
    public short TrackData { get; internal set; }
}