using System;
using System.IO;

namespace ArgData.Tests
{
    internal class ExampleDataContext : IDisposable
    {
        public GpExeFile ExeFile { get; }
        public string ExePath { get; }

        private ExampleDataContext(string exePath)
        {
            ExePath = exePath;
            ExeFile = new GpExeFile(exePath);
        }

        public static ExampleDataContext ExeCopy(GpExeInfo exeInfo)
        {
            string exePath = ExampleDataHelper.CopyOfGpExePath(exeInfo);
            return new ExampleDataContext(exePath);
        }

        public void Dispose()
        {
            File.Delete(ExePath);
        }
    }

    internal static class ExampleDataHelper
    {
        internal static PlayerHorsepowerEditor PlayerHorsepowerEditorForDefault(GpExeInfo exeInfo)
        {
            return new PlayerHorsepowerEditor(new GpExeFile(GpExePath(exeInfo)));
        }

        internal static DriverNumberEditor DriverNumberEditorForDefault(GpExeInfo exeInfo)
        {
            return new DriverNumberEditor(new GpExeFile(GpExePath(exeInfo)));
        }

        internal static GripLevelEditor GripLevelEditorForDefault(GpExeInfo exeInfo)
        {
            return new GripLevelEditor(new GpExeFile(GpExePath(exeInfo)));
        }

        internal static string GpExePath(GpExeInfo exeVersion)
        {
            return GetExampleDataPath(FileNameFor(exeVersion));
        }

        internal static string CopyOfGpExePath(GpExeInfo exeVersion)
        {
            return GetCopyOfExampleData(FileNameFor(exeVersion));
        }

        private static string FileNameFor(GpExeInfo exeInfo)
        {
            switch (exeInfo)
            {
                case GpExeInfo.European105:
                    return "GP-EU105.EXE";
                case GpExeInfo.Us105:
                    return "GP-US105.EXE";
                default:
                    throw new ArgumentOutOfRangeException(nameof(exeInfo), exeInfo, null);
            }
        }

        internal static string GetExampleDataPath(string fileName)
        {
            string exampleDataEnvironment = Environment.GetEnvironmentVariable("BUILD_ARGDATA_EXAMPLEDATA");

            return Path.Combine(exampleDataEnvironment ?? string.Empty, fileName);
        }

        private static string GetCopyOfExampleData(string fileName)
        {
            string originalLocation = GetExampleDataPath(fileName);
            string tempFile = GetTempFileName(fileName);
            File.Copy(originalLocation, tempFile);

            return tempFile;
        }

        internal static string GetTempFileName(string extFileName)
        {
            return Path.GetTempPath() + Path.GetRandomFileName() + extFileName;
        }

        internal static byte[] ReadBytes(string path, int position, int count)
        {
            var stream = new FileStream(path, FileMode.Open);

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
