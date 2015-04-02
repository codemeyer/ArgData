using System.IO;

namespace ArgData.IO
{
    internal class FileReader
    {
        internal FileReader(string exePath)
        {
            _exePath = exePath;
        }

        private readonly string _exePath;

        internal ushort ReadUShort(int position)
        {
            var stream = new FileStream(_exePath, FileMode.Open);

            var br = new BinaryReader(stream);

            br.BaseStream.Position = position;
            ushort value = br.ReadUInt16();

            br.Close();
            br.Dispose();
            stream.Close();
            stream.Dispose();

            return value;
        }

        internal byte ReadByte(int position)
        {
            var stream = new FileStream(_exePath, FileMode.Open);

            var br = new BinaryReader(stream);

            br.BaseStream.Position = position;
            byte value = br.ReadByte();

            br.Close();
            br.Dispose();
            stream.Close();
            stream.Dispose();

            return value;
        }

        internal byte[] ReadBytes(int position, int count)
        {
            var stream = new FileStream(_exePath, FileMode.Open);

            var br = new BinaryReader(stream);

            br.BaseStream.Position = position;
            byte[] bytes = br.ReadBytes(count);

            br.Close();
            br.Dispose();
            stream.Close();
            stream.Dispose();

            return bytes;
        }
    }
}