using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class NamesFileParserFacts
    {
        public class ParsingNameFile
        {
            private readonly NamesFile _data;

            public ParsingNameFile()
            {
                string exampleDataPath = ExampleDataHelper.GetExampleDataPath("names1991.nam");
                byte[] bytes = File.ReadAllBytes(exampleDataPath);

                var parser = new NamesFileParser();
                _data = parser.Parse(bytes);
            }

            [Fact]
            public void ReturnedDataShouldNotBeNull()
            {
                _data.Should().NotBeNull();
            }

            [Fact]
            public void ShouldReturnListOf_36_Drivers()
            {
                _data.Drivers.Count.Should().Be(36);
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
                _data.Teams.Count.Should().Be(18);
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
