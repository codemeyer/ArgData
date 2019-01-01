using ArgData.Entities;

namespace ArgData.Tests
{
    public static class TrackFactsHelper
    {
        public static TestTrackKnownData GetTrackPhoenix()
        {
            return new TestTrackKnownData
            {
                Path = GetTrackPath("F1CT01.DAT"),
                KnownHeaderLength = 28,
                KnownOffsets = new TrackOffsets
                {
                    UnknownLong1 = 368381968,
                    UnknownLong2 = 368384044,
                    ChecksumPosition = 16920,
                    ObjectData = 12362,
                    TrackData = 14410
                },
                KnownBestLineSectionDataStart = 16342,
                KnownComputerCarSetupDataStart = 16586,
                KnownPitLaneSectionDataStart = 16624
            };
        }

        public static TestTrackKnownData GetTrackMexico()
        {
            return new TestTrackKnownData
            {
                Path = GetTrackPath("F1CT06.DAT"),
                KnownHeaderLength = 32, // triple-colored kerbs
                KnownOffsets = new TrackOffsets
                {
                    UnknownLong1 = 712052752,
                    UnknownLong2 = 712056054,
                    ChecksumPosition = 9425 + 4112,
                    ObjectData = 5377 + 4112,
                    TrackData = 7281 + 4112
                },
                KnownComputerCarSetupDataStart = 13065,
                KnownTrackCameraDataStart = 13467
            };
        }

        private static string GetTrackPath(string fileName)
        {
            return ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Tracks);
        }
    }

    public class TestTrackKnownData
    {
        public string Path { get; set; }

        public TrackOffsets KnownOffsets { get; set; }

        public int KnownHeaderLength { get; set; }

        public int KnownTrackSectionDataStart => KnownOffsets.TrackData + KnownHeaderLength;

        public int KnownBestLineSectionDataStart { get; set; }
        public int KnownComputerCarSetupDataStart { get; set; }
        public int KnownPitLaneSectionDataStart { get; set; }
        public int KnownTrackCameraDataStart { get; set; }
    }
}
