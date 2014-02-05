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
        }
    }
}
