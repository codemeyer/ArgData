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

                _data = SavedGameFileReader.ReadSavedGame(exampleDataPath);
            }

            [Fact]
            public void NumberOfRacesShouldBe_3()
            {
                _data.NumberOfRacesCompleted.Should().Be(3);
            }

            [Fact]
            public void NumberOfDriversShouldBe_39()
            {
                _data.Drivers.Count.Should().Be(39, "because there is only one driver with an empty name");
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
                foreach (var driver in _data.Drivers)
                {
                    driver.Results.Count.Should().Be(3);
                }
            }

            [Fact]
            public void FirstDriverShouldHaveFinished_First_First_Third()
            {
                _data.Drivers[0].Results.Should().ContainInOrder(1, 1, 3);
            }
        }
    }

    public class ReadingSavedGameFileWithFewerDriversThanOriginal
    {
        private readonly SavedGame _data;

        public ReadingSavedGameFileWithFewerDriversThanOriginal()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("season_fewerdrv.gam");

            _data = SavedGameFileReader.ReadSavedGame(exampleDataPath);
        }

        [Fact]
        public void NumberOfRacesShouldBe_8()
        {
            _data.NumberOfRacesCompleted.Should().Be(8);
        }

        [Fact]
        public void NumberOfDriversShouldBe_26()
        {
            _data.Drivers.Count.Should().Be(26);
        }

        [Fact]
        public void AllDriversShouldHaveEightResults()
        {
            foreach (var driver in _data.Drivers)
            {
                driver.Results.Count.Should().Be(8);
            }
        }
    }
}
