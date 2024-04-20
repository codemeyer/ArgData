namespace ArgData.Entities;

/// <summary>
/// Represents a segment of the computer car line.
///
/// This line around the track is also used to provide steering help.
/// </summary>
public class TrackComputerCarLineSegment
{
    /// <summary>
    /// Gets or sets the type of segment.
    /// </summary>
    public TrackComputerCarLineSegmentType SegmentType { get; set; }

    /// <summary>
    /// Gets or sets the length of the segment.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Gets or sets the correction value. Called Tighter/Wider in GP2 Track Editor.
    /// </summary>
    public short Correction { get; set; }

    /// <summary>
    /// Gets or sets the corner radius. Only used when SegmentType is Normal.
    /// </summary>
    public short Radius { get; set; }

    /// <summary>
    /// Gets or sets the corner high radius. Only used when SegmentType is WideRadius.
    /// </summary>
    public short HighRadius { get; set; }

    /// <summary>
    /// Gets or sets the corner low radius. Only used when SegmentType is WideRadius.
    /// </summary>
    public short LowRadius { get; set; }
}

/// <summary>
/// Type of computer car line segment.
/// </summary>
public enum TrackComputerCarLineSegmentType
{
    /// <summary>
    /// Normal segment.
    /// </summary>
    Normal,

    /// <summary>
    /// Wide radius segment, e.g. the back straight in Montreal.
    /// </summary>
    WideRadius
}