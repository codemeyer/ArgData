using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetEditorFacts
    {
        [Fact]
        public void ReadingFirstHelmet_ReturnsSennaColors()
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

        // TODO: tests for special cases #13, #15, etc
    }
}
