using System.IO;

namespace ArgData.IO
{
    internal static class FileStreamProvider
    {
        public static Stream Open(string path)
        {
            return File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static Stream OpenWriter(string path)
        {
            return File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
        }
    }

    internal static class BinaryReaderExtension
    {
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            return reader.ReadBytes((int)reader.BaseStream.Length);
        }
    }
}
