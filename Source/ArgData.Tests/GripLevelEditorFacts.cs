using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GripLevelEditorFacts
    {
        [Fact]
        public void ReadingRaceGripLevelsReturnsCorrectLevels()
        {
            var expectedValues = new[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };

            var gripLevelEditor = GetGripLevelEditor();

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

            var gripLevelEditor = GetGripLevelEditor();

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelEditor.ReadQualifyingGripLevel(i);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Fact]
        public void WritingRaceGripLevelStoresCorrectValues()
        {
            var gripLevelEditor = GetGripLevelEditorForCopy();

            for (byte i = 0; i < 5; i++)
            {
                gripLevelEditor.WriteRaceGripLevel(i, i);
            }

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadRaceGripLevel(i);

                grip.Should().Be(i);
            }
        }

        [Fact]
        public void WritingQualifyingGripLevelStoresCorrectValues()
        {
            var gripLevelEditor = GetGripLevelEditorForCopy();

            for (byte i = 0; i < 5; i++)
            {
                gripLevelEditor.WriteQualifyingGripLevel(i, i);
            }

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadQualifyingGripLevel(i);

                grip.Should().Be(i);
            }
        }

        private static GripLevelEditor GetGripLevelEditor()
        {
            string exampleDataPath = ExampleDataHelper.GpExePath();
            return CreateGripLevelEditor(exampleDataPath);
        }

        private static GripLevelEditor GetGripLevelEditorForCopy()
        {
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            return CreateGripLevelEditor(exampleDataPath);
        }

        private static GripLevelEditor CreateGripLevelEditor(string exampleDataPath)
        {
            var exeEditor = new GpExeEditor(exampleDataPath);
            var gripLevelEditor = new GripLevelEditor(exeEditor);
            return gripLevelEditor;
        }
    }
}
