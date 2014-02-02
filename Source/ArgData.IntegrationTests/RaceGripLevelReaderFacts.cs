using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace RaceGripReaderFacts
    {
        public class ReadingRaceGripLevel : IntegrationTestBase
        {
            private readonly RaceGripLevelReader _reader;

            public ReadingRaceGripLevel()
            {
                var positions = Substitute.For<DataPositions>();
                positions.RaceGripLevels.Returns(476);
                _reader = new RaceGripLevelReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void SennaHasGripLevel1()
            {
                int gripLevel = _reader.ReadGripLevel(0);

                gripLevel.Should().Be(1);
            }

            [Fact]
            public void MansellHasGripLevel2()
            {
                int gripLevel = _reader.ReadGripLevel(4);

                gripLevel.Should().Be(2);
            }

            [Fact]
            public void VandePoeleHasGripLevel31()
            {
                int gripLevel = _reader.ReadGripLevel(34);

                gripLevel.Should().Be(33);
            }
        }
    }
}
