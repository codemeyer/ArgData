using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class ChecksumCalculatorFacts
    {
        [Fact]
        public void ReturnExpectedChecksumsForNamesFile()
        {
            string path = ExampleDataHelper.GetExampleDataPath("names1991.nam");
            byte[] allBytes = GetBytesToCalculateChecksumFor(path);

            var calc = new ChecksumCalculator();

            var values = calc.Calculate(allBytes);

            values.Checksum1.Should().Be(16387);
            values.Checksum2.Should().Be(32103);

            ExampleDataHelper.DeleteLatestTempFile();
        }

        [Fact]
        public void ReturnExpectedChecksumsForTrackFile()
        {
            string path = ExampleDataHelper.GetExampleDataPath("F1CT01.DAT");
            byte[] allBytes = GetBytesToCalculateChecksumFor(path);
            var calc = new ChecksumCalculator();

            var values = calc.Calculate(allBytes);

            values.Checksum1.Should().Be(30567);
            values.Checksum2.Should().Be(7380);

            ExampleDataHelper.DeleteLatestTempFile();
        }

        private byte[] GetBytesToCalculateChecksumFor(string path)
        {
            byte[] allFileBytes = File.ReadAllBytes(path);
            byte[] allChecksumBytes = new byte[allFileBytes.Length - 4];

            Array.Copy(allFileBytes, allChecksumBytes, allFileBytes.Length - 4);

            return allChecksumBytes;
        }
    }
}
