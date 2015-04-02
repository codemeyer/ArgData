using System;
using System.IO;
using System.Reflection;

namespace ArgData.IntegrationTests
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
