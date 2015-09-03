using System.IO;

namespace ArgData
{
    internal class FileInspector
    {
        internal GpExeVersionInfo GetGpExeInfo(string exePath)
        {
            var fileInfo = new FileInfo(exePath);

            switch (fileInfo.Length)
            {
                case 321878:
                    return GpExeVersionInfo.European105;

                case 321716:
                    return GpExeVersionInfo.Us105;

                default:
                    return GpExeVersionInfo.Unknown;
            }
        }
    }
}
