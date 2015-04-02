using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace PlayerHorsepowerEditorFacts
    {
        public class ReadingPlayerHorsepowerValuesFromOriginalExeFile
        {
            [Fact]
            public void ReturnsCorrectDefaultData()
            {
                string exampleDataPath = ExampleDataHelper.GpExePath();
                var exeEditor = new GpExeEditor(exampleDataPath);
                var horsepowerEditor = new PlayerHorsepowerEditor(exeEditor);

                var playerHP = horsepowerEditor.ReadPlayerHorsepower();

                playerHP.Should().Be(716);
            }
        }
    }
}
