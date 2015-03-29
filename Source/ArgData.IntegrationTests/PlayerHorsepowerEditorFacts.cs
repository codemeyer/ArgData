using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace PlayerHorsepowerEditorFacts
    {
        public class ReadingPlayerHorsepowerValuesFromOriginalExeFile : IntegrationTestBase
        {
            [Fact]
            public void ReturnsCorrectDefaultData()
            {
                string exampleDataPath = GetExampleDataPath("gp-orig.exe");
                var exeEditor = new GpExeEditor(exampleDataPath);
                var horsepowerEditor = new PlayerHorsepowerEditor(exeEditor);

                var playerHP = horsepowerEditor.ReadPlayerHorsepower();

                playerHP.Should().Be(716);
            }
        }
    }
}
