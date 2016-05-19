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
        public void IsValid_WhenFrontWingHigherThan64_ReturnsFalse()
        {
            var setup = new Setup
            {
                FrontWing = 65
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenRearWingHigherThan64_ReturnsFalse()
        {
            var setup = new Setup
            {
                RearWing = 65
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenBrakeBalanceHigherThan32_ReturnsFalse()
        {
            var setup = new Setup
            {
                BrakeBalanceValue = 33
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio1LowerThan16_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio1 = 15
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio1IsHigherThanGearRatio2_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio1 = 27,
                GearRatio2 = 26
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio2IsHigherThanGearRatio3_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio2 = 37,
                GearRatio3 = 36
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio3IsHigherThanGearRatio4_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio3 = 47,
                GearRatio4 = 46
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio4IsHigherThanGearRatio5_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio4 = 57,
                GearRatio5 = 56
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio5IsHigherThanGearRatio6_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio5 = 67,
                GearRatio6 = 66
            };

            setup.IsValid.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenGearRatio6IsHigherThan80_ReturnsFalse()
        {
            var setup = new Setup
            {
                GearRatio6 = 81
            };

            setup.IsValid.Should().BeFalse();
        }
    }
}
