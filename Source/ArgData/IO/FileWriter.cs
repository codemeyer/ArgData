using System.IO;

namespace ArgData
{
    internal class FileWriter
    {
        internal FileWriter(string exePath)
        {
            _exePath = exePath;
        }

        private readonly string _exePath;

        internal void WriteUInt16(int value, int position)
        {
            var writer = new BinaryWriter(new FileStream(_exePath, FileMode.OpenOrCreate));
            writer.BaseStream.Position = position;

            writer.Write((ushort)value);

            writer.Close();
            writer.Dispose();
        }

        internal void WriteByte(byte value, int position)
        {
            var writer = new BinaryWriter(new FileStream(_exePath, FileMode.OpenOrCreate));
            writer.BaseStream.Position = position;

            writer.Write(value);

            writer.Close();
            writer.Dispose();
        }


        internal void WriteBytes(byte[] values, int position)
        {
            var writer = new BinaryWriter(new FileStream(_exePath, FileMode.OpenOrCreate));
            writer.BaseStream.Position = position;

            writer.Write(values);

            writer.Close();
            writer.Dispose();
        }
    }
}
