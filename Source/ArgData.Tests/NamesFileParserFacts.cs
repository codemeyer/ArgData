using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class NamesFileParserFacts
    {
        public class ParsingNameFile
        {
            private readonly NamesFile _data;

            public ParsingNameFile()
            {
                string exampleDataPath = ExampleDataHelper.GetExampleDataPath("names1991.nam");

                var parser = new NamesFileParser();
                _data = parser.Parse(exampleDataPath);
            }

            [Fact]
            public void ReturnedDataShouldNotBeNull()
            {
                _data.Should().NotBeNull();
            }

            [Fact]
            public void ShouldReturnListOf_40_Drivers()
            {
                _data.Drivers.Count.Should().Be(40);
            }

            [Fact]
            public void FirstDriverShouldBeAyrtonSenna()
            {
                Driver firstDriver = _data.Drivers.First();

                firstDriver.Name.Should().Be("Ayrton Senna");
            }

            [Fact]
            public void ShouldReturnListOf_18_Teams()
            {
                _data.Teams.Count.Should().Be(20);
            }

            [Fact]
            public void FirstTeamShouldBeMcLaren()
            {
                Team firstTeam = _data.Teams.First();

                firstTeam.Name.Should().Be("McLaren");
            }

            [Fact]
            public void FirstTeamEngineShouldBeHonda()
            {
                Team firstTeam = _data.Teams.First();

                firstTeam.Engine.Should().Be("Honda");
            }
        }
    }
}
