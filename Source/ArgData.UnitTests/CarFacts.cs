using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.UnitTests
{
    public class CarFacts
    {
        [Fact]
        public void CarHasColors()
        {
            var car = new Car(new byte[16]);

            car.EngineCover.Should().Be(0);
        }
    }
}
