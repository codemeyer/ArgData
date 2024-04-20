using ArgData.Entities;

namespace ArgData.Tests;

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
                ChecksumPosition = 16920,
                ObjectData = 12362,
                TrackData = 14410
            },
            KnownComputerCarLineSectionDataStart = 16342,
            KnownComputerCarSetupDataStart = 16586,
            KnownPitLaneSectionDataStart = 16624,
            KnownComputerCarBehaviorStart = 16892
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
                ChecksumPosition = 9425 + 4112,
                ObjectData = 5377 + 4112,
                TrackData = 7281 + 4112
            },
            KnownComputerCarSetupDataStart = 13065,
            KnownTrackCameraDataStart = 13467,
            KnownComputerCarBehaviorStart = 13509
        };
    }

    public static TestTrackKnownData GetTrackMonaco()
    {
        return new TestTrackKnownData
        {
            Path = GetTrackPath("F1CT04.DAT"),
        };
    }

    public static TestTrackKnownData GetTrackSilverstone()
    {
        return new TestTrackKnownData
        {
            Path = GetTrackPath("F1CT08.DAT"),
            KnownOffsets = new TrackOffsets
            {
                ObjectData = 11081
            }
        };
    }

    private static string GetTrackPath(string fileName)
    {
        return ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Tracks);
    }
}

public class TestTrackKnownData
{
    public string Path { get; init; }

    public TrackOffsets KnownOffsets { get; init; }

    public int KnownHeaderLength { get; init; }

    public int KnownTrackSectionDataStart => KnownOffsets.TrackData + KnownHeaderLength;

    public int KnownComputerCarLineSectionDataStart { get; init; }
    public int KnownComputerCarSetupDataStart { get; init; }
    public int KnownPitLaneSectionDataStart { get; init; }
    public int KnownTrackCameraDataStart { get; init; }
    public int KnownComputerCarBehaviorStart { get; set; }
}
