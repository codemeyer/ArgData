using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PlayerHorsepowerFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingPlayerHorsepowerValuesReturnsCorrectDefaultData(GpExeVersionInfo exeVersionInfo)
        {
            var horsepowerReader = ExampleDataHelper.PlayerHorsepowerReaderForDefault(exeVersionInfo);

            var playerHorsepower = horsepowerReader.ReadPlayerHorsepower();

            playerHorsepower.Should().Be(716);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingPlayerHorsepowerValuesStoresExpectedData(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var horsepowerWriter = new PlayerHorsepowerWriter(context.ExeFile);

                horsepowerWriter.WritePlayerHorsepower(640);

                var horsepowerReader = new PlayerHorsepowerReader(context.ExeFile);

                var readHorsepower = horsepowerReader.ReadPlayerHorsepower();
                readHorsepower.Should().Be(640);
            }
        }
    }
}
