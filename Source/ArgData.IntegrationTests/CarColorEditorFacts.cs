using ArgData.IntegrationTests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class CarColorEditorFacts : IntegrationTestBase
    {
        [Fact]
        public void ReadingOriginalCarColorsReturnsExpectedValues()
        {
            var expectedCarColors = new DefaultCarColors();
            string exampleDataPath = GetExampleDataPath("gp-orig.exe");
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            var carColors = carColorEditor.ReadCarColors();

            for(int i = 0; i < 1; i++)
            {
                carColors[i].ShouldBeEquivalentTo(expectedCarColors[i]);
            }
        }
    }
}
