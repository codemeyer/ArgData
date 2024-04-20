using ArgData.Internals;

namespace ArgData.Entities;

/// <summary>
/// The ITrackObjectShapePoint represents a basic point in a 3D coordinate system (X, Y and Z).
/// </summary>
public interface ITrackObjectShapePoint
{
    /// <summary>
    /// Gets the X coordinate of the point.
    /// </summary>
    short X { get; }

    /// <summary>
    /// Gets the Y coordinate of the point.
    /// </summary>
    short Y { get; }

    /// <summary>
    /// Gets the Z coordinate of the point.
    /// </summary>
    ushort Z { get; }

    /// <summary>
    /// Returns the bytes that represent the point in the track file.
    /// </summary>
    /// <returns>Byte array.</returns>
    byte[] GetBytes();
}

/// <summary>
/// Represents the raw data of a point in the 3D shape.
/// </summary>
internal class TrackObjectShapeRawPoint
{
    /// <summary>
    /// Gets or sets the raw X coordinate value.
    /// </summary>
    public short XCoord { get; set; }

    /// <summary>
    /// Gets or sets the X and Y coordinate reference point value (for reference points).
    ///
    /// This is the first byte of the XCoord.
    /// </summary>
    public byte ReferencePointValue { get; set; }

    /// <summary>
    /// Gets or sets the reference point flag (0x80).
    ///
    /// This is the second byte of the XCoord.
    /// </summary>
    public byte ReferencePointFlag { get; set; }

    /// <summary>
    /// Gets or sets the raw Y coordinate value.
    /// </summary>
    public short YCoord { get; set; }

    /// <summary>
    /// Gets or sets the Z coordinate value. Always positive.
    /// </summary>
    public ushort ZCoord { get; set; }

    /// <summary>
    /// Gets or sets an unknown value. Always 0 in standard tracks.
    /// </summary>
    public ushort Unknown { get; set; }
}

/// <summary>
/// Represents a 3D point that uses the scale values to define its X, Y and Z coordinates.
/// </summary>
public class TrackObjectShapeScalePoint : ITrackObjectShapePoint
{
    private readonly TrackObjectShape _shape;

    /// <summary>
    /// Initializes an instance of a TrackObjectShapeScalePoint.
    /// </summary>
    /// <param name="shape">Related TrackObjectShape.</param>
    public TrackObjectShapeScalePoint(TrackObjectShape shape)
    {
        _shape = shape;
    }

    /// <summary>
    /// Gets or sets the index of the scale value to use for the X coordinate.
    /// </summary>
    public short XScaleValueIndex { get; set; }

    /// <summary>
    /// Gets or sets whether the X coordinate value is positive or negative.
    /// </summary>
    public bool XIsNegative { get; set; }

    /// <summary>
    /// Gets the actual X point coordinate using the scale value index.
    /// </summary>
    public short X
    {
        get
        {
            if (XScaleValueIndex == -1)
            {
                return 0;
            }

            short value = _shape.ScaleValues[XScaleValueIndex];

            return XIsNegative ? (short)-value : value;
        }
    }

    /// <summary>
    /// Gets or sets the index of the scale value to use for the Y coordinate.
    /// </summary>
    public short YScaleValueIndex { get; set; }

    /// <summary>
    /// Gets or sets whether the Y coordinate value is positive or negative.
    /// </summary>
    public bool YIsNegative { get; set; }

    /// <summary>
    /// Gets the actual Y point coordinate using the scale value index.
    /// </summary>
    public short Y
    {
        get
        {
            if (YScaleValueIndex == -1)
            {
                return 0;
            }

            short value = _shape.ScaleValues[YScaleValueIndex];

            return YIsNegative ? (short)-value : value;
        }
    }

    /// <summary>
    /// Gets or sets the value of the Z coordinate.
    /// </summary>
    [CLSCompliant(false)]
    public ushort Z { get; set; }

    /// <summary>
    /// Returns the bytes that represent the point in the track file.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] GetBytes()
    {
        var bytes = new ByteList();

        // Xr1
        int xr1Shift = XIsNegative ? 34 : 2;
        byte xr1 = (byte)((XScaleValueIndex * 2) + xr1Shift);
        bytes.AddByte(xr1);

        // Xr2
        bytes.AddByte(0x00);

        // YCoord, first part
        int yr1Shift = YIsNegative ? 34 : 2;
        byte yr1 = (byte)((YScaleValueIndex * 2) + yr1Shift);
        bytes.AddByte(yr1);

        // YCoord, second part
        bytes.AddByte(0x00);

        // Z
        bytes.AddUInt16(Z);

        // Unknown, always 0 ("TwinPoint"?)
        bytes.AddUInt16(0);

        return bytes.GetBytes();
    }
}

/// <summary>
/// The TrackObjectShapeReferencePoint class represents a 3D point that is defined by using references
/// to other previously defined X and Y coordinates, but with a separate Z value.
/// </summary>
public class TrackObjectShapeReferencePoint : ITrackObjectShapePoint
{
    private readonly TrackObjectShape _shape;

    /// <summary>
    /// Initializes an instance of a TrackObjectShapeReferencePoint.
    /// </summary>
    /// <param name="shape">Related TrackObjectShape.</param>
    public TrackObjectShapeReferencePoint(TrackObjectShape shape)
    {
        _shape = shape;
    }

    /// <summary>
    /// Gets or sets the index of the other point that this point uses for X and Y coordinates.
    /// </summary>
    public byte PointIndex { get; set; }

    /// <summary>
    /// Gets the actual X point coordinate using the referenced value.
    /// </summary>
    public short X
    {
        get
        {
            return _shape.Points[PointIndex].X;
        }
    }

    /// <summary>
    /// Gets the actual Y point coordinate using the referenced value.
    /// </summary>
    public short Y
    {
        get
        {
            return _shape.Points[PointIndex].Y;
        }
    }

    /// <summary>
    /// Gets the Z point coordinate.
    /// </summary>
    public ushort Z { get; set; }

    /// <summary>
    /// Returns the bytes that represent the point in the track file.
    /// </summary>
    /// <returns>Byte array.</returns>
    public byte[] GetBytes()
    {
        var bytes = new ByteList();

        // Xr1
        bytes.AddByte(PointIndex);

        // Xr2
        bytes.AddByte(0x80);

        // YCoord
        bytes.AddUInt16(0x00);

        // Z
        bytes.AddUInt16(Z);

        // Unknown, always 0 ("TwinPoint"?)
        bytes.AddUInt16(0);

        return bytes.GetBytes();
    }
}
