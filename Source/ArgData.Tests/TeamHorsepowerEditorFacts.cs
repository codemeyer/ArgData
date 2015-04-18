using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TeamHorsepowerFacts
    {
        public class ReadingHorsepowerValuesFromOriginalExeFile
        {
            [Fact]
            public void ReturnsCorrectHorsepowerLevelsForEachTeam()
            {
                var expectedValues = new[] { 716, 676, 716, 650, 620, 625, 620, 665, 610, 680,
                    655, 665, 640, 700, 630, 610, 680, 615 };

                string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
                var exeEditor = new GpExeFile(exampleDataPath);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileHorsepower = horsepowerEditor.ReadTeamHorsepower(i);
                    var expectedHorsepower = expectedValues[i];

                    fileHorsepower.Should().Be(expectedHorsepower);
                }

                ExampleDataHelper.DeleteFile(exampleDataPath);
            }
        }

        public class WritingHorsepowerValues
        {
            [Fact]
            public void Setup()
            {
                string exampleDataFile = ExampleDataHelper.GetCopyOfExampleData("gp-orig.exe");

                var exeEditor = new GpExeFile(exampleDataFile);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                int startValue = 700;

                for (int i = 0; i < GpExeFile.NumberOfTeams; i++)
                {
                    horsepowerEditor.WriteTeamHorsepower(i, startValue);
                    startValue++;
                }

                for (int i = 0; i < GpExeFile.NumberOfTeams; i++)
                {
                    var value = horsepowerEditor.ReadTeamHorsepower(i);

                    value.Should().Be(700 + i);
                }

                ExampleDataHelper.DeleteFile(exampleDataFile);
            }
        }
    }
}
