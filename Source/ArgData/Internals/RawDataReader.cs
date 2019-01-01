using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class RawDataReader
    {
        public static TrackRawData Read(BinaryReader reader, int positionAfterCameras)
        {
            reader.BaseStream.Position = positionAfterCameras;

            byte[] final2 = reader.ReadBytes(28);

            return new TrackRawData
            {
                FinalData2 = final2
            };
        }
    }
}
