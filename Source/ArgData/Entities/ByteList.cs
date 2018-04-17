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

        public void Add(int value)
        {
            _bytes.AddRange(BitConverter.GetBytes(value));
        }

        public void Add(short value)
        {
            _bytes.AddRange(BitConverter.GetBytes(value));
        }

        public void Add(ushort value)
        {
            _bytes.AddRange(BitConverter.GetBytes(value));
        }

        public void Add(byte value)
        {
            _bytes.Add(value);
        }

        public void Add(byte[] bytes)
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
