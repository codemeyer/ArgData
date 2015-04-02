using System;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class GpExeEditorFacts : IntegrationTestBase
    {
        [Fact]
        public void NotGpExeThrows()
        {
            string dataPath = GetExampleDataPath("fake.gpexe");

            Action act = () => new GpExeEditor(dataPath);

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void IsGpExeShouldJustWork()
        {
            string dataPath = GetExampleDataPath("GP-ORIG.EXE");

            var exeEditor = new GpExeEditor(dataPath);

            exeEditor.Should().BeOfType<GpExeEditor>();
        }
    }
}
