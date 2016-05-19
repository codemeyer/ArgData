using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class WetWeatherSettingsFacts
    {
        [Fact]
        public void ReadWetWeatherSettings_NoRainAtFirstTrack_ReturnsFalse()
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.RainAtFirstTrack.Should().BeFalse();
        }

        [Fact]
        public void ReadWetWeatherSettings_RainAtFirstTrack_ReturnsTrue()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GPWETPHO.EXE");
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.RainAtFirstTrack.Should().BeTrue();
        }

        [Fact]
        public void ReadWetWeatherSettings_ChanceOfRainDefault_Returns6()
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);
            var reader = WetWeatherSettingsReader.For(GpExeFile.At(exampleDataPath));

            var settings = reader.ReadSettings();

            settings.ChanceOfRain.Should().Be(6);
        }

        [Fact]
        public void ReadWetWeatherSettings_ChanceOfRain10Pct_Returns10()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GPWET10.EXE");
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

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }
    }
}
