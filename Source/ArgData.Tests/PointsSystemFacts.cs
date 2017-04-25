using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PointsSystemFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void Read_ReturnsDefaultPointsSystem(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var reader = PointsSystemReader.For(GpExeFile.At(exampleDataPath));

            var system = reader.Read();

            system.PointsFor1st.Should().Be(10);
            system.PointsFor2nd.Should().Be(6);
            system.PointsFor3rd.Should().Be(4);
            system.PointsFor4th.Should().Be(3);
            system.PointsFor5th.Should().Be(2);
            system.PointsFor6th.Should().Be(1);
            for (int i = 6; i < 26; i++)
            {
                system.Points[i].Should().Be(0);
            }
        }

        [Fact]
        public void PointsSystemReader_WithNullExe_ThrowsArgumentNullException()
        {
            Action action = () => PointsSystemReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void Writer_WritingPointsForAllInCompressedExe_OnlyStoresTopSix(GpExeVersionInfo exeVersionInfo)
        {
            var systemToSave = CreatePointsSystemWith26Scorers();

            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var writer = PointsSystemWriter.For(context.ExeFile);
                writer.Write(systemToSave);

                var reader = PointsSystemReader.For(context.ExeFile);
                var storedSystem = reader.Read();

                storedSystem.PointsFor1st.Should().Be(26);
                storedSystem.PointsFor2nd.Should().Be(25);
                storedSystem.PointsFor3rd.Should().Be(24);
                storedSystem.PointsFor4th.Should().Be(23);
                storedSystem.PointsFor5th.Should().Be(22);
                storedSystem.PointsFor6th.Should().Be(21);
                storedSystem.PointsFor7th.Should().Be(0);
                storedSystem.PointsFor8th.Should().Be(0);
                storedSystem.PointsFor9th.Should().Be(0);
                storedSystem.PointsFor10th.Should().Be(0);
                storedSystem.PointsFor11th.Should().Be(0);
                storedSystem.PointsFor12th.Should().Be(0);
                storedSystem.PointsFor13th.Should().Be(0);
                storedSystem.PointsFor14th.Should().Be(0);
                storedSystem.PointsFor15th.Should().Be(0);
                storedSystem.PointsFor16th.Should().Be(0);
                storedSystem.PointsFor17th.Should().Be(0);
                storedSystem.PointsFor18th.Should().Be(0);
                storedSystem.PointsFor19th.Should().Be(0);
                storedSystem.PointsFor20th.Should().Be(0);
                storedSystem.PointsFor21st.Should().Be(0);
                storedSystem.PointsFor22nd.Should().Be(0);
                storedSystem.PointsFor23rd.Should().Be(0);
                storedSystem.PointsFor24th.Should().Be(0);
                storedSystem.PointsFor25th.Should().Be(0);
                storedSystem.PointsFor26th.Should().Be(0);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void Writer_WritingPointsForAllInDecompressedExe_StoresPointsForAll(GpExeVersionInfo exeVersionInfo)
        {
            var systemToSave = CreatePointsSystemWith26Scorers();

            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var writer = PointsSystemWriter.For(context.ExeFile);
                writer.Write(systemToSave);

                var reader = PointsSystemReader.For(context.ExeFile);
                var storedSystem = reader.Read();

                storedSystem.PointsFor1st.Should().Be(26);
                storedSystem.PointsFor2nd.Should().Be(25);
                storedSystem.PointsFor3rd.Should().Be(24);
                storedSystem.PointsFor4th.Should().Be(23);
                storedSystem.PointsFor5th.Should().Be(22);
                storedSystem.PointsFor6th.Should().Be(21);
                storedSystem.PointsFor7th.Should().Be(20);
                storedSystem.PointsFor8th.Should().Be(19);
                storedSystem.PointsFor9th.Should().Be(18);
                storedSystem.PointsFor10th.Should().Be(17);
                storedSystem.PointsFor11th.Should().Be(16);
                storedSystem.PointsFor12th.Should().Be(15);
                storedSystem.PointsFor13th.Should().Be(14);
                storedSystem.PointsFor14th.Should().Be(13);
                storedSystem.PointsFor15th.Should().Be(12);
                storedSystem.PointsFor16th.Should().Be(11);
                storedSystem.PointsFor17th.Should().Be(10);
                storedSystem.PointsFor18th.Should().Be(9);
                storedSystem.PointsFor19th.Should().Be(8);
                storedSystem.PointsFor20th.Should().Be(7);
                storedSystem.PointsFor21st.Should().Be(6);
                storedSystem.PointsFor22nd.Should().Be(5);
                storedSystem.PointsFor23rd.Should().Be(4);
                storedSystem.PointsFor24th.Should().Be(3);
                storedSystem.PointsFor25th.Should().Be(2);
                storedSystem.PointsFor26th.Should().Be(1);
            }
        }

        private static PointsSystem CreatePointsSystemWith26Scorers()
        {
            return new PointsSystem
            {
                PointsFor1st = 26,
                PointsFor2nd = 25,
                PointsFor3rd = 24,
                PointsFor4th = 23,
                PointsFor5th = 22,
                PointsFor6th = 21,
                PointsFor7th = 20,
                PointsFor8th = 19,
                PointsFor9th = 18,
                PointsFor10th = 17,
                PointsFor11th = 16,
                PointsFor12th = 15,
                PointsFor13th = 14,
                PointsFor14th = 13,
                PointsFor15th = 12,
                PointsFor16th = 11,
                PointsFor17th = 10,
                PointsFor18th = 9,
                PointsFor19th = 8,
                PointsFor20th = 7,
                PointsFor21st = 6,
                PointsFor22nd = 5,
                PointsFor23rd = 4,
                PointsFor24th = 3,
                PointsFor25th = 2,
                PointsFor26th = 1
            };
        }

        [Fact]
        public void PointsSystemWriter_WithNullExe_ThrowsArgumentNullException()
        {
            Action action = () => PointsSystemWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WritePointsSystem_NullList_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var writer = PointsSystemWriter.For(context.ExeFile);

                Action action = () => writer.Write(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }
    }
}
