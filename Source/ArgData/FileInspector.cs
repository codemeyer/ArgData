using System.IO;

namespace ArgData
{
    internal class FileInspector
    {
        internal GpExeInfo GetGpExeInfo(string exePath)
        {
            var fileInfo = new FileInfo(exePath);

            switch (fileInfo.Length)
            {
                case 321878:
                    return GpExeInfo.European105;

                case 321716:
                    return GpExeInfo.Us105;

                default:
                    return GpExeInfo.Unknown;
            }
        }
    }
}
