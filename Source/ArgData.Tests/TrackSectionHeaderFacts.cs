using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackSectionHeaderFacts
    {
        [Fact]
        public void PhoenixTrackSectionHeader()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);
            var header = track.TrackDataHeader;

            header.FirstSectionAngle.Should().Be(0);
            header.FirstSectionHeight.Should().Be(0);
            header.TrackCenterX.Should().Be(0);
            header.TrackCenterY.Should().Be(-14763);
            header.TrackCenterZ.Should().Be(0);
            header.StartWidth.Should().Be(1536);

            header.LeftVergeStartWidth.Should().Be(2);
            header.RightVergeStartWidth.Should().Be(2);
        }

        [Fact]
        public void MexicoTrackSectionHeader()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();
            var track = new TestableTrackReader().Read(trackData.Path);
            var header = track.TrackDataHeader;

            header.FirstSectionAngle.Should().Be(0);
            header.FirstSectionHeight.Should().Be(0);
            header.TrackCenterX.Should().Be(-9052);
            header.TrackCenterY.Should().Be(-11991);
            header.TrackCenterZ.Should().Be(0);
            header.StartWidth.Should().Be(1792);

            header.LeftVergeStartWidth.Should().Be(32);
            header.RightVergeStartWidth.Should().Be(32);
        }
    }
}
