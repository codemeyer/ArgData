using System.IO;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class TrackSectionHeaderFacts
    {
        [Fact]
        public void PhoenixTrackSectionHeader()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var header = TrackSectionHeaderReader.Read(reader, trackData.KnownOffsets.TrackData);

                header.FirstSectionAngle.Should().Be(0);
                header.FirstSectionHeight.Should().Be(0);
                header.TrackCenterX.Should().Be(0);
                header.TrackCenterY.Should().Be(-14763);
                header.TrackCenterZ.Should().Be(0);
                header.StartWidth.Should().Be(1536);

                header.PoleSide.Should().Be(TrackSide.Right);
                header.PitsSide.Should().Be(TrackSide.Left);
                header.SurroundingArea.Should().Be(SurroundingArea.Gray2);

                header.LeftVergeStartWidth.Should().Be(2);
                header.RightVergeStartWidth.Should().Be(2);

                header.KerbType.Should().Be(KerbType.DualColor);
                header.KerbUpperColor.Should().Be(9);
                header.KerbLowerColor.Should().Be(2);
                header.KerbUpperColor2.Should().Be(0);
                header.KerbLowerColor2.Should().Be(0);

                header.GetHeaderLength().Should().Be(trackData.KnownHeaderLength); // 28
            }
        }

        [Fact]
        public void MexicoTrackSectionHeader()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var header = TrackSectionHeaderReader.Read(reader, trackData.KnownOffsets.TrackData);

                header.FirstSectionAngle.Should().Be(0);
                header.FirstSectionHeight.Should().Be(0);
                header.TrackCenterX.Should().Be(-9052);
                header.TrackCenterY.Should().Be(-11991);
                header.TrackCenterZ.Should().Be(0);
                header.StartWidth.Should().Be(1792);

                header.PoleSide.Should().Be(TrackSide.Left);
                header.PitsSide.Should().Be(TrackSide.Right);
                header.SurroundingArea.Should().Be(SurroundingArea.Green);

                header.LeftVergeStartWidth.Should().Be(32);
                header.RightVergeStartWidth.Should().Be(32);

                header.KerbType.Should().Be(KerbType.TripleColor);
                header.KerbUpperColor.Should().Be(9);
                header.KerbLowerColor.Should().Be(2);
                header.KerbUpperColor2.Should().Be(15);
                header.KerbLowerColor2.Should().Be(11);

                header.GetHeaderLength().Should().Be(trackData.KnownHeaderLength); // 32
            }
        }
    }
}
