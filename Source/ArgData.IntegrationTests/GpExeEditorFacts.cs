using System;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class GpExeEditorFacts
    {
        [Fact]
        public void NotGpExeThrows()
        {
            string dataPath = ExampleDataHelper.GetExampleDataPath("fake.gpexe");

            Action act = () => new GpExeEditor(dataPath);

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void IsGpExeShouldJustWork()
        {
            string dataPath = ExampleDataHelper.GpExePath();

            var exeEditor = new GpExeEditor(dataPath);

            exeEditor.Should().BeOfType<GpExeEditor>();
        }
    }
}
