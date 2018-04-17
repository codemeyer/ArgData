using System.Linq;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class BestLineReaderFacts
    {
        [Fact]
        public void Phoenix_FirstSegment_IsDisplacement()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            var result = BestLineReader.Read(trackData.Path, trackData.KnownBestLineSectionDataStart);

            var firstSegment = result.BestLineSegments.First();
            firstSegment.SegmentType.Should().Be(TrackBestLineSegmentType.Displacement);
            firstSegment.Displacement.Should().Be(576);
        }

        [Fact]
        public void PhoenixBestLineHas40Segments()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            var result = BestLineReader.Read(trackData.Path, trackData.KnownBestLineSectionDataStart);

            result.BestLineSegments.Count.Should().Be(40);
            result.PositionAfterReading.Should().Be(trackData.KnownComputerCarSetupDataStart); // 16586
        }

        [Fact]
        public void PhoenixBestLineHasFirstSegmentWithLength40()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            var result = BestLineReader.Read(trackData.Path, trackData.KnownBestLineSectionDataStart);

            var firstSegment = result.BestLineSegments.First();
            firstSegment.Length.Should().Be(48);
            firstSegment.Displacement.Should().Be(576);
        }
    }
}
