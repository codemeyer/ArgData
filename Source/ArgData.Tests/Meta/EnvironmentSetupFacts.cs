using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Meta
{
    public class EnvironmentSetupFacts
    {
        [Fact]
        public void TestFilesMustExist()
        {
            string path = ExampleDataHelper.GetExampleDataBaseFolder();

            Directory.Exists(path).Should().BeTrue("the TestData folder must exist.");

            foreach (var dataFolder in Enum.GetNames(typeof(TestDataFileType)))
            {
                string folder = Path.Combine(path, dataFolder);

                Directory.Exists(folder).Should().BeTrue($"the TestData folder {dataFolder} must exist.");
                Directory.GetFiles(folder).Length.Should().BeGreaterOrEqualTo(1, "the folder should contain some files.");
            }
        }
    }
}
