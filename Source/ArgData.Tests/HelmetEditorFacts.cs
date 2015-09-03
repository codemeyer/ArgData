using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetEditorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalHelmetColors_FirstHelmetReturnsSennaColors(GpExeVersionInfo exeVersionInfo)
        {
            var expectedHelmetColors = new DefaultHelmetColors();
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetColors = helmetEditor.ReadHelmetColors();

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
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetColors = helmetEditor.ReadHelmetColors();

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
                var helmetEditor = new HelmetEditor(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList[0] = new Helmet(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

                helmetEditor.WriteHelmetColors(helmetList);

                var helmetColors = new HelmetEditor(context.ExeFile).ReadHelmetColors();

                helmetColors[0].Visor.Should().Be(1);
                helmetColors[0].VisorSurround.Should().Be(7); // zero-based index 6
                helmetColors[0].Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingLastHelmet_ReturnsWrittenColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetEditor = new HelmetEditor(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList[34] = new Helmet(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

                helmetEditor.WriteHelmetColors(helmetList);

                var helmetColors = new HelmetEditor(context.ExeFile).ReadHelmetColors();

                helmetColors[34].Visor.Should().Be(1);
                helmetColors[34].VisorSurround.Should().Be(7); // zero-based index 6
                helmetColors[34].Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingHelmet15_ReturnsPartWrittenColorsPartFixedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetEditor = new HelmetEditor(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList[14] = new Helmet(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16});

                helmetEditor.WriteHelmetColors(helmetList);

                var helmetColors = new HelmetEditor(context.ExeFile).ReadHelmetColors();

                helmetColors[14].Visor.Should().Be(1);
                helmetColors[14].VisorSurround.Should().Be(7); // zero-based index 6
                helmetColors[14].Stripes[0].Should().Be(3);

                var helmetPosition = (exeVersionInfo == GpExeVersionInfo.European105) ? 159017 : 158973;
                var specialBytes = ExampleDataHelper.ReadBytes(context.FilePath, helmetPosition, 14);
                specialBytes.Should().ContainInOrder(new byte[] {23, 0, 178, /**/ 11 /**/, 9, 0, 176});
            }
        }

        // TODO: tests for more special cases
    }
}
