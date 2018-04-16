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
            var exeFile = GpExeFile.At(exePath);
            return new ExampleDataContext(exeFile);
        }

        public static ExampleDataContext PreferencesCopy()
        {
            string filePath = ExampleDataHelper.CopyOfPrefsPath();
            return new ExampleDataContext(filePath);
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
        internal static PlayerHorsepowerReader PlayerHorsepowerReaderForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return PlayerHorsepowerReader.For(GpExeFile.At(GpExePath(exeVersionInfo)));
        }

        internal static DriverNumberReader DriverNumberReaderForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return DriverNumberReader.For(GpExeFile.At(GpExePath(exeVersionInfo)));
        }

        internal static DriverPerformanceReader DriverPerformanceLevelReaderForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return DriverPerformanceReader.For(GpExeFile.At(GpExePath(exeVersionInfo)));
        }

        internal static string GpExePath(GpExeVersionInfo exeVersion)
        {
            return GetExampleDataPath(FileNameFor(exeVersion), TestDataFileType.Exe);
        }

        internal static string CopyOfGpExePath(GpExeVersionInfo exeVersion)
        {
            return GetCopyOfExampleData(FileNameFor(exeVersion), TestDataFileType.Exe);
        }

        internal static string CopyOfPrefsPath()
        {
            return GetCopyOfExampleData("f1prefs-src.dat", TestDataFileType.Prefs);
        }

        private static string FileNameFor(GpExeVersionInfo exeVersionInfo)
        {
            switch (exeVersionInfo)
            {
                case GpExeVersionInfo.European105:
                    return "GP-EU105.EXE";
                case GpExeVersionInfo.European105Decompressed:
                    return "GP-EU105-UNP.EXE";
                case GpExeVersionInfo.Us105:
                    return "GP-US105.EXE";
                case GpExeVersionInfo.Us105Decompressed:
                    return "GP-US105-UNP.EXE";
                default:
                    throw new ArgumentOutOfRangeException(nameof(exeVersionInfo), exeVersionInfo, null);
            }
        }

        private static string GetCopyOfExampleData(string fileName, TestDataFileType dataFileType)
        {
            string originalLocation = GetExampleDataPath(fileName, dataFileType);
            string tempFile = GetTempFileName(fileName);
            File.Copy(originalLocation, tempFile);

            return tempFile;
        }

        internal static string GetExampleDataPath(string fileName, TestDataFileType dataFileType)
        {
            return Path.Combine(GetExampleDataBaseFolder() + dataFileType, fileName);
        }

        internal static string GetExampleDataBaseFolder()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;

            return Path.Combine(directory, @"..\..\..\..\..\TestData\");
        }

        internal static string GetTempFileName(string extFileName)
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

    internal enum TestDataFileType
    {
        Exe,
        Names,
        Prefs,
        Saves,
        Tracks,
        Setups
    }
}
