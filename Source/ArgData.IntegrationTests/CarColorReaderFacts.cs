using System.Linq;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace CarColorReaderFacts
    {
        public class ReadingCarColors : IntegrationTestBase
        {
            private readonly CarColorReader _reader;

            public ReadingCarColors()
            {
                var positions = Substitute.For<DataPositions>();
                positions.CarColors.Returns(106);
                _reader = new CarColorReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void EachCarStartsWith33()
            {
                byte[] colors = _reader.ReadCarColors(0);

                colors.First().Should().Be(33);
            }

            [Fact]
            public void FirstTeamHasExpectedColors()
            {
                byte[] colors = _reader.ReadCarColors(0);

                colors.Should().Contain(47);
            }

            [Fact]
            public void LastTeamHasExpectedColors()
            {
                byte[] colors = _reader.ReadCarColors(17);

                colors.Should().Contain(88);
                colors.Should().Contain(32);
            }

            [Fact]
            public void TeamWithIndex12HasIncreasingNumbers()
            {
                byte[] colors = _reader.ReadCarColors(12);

                colors[1].Should().Be(0);
                colors[2].Should().Be(1);
                colors[3].Should().Be(2);
                colors[15].Should().Be(12);
            }
        }
        

        public class ReadingCarColorsAsCars : IntegrationTestBase
        {
            private readonly CarColorReader _reader;

            public ReadingCarColorsAsCars()
            {
                var positions = Substitute.For<DataPositions>();
                positions.CarColors.Returns(106);
                _reader = new CarColorReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void ReadCarColorsAsCarsReturnsAllCars()
            {
                var cars = _reader.ReadCarColorsAsCars();

                cars.Count.Should().Be(18);
            }

            [Fact]
            public void ReadCarReturnsExpectedColors()
            {
                var cars = _reader.ReadCarColorsAsCars();
                var car = cars[12];

                car.EngineCover.Should().Be(0);
                car.CockpitFront.Should().Be(1);
                car.FrontWingEndplate.Should().Be(2);
                car.RearWingSide.Should().Be(3);
                car.NoseSide.Should().Be(4);
                car.Sidepod.Should().Be(5);
                car.FrontAndRearWing.Should().Be(6);
                car.NoseTop.Should().Be(7);
                car.NoseAngle.Should().Be(8);
                car.CockpitSide.Should().Be(9);
                car.EngineCoverSide.Should().Be(10);
                car.EngineCoverRear.Should().Be(11);
                car.SidepodTop.Should().Be(12);
            }
        }
    }
}
