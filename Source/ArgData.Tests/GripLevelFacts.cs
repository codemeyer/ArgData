using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class GripLevelFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingRaceGripLevelsReturnsCorrectLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelReader.ReadRaceGripLevel(i + 1);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingRaceGripLevelsReturnsCorrectLevelsAll(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            var gripLevels = gripLevelReader.ReadRaceGripLevels().ToArray();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReturnsCorrectLevelsForQualifyingGrip(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var fileGrip = gripLevelReader.ReadQualifyingGripLevel(i + 1);
                var expectedGrip = expectedValues[i];

                fileGrip.Should().Be(expectedGrip);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReturnsCorrectLevelsForQualifyingGripAll(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            var gripLevels = gripLevelReader.ReadQualifyingGripLevels().ToArray();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReturnsCorrectValueWhenReadingSingleGripLevel(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            var gripLevels = gripLevelReader.ReadRaceGripLevels();

            gripLevels.GetByDriverNumber(5).Should().Be(2);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingRaceGripLevelStoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = new GripLevelWriter(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    gripLevelWriter.WriteRaceGripLevel(i, i);
                }

                var gripLevelReader = new GripLevelReader(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    var grip = gripLevelReader.ReadRaceGripLevel(i);

                    grip.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingRaceGripLevelStoresCorrectValuesAll(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = new GripLevelWriter(context.ExeFile);

                var gripLevels = new GripLevelList();
                gripLevels.SetByDriverNumber(1, 1);
                gripLevels.SetByDriverNumber(2, 2);
                gripLevels.SetByDriverNumber(3, 3);
                gripLevelWriter.WriteRaceGripLevels(gripLevels);

                var gripLevelReader = new GripLevelReader(context.ExeFile);

                for (byte i = 0; i < 2; i++)
                {
                    var grip = gripLevelReader.ReadRaceGripLevel(i);

                    grip.Should().Be((byte)(i + 1));
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingQualifyingGripLevelStoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = new GripLevelWriter(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    gripLevelWriter.WriteQualifyingGripLevel(i, i);
                }

                var gripLevelReader = new GripLevelReader(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    var grip = gripLevelReader.ReadQualifyingGripLevel(i);

                    grip.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingQualifyingGripLevelStoresCorrectValuesAll(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = new GripLevelWriter(context.ExeFile);

                var gripLevels = new GripLevelList();
                gripLevels.SetByDriverNumber(1, 1);
                gripLevels.SetByDriverNumber(2, 2);
                gripLevels.SetByDriverNumber(3, 3);
                gripLevelWriter.WriteQualifyingGripLevels(gripLevels);

                var gripLevelReader = new GripLevelReader(context.ExeFile);

                for (byte i = 0; i < 2; i++)
                {
                    var grip = gripLevelReader.ReadQualifyingGripLevel(i);

                    grip.Should().Be((byte)(i + 1));
                }
            }
        }
    }
}
