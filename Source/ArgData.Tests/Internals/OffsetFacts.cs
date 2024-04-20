using System.IO;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals;

public class OffsetFacts
{
    [Fact]
    public void PhoenixDataOffsets()
    {
        var knownTrackData = TrackFactsHelper.GetTrackPhoenix();
        using var reader = new BinaryReader(MemoryStreamProvider.Open(knownTrackData.Path));
        reader.BaseStream.Position = 4096;

        var readOffsets = OffsetReader.Read(reader);
        var knownOffsets = knownTrackData.KnownOffsets;

        readOffsets.BaseOffset.Should().Be(0x1010);
        readOffsets.Unknown2.Should().Be(5621);
        readOffsets.Unknown3.Should().Be(6188);
        readOffsets.Unknown4.Should().Be(5621);
        readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
        readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
        readOffsets.TrackData.Should().Be(knownOffsets.TrackData);

        readOffsets.Unknown2.Should().Be(readOffsets.Unknown4);
    }

    [Fact]
    public void MexicoDataOffsets()
    {
        var knownTrackData = TrackFactsHelper.GetTrackMexico();
        using var reader = new BinaryReader(MemoryStreamProvider.Open(knownTrackData.Path));
        reader.BaseStream.Position = 4096;

        var readOffsets = OffsetReader.Read(reader);
        var knownOffsets = knownTrackData.KnownOffsets;

        readOffsets.BaseOffset.Should().Be(0x1010);
        readOffsets.Unknown2.Should().Be(10865);
        readOffsets.Unknown3.Should().Be(7414);
        readOffsets.Unknown4.Should().Be(10865);
        readOffsets.ChecksumPosition.Should().Be(knownOffsets.ChecksumPosition);
        readOffsets.ObjectData.Should().Be(knownOffsets.ObjectData);
        readOffsets.TrackData.Should().Be(knownOffsets.TrackData);

        readOffsets.Unknown2.Should().Be(readOffsets.Unknown4);
    }
}