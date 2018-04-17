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

        internal void WriteInt16(short value, int position)
        {
            using (var writer = new BinaryWriter(new FileStream(_path, FileMode.Open)))
            {
                writer.BaseStream.Position = position;

                writer.Write(value);
            }
        }

        internal void WriteUInt16(ushort value, int position)
        {
            using (var writer = new BinaryWriter(new FileStream(_path, FileMode.Open)))
            {
                writer.BaseStream.Position = position;

                writer.Write(value);
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

        public FileWriter CreateFile()
        {
            using (File.Open(_path, FileMode.OpenOrCreate)) { }

            return this;
        }
    }
}
