using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests;

public class TrackSettingsFacts
{
    [Fact]
    public void PhoenixHasExpectedTrackSettings()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();
        var track = new TestableTrackReader().Read(trackData.Path);
        var settings = track.TrackSettings;

        settings.LapCount.Should().Be(81);
        settings.LapTimeIndication.Should().Be(86000);
        settings.TimeFactorNonRace.Should().Be(18094);
        settings.TimeFactorRace.Should().Be(18031);
        settings.UnknownTrackDistance.Should().Be(256);
        settings.DefaultPitLaneViewDistance.Should().Be(256);

        settings.PoleSide.Should().Be(TrackSide.Right);
        settings.PitsSide.Should().Be(TrackSide.Left);
        settings.SurroundingArea.Should().Be(SurroundingArea.Gray2);

        settings.KerbType.Should().Be(KerbType.DualColor);
        settings.KerbUpperColor.Should().Be(9);
        settings.KerbLowerColor.Should().Be(2);
        settings.KerbUpperColor2.Should().Be(0);
        settings.KerbLowerColor2.Should().Be(0);
    }

    [Fact]
    public void MexicoHasExpectedTrackSettings()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();
        var track = new TestableTrackReader().Read(trackData.Path);
        var settings = track.TrackSettings;

        settings.LapCount.Should().Be(69);
        settings.LapTimeIndication.Should().Be(80000);
        settings.TimeFactorNonRace.Should().Be(18518);
        settings.TimeFactorRace.Should().Be(18220);
        settings.UnknownTrackDistance.Should().Be(256);
        settings.DefaultPitLaneViewDistance.Should().Be(640);

        settings.PoleSide.Should().Be(TrackSide.Left);
        settings.PitsSide.Should().Be(TrackSide.Right);
        settings.SurroundingArea.Should().Be(SurroundingArea.Green);
    }

    [Fact]
    public void MonacoHasExpectedTrackSettings()
    {
        var trackData = TrackFactsHelper.GetTrackMonaco();
        var track = new TestableTrackReader().Read(trackData.Path);
        var settings = track.TrackSettings;

        settings.LapCount.Should().Be(78);

        settings.PoleSide.Should().Be(TrackSide.Right);
        settings.PitsSide.Should().Be(TrackSide.Right);
        settings.SurroundingArea.Should().Be(SurroundingArea.Gray1);
    }
}
