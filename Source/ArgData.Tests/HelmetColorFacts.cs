﻿using System;
using System.Linq;
using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetColorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalHelmetColors_FirstHelmetReturnsSennaColors(GpExeVersionInfo exeVersionInfo)
        {
            var expectedHelmet = DefaultHelmetColors.GetByDriverNumber(1);
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var helmetReader = new HelmetColorReader(exeFile);

            var helmetColors = helmetReader.ReadHelmetColors();

            var actualHelmet = helmetColors.GetByDriverNumber(1);
            actualHelmet.Visor.Should().Be(expectedHelmet.Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmet.VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmet.Stripes);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalHelmetColors_LastHelmetReturnsVanDePoeleColors(GpExeVersionInfo exeVersionInfo)
        {
            var expectedHelmet = DefaultHelmetColors.GetByDriverNumber(35);
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var helmetReader = new HelmetColorReader(exeFile);

            var helmetColors = helmetReader.ReadHelmetColors();

            var actualHelmet = helmetColors.GetByDriverNumber(35);
            actualHelmet.Visor.Should().Be(expectedHelmet.Visor);
            actualHelmet.VisorSurround.Should().Be(expectedHelmet.VisorSurround);
            actualHelmet.Stripes.Should().BeEquivalentTo(expectedHelmet.Stripes);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingFirstHelmet_ReturnsWrittenColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetWriter = new HelmetColorWriter(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList.SetByDriverNumber(1, new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }));

                helmetWriter.WriteHelmetColors(helmetList);

                var helmet = ReadHelmetByNumber(1, context.ExeFile);
                helmet.Visor.Should().Be(1);
                helmet.VisorSurround.Should().Be(7); // zero-based index 6
                helmet.Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingLastHelmet_ReturnsWrittenColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var helmetWriter = new HelmetColorWriter(context.ExeFile);

                var helmetList = new HelmetList();
                helmetList.SetByDriverNumber(35, new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }));

                helmetWriter.WriteHelmetColors(helmetList);

                var helmet = ReadHelmetByNumber(35, context.ExeFile);
                helmet.Visor.Should().Be(1);
                helmet.VisorSurround.Should().Be(7); // zero-based index 6
                helmet.Stripes[0].Should().Be(3);
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WritingSpecialCaseHelmets15And36To40_ReturnsPartWrittenColorsPartFixedValues(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                TestSpecialCaseHelmet(15, 23, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(36, 71, 1, context, exeVersionInfo);
                TestSpecialCaseHelmet(37, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(38, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(39, 7, 0, context, exeVersionInfo);
                TestSpecialCaseHelmet(40, 7, 0, context, exeVersionInfo);
            }
        }

        private void TestSpecialCaseHelmet(byte driverNumber, byte alteringValue1, byte alteringValue2, ExampleDataContext context, GpExeVersionInfo exeVersionInfo)
        {
            var helmetWriter = new HelmetColorWriter(context.ExeFile);

            var helmetList = new HelmetList();
            helmetList.SetByDriverNumber(driverNumber, new Helmet(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }));

            helmetWriter.WriteHelmetColors(helmetList);

            var helmet = ReadHelmetByNumber(driverNumber, context.ExeFile);

            helmet.Visor.Should().Be(1);
            helmet.VisorSurround.Should().Be(7); // zero-based index 6
            helmet.Stripes[0].Should().Be(3);

            var helmetPosition = GetHelmetColorsPosition(driverNumber - 1, exeVersionInfo);
            var specialBytes = ExampleDataHelper.ReadBytes(context.FilePath, helmetPosition, driverNumber - 1);
            specialBytes.Should().ContainInOrder(new byte[] { alteringValue1, alteringValue2, 178, /**/ 11 /**/, 9, 0, 176 });
        }

        private Helmet ReadHelmetByNumber(byte driverNumber, GpExeFile exeFile)
        {
            var helmetColors = new HelmetColorReader(exeFile).ReadHelmetColors();
            return helmetColors.GetByDriverNumber(driverNumber);
        }

        // this code is quite similar to the one in GpExeFile.cs...

        private int GetHelmetColorsPosition(int helmetIndex, GpExeVersionInfo exeVersion)
        {
            int bytesForPreviousHelmets = _bytesPerHelmet.Take(helmetIndex).Sum(b => b);
            int basePosition = exeVersion == GpExeVersionInfo.European105 ? 158795 : 158751;

            return basePosition + bytesForPreviousHelmets;
        }

        private readonly byte[] _bytesPerHelmet =
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 14, 16, 14, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 14, 14, 14, 14, 14
        };

        [Theory]
        [InlineData(0)]
        [InlineData(41)]
        public void ReadingOutsideRangeThrowsException(byte value)
        {
            var helmetList = new HelmetList();

            Action action = () => helmetList.GetByDriverNumber(value);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(41)]
        public void WritingOutsideRangeThrowsException(byte value)
        {
            var helmetList = new HelmetList();

            Action action = () => helmetList.SetByDriverNumber(value, new Helmet());

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}