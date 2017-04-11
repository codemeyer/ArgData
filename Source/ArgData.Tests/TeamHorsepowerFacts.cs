using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TeamHorsepowerFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadTeamHorsepower_OriginalValues_ReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
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
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteTeamHorsepower_KnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
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

        [Fact]
        public void CreateReaderFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => TeamHorsepowerReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CreateWriterFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => TeamHorsepowerWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(17)]
        public void ReadTeamHorsepower_InsideRange_DoesNotThrowArgumentOutOfRangeException(int teamIndex)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = TeamHorsepowerReader.For(context.ExeFile);

                Action action = () => horsepowerWriter.ReadTeamHorsepower(teamIndex);

                action.ShouldNotThrow<ArgumentOutOfRangeException>();
            }

        }

        [Theory]
        [InlineData(-1)]
        [InlineData(18)]
        public void ReadTeamHorsepower_OutsideRange_DoesNotThrowArgumentOutOfRangeException(int teamIndex)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = TeamHorsepowerReader.For(context.ExeFile);

                Action action = () => horsepowerWriter.ReadTeamHorsepower(teamIndex);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }

        }

        [Theory]
        [InlineData(0)]
        [InlineData(17)]
        public void WriteTeamHorsepower_InsideRange_DoesNotThrowArgumentOutOfRangeException(int teamIndex)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = TeamHorsepowerWriter.For(context.ExeFile);

                Action action = () => horsepowerWriter.WriteTeamHorsepower(teamIndex, 700);

                action.ShouldNotThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(18)]
        public void WriteTeamHorsepower_OutsideRange_ThrowsArgumentOutOfRangeException(int teamIndex)
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var horsepowerWriter = TeamHorsepowerWriter.For(context.ExeFile);

                Action action = () => horsepowerWriter.WriteTeamHorsepower(teamIndex, 700);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }
    }
}
