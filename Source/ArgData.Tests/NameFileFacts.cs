using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class NameFileFacts
    {
        public class ReadingNameFile
        {
            private readonly NameFile _data;

            public ReadingNameFile()
            {
                string exampleDataPath = ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names);

                _data = NameFileReader.Read(exampleDataPath);
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
            public void ShouldReturnListOf_20_Teams()
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

            [Fact]
            public void NonNameFileThrowsException()
            {
                var notNameFilePath = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);

                Action action = () => NameFileReader.Read(notNameFilePath);

                action.ShouldThrow<Exception>();
            }
        }
    }

    public class WritingNameFile
    {
        private readonly NameFileTeamList _teams;
        private readonly NameFileDriverList _drivers;

        public WritingNameFile()
        {
            _teams = new NameFileTeamList();
            _drivers = new NameFileDriverList();
        }

        [Fact]
        public void FileShouldBeCorrectSize()
        {
            using (var context = ExampleDataContext.GetTempFileName("names.nam"))
            {
                NameFileWriter.Write(context.FilePath, _drivers, _teams);

                var fileInfo = new FileInfo(context.FilePath);

                fileInfo.Length.Should().Be(1484);
            }
        }

        [Fact]
        public void WriteAndRead()
        {
            using (var context = ExampleDataContext.GetTempFileName("names.nam"))
            {
                NameFileWriter.Write(context.FilePath, _drivers, _teams);
                var namesFile = NameFileReader.Read(context.FilePath);

                namesFile.Drivers.Count.Should().Be(40);
                namesFile.Teams.Count.Should().Be(20);
                namesFile.Drivers[0].Name.Should().Be("Driver 1");
                namesFile.Teams[0].Name.Should().Be("Team 1");
            }
        }
    }
}
