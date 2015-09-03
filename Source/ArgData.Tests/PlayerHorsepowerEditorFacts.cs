using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PlayerHorsepowerEditorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingPlayerHorsepowerValuesReturnsCorrectDefaultData(GpExeVersionInfo exeVersionInfo)
        {
            var horsepowerEditor = ExampleDataHelper.PlayerHorsepowerEditorForDefault(exeVersionInfo);

            var playerHorsepower = horsepowerEditor.ReadPlayerHorsepower();

            playerHorsepower.Should().Be(716);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingPlayerHorsepowerValuesStoresExpectedData(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var horsepowerEditor = new PlayerHorsepowerEditor(context.ExeFile);

                horsepowerEditor.WritePlayerHorsepower(640);

                var readHorsepower = horsepowerEditor.ReadPlayerHorsepower();
                readHorsepower.Should().Be(640);
            }
        }
    }
}
