using ArgData.Internals;

namespace ArgData.Entities;

/// <summary>
/// Represents the graphical elements - such as polygons, lines and bitmaps - that
/// make up the track object shape.
/// </summary>
public class TrackObjectShapeGraphicalElements
{
    /// <summary>
    /// Gets the list of header values.
    /// </summary>
    public List<byte> HeaderValues { get; } = [];

    /// <summary>
    /// Gets the list of unique elements.
    /// </summary>
    public List<ITrackObjectShapeGraphicalElement> Elements { get; } = [];

    /// <summary>
    /// Returns the byte array representation of the entire graphical element data.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] ToBytes()
    {
        var bytes = new ByteList();

        foreach (var header in HeaderValues)
        {
            bytes.AddByte(header);
        }

        bytes.AddByte(0xFF);

        foreach (var element in Elements)
        {
            bytes.AddBytes(element.ToBytes());
        }

        return bytes.GetBytes();
    }
}

/// <summary>
/// Represents a polygon in a track shape object. A polygon has a specific base color and
/// a number of vectors.
/// </summary>
public class TrackObjectShapeGraphicalElementPolygon : ITrackObjectShapeGraphicalElement
{
    /// <summary>
    /// Gets or sets the base color of the polygon.
    ///
    /// The actual color that appears in the game may be affected by the ObjectSetting used
    /// when placing the track-side object.
    /// </summary>
    public byte Color { get; set; }

    /// <summary>
    /// Gets the list of vector indexes that make up the polygon.
    ///
    /// If a value is negative, the direction is reversed.
    /// </summary>
    public List<sbyte> Vectors { get; } = [];

    /// <summary>
    /// Returns the byte array representation of the polygon element.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] ToBytes()
    {
        var bytes = new ByteList();

        bytes.AddByte(Color);
        bytes.AddSBytes(Vectors.ToArray());
        bytes.AddByte(0);

        return bytes.GetBytes();
    }
}

/// <summary>
/// Represents a single line in a track shape object.
/// </summary>
public class TrackObjectShapeGraphicalElementLine : ITrackObjectShapeGraphicalElement
{
    /// <summary>
    /// Gets or sets Value1 of a line element. Purpose currently unknown, but values usually are 8 or 0.
    /// </summary>
    public byte Value1 { get; set; }

    /// <summary>
    /// Gets or sets Value2 of a line element. Purpose currently unknown, but could be related to vectors.
    /// </summary>
    public byte Value2 { get; set; }

    /// <summary>
    /// Returns the byte array representation of the line element.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] ToBytes()
    {
        return [0xA0, Value1, Value2];
    }
}

/// <summary>
/// Represents the occurrence of a bitmap image in a 3D shape.
/// </summary>
public class TrackObjectShapeGraphicalElementBitmap : ITrackObjectShapeGraphicalElement
{
    /// <summary>
    /// Gets or sets the value that indicates that this is a bitmap.
    ///
    /// Expected values are 0x80 (128), 0x88 (136) or 0xD0 (208).
    /// </summary>
    public byte Indicator { get; set; }

    /// <summary>
    /// Gets or sets the point in the object shape where the bitmap should be located.
    /// </summary>
    public byte PointIndex { get; set; }

    /// <summary>
    /// Gets or sets the UnknownFlag of a bitmap element. Purpose currently unknown.
    /// </summary>
    public byte UnknownFlag { get; set; }

    /// <summary>
    /// Gets or sets the index of the bitmap.
    /// </summary>
    public byte ObjectIndex { get; set; }

    /// <summary>
    /// Returns the byte array representation of the bitmap element.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] ToBytes()
    {
        return [Indicator, PointIndex, UnknownFlag, ObjectIndex];
    }
}

/// <summary>
/// Represents the occurrence of a bitmap image in a 3D shape,
/// with some additional data.
/// </summary>
public class TrackObjectShapeGraphicalElementBitmapExtended : ITrackObjectShapeGraphicalElement
{
    /// <summary>
    /// Gets or sets the value that indicates that this is an extended bitmap.
    ///
    /// Expected values are 0x82 (130) or 0x86 (134).
    /// </summary>
    public byte Indicator { get; set; }

    /// <summary>
    /// Gets or sets the point in the object shape where the bitmap should be located.
    /// </summary>
    public byte PointIndex { get; set; }

    /// <summary>
    /// Gets or sets the UnknownFlag of a bitmap element. Purpose currently unknown.
    /// </summary>
    public byte UnknownFlag { get; set; }

    /// <summary>
    /// Gets or sets the index of the bitmap.
    /// </summary>
    public byte ObjectIndex { get; set; }

    /// <summary>
    /// Gets or sets the AdditionalData1 value. Purpose currently unknown.
    /// </summary>
    public byte AdditionalData1 { get; set; }

    /// <summary>
    /// Gets or sets the AdditionalData1 value. Purpose currently unknown.
    /// </summary>
    public byte AdditionalData2 { get; set; }

    /// <summary>
    /// Returns the byte array representation of the bitmap element.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] ToBytes()
    {
        return [Indicator, PointIndex, UnknownFlag, ObjectIndex, AdditionalData1, AdditionalData2];
    }
}

/// <summary>
/// Interface that represents a graphical element in an object shape.
/// </summary>
public interface ITrackObjectShapeGraphicalElement
{
    /// <summary>
    /// Returns the byte array representation of the graphical element.
    /// </summary>
    /// <returns>Byte array.</returns>
    byte[] ToBytes();
}
