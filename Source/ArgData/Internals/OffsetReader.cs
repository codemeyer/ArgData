using System;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class OffsetReader
    {
        public static TrackOffsets Read(string path)
        {
            var trackFileReader = new FileReader(path);

            return new TrackOffsets
            {
                UnknownLong1 = trackFileReader.ReadInt32(4096),
                UnknownLong2 = trackFileReader.ReadInt32(4100),
                ChecksumPosition = Convert.ToInt16(trackFileReader.ReadInt16(4104) + 4112),
                ObjectData = Convert.ToInt16(trackFileReader.ReadInt16(4106) + 4112),
                TrackData = Convert.ToInt16(trackFileReader.ReadInt16(4108) + 4112)
            };
        }
    }
}
