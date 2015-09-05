using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class SavedGameFileFacts
    {
        public class ReadingSavedGameFile
        {
            private readonly SavedGame _data;

            public ReadingSavedGameFile()
            {
                string exampleDataPath = ExampleDataHelper.GetExampleDataPath("season_after_r3.gam");

                var gameFileReader = new SavedGameFileReader();
                _data = gameFileReader.ReadSavedGame(exampleDataPath);
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
