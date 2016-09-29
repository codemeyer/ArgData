using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class SetupFacts
    {
        [Fact]
        public void IsValid_WhenAllValuesAreOk_ReturnsTrue()
        {
            var setup = new Setup();

            setup.IsValid.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenFrontWingGreaterThan64_ReturnsFalse()
        {
            var setup = new Setup
            {
                FrontWing = 65
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenRearWingGreaterThan64_ReturnsFalse()
        {
            var setup = new Setup
            {
                RearWing = 65
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenBrakeBalanceGreaterThan32_ReturnsFalse()
        {
            var setup = new Setup
            {
                BrakeBalance = 33
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenBrakeBalanceLessThanMinus32_ReturnsFalse()
        {
            var setup = new Setup
            {
                BrakeBalance = -33
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio1LessThan16_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio1 = 15
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio1IsGreaterThanGearRatio2_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio1 = 27,
                GearRatio2 = 26
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio2IsGreaterThanGearRatio3_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio2 = 37,
                GearRatio3 = 36
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio3IsGreaterThanGearRatio4_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio3 = 47,
                GearRatio4 = 46
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio4IsGreaterThanGearRatio5_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio4 = 57,
                GearRatio5 = 56
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio5IsGreaterThanGearRatio6_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio5 = 67,
                GearRatio6 = 66
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio6IsGreaterThan80_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio6 = 81
            };

            setup.IsValid.Should().BeFalse();
        }
    }
}
