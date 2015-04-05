using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PlayerHorsepowerEditorFacts
    {
        [Fact]
        public void ReadingPlayerHorsepowerValuesReturnsCorrectDefaultData()
        {
            var horsepowerEditor = ExampleDataHelper.PlayerHorsepowerEditorForDefault();

            var playerHorsepower = horsepowerEditor.ReadPlayerHorsepower();

            playerHorsepower.Should().Be(716);
        }

        [Fact]
        public void WritingPlayerHorsepowerValuesStoresExpectedData()
        {
            var horsepowerEditor = ExampleDataHelper.PlayerHorsepowerEditorForCopy();

            horsepowerEditor.WritePlayerHorsepower(640);

            var readHorsepower = horsepowerEditor.ReadPlayerHorsepower();
            readHorsepower.Should().Be(640);

            ExampleDataHelper.DeleteLatestTempFile();
        }
    }
}
