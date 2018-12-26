using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class RawDataReader
    {
        public static TrackRawData Read(BinaryReader reader, TrackOffsets offsets, int positionAfterBestLine, int positionAfterPitLane)
        {
            reader.BaseStream.Position = positionAfterBestLine + 8;

            // the setup is the first 8 bytes
            byte[] dataAfterSetup = reader.ReadBytes(30);

            int bytesToRead = offsets.ChecksumPosition - positionAfterPitLane;

            // TODO: cleanup!

            reader.BaseStream.Position = positionAfterPitLane;

            byte[] final = reader.ReadBytes(bytesToRead);

            byte[] final1 = {};

            int final1EndAt = 0;

            for (int i = 0; i < final.Length - 1; i++)
            {
                byte byte1 = final[i];
                byte byte2 = final[i + 1];

                if (byte1 == 0xFF && byte2 == 0xFF)
                {
                    final1 = final.Take(i).ToArray();
                    final1EndAt = i;
                }
            }

            byte[] final2 = final.Skip(2 + final1EndAt).ToArray();

            return new TrackRawData
            {
                FinalData1 = final1,
                FinalData2 = final2,
                DataAfterSetup = dataAfterSetup
            };
        }
    }
}
