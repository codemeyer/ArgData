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

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
