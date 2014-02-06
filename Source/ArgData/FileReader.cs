using System.IO;

namespace ArgData
{
    public class FileReader
    {
        public FileReader(string exePath)
        {
            _exePath = exePath;
        }

        private readonly string _exePath;
        
        protected ushort ReadUShort(int position)
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

        protected byte ReadByte(int position)
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

        protected byte[] ReadBytes(int position, int count)
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