using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GripLevelEditorFacts
    {
        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void ReadingRaceGripLevelsReturnsCorrectLevels(GpExeInfo exeInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault(exeInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelEditor.ReadRaceGripLevel(i);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void ReadingRaceGripLevelsReturnsCorrectLevelsAll(GpExeInfo exeInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault(exeInfo);

            byte[] gripLevels = gripLevelEditor.ReadRaceGripLevels();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void ReturnsCorrectLevelsForQualifyingGrip(GpExeInfo exeInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault(exeInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelEditor.ReadQualifyingGripLevel(i);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void ReturnsCorrectLevelsForQualifyingGripAll(GpExeInfo exeInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelEditor = ExampleDataHelper.GripLevelEditorForDefault(exeInfo);

            byte[] gripLevels = gripLevelEditor.ReadQualifyingGripLevels();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void WritingRaceGripLevelStoresCorrectValues(GpExeInfo exeInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeInfo))
            {
                var gripLevelEditor = new GripLevelEditor(context.ExeFile);

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
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void WritingRaceGripLevelStoresCorrectValuesAll(GpExeInfo exeInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeInfo))
            {
                var gripLevelEditor = new GripLevelEditor(context.ExeFile);

                byte[] gripLevels = new byte[] {1, 2, 3, 4, 5};
                gripLevelEditor.WriteRaceGripLevels(gripLevels);

                for (byte i = 0; i < 5; i++)
                {
                    var grip = gripLevelEditor.ReadRaceGripLevel(i);

                    grip.Should().Be((byte)(i + 1));
                }
            }
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void WritingQualifyingGripLevelStoresCorrectValues(GpExeInfo exeInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeInfo))
            {
                var gripLevelEditor = new GripLevelEditor(context.ExeFile);

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
        }

        [Theory]
        [InlineData(GpExeInfo.European105)]
        [InlineData(GpExeInfo.Us105)]
        public void WritingQualifyingGripLevelStoresCorrectValuesAll(GpExeInfo exeInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeInfo))
            {
                var gripLevelEditor = new GripLevelEditor(context.ExeFile);

                byte[] gripLevels = new byte[] {1, 2, 3, 4, 5};
                gripLevelEditor.WriteQualifyingGripLevels(gripLevels);

                for (byte i = 0; i < 5; i++)
                {
                    var grip = gripLevelEditor.ReadQualifyingGripLevel(i);

                    grip.Should().Be((byte)(i + 1));
                }
            }
        }
    }
}
