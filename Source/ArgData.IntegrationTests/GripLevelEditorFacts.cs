using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace GripLevelEditorFacts
    {
        public class ReadingGripLevels : IntegrationTestBase
        {
            [Fact]
            public void ReturnsCorrectLevelsForRaceGrip()
            {
                var expectedValues = new[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                    12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };

                string exampleDataPath = GetExampleDataPath("gp-orig.exe");
                var exeEditor = new GpExeEditor(exampleDataPath);
                var gripLevelEditor = new GripLevelEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileGrip = gripLevelEditor.ReadRaceGripLevel(i);
                    var expectedGrip = expectedValues[i];

                    fileGrip.Should().Be(expectedGrip);
                }
            }

            [Fact]
            public void ReturnsCorrectLevelsForQualifyingGrip()
            {
                var expectedValues = new[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                    12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };

                string exampleDataPath = GetExampleDataPath("gp-orig.exe");
                var exeEditor = new GpExeEditor(exampleDataPath);
                var gripLevelEditor = new GripLevelEditor(exeEditor);

                for (int i = 0; i < expectedValues.Length; i++)
                {
                    var fileGrip = gripLevelEditor.ReadQualifyingGripLevel(i);
                    var expectedGrip = expectedValues[i];

                    fileGrip.Should().Be(expectedGrip);
                }
            }
        }
    }
}
