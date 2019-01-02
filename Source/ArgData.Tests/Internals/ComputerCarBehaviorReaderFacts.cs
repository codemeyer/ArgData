using System.IO;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ComputerCarBehaviorReaderFacts
    {
        [Fact]
        public void Read_PhoenixTrack_HasExpectedBehaviorData()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var behavior = ComputerCarBehaviorReader.Read(reader, trackData.KnownComputerCarBehaviorStart);

                behavior.UnknownData.Length.Should().Be(16);
                behavior.FormationLength.Should().Be(118);
                behavior.LapTimeIndication.Should().Be(86000);
                behavior.LapCount.Should().Be(81);
                behavior.StrategyFirstPitStopLap.Should().Be(43);
                behavior.StrategyChance.Should().Be(8192);
            }
        }

        [Fact]
        public void Read_MexicoTrack_HasExpectedBehaviorData()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var behavior = ComputerCarBehaviorReader.Read(reader, trackData.KnownComputerCarBehaviorStart);

                behavior.UnknownData.Length.Should().Be(16);
                behavior.FormationLength.Should().Be(203);
                behavior.LapTimeIndication.Should().Be(80000);
                behavior.LapCount.Should().Be(69);
                behavior.StrategyFirstPitStopLap.Should().Be(37);
                behavior.StrategyChance.Should().Be(4096);
            }
        }
    }
}
