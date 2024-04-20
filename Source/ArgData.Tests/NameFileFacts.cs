using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests;

public class NameFileFacts
{
    [Fact]
    public void Read_ReturnedDataShouldNotBeNull()
    {
        var nameFile = GetExampleNameFile();

        nameFile.Should().NotBeNull();
    }

    [Fact]
    public void Read_ShouldReturnListOf_40_Drivers()
    {
        var nameFile = GetExampleNameFile();

        nameFile.Drivers.Count.Should().Be(40);
    }

    [Fact]
    public void Read_FirstDriverShouldBeAyrtonSenna()
    {
        var nameFile = GetExampleNameFile();

        Driver firstDriver = nameFile.Drivers.First();

        firstDriver.Name.Should().Be("Ayrton Senna");
    }

    [Fact]
    public void Read_ShouldReturnListOf_20_Teams()
    {
        var nameFile = GetExampleNameFile();

        nameFile.Teams.Count.Should().Be(20);
    }

    [Fact]
    public void Read_FirstTeamShouldBeMcLarenHonda()
    {
        var nameFile = GetExampleNameFile();

        Team firstTeam = nameFile.Teams.First();

        firstTeam.Name.Should().Be("McLaren");
        firstTeam.Engine.Should().Be("Honda");
    }

    private NameFile GetExampleNameFile()
    {
        string exampleDataPath = ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names);

        return new NameFileReader().Read(exampleDataPath);
    }

    [Fact]
    public void Read_NonExistingFile_ThrowsFileNotFoundException()
    {
        string nonExistingFile = ExampleDataHelper.GetExampleDataPath("names-not-exist.nam", TestDataFileType.Names);

        Action action = () => new NameFileReader().Read(nonExistingFile);

        action.Should().Throw<FileNotFoundException>();
    }

    [Fact]
    public void Read_NonNameFile_ThrowsException()
    {
        var notNameFilePath = ExampleDataHelper.GpExePath(GpExeVersionInfo.European105);

        Action action = () => new NameFileReader().Read(notNameFilePath);

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void Write_FileShouldBeCorrectSize()
    {
        var teams = new NameFileTeamList();
        var drivers = new NameFileDriverList();

        using var context = ExampleDataContext.GetTempFileName("names.nam");
        new NameFileWriter().Write(context.FilePath, drivers, teams);

        var fileInfo = new FileInfo(context.FilePath);

        fileInfo.Length.Should().Be(1484);
    }

    [Fact]
    public void Write_CorrectValuesStored()
    {
        var teams = new NameFileTeamList();
        var drivers = new NameFileDriverList();

        using var context = ExampleDataContext.GetTempFileName("names.nam");
        new NameFileWriter().Write(context.FilePath, drivers, teams);
        var namesFile = new NameFileReader().Read(context.FilePath);

        namesFile.Drivers.Count.Should().Be(40);
        namesFile.Teams.Count.Should().Be(20);
        namesFile.Drivers[0].Name.Should().Be("Driver 1");
        namesFile.Teams[0].Name.Should().Be("Team 1");
    }

    [Fact]
    public void Write_TooLongDriverNames_AreTruncated()
    {
        var teams = new NameFileTeamList();
        var drivers = new NameFileDriverList();

        drivers[0].Name = "12345678901234567890123oh";

        using var context = ExampleDataContext.GetTempFileName("names.nam");
        new NameFileWriter().Write(context.FilePath, drivers, teams);
        var namesFile = new NameFileReader().Read(context.FilePath);
        namesFile.Drivers[0].Name.Should().Be("12345678901234567890123");
        namesFile.Drivers[1].Name.Should().Be("Driver 2");
    }

    [Fact]
    public void Write_TooLongTeamNamesAndEngines_AreTruncated()
    {
        var teams = new NameFileTeamList();
        var drivers = new NameFileDriverList();

        teams[0].Name = "123456789012oh";
        teams[0].Engine = "123456789012oh";

        using var context = ExampleDataContext.GetTempFileName("names.nam");
        new NameFileWriter().Write(context.FilePath, drivers, teams);
        var namesFile = new NameFileReader().Read(context.FilePath);
        namesFile.Teams[0].Name.Should().Be("123456789012");
        namesFile.Teams[1].Name.Should().Be("Team 2");
        namesFile.Teams[0].Engine.Should().Be("123456789012");
        namesFile.Teams[1].Engine.Should().Be("Engine 2");
    }
}
