using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackComputerCarSettingsFacts
    {
        [Fact]
        public void PhoenixHasExpectedCarSettings()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);
            var settings = track.CarSettings;

            settings.Acceleration.Should().Be(16384);
            settings.AirResistance.Should().Be(16384);
            settings.FuelLoad.Should().Be(358);
            settings.GripFactor.Should().Be(16512);
            settings.TyreWearQualifying.Should().Be(11915);
            settings.TyreWearNonQualifying.Should().Be(17765);
        }

        [Fact]
        public void MexicoHasExpectedCarSettings()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();
            var track = new TestableTrackReader().Read(trackData.Path);
            var settings = track.CarSettings;

            settings.Acceleration.Should().Be(13107);
            settings.AirResistance.Should().Be(13107);
            settings.FuelLoad.Should().Be(309);
            settings.GripFactor.Should().Be(16512);
            settings.TyreWearQualifying.Should().Be(11915);
            settings.TyreWearNonQualifying.Should().Be(12632);
        }
    }
}
