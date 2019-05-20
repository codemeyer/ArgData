using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class HorizonReader
    {
        public static TrackHorizon Read(BinaryReader reader)
        {
            reader.BaseStream.Position = 0;

            byte[] horizonBytes = reader.ReadBytes(4096);

            return new TrackHorizon(horizonBytes);
        }
    }
}
