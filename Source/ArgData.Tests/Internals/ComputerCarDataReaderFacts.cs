using System.IO;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ComputerCarDataReaderFacts
    {
        [Fact]
        public void PhoenixHasKnownDefaultSetup()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarDataReader.Read(reader, trackData.KnownComputerCarSetupDataStart);
                var setup = result.Setup;

                setup.FrontWing.Should().Be(48);
                setup.RearWing.Should().Be(48);
                setup.GearRatio1.Should().Be(23);
                setup.GearRatio2.Should().Be(30);
                setup.GearRatio3.Should().Be(37);
                setup.GearRatio4.Should().Be(43);
                setup.GearRatio5.Should().Be(51);
                setup.GearRatio6.Should().Be(57);
                setup.TyreCompound.Should().Be(SetupTyreCompound.C);
                setup.BrakeBalance.Should().Be(0);
            }
        }

        [Fact]
        public void PhoenixHasExpectedData()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarDataReader.Read(reader, trackData.KnownComputerCarSetupDataStart);
                var data = result.ComputerCarData;

                data.GripFactor.Should().Be(16512);
                data.ComputerCarLateBrakingFactorNonRace.Should().Be(16384);
                data.ComputerCarLateBrakingFactorRace.Should().Be(16384);
                data.TimeFactorNonRace.Should().Be(18094);
                data.Acceleration.Should().Be(16384);
                data.AirResistance.Should().Be(16384);
                data.TyreWearQualifying.Should().Be(11915);
                data.TyreWearNonQualifying.Should().Be(17765);
                data.FuelLoad.Should().Be(358);
                data.TimeFactorRace.Should().Be(18031);
                data.ComputerCarPowerFactor.Should().Be(9216);
                data.ComputerCarLateBrakingFactorWetRace.Should().Be(16128);
                data.UnknownTrackDistance.Should().Be(256);
                data.DefaultPitLaneViewDistance.Should().Be(256);
            }
        }

        [Fact]
        public void MexicoHasExpectedData()
        {
            var trackData = TrackFactsHelper.GetTrackMexico();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                var result = ComputerCarDataReader.Read(reader, trackData.KnownComputerCarSetupDataStart);
                var data = result.ComputerCarData;

                data.GripFactor.Should().Be(16512);
                data.ComputerCarLateBrakingFactorNonRace.Should().Be(16384);
                data.ComputerCarLateBrakingFactorRace.Should().Be(16384);
                data.TimeFactorNonRace.Should().Be(18518);
                data.Acceleration.Should().Be(13107);
                data.AirResistance.Should().Be(13107);
                data.TyreWearQualifying.Should().Be(11915);
                data.TyreWearNonQualifying.Should().Be(12632);
                data.FuelLoad.Should().Be(309);
                data.TimeFactorRace.Should().Be(18220);
                data.ComputerCarPowerFactor.Should().Be(11648);
                data.ComputerCarLateBrakingFactorWetRace.Should().Be(16128);
                data.UnknownTrackDistance.Should().Be(256);
                data.DefaultPitLaneViewDistance.Should().Be(640);
            }
        }
    }
}
