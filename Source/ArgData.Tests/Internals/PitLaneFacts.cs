using System.IO;
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

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownPitLaneSectionDataStart);

                result.TrackSections.Count.Should().Be(13);
                result.Position.Should().Be(16876);
            }
        }
    }
}
