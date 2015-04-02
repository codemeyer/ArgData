using System.IO;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace SavedGameFileParserFacts
    {
        public class ParsingSavedGameFile : IntegrationTestBase
        {
            private readonly SavedGame _data;

            public ParsingSavedGameFile()
            {
                string exampleDataPath = GetExampleDataPath("season_after_r3.gam");
                byte[] bytes = File.ReadAllBytes(exampleDataPath);

                var parser = new SavedGameFileParser();
                _data = parser.Parse(bytes);
            }

            [Fact]
            public void NumberOfRacesShouldBe_3()
            {
                _data.NumberOfRacesCompleted.Should().Be(3);
            }

            [Fact]
            public void NumberOfDriversShouldBe_34()
            {
                _data.Drivers.Count.Should().Be(34);
            }

            [Fact]
            public void FirstDriverShouldBeAyrtonSenna()
            {
                _data.Drivers[0].Name.Should().Be("Ayrton Senna");
            }

            [Fact]
            public void LastDriverShouldBeEricvandePoele()
            {
                _data.Drivers[33].Name.Should().Be("Eric van de Poele");
            }

            [Fact]
            public void AllDriversShouldHaveThreeResults()
            {
                _data.Drivers.ForEach(d => d.Results.Count.Should().Be(3));
            }

            [Fact]
            public void FirstDriverShouldHaveFinished_First_First_Third()
            {
                _data.Drivers[0].Results.Should().ContainInOrder(1, 1, 3);
            }
        }
    }
}
