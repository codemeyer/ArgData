using System.IO;
using System.Linq;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class BestLineReaderFacts
    {
        [Fact]
        public void Phoenix_Displacement_576()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = BestLineReader.Read(reader, trackData.KnownBestLineSectionDataStart);

                result.Displacement.Should().Be(576);
            }
        }

        [Fact]
        public void PhoenixBestLineHas40Segments()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = BestLineReader.Read(reader, trackData.KnownBestLineSectionDataStart);

                result.BestLineSegments.Count.Should().Be(40);
                result.PositionAfterReading.Should().Be(trackData.KnownComputerCarSetupDataStart); // 16586
            }
        }

        [Fact]
        public void PhoenixBestLineHasFirstSegmentWithLength48()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = BestLineReader.Read(reader, trackData.KnownBestLineSectionDataStart);

                var firstSegment = result.BestLineSegments.First();
                firstSegment.Length.Should().Be(48);
            }
        }
    }
}
