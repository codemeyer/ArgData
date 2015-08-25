using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PlayerHorsepowerEditorFacts
    {
        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void ReadingPlayerHorsepowerValuesReturnsCorrectDefaultData(GpExeInfo exeInfo)
        {
            var horsepowerEditor = ExampleDataHelper.PlayerHorsepowerEditorForDefault(exeInfo);

            var playerHorsepower = horsepowerEditor.ReadPlayerHorsepower();

            playerHorsepower.Should().Be(716);
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void WritingPlayerHorsepowerValuesStoresExpectedData(GpExeInfo exeInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeInfo))
            {
                var horsepowerEditor = new PlayerHorsepowerEditor(context.ExeFile);

                horsepowerEditor.WritePlayerHorsepower(640);

                var readHorsepower = horsepowerEditor.ReadPlayerHorsepower();
                readHorsepower.Should().Be(640);
            }
        }
    }
}
