namespace ArgData.Entities;

/// <summary>
/// Class that contains properties that are related to the initial state of the track sections.
/// </summary>
public class TrackSectionHeader
{
    /// <summary>
    /// Gets or sets the angle of the first track section.
    /// </summary>
    public ushort FirstSectionAngle { get; set; }

    /// <summary>
    /// Gets or sets the height of the first track section.
    /// </summary>
    public short FirstSectionHeight { get; set; }

    /// <summary>
    /// Gets or sets the track center X position.
    /// </summary>
    public short TrackCenterX { get; set; }

    /// <summary>
    /// Gets or sets the track center Y position
    /// </summary>
    public short TrackCenterY { get; set; }

    /// <summary>
    /// Gets or sets the track center Z position
    /// </summary>
    public short TrackCenterZ { get; set; }

    /// <summary>
    /// Gets or sets the start width of the track.
    /// </summary>
    public short StartWidth { get; set; }

    /// <summary>
    /// Gets or sets the start width of the left verge.
    /// </summary>
    public byte LeftVergeStartWidth { get; set; }

    /// <summary>
    /// Gets or sets the start width of the right verge.
    /// </summary>
    public byte RightVergeStartWidth { get; set; }
}

/// <summary>
/// Represents the color of the surrounding area around the track.
/// </summary>
public enum SurroundingArea
{
    /// <summary>
    /// Green as grass.
    /// </summary>
    Green = 0,

    /// <summary>
    /// Gray, used in Monaco.
    /// </summary>
    Gray1 = 128,

    /// <summary>
    /// Gray, used in Phoenix.
    /// </summary>
    Gray2 = 192
}

/// <summary>
/// Type of kerb, either two colors or three colors.
/// </summary>
public enum KerbType
{
    /// <summary>
    /// Two-colored kerb.
    /// </summary>
    DualColor,

    /// <summary>
    /// Three-colored kerb.
    /// </summary>
    TripleColor
}

/// <summary>
/// Track side.
/// </summary>
public enum TrackSide
{
    /// <summary>
    /// Left side of track.
    /// </summary>
    Left,

    /// <summary>
    /// Right side of track.
    /// </summary>
    Right
}
