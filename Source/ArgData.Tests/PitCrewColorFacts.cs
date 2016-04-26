﻿using System;
using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PitCrewColorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingOriginalPitCrewColorsReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var pitCrewColorReader = new PitCrewColorReader(exeFile);

            var pitCrewColors = pitCrewColorReader.ReadPitCrewColors();

            for (int i = 0; i < 14; i++)
            {
                pitCrewColors[i].ShouldBeEquivalentTo(DefaultPitCrewColors.GetByIndex(i));
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void ReadingSingleOriginalPitCrewColorReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            var expectedPitCrew = DefaultPitCrewColors.GetByIndex(0);
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var exeFile = new GpExeFile(exampleDataPath);
            var pitCrewColorReader = new PitCrewColorReader(exeFile);

            var pitCrew = pitCrewColorReader.ReadPitCrewColors(0);

            pitCrew.ShirtPrimary.Should().Be(expectedPitCrew.ShirtPrimary);
            pitCrew.ShirtSecondary.Should().Be(expectedPitCrew.ShirtSecondary);
            pitCrew.PantsPrimary.Should().Be(expectedPitCrew.PantsPrimary);
            pitCrew.PantsSecondary.Should().Be(expectedPitCrew.PantsSecondary);
            pitCrew.Socks.Should().Be(expectedPitCrew.Socks);
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteAndReadPitCrews(GpExeVersionInfo exeVersionInfo)
        {
            var pitCrewList = new PitCrewList();
            for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
            {
                byte b = Convert.ToByte(i + 1);
                pitCrewList[i] = new PitCrew(new[] { b, b, b, b, b, b, b, b, b, b, b, b, b, b, b, b });
            }

            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var pitCrewColorWriter = new PitCrewColorWriter(context.ExeFile);

                pitCrewColorWriter.WritePitCrewColors(pitCrewList);

                var pitCrewColorReader = new PitCrewColorReader(context.ExeFile).ReadPitCrewColors();

                byte expectedColor = 1;
                foreach (PitCrew pitCrew in pitCrewColorReader)
                {
                    pitCrew.ShirtPrimary.Should().Be(expectedColor);

                    expectedColor++;
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.Us105)]
        public void WriteAndReadPitCrew(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var pitCrewList = new PitCrewList();
                var exeFile = new GpExeFile(context.FilePath);
                var pitCrew = new PitCrew
                {
                    ShirtPrimary = 1,
                    ShirtSecondary = 2,
                    PantsPrimary = 3,
                    PantsSecondary = 4,
                    Socks = 5
                };
                pitCrewList[0] = pitCrew;

                var pitCrewColorWriter = new PitCrewColorWriter(exeFile);

                pitCrewColorWriter.WritePitCrewColors(pitCrewList[0], 0);

                var pitCrewColorReader = new PitCrewColorReader(exeFile).ReadPitCrewColors();
                var actualPitCrew = pitCrewColorReader[0];

                actualPitCrew.ShirtPrimary.Should().Be(1);
                actualPitCrew.ShirtSecondary.Should().Be(2);
                actualPitCrew.PantsPrimary.Should().Be(3);
                actualPitCrew.PantsSecondary.Should().Be(4);
                actualPitCrew.Socks.Should().Be(5);
            }
        }
    }
}