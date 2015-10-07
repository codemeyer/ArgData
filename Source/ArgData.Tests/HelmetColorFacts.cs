using System.Linq;
using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetColorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalHelmetColors_FirstHelmetReturnsSennaColors(GpExeVersionInfo exeVersionInfo)
        {
            var expectedHelmetColors = new DefaultHelmetColors();
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var helmetReader = new HelmetColorReader(exeFile);

            var helmetColors = helmetReader.ReadHelmetColors();

            var actualHelmet = helmetColors[0];
            actualHelmet.Visor.Should().Be(expectedHelmetColors[0].Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmetColors[0].VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmetColors[0].Stripes);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalHelmetColors_LastHelmetReturnsVanDePoeleColors(GpExeVersionInfo exeVersionInfo)
        {
            var expectedHelmetColors = new DefaultHelmetColors();
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var helmetReader = new HelmetColorReader(exeFile);

            var helmetColors = helmetReader.ReadHelmetColors();

            var actualHelmet = helmetColors[34];
            actualHelmet.Visor.Should().Be(expectedHelmetColors[34].Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmetColors[34].VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmetColors[34].Stripes);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingFirstHelmet_ReturnsWrittenColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetWriter = new HelmetColorWriter(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList[0] = new Helmet(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

                helmetWriter.WriteHelmetColors(helmetList);

                var helmet = GetHelmetAtIndex(0, context.ExeFile);

                helmet.Visor.Should().Be(1);
                helmet.VisorSurround.Should().Be(7); // zero-based index 6
                helmet.Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingLastHelmet_ReturnsWrittenColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetWriter = new HelmetColorWriter(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList[34] = new Helmet(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

                helmetWriter.WriteHelmetColors(helmetList);

                var helmet = GetHelmetAtIndex(34, context.ExeFile);

                helmet.Visor.Should().Be(1);
                helmet.VisorSurround.Should().Be(7); // zero-based index 6
                helmet.Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingSpecialCaseHelmets15And36To40_ReturnsPartWrittenColorsPartFixedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                TestSpecialCaseHelmet(14, 23, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(35, 71, 1, context, exeVersionInfo);
                TestSpecialCaseHelmet(36, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(37, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(38, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(39, 7, 0, context, exeVersionInfo);
            }
        }

        private void TestSpecialCaseHelmet(int index, byte alteringValue1, byte alteringValue2, ExampleDataContext context, GpExeVersionInfo exeVersionInfo)
        {
            var helmetWriter = new HelmetColorWriter(context.ExeFile);

            var helmetList = new HelmetList();
            helmetList[index] = new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            helmetWriter.WriteHelmetColors(helmetList);

            var helmet = GetHelmetAtIndex(index, context.ExeFile);

            helmet.Visor.Should().Be(1);
            helmet.VisorSurround.Should().Be(7); // zero-based index 6
            helmet.Stripes[0].Should().Be(3);

            var helmetPosition = GetHelmetColorsPosition(index, exeVersionInfo);
            var specialBytes = ExampleDataHelper.ReadBytes(context.FilePath, helmetPosition, index);
            specialBytes.Should().ContainInOrder(new byte[] { alteringValue1, alteringValue2, 178, /**/ 11 /**/, 9, 0, 176 });
        }

        private Helmet GetHelmetAtIndex(int index, GpExeFile exeFile)
        {
            var helmetColors = new HelmetColorReader(exeFile).ReadHelmetColors();
            return helmetColors[index];
        }

        // this code is quite similar to the one in HelmetColors.cs...

        private int GetHelmetColorsPosition(int helmetIndex, GpExeVersionInfo exeVersion)
        {
            int bytesForPreviousHelmets = _bytesPerHelmet.Take(helmetIndex).Sum(b => b);
            int basePosition = (exeVersion == GpExeVersionInfo.European105) ? 158795 : 158751;

            return basePosition + bytesForPreviousHelmets;
        }

        private readonly byte[] _bytesPerHelmet =
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 14, 16, 14, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 14, 14, 14, 14, 14
        };
    }
}
