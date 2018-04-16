using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class DamageSettingsFacts
    {
        [Fact]
        public void IsValid_WhenAllValuesAreOk_ReturnsTrue()
        {
            var settings = new DamageSettings();

            settings.IsValid.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenRetiredWallValueIsBelowZero_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                RetireAfterHittingWall = -1
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenRetiredCarValueIsBelowZero_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                RetireAfterHittingOtherCar = -1
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenDamagedWallValueIsBelowZero_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                DamageAfterHittingWall = -1
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenDamagedCarValueIsBelowZero_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                DamageAfterHittingOtherCar = -1
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenYellowFlagSecondsIsLessThan1_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                YellowFlagsForStationaryCarsAfterSeconds = 0
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenYellowFlagSecondsIsGreaterThan60_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                YellowFlagsForStationaryCarsAfterSeconds = 61
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenRemovedCarsSecondsIsLessThan1_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                RetiredCarsRemovedAfterSeconds = 0
            };

            settings.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenRemovedCarsSecondsIsGreaterThan60_ReturnsFalse()
        {
            var settings = new DamageSettings
            {
                RetiredCarsRemovedAfterSeconds = 61
            };

            settings.IsValid.Should().BeFalse();
        }
    }
}
