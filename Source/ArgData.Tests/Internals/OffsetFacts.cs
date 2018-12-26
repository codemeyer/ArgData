using System.IO;
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
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(knownTrackData.Path)))
            {
                reader.BaseStream.Position = 4096;

                var readOffsets = OffsetReader.Read(reader);
                var knownOffsets = knownTrackData.KnownOffsets;

                readOffsets.UnknownLong1.Should().Be(knownOffsets.UnknownLong1);
                readOffsets.UnknownLong2.Should().Be(knownOffsets.UnknownLong2);
                readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
                readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
                readOffsets.TrackData.Should().Be(knownOffsets.TrackData);
            }
        }

        [Fact]
        public void MexicoDataOffsets()
        {
            var knownTrackData = TrackFactsHelper.GetTrackMexico();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(knownTrackData.Path)))
            {
                reader.BaseStream.Position = 4096;

                var readOffsets = OffsetReader.Read(reader);
                var knownOffsets = knownTrackData.KnownOffsets;

                readOffsets.UnknownLong1.Should().Be(knownOffsets.UnknownLong1);
                readOffsets.UnknownLong2.Should().Be(knownOffsets.UnknownLong2);
                readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
                readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
                readOffsets.TrackData.Should().Be(knownOffsets.TrackData);
            }
        }
    }
}
