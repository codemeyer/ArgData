using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class RawDataReader
    {
        public static TrackRawData Read(string path, TrackOffsets offsets, int positionAfterBestLine, int positionAfterPitLane)
        {
            var trackFileReader = new FileReader(path);

            // the setup is the first 8 bytes
            byte[] dataAfterSetup = trackFileReader.ReadBytes(positionAfterBestLine + 8, 30);

            int bytesToRead = offsets.ChecksumPosition - positionAfterPitLane;

            // TODO: cleanup!

            byte[] final = trackFileReader.ReadBytes(positionAfterPitLane, bytesToRead);

            byte[] final1 = {}; // = new byte[];

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
