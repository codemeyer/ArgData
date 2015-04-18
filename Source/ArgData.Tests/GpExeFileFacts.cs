using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GpExeFileFacts
    {
        [Fact]
        public void NotGpExeThrows()
        {
            string exePath = ExampleDataHelper.GetExampleDataPath("not.gpexe");

            Action act = () => new GpExeFile(exePath);

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void IsGpExeShouldJustWork()
        {
            string exePath = ExampleDataHelper.GpExePath();

            var exeEditor = new GpExeFile(exePath);

            exeEditor.Should().BeOfType<GpExeFile>();
        }

        [Fact]
        public void EuropeanGpExeReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath();

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeInfo.European105);
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = ExampleDataHelper.GetExampleDataPath("not.gpexe");

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeInfo.Unknown);
        }
    }
}
