using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class DriverPerformanceFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadRacePerformanceLevel_DefaultValuesPerDriver_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var reader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var filePerformance = reader.ReadRacePerformanceLevel(i + 1);
                var expectedPerformance = expectedValues[i];

                filePerformance.Should().Be(expectedPerformance);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadRacePerformanceLevel_DefaultValuesArray_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 2, 3, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            var performanceLevels = performanceLevelReader.ReadRacePerformanceLevels().ToArray();

            performanceLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadQualifyingPerformanceLevel_DefaultValuesPerDriver_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33 };
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                var filePerformance = performanceLevelReader.ReadQualifyingPerformanceLevel(i + 1);
                var expectedPerformance = expectedValues[i];

                filePerformance.Should().Be(expectedPerformance);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadQualifyingPerformanceLevel_DefaultValuesArray_ReturnsExpectedLevels(GpExeVersionInfo exeVersionInfo)
        {
            var expectedValues = new byte[] { 1, 4, 16, 9, 3, 2, 19, 21, 26, 31, 25, 27, 0, 28,
                12, 14, 30, 32, 8, 7, 18, 15, 11, 17, 20, 24, 5, 6, 22, 23, 34, 13, 10, 29, 33, 0, 0, 0, 0, 0 };
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            var performanceLevels = performanceLevelReader.ReadQualifyingPerformanceLevels().ToArray();

            performanceLevels.ShouldBeEquivalentTo(expectedValues);
        }

        [Fact]
        public void ReadRacePerformanceLevels_DriverNumber_0_Returns_0()
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(GpExeVersionInfo.European105);

            var performanceLevels = performanceLevelReader.ReadRacePerformanceLevels();

            performanceLevels.GetByDriverNumber(0).Should().Be(0);
        }

        [Fact]
        public void ReadQualifyingPerformanceLevels_DriverNumber_0_Returns_0()
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(GpExeVersionInfo.European105);

            var performanceLevels = performanceLevelReader.ReadQualifyingPerformanceLevels();

            performanceLevels.GetByDriverNumber(0).Should().Be(0);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadRaceGroupLevels_GetSingleDriverPerformance_ReturnsExpectedValue(GpExeVersionInfo exeVersionInfo)
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            var performanceLevels = performanceLevelReader.ReadRacePerformanceLevels();

            performanceLevels.GetByDriverNumber(5).Should().Be(2);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadRacePerformanceLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            Action action = () => performanceLevelReader.ReadRacePerformanceLevel(-1);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadRacePerformanceLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            Action action = () => performanceLevelReader.ReadRacePerformanceLevel(41);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteRacePerformanceLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteRacePerformanceLevel(-1, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteRacePerformanceLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteRacePerformanceLevel(41, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void WriteRacePerformanceLevels_NullList_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteRacePerformanceLevels(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteRacePerformanceLevel_KnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    performanceLevelWriter.WriteRacePerformanceLevel(i, i);
                }

                var performanceLevelReader = DriverPerformanceReader.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    var performance = performanceLevelReader.ReadRacePerformanceLevel(i);

                    performance.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteRacePerformanceLevel_UpdateKnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                var performanceLevels = new DriverPerformanceList();
                performanceLevels.SetByDriverNumber(1, 1);
                performanceLevels.SetByDriverNumber(2, 2);
                performanceLevels.SetByDriverNumber(3, 3);
                performanceLevelWriter.WriteRacePerformanceLevels(performanceLevels);

                var performanceLevelReader = DriverPerformanceReader.For(context.ExeFile);

                for (byte i = 1; i < 3; i++)
                {
                    var performance = performanceLevelReader.ReadRacePerformanceLevel(i);

                    performance.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteQualifyingPerformanceLevel_KnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    performanceLevelWriter.WriteQualifyingPerformanceLevel(i, i);
                }

                var performanceLevelReader = DriverPerformanceReader.For(context.ExeFile);

                for (byte i = 0; i < 5; i++)
                {
                    var performance = performanceLevelReader.ReadQualifyingPerformanceLevel(i);

                    performance.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteQualifyingPerformanceLevel_UpdateKnownValues_StoresCorrectValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                var performanceLevels = new DriverPerformanceList();
                performanceLevels.SetByDriverNumber(1, 1);
                performanceLevels.SetByDriverNumber(2, 2);
                performanceLevels.SetByDriverNumber(3, 3);
                performanceLevelWriter.WriteQualifyingPerformanceLevels(performanceLevels);

                var performanceLevelReader = DriverPerformanceReader.For(context.ExeFile);

                for (byte i = 1; i < 3; i++)
                {
                    var performance = performanceLevelReader.ReadQualifyingPerformanceLevel(i);

                    performance.Should().Be(i);
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadQualifyingPerformanceLevel_DriverNumberLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            Action action = () => performanceLevelReader.ReadQualifyingPerformanceLevel(-1);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadQualifyingPerformanceLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            var performanceLevelReader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            Action action = () => performanceLevelReader.ReadQualifyingPerformanceLevel(41);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteQualifyingPerformanceLevel_DriverIndexLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteQualifyingPerformanceLevel(-1, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void WriteQualifyingPerformanceLevels_NullList_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteQualifyingPerformanceLevels(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteQualifyingPerformanceLevel_DriverNumberGreaterThan_40_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteQualifyingPerformanceLevel(41, 1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void PerformanceLevelReader_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => DriverPerformanceReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PerformanceLevelWriterFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => DriverPerformanceWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadGeneralGripLevel_DefaultValue_Returns1(GpExeVersionInfo exeVersionInfo)
        {
            var reader = ExampleDataHelper.DriverPerformanceLevelReaderForDefault(exeVersionInfo);

            int generalGrip = reader.ReadGeneralGripLevel();

            generalGrip.Should().Be(1);
        }

        [Fact]
        public void ReadGeneralGripLevel_FileWithValue50_Returns50()
        {
            var path = ExampleDataHelper.GetExampleDataPath("GP-EU-AI-50.EXE", TestDataFileType.Exe);
            var reader = DriverPerformanceReader.For(GpExeFile.At(path));

            int generalGrip = reader.ReadGeneralGripLevel();

            generalGrip.Should().Be(50);
        }

        [Fact]
        public void WriteGeneralGripLevel_StoreDefaultValue1_ValueIsStored()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var writer = DriverPerformanceWriter.For(context.ExeFile);

                writer.WriteGeneralGripLevel(1);

                var reader = DriverPerformanceReader.For(context.ExeFile);
                var value = reader.ReadGeneralGripLevel();

                value.Should().Be(1);
                // TODO: check signature?
            }
        }

        [Fact]
        public void WriteGeneralGripLevel_StoreNonDefaultValue25_ValueIsStored()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var writer = DriverPerformanceWriter.For(context.ExeFile);

                writer.WriteGeneralGripLevel(25);

                var reader = DriverPerformanceReader.For(context.ExeFile);
                var value = reader.ReadGeneralGripLevel();

                value.Should().Be(25);
                // TODO: check signature?
            }
        }

        [Fact]
        public void WriteGeneralGripLevel_ValueLessThan1_ThrowsException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteGeneralGripLevel(0);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void WriteGeneralGripLevel_ValueGreaterThan100_ThrowsException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var performanceLevelWriter = DriverPerformanceWriter.For(context.ExeFile);

                Action action = () => performanceLevelWriter.WriteGeneralGripLevel(101);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }
    }
}
