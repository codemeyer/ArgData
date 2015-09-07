﻿using System;
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
            return new PlayerHorsepowerReader(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static DriverNumberReader DriverNumberReaderForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return new DriverNumberReader(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static GripLevelReader GripLevelReaderForDefault(GpExeVersionInfo exeVersionInfo)
        {
            return new GripLevelReader(new GpExeFile(GpExePath(exeVersionInfo)));
        }

        internal static string GpExePath(GpExeVersionInfo exeVersion)
        {
            return GetExampleDataPath(FileNameFor(exeVersion));
        }

        internal static string CopyOfGpExePath(GpExeVersionInfo exeVersion)
        {
            return GetCopyOfExampleData(FileNameFor(exeVersion));
        }

        internal static string CopyOfPrefsPath()
        {
            return GetCopyOfExampleData("f1prefs-src.dat");
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
