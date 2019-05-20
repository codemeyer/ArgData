using System.IO;
using System.Linq;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ComputerCarLineReaderFacts
    {
        [Fact]
        public void Phoenix_Displacement_576()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarLineReader.Read(reader, trackData.KnownComputerCarLineSectionDataStart);

                result.Displacement.Should().Be(576);
            }
        }

        [Fact]
        public void PhoenixComputerCarLinesHave40Segments()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarLineReader.Read(reader, trackData.KnownComputerCarLineSectionDataStart);

                result.ComputerCarLineSegments.Count.Should().Be(40);
                result.PositionAfterReading.Should().Be(trackData.KnownComputerCarSetupDataStart); // 16586
            }
        }

        [Fact]
        public void PhoenixComputerCarLinesHaveFirstSegmentWithLength48()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarLineReader.Read(reader, trackData.KnownComputerCarLineSectionDataStart);

                var firstSegment = result.ComputerCarLineSegments.First();
                firstSegment.Length.Should().Be(48);
            }
        }
    }
}
