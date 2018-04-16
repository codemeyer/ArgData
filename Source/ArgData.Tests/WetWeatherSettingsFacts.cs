using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class WetWeatherSettingsFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadWetWeatherSettings_RainAtFirstTrack_ReturnsFalse(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.RainAtFirstTrack.Should().BeFalse();
        }


        [Fact]
        public void ReadWetWeatherSettings_RainAtFirstTrack_ReturnsTrue()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GPWETPHO.EXE", TestDataFileType.Exe);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.RainAtFirstTrack.Should().BeTrue();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadWetWeatherSettings_ChanceOfRainDefault_Returns6(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.ChanceOfRain.Should().Be(6);
        }

        [Fact]
        public void ReadWetWeatherSettings_ChanceOfRain10Pct_Returns10()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GPWET10.EXE", TestDataFileType.Exe);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.ChanceOfRain.Should().Be(10);
        }

        [Fact]
        public void WriteWetWeatherSettings_ExpectedRainChanceStored()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var settings = new WetWeatherSettings
                {
                    ChanceOfRain = 10
                };

                var writer = WetWeatherSettingsWriter.For(context.ExeFile);
                writer.WriteSettings(settings);

                var reader = WetWeatherSettingsReader.For(context.ExeFile);
                var storedSettings = reader.ReadSettings();

                storedSettings.ChanceOfRain.Should().Be(10);
            }
        }

        [Fact]
        public void WriteWetWeatherSettings_ExpectedRainAtFirstTrackStored()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var settings = new WetWeatherSettings
                {
                    RainAtFirstTrack = true
                };

                var writer = WetWeatherSettingsWriter.For(context.ExeFile);
                writer.WriteSettings(settings);

                var reader = WetWeatherSettingsReader.For(context.ExeFile);
                var storedSettings = reader.ReadSettings();

                storedSettings.RainAtFirstTrack.Should().BeTrue();
            }
        }

        [Fact]
        public void WriteWetWeatherSettings_RainChangeGreaterThan100_ThrowsArgumentOutOfRangeException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var settings = new WetWeatherSettings
                {
                    ChanceOfRain = 101
                };

                var writer = WetWeatherSettingsWriter.For(context.ExeFile);
                Action action = () => writer.WriteSettings(settings);

                action.Should().Throw<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void CreateReaderFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => WetWeatherSettingsReader.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateWriterFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => WetWeatherSettingsWriter.For(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WriteSettings_NullSettings_ThrowsArgumentNullException()
        {
            using (var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var writer = WetWeatherSettingsWriter.For(context.ExeFile);

                Action action = () => writer.WriteSettings(null);

                action.Should().Throw<ArgumentNullException>();
            }
        }
    }
}
