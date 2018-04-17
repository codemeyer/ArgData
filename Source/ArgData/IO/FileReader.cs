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

        internal ushort ReadUInt16(int position)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                ushort value = br.ReadUInt16();

                return value;
            }
        }

        internal short ReadInt16(int position)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                short value = br.ReadInt16();

                return value;
            }
        }

        internal int ReadInt32(int position)
        {
            using (var br = new BinaryReader(new FileStream(_path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                int value = br.ReadInt32();

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

        internal byte[] ReadAll()
        {
            return File.ReadAllBytes(_path);
        }
    }
}
