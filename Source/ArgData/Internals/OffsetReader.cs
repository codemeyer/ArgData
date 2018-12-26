using System;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class OffsetReader
    {
        public static TrackOffsets Read(BinaryReader reader)
        {
            return new TrackOffsets
            {
                UnknownLong1 = reader.ReadInt32(),
                UnknownLong2 = reader.ReadInt32(),
                ChecksumPosition = Convert.ToInt16(reader.ReadInt16() + 4112),
                ObjectData = Convert.ToInt16(reader.ReadInt16() + 4112),
                TrackData = Convert.ToInt16(reader.ReadInt16() + 4112)
            };
        }
    }
}
