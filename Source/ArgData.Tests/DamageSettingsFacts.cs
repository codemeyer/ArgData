using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests;

public class DamageSettingsFacts
{
    [Theory]
    [InlineData(GpExeVersionInfo.European105)]
    [InlineData(GpExeVersionInfo.European105Decompressed)]
    [InlineData(GpExeVersionInfo.Us105)]
    [InlineData(GpExeVersionInfo.Us105Decompressed)]
    public void ReadDamageSettings_Defaults_AreDefaults(GpExeVersionInfo exeVersionInfo)
    {
        string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
        var reader = DamageSettingsReader.For(GpExeFile.At(exampleDataPath));

        var settings = reader.Read();

        settings.RetireAfterHittingWall.Should().Be(7424);
        settings.RetireAfterHittingOtherCar.Should().Be(8192);
        settings.DamageAfterHittingWall.Should().Be(1792);
        settings.DamageAfterHittingOtherCar.Should().Be(1792);
        settings.RetiredCarsRemovedAfterSeconds.Should().Be(15, "retired cars should be removed after 15 seconds");
        settings.YellowFlagsForStationaryCarsAfterSeconds.Should().Be(20, "yellow flags should be shown after 20 s");
    }

    [Fact]
    public void DamageSettingsReaderFor_WithNullExe_ThrowsArgumentNullException()
    {
        Action action = () => DamageSettingsReader.For(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DamageSettingsReader_WithNullExe_ThrowsArgumentNullException()
    {
        Action action = () => _ = new DamageSettingsReader(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(GpExeVersionInfo.European105)]
    [InlineData(GpExeVersionInfo.Us105)]
    public void Writer_WritingSettings_StoresExpectedValues(GpExeVersionInfo exeVersionInfo)
    {
        var settingsToSave = new DamageSettings
        {
            DamageAfterHittingWall = 0,
            DamageAfterHittingOtherCar = 32766,
            RetireAfterHittingWall = 3333,
            RetireAfterHittingOtherCar = 444,
            YellowFlagsForStationaryCarsAfterSeconds = 1,
            RetiredCarsRemovedAfterSeconds = 60
        };

        using var context = ExampleDataContext.ExeCopy(exeVersionInfo);
        var writer = DamageSettingsWriter.For(context.ExeFile);
        writer.Write(settingsToSave);

        var reader = DamageSettingsReader.For(context.ExeFile);
        var storedSettings = reader.Read();

        storedSettings.DamageAfterHittingWall.Should().Be(0);
        storedSettings.DamageAfterHittingOtherCar.Should().Be(32766);
        storedSettings.RetireAfterHittingWall.Should().Be(3333);
        storedSettings.RetireAfterHittingOtherCar.Should().Be(444);
        storedSettings.YellowFlagsForStationaryCarsAfterSeconds.Should().Be(1);
        storedSettings.RetiredCarsRemovedAfterSeconds.Should().Be(60);
    }

    [Fact]
    public void DamageSettingsWriterFor_WithNullExe_ThrowsArgumentNullException()
    {
        Action action = () => DamageSettingsWriter.For(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DamageSettingsWriter_WithNullExe_ThrowsArgumentNullException()
    {
        Action action = () => _ = new DamageSettingsWriter(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void WriteDamageSettings_NullSettings_ThrowsArgumentNullException()
    {
        using var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105);
        var writer = DamageSettingsWriter.For(context.ExeFile);

        Action action = () => writer.Write(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void WriteDamageSettings_SettingsInvalid_ThrowsArgumentOutOfRangeException()
    {
        var settings = new DamageSettings
        {
            YellowFlagsForStationaryCarsAfterSeconds = 99
        };

        using var context = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105);
        var writer = DamageSettingsWriter.For(context.ExeFile);

        Action action = () => writer.Write(settings);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
