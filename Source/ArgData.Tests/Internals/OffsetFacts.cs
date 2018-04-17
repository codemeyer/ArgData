using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class OffsetFacts
    {
        [Fact]
        public void PhoenixDataOffsets()
        {
            var knownTrackData = TrackFactsHelper.GetTrackPhoenix();
            var readOffsets = OffsetReader.Read(knownTrackData.Path);
            var knownOffsets = knownTrackData.KnownOffsets;

            readOffsets.UnknownLong1.Should().Be(knownOffsets.UnknownLong1);
            readOffsets.UnknownLong2.Should().Be(knownOffsets.UnknownLong2);
            readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
            readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
            readOffsets.TrackData.Should().Be(knownOffsets.TrackData);
        }

        [Fact]
        public void MexicoDataOffsets()
        {
            var knownTrackData = TrackFactsHelper.GetTrackMexico();
            var readOffsets = OffsetReader.Read(knownTrackData.Path);
            var knownOffsets = knownTrackData.KnownOffsets;

            readOffsets.UnknownLong1.Should().Be(knownOffsets.UnknownLong1);
            readOffsets.UnknownLong2.Should().Be(knownOffsets.UnknownLong2);
            readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
            readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
            readOffsets.TrackData.Should().Be(knownOffsets.TrackData);
        }
    }
}
