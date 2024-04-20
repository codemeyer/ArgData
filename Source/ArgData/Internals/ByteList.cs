namespace ArgData.Internals;

internal class ByteList
{
    private readonly List<byte> _bytes = [];

    public void AddInt32(int value)
    {
        _bytes.AddRange(BitConverter.GetBytes(value));
    }

    public void AddInt16(short value)
    {
        _bytes.AddRange(BitConverter.GetBytes(value));
    }

    public void AddUInt16(ushort value)
    {
        _bytes.AddRange(BitConverter.GetBytes(value));
    }

    public void AddByte(byte value)
    {
        _bytes.Add(value);
    }

    public void AddByte(int value)
    {
        _bytes.Add((byte)value);
    }

    public void AddBytes(byte[] bytes)
    {
        _bytes.AddRange(bytes);
    }

    public void AddSBytes(sbyte[] bytes)
    {
        foreach (sbyte sb in bytes)
        {
            _bytes.Add((byte)sb);
        }
    }

    public int Count => _bytes.Count;

    public byte[] GetBytes()
    {
        return _bytes.ToArray();
    }
}
