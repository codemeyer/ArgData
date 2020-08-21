using System;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class OffsetReader
    {
        public static TrackOffsets Read(BinaryReader reader)
        {
            var offsets = new TrackOffsets
            {
                BaseOffset = reader.ReadInt16(),
                Unknown2 = reader.ReadInt16(),
                Unknown3 = reader.ReadInt16(),
                Unknown4 = reader.ReadInt16(),
                ChecksumPosition = Convert.ToInt16(reader.ReadInt16() + 4112),
                ObjectData = Convert.ToInt16(reader.ReadInt16() + 4112),
                TrackData = Convert.ToInt16(reader.ReadInt16() + 4112)
            };

            return offsets;
        }
    }
}
