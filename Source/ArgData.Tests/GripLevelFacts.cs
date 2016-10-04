using System;
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
        public void ReadRaceGripLevel_DefaultValuesPerDriver_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
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
        public void ReadRaceGripLevel_DefaultValuesArray_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
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
        public void ReadQualifyingGripLevel_DefaultValuesPerDriver_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
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
        public void ReadQualifyingGripLevel_DefaultValuesArray_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            var gripLevels = gripLevelReader.ReadQualifyingGripLevels().ToArray();

            gripLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Fact]
        public void ReadRaceGripLevels_DriverNumber_0_Returns_0()
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(GpExeVersionInfo.European105);

            var gripLevels = gripLevelReader.ReadRaceGripLevels();

            gripLevels.GetByDriverNumber(0).Should().Be(0);
        }

        [Fact]
        public void ReadQualifyingGripLevels_DriverNumber_0_Returns_0()
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(GpExeVersionInfo.European105);

            var gripLevels = gripLevelReader.ReadQualifyingGripLevels();

            gripLevels.GetByDriverNumber(0).Should().Be(0);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadRaceGroupLevels_GetSingleDriverGrip_ReturnsExpectedValue(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            var gripLevels = gripLevelReader.ReadRaceGripLevels();

            gripLevels.GetByDriverNumber(5).Should().Be(2);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadRaceGripLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            Action action = () => gripLevelReader.ReadRaceGripLevel(-1);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadRaceGripLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            Action action = () => gripLevelReader.ReadRaceGripLevel(41);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteRaceGripLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                Action action = () => gripLevelWriter.WriteRaceGripLevel(-1, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteRaceGripLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                Action action = () => gripLevelWriter.WriteRaceGripLevel(41, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteRaceGripLevel_KnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    gripLevelWriter.WriteRaceGripLevel(i, i);
                }

                var gripLevelReader = GripLevelReader.For(context.ExeFile);

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
        public void WriteRaceGripLevel_UpdateKnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                var gripLevels = new GripLevelList();
                gripLevels.SetByDriverNumber(1, 1);
                gripLevels.SetByDriverNumber(2, 2);
                gripLevels.SetByDriverNumber(3, 3);
                gripLevelWriter.WriteRaceGripLevels(gripLevels);

                var gripLevelReader = GripLevelReader.For(context.ExeFile);

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
        public void WriteQualifyingGripLevel_KnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    gripLevelWriter.WriteQualifyingGripLevel(i, i);
                }

                var gripLevelReader = GripLevelReader.For(context.ExeFile);

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
        public void WriteQualifyingGripLevel_UpdateKnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                var gripLevels = new GripLevelList();
                gripLevels.SetByDriverNumber(1, 1);
                gripLevels.SetByDriverNumber(2, 2);
                gripLevels.SetByDriverNumber(3, 3);
                gripLevelWriter.WriteQualifyingGripLevels(gripLevels);

                var gripLevelReader = GripLevelReader.For(context.ExeFile);

                for (byte i = 0; i < 2; i++)
                {
                    var grip = gripLevelReader.ReadQualifyingGripLevel(i);

                    grip.Should().Be((byte)(i + 1));
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadQualifyingGripLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            Action action = () => gripLevelReader.ReadQualifyingGripLevel(-1);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadQualifyingGripLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var gripLevelReader = ExampleDataHelper.GripLevelReaderForDefault(exeVersionInfo);

            Action action = () => gripLevelReader.ReadQualifyingGripLevel(41);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteQualifyingGripLevel_DriverIndexLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                Action action = () => gripLevelWriter.WriteQualifyingGripLevel(-1, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteQualifyingGripLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var gripLevelWriter = GripLevelWriter.For(context.ExeFile);

                Action action = () => gripLevelWriter.WriteQualifyingGripLevel(41, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void GripLevelReader_WithNull_ThrowsArgumentNullException()
        {
            Action act = () => GripLevelReader.For(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GripLevelWriterFor_WithNull_ThrowsArgumentNullException()
        {
            Action act = () => GripLevelWriter.For(null);

            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
