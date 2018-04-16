using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class CarFacts
    {
        [Fact]
        public void Car_HasDefaultColors()
        {
            var car = new Car(new byte[16]);

            car.EngineCover.Should().Be(0);
        }

        [Fact]
        public void Car_CreatedWithOtherThan_16_Bytes_ThrowsArgumentOutOfRangeException()
        {
            byte[] tooFewColors = new byte[5];

            Action action = () => new Car(tooFewColors);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Copy_TransfersAllColors()
        {
            var sourceCar = new Car
            {
                CockpitSide = 55,
                FrontWingEndplate = 66,
                NoseSide = 77,
                Sidepod = 88
            };
            var targetCar = new Car();

            targetCar.Copy(sourceCar);

            targetCar.CockpitSide.Should().Be(55);
            targetCar.FrontWingEndplate.Should().Be(66);
            targetCar.NoseSide.Should().Be(77);
            targetCar.Sidepod.Should().Be(88);
        }

        [Fact]
        public void Copy_NullCar_ThrowsArgumentNullException()
        {
            var car = new Car();

            Action action = () => car.Copy(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
