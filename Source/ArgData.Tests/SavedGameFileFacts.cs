using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class SavedGameFileFacts
    {
        [Fact]
        public void ReadSavedGame_NumberOfRacesShouldBe_3()
        {
            var savedGame = GetExampleFile();

            savedGame.NumberOfRacesCompleted.Should().Be(3);
        }

        [Fact]
        public void ReadSavedGame_NumberOfDriversShouldBe_39()
        {
            var savedGame = GetExampleFile();

            savedGame.Drivers.Count.Should().Be(39, "because there is only one driver with an empty name");
        }

        [Fact]
        public void ReadSavedGame_FirstDriverShouldBeAyrtonSenna()
        {
            var savedGame = GetExampleFile();

            savedGame.Drivers[0].Name.Should().Be("Ayrton Senna");
        }

        [Fact]
        public void ReadSavedGame_LastDriverShouldBeEricvandePoele()
        {
            var savedGame = GetExampleFile();

            savedGame.Drivers[33].Name.Should().Be("Eric van de Poele");
        }

        [Fact]
        public void ReadSavedGame_AllDriversShouldHaveThreeResults()
        {
            var savedGame = GetExampleFile();

            foreach (var driver in savedGame.Drivers)
            {
                driver.Results.Count().Should().Be(3);
            }
        }

        [Fact]
        public void ReadSavedGame_FirstDriverShouldHaveFinished_First_First_Third()
        {
            var savedGame = GetExampleFile();

            savedGame.Drivers[0].Results.Should().ContainInOrder(1, 1, 3);
        }

        private SavedGame GetExampleFile()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("season_after_r3.gam", TestDataFileType.Saves);

            return SavedGameFileReader.ReadSavedGame(exampleDataPath);
        }

        [Fact]
        public void ReadSavedGame_FewerDrivers_NumberOfRacesShouldBe_8()
        {
            var savedGame = GetExampleFileWithFewerDrivers();

            savedGame.NumberOfRacesCompleted.Should().Be(8);
        }

        [Fact]
        public void ReadSavedGame_FewerDrivers_NumberOfDriversShouldBe_26()
        {
            var savedGame = GetExampleFileWithFewerDrivers();

            savedGame.Drivers.Count.Should().Be(26);
        }

        [Fact]
        public void ReadSavedGame_FewerDrivers_AllDriversShouldHaveEightResults()
        {
            var savedGame = GetExampleFileWithFewerDrivers();

            foreach (var driver in savedGame.Drivers)
            {
                driver.Results.Count().Should().Be(8);
            }
        }

        private SavedGame GetExampleFileWithFewerDrivers()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("season_fewerdrv.gam", TestDataFileType.Saves);

            return SavedGameFileReader.ReadSavedGame(exampleDataPath);
        }

        [Fact]
        public void ReadSavedGame_Null_ThrowsArgumentNullException()
        {
            Action action = () => SavedGameFileReader.ReadSavedGame(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReadSavedGame_NonExistingFile_ThrowsFileNotFoundException()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("season-does-not-exist.gam", TestDataFileType.Saves);

            Action action = () => SavedGameFileReader.ReadSavedGame(exampleDataPath);

            action.ShouldThrow<FileNotFoundException>();
        }
    }
}
