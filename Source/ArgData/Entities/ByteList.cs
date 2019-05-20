using System;
using System.Collections.Generic;

namespace ArgData.Entities
{
    internal class ByteList
    {
        private readonly List<byte> _bytes;

        public ByteList()
        {
            _bytes = new List<byte>();
        }

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

        public int Count => _bytes.Count;

        public byte[] GetBytes()
        {
            return _bytes.ToArray();
        }
    }
}
