using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TeamHorsepowerFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingHorsepowerValuesFromOriginalExeFile_ReturnsCorrectHorsepowerLevelsForEachTeam(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new[] { 716, 676, 716, 650, 620, 625, 620, 665, 610, 680,
                655, 665, 640, 700, 630, 610, 680, 615 };
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var horsepowerReader = TeamHorsepowerReader.For(GpExeFile.At(exampleDataPath));

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileHorsepower = horsepowerReader.ReadTeamHorsepower(i);
                var expectedHorsepower = expectedValues[i];

                fileHorsepower.Should().Be(expectedHorsepower);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingHorsepowerValues_StoresAndReturnsTheCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var horsepowerWriter = TeamHorsepowerWriter.For(context.ExeFile);

                int startValue = 700;

                for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                {
                    horsepowerWriter.WriteTeamHorsepower(i, startValue);
                    startValue++;
                }

                var horsepowerReader = TeamHorsepowerReader.For(context.ExeFile);

                for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                {
                    var value = horsepowerReader.ReadTeamHorsepower(i);

                    value.Should().Be(700 + i);
                }
            }
        }
    }
}
