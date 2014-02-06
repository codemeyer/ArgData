﻿using System.IO;
using System.Reflection;

namespace ArgData.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected string GetExampleDataPath(string fileName)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            return Path.Combine(assemblyDirectory,  string.Format(@"ExampleData\{0}", fileName));
        }

        protected string GetTempFile()
        {
            string path = Path.GetTempFileName();
            var writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate));
            byte[] bytes = new byte[20];
            writer.Write(bytes);
            writer.Close();
            writer.Dispose();

            return path;
        }

        protected ushort ReadUShort(string path, int position)
        {
            var stream = new FileStream(path, FileMode.Open);

            var br = new BinaryReader(stream);

            br.BaseStream.Position = position;
            ushort value = br.ReadUInt16();

            br.Close();
            br.Dispose();
            stream.Close();
            stream.Dispose();

            return value;
        }

        protected void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
            }
        }
    }
}
