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
                var exeEditor = new GpExeEditor(exampleDataPath);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileHP = horsepowerEditor.ReadTeamHorsepower(i);
                    var expectedHP = expectedValues[i];

                    fileHP.Should().Be(expectedHP);
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

                var exeEditor = new GpExeEditor(exampleDataFile);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                int startValue = 700;

                for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
                {
                    horsepowerEditor.WriteTeamHorsepower(i, startValue);
                    startValue++;
                }

                for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
                {
                    var value = horsepowerEditor.ReadTeamHorsepower(i);

                    value.Should().Be(700 + i);
                }

                ExampleDataHelper.DeleteFile(exampleDataFile);
            }
        }
    }
}
