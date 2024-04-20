namespace ArgData.Entities;

/// <summary>
/// Represents the horizon of a track.
/// </summary>
public class TrackHorizon
{
    private readonly byte[] _horizonBytes;

    internal TrackHorizon(byte[] horizonBytes)
    {
        if (horizonBytes.Length != 4096)
            throw new Exception("Not enough bytes for horizon. A horizon is exactly 4096 bytes.");

        _horizonBytes = horizonBytes;
    }

    /// <summary>
    /// Returns the 4096 bytes that compose the horizon image.
    /// </summary>
    /// <returns></returns>
    public byte[] GetBytes()
    {
        return _horizonBytes;
    }

    /// <summary>
    /// Update a specific "pixel" in the horizon image.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Update(int index, byte value)
    {
        _horizonBytes[index] = value;
    }
}
