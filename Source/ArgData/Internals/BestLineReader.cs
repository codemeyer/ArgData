using System.Collections.Generic;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class BestLineReader
    {
        public static TrackBestLineReadingResult Read(BinaryReader reader, int startPosition)
        {
            var list = new List<TrackBestLineSegment>();

            reader.BaseStream.Position = startPosition;

            byte firstLength = reader.ReadByte();
            reader.BaseStream.Position++;

            short displacement = reader.ReadInt16();
            short correction = reader.ReadInt16();
            short radius = reader.ReadInt16();

            list.Add(new TrackBestLineSegment
            {
                Length = firstLength,
                Displacement = displacement,
                Correction = correction,
                Radius = radius
            });

            while (true)
            {
                byte byte1 = reader.ReadByte();
                byte byte2 = reader.ReadByte();

                if (byte2 == 0x40)
                {
                    // wide-radius
                    short length = byte1;
                    correction = reader.ReadInt16();
                    short highRadius = reader.ReadInt16();
                    short lowRadius = reader.ReadInt16();

                    list.Add(new TrackBestLineSegment
                    {
                        SegmentType = TrackBestLineSegmentType.WideRadius,
                        Length = length,
                        Correction = correction,
                        HighRadius = highRadius,
                        LowRadius = lowRadius
                    });
                }
                else
                {
                    short length = byte1;
                    correction = reader.ReadInt16();
                    radius = reader.ReadInt16();

                    list.Add(new TrackBestLineSegment
                    {
                        SegmentType = TrackBestLineSegmentType.Normal,
                        Length = length,
                        Correction = correction,
                        Radius = radius
                    });
                }

                short nextShort = reader.ReadInt16();
                if (nextShort == 0)
                {
                    break;
                }

                reader.BaseStream.Position -= 2;
            }

            int position = (int)reader.BaseStream.Position;
            return new TrackBestLineReadingResult(list, position);
        }
    }
}
