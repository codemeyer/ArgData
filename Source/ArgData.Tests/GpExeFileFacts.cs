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
            string exePath = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);

            var exeFile = new GpExeFile(exePath);

            exeFile.Should().BeOfType<GpExeFile>();
        }

        [Fact]
        public void EuropeanGpExeReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeVersionInfo.European105);
        }

        [Fact]
        public void WorldCircuitUsGpExeReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath(GpExeVersionInfo.Us105);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeVersionInfo.Us105);
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = ExampleDataHelper.GetExampleDataPath("not.gpexe");

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeVersionInfo.Unknown);
        }
    }
}
