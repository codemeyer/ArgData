using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class DriverNumberFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadDriverNumbers_OriginalDrivers_HaveExpectedNumbers(GpExeVersionInfo exeVersionInfo)
        {
            var driverNumberReader = ExampleDataHelper.DriverNumberReaderForDefault(exeVersionInfo);

            var driverNumbers = driverNumberReader.ReadDriverNumbers();

            driverNumbers[0].Should().Be(1);
            driverNumbers[12].Should().Be(14, "Grouillard is number 14 in slot 13 (i.e. index 12)");
            driverNumbers[13].Should().Be(0);
            driverNumbers[30].Should().Be(31);
            driverNumbers[31].Should().Be(0, "Coloni only has one driver");
            driverNumbers[32].Should().Be(32);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteDriverNumbers_WithKnownValues_StoresExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                DriverNumberList driverNumbers = CreateIncrementingDriverNumberList(40);
                var driverNumberWriter = DriverNumberWriter.For(context.ExeFile);

                driverNumberWriter.WriteDriverNumbers(driverNumbers);

                var driverNumberReader = DriverNumberReader.For(context.ExeFile);
                DriverNumberList readNumbers = driverNumberReader.ReadDriverNumbers();
                readNumbers[0].Should().Be(1);
                readNumbers[39].Should().Be(40);
            }
        }

        private DriverNumberList CreateIncrementingDriverNumberList(byte count)
        {
            var driverNumbers = new DriverNumberList();

            for (byte b = 0; b < count; b++)
            {
                driverNumbers[b] = Convert.ToByte(b + 1);
            }

            return driverNumbers;
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteDriverNumbers_LessThan_26_ActiveDrivers_ThrowsException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var driverNumbers = new DriverNumberList();
                for (byte b = 0; b < 20; b++)
                {
                    driverNumbers[b] = 0;
                }
                var driverNumberWriter = DriverNumberWriter.For(context.ExeFile);

                Action action = () => driverNumberWriter.WriteDriverNumbers(driverNumbers);

                action.Should().Throw<ArgumentException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteDriverNumbers_AnyDriverNumberHigherThan40_ThrowsException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var driverNumbers = CreateIncrementingDriverNumberList(40);
                var driverNumberWriter = DriverNumberWriter.For(context.ExeFile);

                driverNumbers[10] = 41;
                Action action = () => driverNumberWriter.WriteDriverNumbers(driverNumbers);

                action.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void DriverNumberReaderFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => DriverNumberReader.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DriverNumberReader_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => new DriverNumberReader(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DriverNumberWriterFor_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => DriverNumberWriter.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void DriverNumberWriter_WithNull_ThrowsArgumentNullException()
        {
            Action action = () => new DriverNumberWriter(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WriteDriverNumbers_Null_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var driverNumberWriter = DriverNumberWriter.For(context.ExeFile);

                Action action = () => driverNumberWriter.WriteDriverNumbers(null);

                action.Should().Throw<ArgumentNullException>();
            }
        }
    }
}
