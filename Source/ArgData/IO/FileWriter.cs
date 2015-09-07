using System.IO;

namespace ArgData.IO
{
    internal class FileWriter
    {
        internal FileWriter(string path)
        {
            _path = path;
        }

        private readonly string _path;

        internal void WriteUInt16(int value, int position)
        {
            using (var writer = new BinaryWriter(new FileStream(_path, FileMode.Open)))
            {
                writer.BaseStream.Position = position;

                writer.Write((ushort)value);
            }
        }

        internal void WriteByte(byte value, int position)
        {
            using (var writer = new BinaryWriter(new FileStream(_path, FileMode.Open)))
            {
                writer.BaseStream.Position = position;

                writer.Write(value);
            }
        }

        internal void WriteBytes(byte[] values, int position)
        {
            using (var writer = new BinaryWriter(new FileStream(_path, FileMode.Open)))
            {
                writer.BaseStream.Position = position;

                writer.Write(values);
            }
        }
    }
}
