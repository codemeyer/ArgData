using ArgData.Internals;

namespace ArgData.Entities;

/// <summary>
/// Represents a media item stored inside a media container file.
/// </summary>
public abstract class MediaFileItem
{
    /// <summary>
    /// Gets the offset of the item inside the file container. Only updated when a container file is read from or written to.
    /// </summary>
    public int Offset { get; internal set; }

    /// <summary>
    /// Gets the length in bytes of the item.
    /// </summary>
    public int Length { get; internal set; }

    /// <summary>
    /// Gets the type value of the item.
    /// </summary>
    public abstract short Type { get; }

    private byte[] _data = [];

    /// <summary>
    /// Gets the raw byte data of the item as a byte array.
    /// </summary>
    public byte[] Data
    {
        get => _data;
        set
        {
            _data = value;
            Length = _data.Length;
        }
    }

    /// <summary>
    /// Gets the width of the image item.
    /// </summary>
    public short Width { get; set; }

    /// <summary>
    /// Gets the height of the image item.
    /// </summary>
    public short Height { get; set; }
}

/// <summary>
/// Image item of type 1774, e.g. an image inside HELMETS.DAT or FLAGS.DAT.
/// </summary>
public class ImageItem1774 : MediaFileItem
{
    /// <inheritdoc />
    public override short Type => 1774;

    /// <summary>
    /// Gets the pixel data from the image item as a byte array.
    ///
    /// The size of the array will be the Width multiplied by the Height of the image.
    /// </summary>
    /// <returns></returns>
    public byte[] GetPixelData()
    {
        return ImageRunParser.ParseRunsToPixels(Data);
    }

    /// <summary>
    /// Sets the pixel data for the image.
    /// </summary>
    /// <param name="pixelData">Pixel data as a byte array, where each byte represents a menu palette index. Must be the same length as the Width multiplied by the Height of the image.</param>
    public void SetPixelData(byte[] pixelData)
    {
        var expectedLength = Width * Height;
        if (pixelData.Length != expectedLength)
        {
            throw new ArgumentOutOfRangeException(nameof(pixelData),
                $"The ${nameof(pixelData)} byte array needs to be the same size as the Width of the image multiplied by the Height. " +
                $"Expected {expectedLength} but was {pixelData.Length}.");
        }

        var runs = ImageRunParser.ParsePixelsToRuns(pixelData, Width);

        var bytes = new ByteList();

        foreach (var colorRun in runs)
        {
            bytes.AddBytes(colorRun.GenerateBytesToWrite());
        }

        Data = bytes.GetBytes();
        Length = Data.Length;
    }
}

/// <summary>
/// Palette item, e.g. an item inside BACKDROP.DAT or TRACKPIX.DAT.
/// </summary>
public class PaletteItem : MediaFileItem
{
    /// <inheritdoc />
    public override short Type => 1776;

}

/// <summary>
/// Image item of type 1769, e.g. an image inside BACKDROP.DAT or TRACKPIX.DAT.
/// </summary>
public class ImageItem1769 : MediaFileItem
{
    /// <inheritdoc />
    public override short Type => 1769;
}

/// <summary>
/// Media item of type 1768, possibly video/animation related. Occurs in e.g. TROPHY.DAT.
/// </summary>
public class MediaItem1768 : MediaFileItem
{
    /// <inheritdoc />
    public override short Type => 1768;
}
