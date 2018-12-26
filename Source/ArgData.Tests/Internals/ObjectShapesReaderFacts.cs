using System.IO;
using System.Linq;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ObjectShapesReaderFacts
    {
        [Fact]
        public void PhoenixContains35InternalObjects()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                objects.Count.Should().Be(35);
                objects.First().DataLength.Should().Be(141);
            }
        }

        [Fact]
        public void PhoenixHasCorrectLengthOfInternalObjects()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var expected = trackData.KnownOffsets.ObjectData - (4112 + 140);

                objects.Sum(o => o.DataLength).Should().Be(expected);
            }
        }

        [Fact]
        public void PhoenixObject2HasOffsetsAndData()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var shapeData = objects[2];

                shapeData.Offset1.Should().Be(4559);
                shapeData.Offset2.Should().Be(4563);
                shapeData.Offset3.Should().Be(4592);
                shapeData.Offset4.Should().Be(4656);
                shapeData.Offset5.Should().Be(4682);

                shapeData.HeaderValue1.Should().Be(30000);
                shapeData.HeaderValue2.Should().Be(5621);
                shapeData.HeaderValue3.Should().Be(5621);
                shapeData.HeaderValue4.Should().Be(5621);
                shapeData.HeaderValue5.Should().BeEquivalentTo(
                    new byte[] {0xF5, 0x15, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x7F, 0x00, 0xE0, 0x0D, 0x00});
                shapeData.HeaderValue6.Should().BeEquivalentTo(
                    new byte[] {0xF5, 0x15});

                shapeData.OffsetData1.Length.Should().Be(4);
                shapeData.OffsetData1.Should().BeEquivalentTo(new byte[] {0x00, 0x0F, 0x00, 0x18});

                shapeData.OffsetData2.Length.Should().Be(29);
                shapeData.OffsetData2.Should().StartWith(new byte[] {0x02, 0x00, 0x01, 0x06});
                shapeData.OffsetData2.Should().EndWith(new byte[] {0x09, 0xF4, 0xFA, 0x00});

                shapeData.OffsetData3.Length.Should().Be(64);
                shapeData.OffsetData3.Should().StartWith(new byte[] {0x00, 0x00, 0x00, 0x00});
                shapeData.OffsetData3.Should().EndWith(new byte[] {0x00, 0x0F, 0x00, 0x00});

                shapeData.OffsetData4.Length.Should().Be(26);
                shapeData.OffsetData4.Should().StartWith(new byte[] {0x00, 0x00, 0x00, 0x01});
                shapeData.OffsetData4.Should().EndWith(new byte[] {0x02, 0x06, 0x03, 0x07});

                shapeData.OffsetData5.Length.Should().Be(24);
                shapeData.OffsetData5.Should().StartWith(new byte[] {0x08, 0x00, 0x10, 0x00});
                shapeData.OffsetData5.Should().EndWith(new byte[] {0x12, 0x00, 0x00, 0x80});
            }
        }
    }
}
