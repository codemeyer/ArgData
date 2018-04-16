using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class ChecksumCalculatorFacts
    {
        [Fact]
        public void Calculate_ForNameFile_ReturnsExpectedChecksum()
        {
            string path = ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names);
            byte[] allBytes = GetBytesToCalculateChecksumFor(path);

            var calc = new ChecksumCalculator();

            var values = calc.Calculate(allBytes);

            values.Checksum1.Should().Be(16387);
            values.Checksum2.Should().Be(32103);
        }

        [Fact]
        public void Calculate_ForTrackFile_ReturnExpectedChecksum()
        {
            string path = ExampleDataHelper.GetExampleDataPath("F1CT01.DAT", TestDataFileType.Tracks);
            byte[] allBytes = GetBytesToCalculateChecksumFor(path);
            var calc = new ChecksumCalculator();

            var values = calc.Calculate(allBytes);

            values.Checksum1.Should().Be(30567);
            values.Checksum2.Should().Be(7380);
        }

        private byte[] GetBytesToCalculateChecksumFor(string path)
        {
            byte[] allFileBytes = File.ReadAllBytes(path);
            byte[] allChecksumBytes = new byte[allFileBytes.Length - 4];

            Array.Copy(allFileBytes, allChecksumBytes, allFileBytes.Length - 4);

            return allChecksumBytes;
        }

        [Fact]
        public void UpdateChecksum_FileDoesNotExist_ThrowFileNotFoundException()
        {
            string path = ExampleDataHelper.GetExampleDataPath("filenotfound", TestDataFileType.Names);

            Action action = () => ChecksumCalculator.UpdateChecksum(path);

            action.Should().Throw<FileNotFoundException>();
        }
    }
}
