using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace RaceGripReaderFacts
    {
        public class ReadingQualifyingGripLevel : IntegrationTestBase
        {
            private readonly QualifyingGripLevelReader _reader;

            public ReadingQualifyingGripLevel()
            {
                var positions = Substitute.For<DataPositions>();
                positions.QualifyingGripLevels.Returns(436);
                _reader = new QualifyingGripLevelReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void SennaHasGripLevel1()
            {
                int gripLevel = _reader.ReadGripLevel(0);

                gripLevel.Should().Be(1);
            }

            [Fact]
            public void MansellHasGripLevel3()
            {
                int gripLevel = _reader.ReadGripLevel(4);

                gripLevel.Should().Be(3);
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
