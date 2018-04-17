using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class HorizonReader
    {
        public static TrackHorizon Read(string path)
        {
            var trackFileReader = new FileReader(path);

            byte[] horizonBytes = trackFileReader.ReadBytes(0, 4096);

            return new TrackHorizon(horizonBytes);
        }
    }
}
