using System.Collections.Generic;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class TrackObjectSettingsReader
    {
        public static List<TrackObjectSettings> Read(BinaryReader reader, short offsetsObjectData, short trackDataOffset)
        {
            var list = new List<TrackObjectSettings>();

            reader.BaseStream.Position = offsetsObjectData;
            short offset = 0;

            while (reader.BaseStream.Position < trackDataOffset)
            {
                var trackObject = new TrackObjectSettings
                {
                    Id = reader.ReadByte(),
                    DetailLevel = reader.ReadByte(),
                    Unknown = reader.ReadInt16(),
                    DistanceFromTrack = reader.ReadInt16(),
                    AngleX = reader.ReadInt16(),
                    AngleY = reader.ReadInt16(),
                    Unknown2 = reader.ReadInt16(),
                    Height = reader.ReadInt16(),
                    Id2 = reader.ReadInt16(),
                    Offset = offset
                };

                offset += 16;

                list.Add(trackObject);
            }

            return list;
        }
    }
}
