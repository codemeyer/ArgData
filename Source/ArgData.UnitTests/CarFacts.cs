using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.UnitTests
{
    public class CarFacts
    {
        [Fact]
        public void CarHasDefaultColors()
        {
            var car = new Car(new byte[16]);

            car.EngineCover.Should().Be(0);
        }

        [Fact]
        public void CarMustBeCreatedWithCorrectNumberOfColors()
        {
            byte[] tooFewColors = new byte[5];

            Action act = () => new Car(tooFewColors);

            act.ShouldThrow<Exception>();
        }
    }
}
