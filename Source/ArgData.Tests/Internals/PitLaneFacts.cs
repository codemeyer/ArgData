using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class PitLaneFacts
    {
        [Fact]
        public void PhoenixPitLaneHasKnownCount()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            var result = TrackSectionReader.Read(trackData.Path, trackData.KnownPitLaneSectionDataStart);

            result.TrackSections.Count.Should().Be(13);
            result.Position.Should().Be(16876);
        }
    }
}
