using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class FileInspectorFacts
    {
        [Fact]
        public void EuropeanGpExeReturnsExpectedResult()
        {
            string path = ExampleDataHelper.GpExePath();
            var fileInspector = new FileInspector();

            var exeInfo = fileInspector.IsGpExe(path);

            exeInfo.Should().Be(GpExeInfo.European105);
        }

        [Fact]
        public void SomeOtherFileReturnsUnknown()
        {
            string path = ExampleDataHelper.GetExampleDataPath("fake.gpexe");
            var fileInspector = new FileInspector();

            var exeInfo = fileInspector.IsGpExe(path);

            exeInfo.Should().Be(GpExeInfo.Unknown);
        }
    }
}
