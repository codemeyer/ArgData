using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackComputerCarBehaviorFacts
    {
        [Fact]
        public void PhoenixHasExpectedComputerCarBehavior()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);
            var behavior = track.ComputerCarBehavior;

            behavior.FormationLength.Should().Be(118);
            behavior.LateBrakingFactorNonRace.Should().Be(16384);
            behavior.LateBrakingFactorRace.Should().Be(16384);
            behavior.LateBrakingFactorWetRace.Should().Be(16128);
            behavior.PowerFactor.Should().Be(9216);
            behavior.StrategyFirstPitStopLap.Should().Be(43);
            behavior.StrategyChance.Should().Be(8192);
            behavior.UnknownData.Length.Should().Be(16);
        }

        [Fact]
        public void MexicoHasExpectedComputerCarBehavior()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();
            var track = new TestableTrackReader().Read(trackData.Path);
            var behavior = track.ComputerCarBehavior;

            behavior.FormationLength.Should().Be(203);
            behavior.LateBrakingFactorNonRace.Should().Be(16384);
            behavior.LateBrakingFactorRace.Should().Be(16384);
            behavior.LateBrakingFactorWetRace.Should().Be(16128);
            behavior.PowerFactor.Should().Be(11648);
            behavior.StrategyFirstPitStopLap.Should().Be(37);
            behavior.StrategyChance.Should().Be(4096);
            behavior.UnknownData.Length.Should().Be(16);
        }
    }
}
