using System.IO;

namespace ArgData.IO
{
    internal class FileReader
    {
        internal FileReader(string path)
        {
            _path = path;
        }

        private readonly string _path;

        internal ushort ReadUShort(int position)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                ushort value = br.ReadUInt16();

                return value;
            }
        }

        internal byte ReadByte(int position)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                byte value = br.ReadByte();

                return value;
            }
        }

        internal byte[] ReadBytes(int position, int count)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                byte[] bytes = br.ReadBytes(count);

                return bytes;
            }
        }
    }
}
