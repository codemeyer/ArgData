using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GripLevelEditorFacts
    {
        [Fact]
        public void ReadingRaceGripLevelsReturnsCorrectLevels()
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault();

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelEditor.ReadRaceGripLevel(i);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Fact]
        public void ReadingRaceGripLevelsReturnsCorrectLevelsAll()
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault();

            byte[] gripLevels = gripLevelEditor.ReadRaceGripLevels();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Fact]
        public void ReturnsCorrectLevelsForQualifyingGrip()
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault();

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelEditor.ReadQualifyingGripLevel(i);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Fact]
        public void ReturnsCorrectLevelsForQualifyingGripAll()
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault();

            byte[] gripLevels = gripLevelEditor.ReadQualifyingGripLevels();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Fact]
        public void WritingRaceGripLevelStoresCorrectValues()
        {
            var gripLevelEditor = ExampleDataHelper.GetGripLevelEditorForCopy();

            for (byte i = 0; i < 5; i++)
            {
                gripLevelEditor.WriteRaceGripLevel(i, i);
            }

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadRaceGripLevel(i);

                grip.Should().Be(i);
            }

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void WritingRaceGripLevelStoresCorrectValuesAll()
        {
            var gripLevelEditor = ExampleDataHelper.GetGripLevelEditorForCopy();

            byte[] gripLevels = new byte[] {1, 2, 3, 4, 5};
            gripLevelEditor.WriteRaceGripLevels(gripLevels);

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadRaceGripLevel(i);

                grip.Should().Be((byte)(i+1));
            }

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void WritingQualifyingGripLevelStoresCorrectValues()
        {
            var gripLevelEditor = ExampleDataHelper.GetGripLevelEditorForCopy();

            for (byte i = 0; i < 5; i++)
            {
                gripLevelEditor.WriteQualifyingGripLevel(i, i);
            }

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadQualifyingGripLevel(i);

                grip.Should().Be(i);
            }

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void WritingQualifyingGripLevelStoresCorrectValuesAll()
        {
            var gripLevelEditor = ExampleDataHelper.GetGripLevelEditorForCopy();

            byte[] gripLevels = new byte[] { 1, 2, 3, 4, 5 };
            gripLevelEditor.WriteQualifyingGripLevels(gripLevels);

            for (byte i = 0; i < 5; i++)
            {
                var grip = gripLevelEditor.ReadQualifyingGripLevel(i);

                grip.Should().Be((byte)(i + 1));
            }

            ExampleDataHelper.DeleteLatestTempFile();
        }
    }
}
