using System.IO;

namespace ArgData
{
    public class FileWriter
    {
        public FileWriter(string exePath)
        {
            _exePath = exePath;
        }

        private readonly string _exePath;

        protected void WriteUInt16(int value, int position)
        {
            var writer = new BinaryWriter(new FileStream(_exePath, FileMode.OpenOrCreate));
            writer.BaseStream.Position = position;

            writer.Write((ushort)value);

            writer.Close();
            writer.Dispose();
        }

        protected void WriteByte(byte value, int position)
        {
            var writer = new BinaryWriter(new FileStream(_exePath, FileMode.OpenOrCreate));
            writer.BaseStream.Position = position;

            writer.Write(value);

            writer.Close();
            writer.Dispose();
        }
    }
}
