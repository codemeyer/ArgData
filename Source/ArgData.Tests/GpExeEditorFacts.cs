using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GpExeEditorFacts
    {
        [Fact]
        public void NotGpExeThrows()
        {
            string exePath = ExampleDataHelper.GetExampleDataPath("not.gpexe");

            Action act = () => new GpExeEditor(exePath);

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void IsGpExeShouldJustWork()
        {
            string exePath = ExampleDataHelper.GpExePath();

            var exeEditor = new GpExeEditor(exePath);

            exeEditor.Should().BeOfType<GpExeEditor>();
        }

        [Fact]
        public void EuropeanGpExeReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath();

            var exeInfo = GpExeEditor.GetGpExeInfo(path);

            exeInfo.Should().Be(GpExeInfo.European105);
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = ExampleDataHelper.GetExampleDataPath("not.gpexe");

            var exeInfo = GpExeEditor.GetGpExeInfo(path);

            exeInfo.Should().Be(GpExeInfo.Unknown);
        }
    }
}
