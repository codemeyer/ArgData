using System.IO;

namespace ArgData
{
    public class FileInspector
    {
        public GpExeInfo IsGpExe(string exePath)
        {
            var fileInfo = new FileInfo(exePath);

            switch (fileInfo.Length)
            {
                case 321878:
                    return GpExeInfo.European105;

                case 321748:
                    return GpExeInfo.Italian105;

                case 321716:
                    return GpExeInfo.Us105;

                default:
                    return GpExeInfo.Unknown;
            }
        }
    }

    public enum GpExeInfo
    {
        Unknown,
        European105,
        Italian105,
        Us105
    }
}
