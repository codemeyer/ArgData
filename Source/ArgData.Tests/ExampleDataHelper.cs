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
            string exampleDataPath = ExampleDataHelper.GpExePath();
            return new DriverNumberEditor(new GpExeFile(exampleDataPath));
        }

        internal static DriverNumberEditor DriverNumberEditorForCopy()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            return new DriverNumberEditor(new GpExeFile(exampleDataPath));
        }

        internal static GripLevelEditor GripLevelEditorForDefault()
        {
            string exampleDataPath = ExampleDataHelper.GpExePath();
            return new GripLevelEditor(new GpExeFile(exampleDataPath));
        }

        internal static GripLevelEditor GetGripLevelEditorForCopy()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            return new GripLevelEditor(new GpExeFile(exampleDataPath));
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
