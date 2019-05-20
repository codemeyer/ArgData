using System;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class TrackSectionHeaderReader
    {
        public static InternalTrackSectionHeader Read(BinaryReader reader, int offset)
        {
            reader.BaseStream.Position = offset + 18;
            byte kerbTypeByte = reader.ReadByte();

            reader.BaseStream.Position = offset;

            var header = new InternalTrackSectionHeader
            {
                FirstSectionAngle = reader.ReadUInt16(),
                FirstSectionHeight = reader.ReadInt16(),
                TrackCenterX = reader.ReadInt16(),
                TrackCenterZ = reader.ReadInt16(),
                TrackCenterY = reader.ReadInt16(),
                StartWidth = reader.ReadInt16(),
                PoleSide = reader.ReadInt16() == -768 ? TrackSide.Left : TrackSide.Right,
                PitsSide = reader.ReadByte() == 0 ? TrackSide.Right : TrackSide.Left,
                SurroundingArea = (SurroundingArea)Enum.Parse(typeof(SurroundingArea), reader.ReadByte().ToString()),
                RightVergeStartWidth = reader.ReadByte(),
                LeftVergeStartWidth = reader.ReadByte()
            };

            header.KerbType = GetKerbType(kerbTypeByte);
            reader.BaseStream.Position = offset + 22;
            header.KerbUpperColor = reader.ReadByte();
            reader.BaseStream.Position = offset + 24;
            header.KerbLowerColor = reader.ReadByte();

            if (header.KerbType == KerbType.TripleColor)
            {
                reader.BaseStream.Position = offset + 28;
                header.KerbUpperColor2 = reader.ReadByte();
                reader.BaseStream.Position = offset + 30;
                header.KerbLowerColor2 = reader.ReadByte();
            }

            return header;
        }

        private static KerbType GetKerbType(byte kerbTypeByte)
        {
            return kerbTypeByte == 4 ? KerbType.TripleColor : KerbType.DualColor;
        }
    }
}
