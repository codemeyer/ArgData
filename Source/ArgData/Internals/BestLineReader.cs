using System.Collections.Generic;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class BestLineReader
    {
        public static TrackBestLineReadResult Read(string path, int startPosition)
        {
            var list = new List<TrackBestLineSegment>();

            int currentPosition = startPosition;

            var trackFileReader = new FileReader(path);

            byte firstLength = trackFileReader.ReadByte(currentPosition);

            short displacement = trackFileReader.ReadInt16(currentPosition + 2);
            short correction = trackFileReader.ReadInt16(currentPosition + 4);
            short radius = trackFileReader.ReadInt16(currentPosition + 6);

            list.Add(new TrackBestLineSegment
            {
                Length = firstLength,
                Displacement = displacement,
                Correction = correction,
                Radius = radius
            });

            currentPosition += 8;

            while (true)
            {
                byte byte1 = trackFileReader.ReadByte(currentPosition);
                byte byte2 = trackFileReader.ReadByte(currentPosition + 1);

                if (byte2 == 0x40)
                {
                    // wide-radius
                    short length = byte1;
                    correction = trackFileReader.ReadInt16(currentPosition + 2);
                    short highRadius = trackFileReader.ReadInt16(currentPosition + 4);
                    short lowRadius = trackFileReader.ReadInt16(currentPosition + 6);

                    list.Add(new TrackBestLineSegment
                    {
                        SegmentType = TrackBestLineSegmentType.WideRadius,
                        Length = length,
                        Correction = correction,
                        HighRadius = highRadius,
                        LowRadius = lowRadius
                    });

                    currentPosition += 8;
                }
                else
                {
                    short length = trackFileReader.ReadInt16(currentPosition);
                    correction = trackFileReader.ReadInt16(currentPosition + 2);
                    radius = trackFileReader.ReadInt16(currentPosition + 4);

                    list.Add(new TrackBestLineSegment
                    {
                        SegmentType = TrackBestLineSegmentType.Normal,
                        Length = length,
                        Correction = correction,
                        Radius = radius
                    });

                    currentPosition += 6;
                }

                short nextShort = trackFileReader.ReadInt16(currentPosition);
                if (nextShort == 0)
                {
                    break;
                }
            }

            return new TrackBestLineReadResult(currentPosition + 2, list);
        }

    }
}
