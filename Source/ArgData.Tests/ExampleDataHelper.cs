using System;
using System.IO;

namespace ArgData.Tests
{
    internal static class ExampleDataHelper
    {
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

            return tempFile;
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
