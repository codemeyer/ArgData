using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class NamesFileEditorFacts
    {
        public class ReadingNameFile
        {
            private readonly NamesFile _data;

            public ReadingNameFile()
            {
                string exampleDataPath = ExampleDataHelper.GetExampleDataPath("names1991.nam");

                var parser = new NamesFileEditor();
                _data = parser.Read(exampleDataPath);
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
        }
    }

    public class WritingNameFile
    {
        private List<Team> _teams;
        private List<Driver> _drivers;

        public WritingNameFile()
        {
            SetupTeams();
            SetupDrivers();
        }

        [Fact]
        public void FileShouldBeCorrectSize()
        {
            string tempNamesFile = Path.GetTempFileName();
            new NamesFileEditor().Write(tempNamesFile, _drivers, _teams);

            var fileInfo = new FileInfo(tempNamesFile);

            fileInfo.Length.Should().Be(1484);

            try
            {
                File.Delete(tempNamesFile);
            }
            catch
            {
            }
        }

        [Fact]
        public void WriteAndRead()
        {
            string tempNamesFile = Path.GetTempFileName();
            new NamesFileEditor().Write(tempNamesFile, _drivers, _teams);
            var namesFile = new NamesFileEditor().Read(tempNamesFile);

            namesFile.Drivers.Count.Should().Be(40);
            namesFile.Teams.Count.Should().Be(20);
            namesFile.Drivers[0].Name.Should().Be("Driver 1");
            namesFile.Teams[0].Name.Should().Be("Team 1");
        }

        private void SetupTeams()
        {
            _teams = new List<Team>();
            for (int i = 1; i <= Constants.NumberOfSupportedTeams; i++)
            {
                _teams.Add(new Team
                {
                    Name = string.Format("Team {0}", i),
                    Engine = string.Format("Engine {0}", i)
                });
            }
        }

        private void SetupDrivers()
        {
            _drivers = new List<Driver>();
            for (int i = 1; i <= Constants.NumberOfDrivers; i++)
            {
                _drivers.Add(new Driver
                {
                    Name = string.Format("Driver {0}", i)
                });
            }
        }
    }
}
