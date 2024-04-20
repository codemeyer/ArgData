using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests;

public class PreferencesFacts
{
    [Fact]
    public void Read_WithAutoloadNames_ReturnsPathToNameFile()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-1.dat", TestDataFileType.Prefs);
        var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

        string nameFile = preferencesReader.GetAutoLoadedNameFile();

        nameFile.Should().Be(@"gpsaves\F1-91.NAM");
    }

    [Fact]
    public void Read_WithoutAutoLoadedNames_ReturnsNull()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-2.dat", TestDataFileType.Prefs);
        var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

        string nameFile = preferencesReader.GetAutoLoadedNameFile();

        nameFile.Should().BeNull();
    }

    [Fact]
    public void Read_WithAutoloadSetupFile_ReturnsPathToFile()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-3.dat", TestDataFileType.Prefs);
        var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

        string nameFile = preferencesReader.GetAutoLoadedSetupFile();

        nameFile.Should().Be(@"gpsaves\ALLSETUPS");
    }

    [Fact]
    public void Read_WithoutAutoloadSetupFile_ReturnsPathToFile()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-1.dat", TestDataFileType.Prefs);
        var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

        string nameFile = preferencesReader.GetAutoLoadedSetupFile();

        nameFile.Should().BeNull();
    }

    [Fact]
    public void Read_NotPreferencesFile_ThrowsException()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE", TestDataFileType.Exe);

        Action action = () => PreferencesReader.For(PreferencesFile.At(exampleDataPath));

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void PreferencesReaderFor_Null_ThrowsArgumentNullException()
    {
        Action action = () => PreferencesReader.For(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void PreferencesReader_Null_ThrowsArgumentNullException()
    {
        Action action = () => _ =new PreferencesReader(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Write_SetAutoLoadedNames_ReturnsPath()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
        preferencesWriter.SetAutoLoadedNameFile("gpsvz\name.nam");

        var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
        string nameFile = preferencesReader.GetAutoLoadedNameFile();

        nameFile.Should().Be("gpsvz\name.nam");
    }

    [Fact]
    public void Write_SetAutoLoadedNamesWithTooLongPath_ThrowsException()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

        Action action = () => preferencesWriter.SetAutoLoadedNameFile("123456789012345678901234567890123");

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Write_SetAutoLoadedNamesWithNullPath_ThrowsException()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

        Action action = () => preferencesWriter.SetAutoLoadedNameFile(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Write_DisableAutoLoadedNames_SetsValueToNull()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
        preferencesWriter.DisableAutoLoadedNameFile();

        var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
        string nameFile = preferencesReader.GetAutoLoadedNameFile();

        nameFile.Should().BeNull();
    }

    [Fact]
    public void Write_SetAutoLoadedSetupWithTooLongPath_ThrowsException()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

        Action action = () => preferencesWriter.SetAutoLoadedSetupFile("123456789012345678901234567890123");

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Write_SetAutoLoadedSetupWithNullPath_ThrowsException()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

        Action action = () => preferencesWriter.SetAutoLoadedSetupFile(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Write_DisableAutoLoadedSetup_SetsValueToNull()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
        preferencesWriter.DisableAutoLoadedSetupFile();

        var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
        string nameFile = preferencesReader.GetAutoLoadedSetupFile();

        nameFile.Should().BeNull();
    }


    [Fact]
    public void Write_SetAutoLoadedSetupFile_ReturnsPath()
    {
        using var context = ExampleDataContext.PreferencesCopy();
        var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
        preferencesWriter.SetAutoLoadedSetupFile("gpsvz\\setup.set");

        var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
        string nameFile = preferencesReader.GetAutoLoadedSetupFile();

        nameFile.Should().Be("gpsvz\\setup.set");
    }

    [Fact]
    public void PreferencesWriterFor_Null_ThrowsArgumentNullException()
    {
        Action action = () => PreferencesWriter.For(null!);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void PreferencesWriter_Null_ThrowsArgumentNullException()
    {
        Action action = () => _ = new PreferencesWriter(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
