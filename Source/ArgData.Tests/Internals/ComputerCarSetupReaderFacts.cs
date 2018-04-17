using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ComputerCarSetupReaderFacts
    {
        [Fact]
        public void PhoenixHasKnownDefaultSetup()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var result = ComputerCarSetupReader.Read(trackData.Path, trackData.KnownComputerCarSetupDataStart);
            var setup = result.Setup;

            setup.FrontWing.Should().Be(48);
            setup.RearWing.Should().Be(48);
            setup.GearRatio1.Should().Be(23);
            setup.GearRatio2.Should().Be(30);
            setup.GearRatio3.Should().Be(37);
            setup.GearRatio4.Should().Be(43);
            setup.GearRatio5.Should().Be(51);
            setup.GearRatio6.Should().Be(57);

            result.RawData.Length.Should().Be(30);
        }
    }
}
