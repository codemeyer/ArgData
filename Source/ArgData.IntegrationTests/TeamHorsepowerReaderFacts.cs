using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace TeamHorsepowerReaderFacts
    {
        public class ReadingTeamHorsepower : IntegrationTestBase
        {
            private readonly TeamHorsepowerReader _reader;

            public ReadingTeamHorsepower()
            {
                var positions = Substitute.For<DataPositions>();
                positions.TeamHorsepower.Returns(63);
                _reader = new TeamHorsepowerReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void FirstTeamHorsepowerReturns716()
            {
                int hp = _reader.ReadTeamHorsepower(0);

                hp.Should().Be(716);
            }

            [Fact]
            public void SecondTeamHorsepowerReturns676()
            {
                int hp = _reader.ReadTeamHorsepower(1);

                hp.Should().Be(676);
            }

            [Fact]
            public void LastTeamHorsepowerReturns615()
            {
                int hp = _reader.ReadTeamHorsepower(17);

                hp.Should().Be(615);
            }
        }
    }
}

