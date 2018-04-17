using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class TrackObjectReaderFacts
    {
        [Fact]
        public void PhoenixContains128Objects()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            var objects = TrackObjectSettingsReader.Read(trackData.Path, trackData.KnownOffsets.ObjectData, trackData.KnownOffsets.TrackData);

            objects.Count.Should().Be(128);
        }
    }
}
