using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TeamHorsepowerFacts
    {
        public class ReadingHorsepowerValuesFromOriginalExeFile
        {
            [Theory]
            [InlineData(GpExeVersionInfo.European105)]
            [InlineData(GpExeVersionInfo.Us105)]
            public void ReturnsCorrectHorsepowerLevelsForEachTeam(GpExeVersionInfo exeVersionInfo)
            {
                var expectedValues = new[] { 716, 676, 716, 650, 620, 625, 620, 665, 610, 680,
                    655, 665, 640, 700, 630, 610, 680, 615 };

                string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
                var exeEditor = new GpExeFile(exampleDataPath);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileHorsepower = horsepowerEditor.ReadTeamHorsepower(i);
                    var expectedHorsepower = expectedValues[i];

                    fileHorsepower.Should().Be(expectedHorsepower);
                }
            }
        }

        public class WritingHorsepowerValues
        {
            [Theory]
            [InlineData(GpExeVersionInfo.European105)]
            [InlineData(GpExeVersionInfo.Us105)]
            public void StoresAndReturnsTheCorrectValues(GpExeVersionInfo exeVersionInfo)
            {
                using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
                {
                    var horsepowerEditor = new TeamHorsepowerEditor(context.ExeFile);

                    int startValue = 700;

                    for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                    {
                        horsepowerEditor.WriteTeamHorsepower(i, startValue);
                        startValue++;
                    }

                    for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                    {
                        var value = horsepowerEditor.ReadTeamHorsepower(i);

                        value.Should().Be(700 + i);
                    }
                }
            }
        }
    }
}
