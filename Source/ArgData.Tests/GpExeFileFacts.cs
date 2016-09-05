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
            string exePath = ExampleDataHelper.GetExampleDataPath("not.gpexe", TestDataFileType.Exe);

            Action act = () => GpExeFile.At(exePath);

            act.ShouldThrow<Exception>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void CorrectGpExeFilesCanBeCreated(GpExeVersionInfo exeVersion)
        {
            string exePath = ExampleDataHelper.GpExePath(exeVersion);

            var exeFile = GpExeFile.At(exePath);

            exeFile.Should().BeAssignableTo<GpExeFile>();
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
            string path = ExampleDataHelper.GetExampleDataPath("not.gpexe", TestDataFileType.Exe);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Should().Be(GpExeVersionInfo.Unknown);
        }
    }
}
