using System;
using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PitCrewColorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadPitCrewColors_OriginalColors_ReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var pitCrewColorReader = PitCrewColorReader.For(GpExeFile.At(exampleDataPath));

            var pitCrewColors = pitCrewColorReader.ReadPitCrewColors();

            for (int i = 0; i < 14; i++)
            {
                pitCrewColors[i].ShouldBeEquivalentTo(DefaultPitCrewColors.GetByIndex(i));
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadPitCrewColors_SingleOriginalColor_ReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            var expectedPitCrew = DefaultPitCrewColors.GetByIndex(0);
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var pitCrewColorReader = PitCrewColorReader.For(GpExeFile.At(exampleDataPath));

            var pitCrew = pitCrewColorReader.ReadPitCrewColors(0);

            pitCrew.ShirtPrimary.Should().Be(expectedPitCrew.ShirtPrimary);
            pitCrew.ShirtSecondary.Should().Be(expectedPitCrew.ShirtSecondary);
            pitCrew.PantsPrimary.Should().Be(expectedPitCrew.PantsPrimary);
            pitCrew.PantsSecondary.Should().Be(expectedPitCrew.PantsSecondary);
            pitCrew.Socks.Should().Be(expectedPitCrew.Socks);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WritePitCrewColors_KnownValues_StoresExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            var pitCrewList = new PitCrewList();
            for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
            {
                byte b = Convert.ToByte(i + 1);
                pitCrewList[i] = new PitCrew(new[] {b, b, b, b, b, b, b, b, b, b, b, b, b, b, b, b});
            }

            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var pitCrewColorWriter = PitCrewColorWriter.For(context.ExeFile);

                pitCrewColorWriter.WritePitCrewColors(pitCrewList);

                var pitCrewColorReader = PitCrewColorReader.For(context.ExeFile).ReadPitCrewColors();

                byte expectedColor = 1;
                foreach (PitCrew pitCrew in pitCrewColorReader)
                {
                    pitCrew.ShirtPrimary.Should().Be(expectedColor);

                    expectedColor++;
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WritePitCrewColors_KnownSingleCrewValues_StoresExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var pitCrewList = new PitCrewList();
                var pitCrew = new PitCrew
                {
                    ShirtPrimary = 1,
                    ShirtSecondary = 2,
                    PantsPrimary = 3,
                    PantsSecondary = 4,
                    Socks = 5
                };
                pitCrewList[0] = pitCrew;

                var pitCrewColorWriter = PitCrewColorWriter.For(context.ExeFile);

                pitCrewColorWriter.WritePitCrewColors(pitCrewList[0], 0);

                var readPitCrewColors = PitCrewColorReader.For(context.ExeFile).ReadPitCrewColors();
                var actualPitCrew = readPitCrewColors[0];

                actualPitCrew.ShirtPrimary.Should().Be(1);
                actualPitCrew.ShirtSecondary.Should().Be(2);
                actualPitCrew.PantsPrimary.Should().Be(3);
                actualPitCrew.PantsSecondary.Should().Be(4);
                actualPitCrew.Socks.Should().Be(5);
            }
        }

        [Fact]
        public void PitCrewColorReader_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => PitCrewColorReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PitCrewColorWriterFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => PitCrewColorWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WritePitCrewColors_NullPitCrew_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var pitCrewColorWriter = PitCrewColorWriter.For(context.ExeFile);

                Action action = () => pitCrewColorWriter.WritePitCrewColors(null, 1);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Fact]
        public void WritePitCrewColors_NullList_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var pitCrewColorWriter = PitCrewColorWriter.For(context.ExeFile);

                Action action = () => pitCrewColorWriter.WritePitCrewColors(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }
    }
}
