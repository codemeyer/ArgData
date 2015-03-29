using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace TeamHorsepowerFacts
    {
        public class ReadingHorsepowerValuesFromOriginalExeFile : IntegrationTestBase
        {
            [Fact]
            public void ReturnsCorrectHorsepowerLevelsForEachTeam()
            {
                var expectedValues = new[] { 716, 676, 716, 650, 620, 625, 620, 665, 610, 680,
                    655, 665, 640, 700, 630, 610, 680, 615 };

                string exampleDataPath = GetExampleDataPath("gp-orig.exe");
                var exeEditor = new GpExeEditor(exampleDataPath);
                var horsepowerEditor = new TeamHorsepowerEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileHP = horsepowerEditor.ReadTeamHorsepower(i);
                    var expectedHP = expectedValues[i];

                    fileHP.Should().Be(expectedHP);
                }
            }
        }
    }
}
