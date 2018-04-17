using System;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class TrackSectionHeaderReader
    {
        public static TrackSectionHeader Read(string path, int offset)
        {
            var trackFileReader = new FileReader(path);

            byte kerbTypeByte = trackFileReader.ReadByte(offset + 18);

            var header = new TrackSectionHeader
            {
                FirstSectionAngle = trackFileReader.ReadUInt16(offset),
                FirstSectionHeight = trackFileReader.ReadInt16(offset + 2),
                TrackCenterX = trackFileReader.ReadInt16(offset + 4),
                TrackCenterZ = trackFileReader.ReadInt16(offset + 6),
                TrackCenterY = trackFileReader.ReadInt16(offset + 8),
                StartWidth = trackFileReader.ReadInt16(offset + 10),
                PoleSide = trackFileReader.ReadInt16(offset + 12) == -768 ? TrackSide.Left : TrackSide.Right,
                PitsSide = trackFileReader.ReadByte(offset + 14) == 0 ? TrackSide.Right : TrackSide.Left,
                SurroundingArea = (SurroundingArea)Enum.Parse(typeof(SurroundingArea), trackFileReader.ReadByte(offset + 15).ToString()),
                RightVergeStartWidth = trackFileReader.ReadByte(offset + 16),
                LeftVergeStartWidth = trackFileReader.ReadByte(offset + 17),
                KerbType = GetKerbType(kerbTypeByte),
                KerbUpperColor = trackFileReader.ReadByte(offset + 22),
                KerbLowerColor = trackFileReader.ReadByte(offset + 24)
            };

            if (header.KerbType == KerbType.TripleColor)
            {
                header.KerbUpperColor2 = trackFileReader.ReadByte(offset + 28);
                header.KerbLowerColor2 = trackFileReader.ReadByte(offset + 30);
            }

            return header;
        }

        private static KerbType GetKerbType(byte kerbTypeByte)
        {
            return kerbTypeByte == 4 ? KerbType.TripleColor : KerbType.DualColor;
        }
    }
}
