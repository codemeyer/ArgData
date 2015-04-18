using System;
using System.IO;

namespace ArgData.Tests
{
    internal static class ExampleDataHelper
    {
        private static string _latestTempFile;

        internal static PlayerHorsepowerEditor PlayerHorsepowerEditorForDefault()
        {
            return new PlayerHorsepowerEditor(new GpExeFile(GpExePath()));
        }

        public static PlayerHorsepowerEditor PlayerHorsepowerEditorForCopy()
        {
            return new PlayerHorsepowerEditor(new GpExeFile(CopyOfGpExePath()));
        }

        internal static DriverNumberEditor DriverNumberEditorForDefault()
        {
            return new DriverNumberEditor(new GpExeFile(GpExePath()));
        }

        internal static DriverNumberEditor DriverNumberEditorForCopy()
        {
            return new DriverNumberEditor(new GpExeFile(CopyOfGpExePath()));
        }

        internal static GripLevelEditor GripLevelEditorForDefault()
        {
            return new GripLevelEditor(new GpExeFile(GpExePath()));
        }

        internal static GripLevelEditor GetGripLevelEditorForCopy()
        {
            return new GripLevelEditor(new GpExeFile(CopyOfGpExePath()));
        }

        internal static string GpExePath()
        {
            return GetExampleDataPath("GP-ORIG.EXE");
        }

        internal static string CopyOfGpExePath()
        {
            return GetCopyOfExampleData("GP-ORIG.EXE");
        }

        internal static string GetExampleDataPath(string fileName)
        {
            string exampleDataEnvironment = Environment.GetEnvironmentVariable("BUILD_ARGDATA_EXAMPLEDATA");

            return Path.Combine(exampleDataEnvironment ?? string.Empty, fileName);
        }

        internal static string GetCopyOfExampleData(string fileName)
        {
            string originalLocation = GetExampleDataPath(fileName);
            string tempFile = Path.GetTempFileName() + Path.GetExtension(fileName);
            File.Copy(originalLocation, tempFile);

            _latestTempFile = tempFile;

            return tempFile;
        }

        internal static void DeleteLatestTempFile()
        {
            DeleteFile(_latestTempFile);
        }

        internal static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                // ignored
            }
        }
    }
}
