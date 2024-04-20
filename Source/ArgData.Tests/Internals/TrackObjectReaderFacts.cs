using System.IO;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals;

public class TrackObjectReaderFacts
{
    [Fact]
    public void PhoenixContains128Objects()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var objects = TrackObjectSettingsReader.Read(reader, trackData.KnownOffsets.ObjectData, trackData.KnownOffsets.TrackData);

        objects.Count.Should().Be(128);
    }
}