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

            Action action = () => GpExeFile.At(exePath);

            action.ShouldThrow<ArgumentException>();
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
        public void EuropeanGpExe105ReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Version.Should().Be(GpExeVersionInfo.European105);
            exeInfo.IsKnownExeVersion.Should().BeTrue();
            exeInfo.IsEditingSupported.Should().BeTrue();
        }

        [Fact]
        public void WorldCircuitUsGpExe105ReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath(GpExeVersionInfo.Us105);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Version.Should().Be(GpExeVersionInfo.Us105);
            exeInfo.IsKnownExeVersion.Should().BeTrue();
            exeInfo.IsEditingSupported.Should().BeTrue();
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = ExampleDataHelper.GetExampleDataPath("not.gpexe", TestDataFileType.Exe);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Version.Should().Be(GpExeVersionInfo.Unknown);
            exeInfo.IsKnownExeVersion.Should().BeFalse();
            exeInfo.IsEditingSupported.Should().BeFalse();
        }

        [Fact]
        public void DetectsOldEuropeanGpExe()
        {
            string path = ExampleDataHelper.GetExampleDataPath("GP-EU103.EXE", TestDataFileType.Exe);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Version.Should().Be(GpExeVersionInfo.European103);
            exeInfo.IsKnownExeVersion.Should().BeTrue();
            exeInfo.IsEditingSupported.Should().BeFalse();
        }

        [Fact]
        public void OldEuropeanGpExeCannotBeReferenced()
        {
            string path = ExampleDataHelper.GetExampleDataPath("GP-EU103.EXE", TestDataFileType.Exe);

            Action action = () => GpExeFile.At(path);

            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void DetectsOldWorldCircuitGpExe()
        {
            string path = ExampleDataHelper.GetExampleDataPath("GP-US103.EXE", TestDataFileType.Exe);

            var exeInfo = GpExeFile.GetFileInfo(path);

            exeInfo.Version.Should().Be(GpExeVersionInfo.Us103);
            exeInfo.IsKnownExeVersion.Should().BeTrue();
            exeInfo.IsEditingSupported.Should().BeFalse();
        }

        [Fact]
        public void OldWorldCircuitGpExeCannotBeReferenced()
        {
            string path = ExampleDataHelper.GetExampleDataPath("GP-US103.EXE", TestDataFileType.Exe);

            Action action = () => GpExeFile.At(path);

            action.ShouldThrow<ArgumentException>();
        }
    }
}
