using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetEditorFacts
    {
        [Fact]
        public void ReadingOriginalHelmetColors_FirstHelmetReturnsSennaColors()
        {
            var expectedHelmetColors = new DefaultHelmetColors();
            string exampleDataPath = ExampleDataHelper.GpExePath();
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetColors = helmetEditor.ReadHelmetColors();

            var actualHelmet = helmetColors[0];
            actualHelmet.Visor.Should().Be(expectedHelmetColors[0].Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmetColors[0].VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmetColors[0].Stripes);
        }

        [Fact]
        public void ReadingOriginalHelmetColors_LastHelmetReturnsVanDePoeleColors()
        {
            var expectedHelmetColors = new DefaultHelmetColors();
            string exampleDataPath = ExampleDataHelper.GpExePath();
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetColors = helmetEditor.ReadHelmetColors();

            var actualHelmet = helmetColors[34];
            actualHelmet.Visor.Should().Be(expectedHelmetColors[34].Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmetColors[34].VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmetColors[34].Stripes);
        }

        [Fact]
        public void WritingFirstHelmet_ReturnsWrittenColors()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetList = new HelmetList();
            helmetList[0]  = new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            helmetEditor.WriteHelmetColors(helmetList);

            var helmetColors = new HelmetEditor(exeEditor).ReadHelmetColors();

            helmetColors[0].Visor.Should().Be(1);
            helmetColors[0].VisorSurround.Should().Be(7);   // zero-based index 6
            helmetColors[0].Stripes[0].Should().Be(3);

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void WritingLastHelmet_ReturnsWrittenColors()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetList = new HelmetList();
            helmetList[34] = new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            helmetEditor.WriteHelmetColors(helmetList);

            var helmetColors = new HelmetEditor(exeEditor).ReadHelmetColors();

            helmetColors[34].Visor.Should().Be(1);
            helmetColors[34].VisorSurround.Should().Be(7);   // zero-based index 6
            helmetColors[34].Stripes[0].Should().Be(3);

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void WritingHelmet15_ReturnsPartWrittenColorsPartFixedValues()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            var exeEditor = new GpExeFile(exampleDataPath);
            var helmetEditor = new HelmetEditor(exeEditor);

            var helmetList = new HelmetList();
            helmetList[14] = new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            helmetEditor.WriteHelmetColors(helmetList);

            var helmetColors = new HelmetEditor(exeEditor).ReadHelmetColors();

            helmetColors[14].Visor.Should().Be(1);
            helmetColors[14].VisorSurround.Should().Be(7);   // zero-based index 6
            helmetColors[14].Stripes[0].Should().Be(3);

            var specialBytes = ExampleDataHelper.ReadBytes(exampleDataPath, 159017, 14);
            specialBytes.Should().ContainInOrder(new byte[] {23, 0, 178, /**/ 11 /**/, 9, 0, 176});

            ExampleDataHelper.DeleteLatestTempFile();
        }

        // TODO: tests for more special cases
    }
}
