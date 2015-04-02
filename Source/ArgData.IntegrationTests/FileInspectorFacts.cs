using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class FileInspectorFacts : IntegrationTestBase
    {
        [Fact]
        public void EuropeanGpExeReturnsExpectedResult()
        {
            string path = GetExampleDataPath("GP-ORIG.EXE");
            var fileInspector = new FileInspector();

            var exeInfo = fileInspector.IsGpExe(path);

            exeInfo.Should().Be(GpExeInfo.European105);
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = GetExampleDataPath("fake.gpexe");
            var fileInspector = new FileInspector();

            var exeInfo = fileInspector.IsGpExe(path);

            exeInfo.Should().Be(GpExeInfo.Unknown);
        }
    }
}
