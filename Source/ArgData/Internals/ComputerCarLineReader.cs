using ArgData.Entities;

namespace ArgData.Internals;

internal static class ComputerCarLineReader
{
    public static TrackComputerCarLineReadingResult Read(BinaryReader reader, int startPosition)
    {
        var list = new List<TrackComputerCarLineSegment>();

        reader.BaseStream.Position = startPosition;

        byte firstLength = reader.ReadByte();
        reader.BaseStream.Position++;

        short displacement = reader.ReadInt16();
        short correction = reader.ReadInt16();
        short radius = reader.ReadInt16();

        list.Add(new TrackComputerCarLineSegment
        {
            Length = firstLength,
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

                list.Add(new TrackComputerCarLineSegment
                {
                    SegmentType = TrackComputerCarLineSegmentType.WideRadius,
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

                list.Add(new TrackComputerCarLineSegment
                {
                    SegmentType = TrackComputerCarLineSegmentType.Normal,
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
        return new TrackComputerCarLineReadingResult(displacement, list, position);
    }
}