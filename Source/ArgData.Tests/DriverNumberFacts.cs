using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class DriverNumberFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalDriverNumbersReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            var driverNumberReader = ExampleDataHelper.DriverNumberReaderForDefault(exeVersionInfo);

            byte[] driverNumbers = driverNumberReader.ReadDriverNumbers();

            driverNumbers[0].Should().Be(1);
            driverNumbers[12].Should().Be(14, "Grouillard is number 14 in slot 13 (i.e. index 12)");
            driverNumbers[13].Should().Be(0);
            driverNumbers[30].Should().Be(31);
            driverNumbers[31].Should().Be(0, "Coloni only has one driver");
            driverNumbers[32].Should().Be(32);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingNumbersStoresExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                byte[] driverNumbers = CreateIncrementingDriverNumberArray(40);
                var driverNumberWriter = new DriverNumberWriter(context.ExeFile);

                driverNumberWriter.WriteDriverNumbers(driverNumbers);

                var driverNumberReader = new DriverNumberReader(context.ExeFile);
                byte[] readNumbers = driverNumberReader.ReadDriverNumbers();
                readNumbers[0].Should().Be(1);
                readNumbers[39].Should().Be(40);
            }
        }

        private byte[] CreateIncrementingDriverNumberArray(byte count)
        {
            byte[] driverNumbers = new byte[count];
            for (byte b = 0; b < count; b++)
            {
                driverNumbers[b] = Convert.ToByte(b + 1);
            }

            return driverNumbers;
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void FewerThan_39_DriversThenThrowException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                byte[] tooFewDriverNumbers = CreateIncrementingDriverNumberArray(39);
                var driverNumberWriter = new DriverNumberWriter(context.ExeFile);

                Action act = () => driverNumberWriter.WriteDriverNumbers(tooFewDriverNumbers);

                act.ShouldThrow<Exception>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void MoreThan_40_DriverNumbersThrowsException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                byte[] tooManyDriverNumbers = CreateIncrementingDriverNumberArray(41);
                var driverNumberWriter = new DriverNumberWriter(context.ExeFile);

                Action act = () => driverNumberWriter.WriteDriverNumbers(tooManyDriverNumbers);

                act.ShouldThrow<Exception>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void IfLessThan_26_ActiveDriversThenThrowException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                byte[] first20 = CreateIncrementingDriverNumberArray(20);
                byte[] full = new byte[40];
                first20.CopyTo(full, 0);
                var driverNumberWriter = new DriverNumberWriter(context.ExeFile);

                Action act = () => driverNumberWriter.WriteDriverNumbers(full);

                act.ShouldThrow<Exception>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void DriverNumberHigherThan40ThrowsException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                byte[] driverNumbers = CreateIncrementingDriverNumberArray(40);
                var driverNumberWriter = new DriverNumberWriter(context.ExeFile);

                driverNumbers[10] = 41;
                Action act = () => driverNumberWriter.WriteDriverNumbers(driverNumbers);

                act.ShouldThrow<Exception>();
            }
        }
    }
}
