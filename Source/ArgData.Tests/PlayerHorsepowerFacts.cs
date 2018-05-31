using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PlayerHorsepowerFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadPlayerHorsepower_DefaultValue_ReturnsExpectedValue(GpExeVersionInfo exeVersionInfo)
        {
            var horsepowerReader = ExampleDataHelper.PlayerHorsepowerReaderForDefault(exeVersionInfo);

            var playerHorsepower = horsepowerReader.ReadPlayerHorsepower();

            playerHorsepower.Should().Be(716);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WritePlayerHorsepower_KnownValue_StoresExpectedValue(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var horsepowerWriter = PlayerHorsepowerWriter.For(context.ExeFile);

                horsepowerWriter.WritePlayerHorsepower(640);

                var horsepowerReader = PlayerHorsepowerReader.For(context.ExeFile);

                var readHorsepower = horsepowerReader.ReadPlayerHorsepower();
                readHorsepower.Should().Be(640);
            }
        }

        [Fact]
        public void PlayerHorsepowerReaderFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => PlayerHorsepowerReader.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void PlayerHorsepowerReader_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => new PlayerHorsepowerReader(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1460)]
        public void WritePlayerHorsepower_InsideRange_DoesNotThrowArgumentOutOfRangeException(int horsepower)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = PlayerHorsepowerWriter.For(context.ExeFile);

                Action action = () => horsepowerWriter.WritePlayerHorsepower(horsepower);

                action.Should().NotThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1461)]
        public void WritePlayerHorsepower_OutsideRange_ThrowsArgumentOutOfRangeException(int horsepower)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = PlayerHorsepowerWriter.For(context.ExeFile);

                Action action = () => horsepowerWriter.WritePlayerHorsepower(horsepower);

                action.Should().Throw<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void PlayerHorsepowerWriterFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => PlayerHorsepowerWriter.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void PlayerHorsepowerWriter_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => new PlayerHorsepowerWriter(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
