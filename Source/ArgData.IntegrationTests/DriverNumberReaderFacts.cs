using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace DriverNumberReaderFacts
    {
        public class ReadingDriverNumbers : IntegrationTestBase
        {
            private readonly DriverNumberReader _reader;

            public ReadingDriverNumbers()
            {
                var positions = Substitute.For<DataPositions>();
                positions.DriverNumbers.Returns(1192);
                _reader = new DriverNumberReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void ShouldBe36Drivers()
            {
                byte[] numbers = _reader.ReadDriverNumbers();

                numbers.Length.Should().Be(36);
            }

            [Fact]
            public void FirstDriverShouldHaveNumber1()
            {
                byte[] numbers = _reader.ReadDriverNumbers();

                numbers.First().Should().Be(1);
            }

            [Fact]
            public void ThirteenthDriverShouldHaveNumber14()
            {
                byte[] numbers = _reader.ReadDriverNumbers();

                numbers[12].Should().Be(14);
            }

            [Fact]
            public void FourteenthDriverShouldBeDisabled()
            {
                byte[] numbers = _reader.ReadDriverNumbers();

                numbers[13].Should().Be(0);
            }

            [Fact]
            public void LastDriverShouldHaveNumber35()
            {
                byte[] numbers = _reader.ReadDriverNumbers();

                numbers.Last().Should().Be(35);
            }
        }
    }
}
