namespace ArgData.Entities;

/// <summary>
/// Represents an instance of a 3D object with related settings.
/// </summary>
public class TrackObjectSettings
{
    /// <summary>
    /// Gets the Id of the object.
    ///
    /// When this is 17 or greater, it refers to the index in the track object shapes.
    /// </summary>
    public byte Id { get; set; }

    /// <summary>
    /// Gets the Id2 value. Unknown functionality.
    /// </summary>
    public short Id2 { get; set; }

    /// <summary>
    /// Gets the detail level that the item appears at. Is actually a Flag value.
    /// </summary>
    public byte DetailLevel { get; set; }

    /// <summary>
    /// Gets the distance from the center of the track. Negative values indicate left side of track.
    /// </summary>
    public short DistanceFromTrack { get; set; }

    /// <summary>
    /// Gets the X angle of the object.
    /// </summary>
    public short AngleX { get; set; }

    /// <summary>
    /// Gets the Y angle of the object.
    ///
    /// When Id is 5, 13 (and others) this refers to the Id of internal "billboard" objects.
    /// </summary>
    public short AngleY { get; set; }

    /// <summary>
    /// Gets the Unknown value. Possibly color-related.
    /// </summary>
    public short Unknown { get; set; }

    /// <summary>
    /// Gets the Unknown2 value. Possibly draw-depth related.
    /// </summary>
    public short Unknown2 { get; set; }
    // sometimes becomes -32736, perhaps it should be ushort instead?
    // draw-depth related? or just one of its "flag" bits? (see objects-phoenix.docx)

    /// <summary>
    /// Gets the height from the ground that the object is placed at.
    /// </summary>
    public short Height { get; set; }

    /// <summary>
    /// Gets or sets the object shape offset (index * 16)
    /// </summary>
    public short Offset { get; set; }
}
