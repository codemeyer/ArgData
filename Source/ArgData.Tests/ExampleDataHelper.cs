using System;
using System.IO;

namespace ArgData.Tests
{
    internal class ExampleDataContext : IDisposable
    {
        public GpExeFile ExeFile { get; }
        public string FilePath { get; }

        private ExampleDataContext(string exePath)
        {
            FilePath = exePath;
        }

        private ExampleDataContext(GpExeFile exeFile)
        {
            ExeFile = exeFile;
            FilePath = exeFile.ExePath;
        }

        public static ExampleDataContext ExeCopy(GpExeVersionInfo exeVersionInfo)
        {
            string exePath = ExampleDataHelper.CopyOfGpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exePath);
            return new ExampleDataContext(exeFile);
        }

        public static ExampleDataContext GetTempFileName(string extFileName)
        {
            string filePath = Path.GetTempPath() + Path.GetRandomFileName() + extFileName;
            return new ExampleDataContext(filePath);
        }

        public void Dispose()
        {
            File.Delete(FilePath);
        }
    }

    internal static class ExampleDataHelper
    {
        internal static PlayerHorsepowerEditor PlayerHorsepowerEditorForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return new PlayerHorsepowerEditor(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static DriverNumberEditor DriverNumberEditorForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return new DriverNumberEditor(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static GripLevelEditor GripLevelEditorForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return new GripLevelEditor(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static string GpExePath(GpExeVersionInfo exeVersion)
        {
            return GetExampleDataPath(FileNameFor(exeVersion));
        }

        internal static string CopyOfGpExePath(GpExeVersionInfo exeVersion)
        {
            return GetCopyOfExampleData(FileNameFor(exeVersion));
        }

        private static string FileNameFor(GpExeVersionInfo exeVersionInfo)
        {
            switch (exeVersionInfo)
            {
                case GpExeVersionInfo.European105:
                    return "GP-EU105.EXE";
                case GpExeVersionInfo.Us105:
                    return "GP-US105.EXE";
                default:
                    throw new ArgumentOutOfRangeException(nameof(exeVersionInfo), exeVersionInfo, null);
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

        private static string GetTempFileName(string extFileName)
        {
            return Path.GetTempPath() + Path.GetRandomFileName() + extFileName;
        }

        internal static byte[] ReadBytes(string path, int position, int count)
        {
            using (var br = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                br.BaseStream.Position = position;
                byte[] bytes = br.ReadBytes(count);

                return bytes;
            }
        }
    }
}
