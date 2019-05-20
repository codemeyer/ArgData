using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackReaderFacts
    {
        // these tests are a form of integration tests, making sure that all data reading glues together correctly

        [Fact]
        public void PhoenixDataIntegration()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            track.TrackSections.Count.Should().Be(67);
            track.PitLaneSections.Count.Should().Be(13);
            track.BestLineDisplacement.Should().Be(576);
            track.BestLineSegments.Count.Should().Be(40);
            track.ComputerCarSetup.FrontWing.Should().Be(48);
            track.ComputerCarSetup.TyreCompound.Should().Be(SetupTyreCompound.C);
            track.CarSettings.FuelLoad.Should().Be(358);
            track.ComputerCarBehavior.FormationLength.Should().Be(118);
            track.TrackSettings.LapCount.Should().Be(81);
        }

        [Fact]
        public void MexicoIntegration()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();
            var track = new TestableTrackReader().Read(trackData.Path);

            track.ComputerCarSetup.FrontWing.Should().Be(36);
            track.ComputerCarSetup.TyreCompound.Should().Be(SetupTyreCompound.C);
            track.CarSettings.FuelLoad.Should().Be(309);
            track.TrackCameraCommands.Count.Should().Be(20);
            track.ComputerCarBehavior.FormationLength.Should().Be(203);
            track.TrackSettings.LapCount.Should().Be(69);
        }
    }
}
