using System.IO;
using System.Linq;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class TrackSectionReaderFacts
    {
        [Fact]
        public void PhoenixTrackDataHas67Sections()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

                result.TrackSections.Count.Should().Be(67);
                result.Position.Should().Be(trackData.KnownBestLineSectionDataStart); // 16342
            }
        }

        [Fact]
        public void PhoenixTrackData_FirstSection_TrackSectionAttributes()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

                var firstSection = result.TrackSections.First();
                firstSection.Length.Should().Be(24);    
            }
        }

        [Fact]
        public void PhoenixTrackData_FirstSectionHas_14_Commands()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);
            
                var firstSection = result.TrackSections.First();
                firstSection.Commands.Count.Should().Be(14);
            }
        }

        [Fact]
        public void PhoenixTrack_FirstTurn_FirstSection()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

                var turn1 = result.TrackSections[5];
                turn1.Length.Should().Be(2);
                turn1.Curvature.Should().Be(2731);
                turn1.Height.Should().Be(0);
                turn1.LeftVergeWidth.Should().Be(2);
                turn1.RightVergeWidth.Should().Be(2);
            }
        }

        [Fact]
        public void PhoenixTrackData_FirstSection_CommandDetails()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

                var firstCommand = result.TrackSections.First().Commands.First();
                firstCommand.Command.Should().Be(0xAC);
                firstCommand.Arguments.Length.Should().Be(5);
                firstCommand.Arguments.Should().ContainInOrder(new short[] {0, 26, 32, 32, 29});

                var lastCommand = result.TrackSections.First().Commands.Last();
                lastCommand.Command.Should().Be(0x81);
                lastCommand.Arguments.Length.Should().Be(2);
                lastCommand.Arguments.Should().ContainInOrder(new short[] {0, 148});
            }
        }
    }
}
