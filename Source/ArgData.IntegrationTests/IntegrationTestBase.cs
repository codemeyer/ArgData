using System;
using System.IO;
using System.Reflection;

namespace ArgData.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected string GetExampleDataPath(string fileName)
        {
            string exampleDataEnvironment = Environment.GetEnvironmentVariable("BUILD_ARGDATA_EXAMPLEDATA");
            if (!string.IsNullOrEmpty(exampleDataEnvironment))
            {
                return Path.Combine(exampleDataEnvironment, fileName);
            }
            else
            {
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
                return Path.Combine(assemblyDirectory, string.Format(@"ExampleData\{0}", fileName));
            }
        }

        protected string GetCopyOfExampleData(string fileName)
        {
            string originalLocation = GetExampleDataPath(fileName);
            string tempFile = Path.GetTempFileName() + Path.GetExtension(fileName);
            File.Copy(originalLocation, tempFile);

            return tempFile;
        }

        protected string GetTempFile()
        {
            string path = Path.GetTempFileName();
            var writer = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate));
            byte[] bytes = new byte[40];
            writer.Write(bytes);
            writer.Close();
            writer.Dispose();

            return path;
        }

        protected ushort ReadUInt16(string path, int position)
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

        protected byte ReadByte(string path, int position)
        {
            var stream = new FileStream(path, FileMode.Open);

            var br = new BinaryReader(stream);

            br.BaseStream.Position = position;
            byte value = br.ReadByte();

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
