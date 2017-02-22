# ArgData API Reference

This is a list of the classes that make up the ArgData API.

Click on the name of a class for more information.

## Readers and Writers
The Reader and Writer classes perform the basic editing of GP.EXE and other files.
Reader classes are used to fetch data from the F1GP files into their respective
representations as C# classes. The Writer classes update GP.EXE and other files.

| Name            | Description        |
|-----------------|--------------------|
| [CarColorReader](/api/carcolorreader)   | Reads the car colors of one or more teams.    |
| [CarColorWriter](/api/carcolorwriter)   | Writes the car colors of one or more teams.    |
| [DriverNumberReader](/api/drivernumberreader)   | Reads the driver numbers.    |
| [DriverNumberWriter](/api/drivernumberwriter)   | Writes the driver numbers, or inactives a driver.    |
| [DriverPerformanceReader](/api/driverperformancereader)   | Reads the race and qualifying driver performance levels for computer drivers, as well as the general grip level for computer cars.    |
| [DriverPerformanceWriter](/api/driverperformancewriter)   | Writes the race or qualifying performance levels for computer drivers, as well as the general grip level for computer cars.    |
| [HelmetColorReader](/api/helmetcolorreader)   | Reads driver helmet colors.    |
| [HelmetColorWriter](/api/helmetcolorwriter)   | Writes driver helmet colors.    |
| [NameFileReader](/api/namefilereader)   | Reads a name file from disk.    |
| [NameFileWriter](/api/namefilewriter)   | Writes a name file to disk.    |
| [PitCrewColorReader](/api/pitcrewcolorreader)   | Reads pit crew colors of one or more teams.    |
| [PitCrewColorWriter](/api/pitcrewcolorwriter)   | Writes pit crew colors of one or more teams.    |
| [PlayerHorsepowerReader](/api/playerhorsepowerreader)   | Reads the horsepower value for the player.    |
| [PlayerHorsepowerWriter](/api/playerhorsepowerwriter)   | Writes the horsepower values for the player.    |
| [PreferencesReader](/api/preferencesreader)   | Reads preferences from the F1PREFS.DAT file.    |
| [PreferencesWriter](/api/preferenceswriter)   | Writes preferences to the F1PREFS.DAT file.    |
| [SavedGameFileReader](/api/savedgamefilereader)   | Reads saved game files.    |
| [SetupReader](/api/setupreader)   | Reads setup files from disk.    |
| [SetupWriter](/api/setupwriter)   | Writes single or multiple setup files to disk.    |
| [TeamHorsepowerReader](/api/teamhorsepowerreader)   | Edits horsepower values of teams.    |
| [TeamHorsepowerWriter](/api/teamhorsepowerwriter)   | Writes horsepower values of teams.    |
| [WetWeatherSettingsReader](/api/wetweathersettingsreader)   | Reads the wet weather settings.    |
| [WetWeatherSettingsWriter](/api/wetweathersettingswriter)   | Writes wet weather settings.    |


## Other Classes

| Name            | Description        |
|-----------------|--------------------|
| [Car](/api/car)   | A Car represents a car with its various colors.    |
| [CarList](/api/carlist)   | Represents a list of Car objects.    |
| [CarSet](/api/carset)   | A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.    |
| [CarSetDriver](/api/carsetdriver)   | Represents a driver in a CarSet.    |
| [CarSetTeam](/api/carsetteam)   | Defines a team as it appears in a CarSet.    |
| [CarSetTeamList](/api/carsetteamlist)   | A list of CarSetTeam items.    |
| [ChecksumCalculator](/api/checksumcalculator)   | Class used for calculating an F1GP checksum.    |
| [Constants](/api/constants)   | Various constant values.    |
| [Driver](/api/driver)   | Represents a driver with a name.    |
| [DriverNumberList](/api/drivernumberlist)   | List of driver numbers for 40 drivers.    |
| [DriverPerformanceList](/api/driverperformancelist)   | List of driver numbers for 40 drivers.    |
| [GpChecksum](/api/gpchecksum)   | GP checksum.    |
| [GpExeFile](/api/gpexefile)   | Represents a GP.EXE file that will be read from or written to.    |
| [GpExeInfo](/api/gpexeinfo)   | Contains details such as version number for a GP.EXE file.    |
| [GpExeVersionInfo](/api/gpexeversioninfo)   | Info about the GP.EXE file version.    |
| [Helmet](/api/helmet)   | A Helmet represents a helmet with its various colors.    |
| [HelmetList](/api/helmetlist)   | Represents a list of Helmet objects.    |
| [ImportExportSettings](/api/importexportsettings)   | ImportExportSettings define what will be imported from or exported to the GP.EXE.    |
| [NameFile](/api/namefile)   | Represents a file containing the names of the teams, engines and drivers.    |
| [NameFileDriverList](/api/namefiledriverlist)   | Represents a list of 40 drivers to be saved to a name file.    |
| [NameFileTeamList](/api/namefileteamlist)   | Represents a list of 20 teams to be saved to a name file.    |
| [Palette](/api/palette)   | Color palette for F1GP.    |
| [PitCrew](/api/pitcrew)   | Represents the colors of the pit crew.    |
| [PitCrewList](/api/pitcrewlist)   | Represents a list of PitCrew objects.    |
| [PreferencesFile](/api/preferencesfile)   | Represents game preferences stored in F1PREFS.DAT.    |
| [SavedGame](/api/savedgame)   | A saved game containing a list of drivers and their results.    |
| [SavedGameDriver](/api/savedgamedriver)   | Represents a driver in a saved game.    |
| [SavedGameDriverList](/api/savedgamedriverlist)   | A list of SavedGameDrivers.    |
| [Setup](/api/setup)   | Single car setup.    |
| [SetupList](/api/setuplist)   | Represents a list of qualifying and race setups for all tracks.    |
| [SetupTyreCompound](/api/setuptyrecompound)   | Tyre compound in setup file. Can be A, B, C or D.    |
| [Team](/api/team)   | Represents a team with a name and engine manufacturer.    |
| [WetWeatherSettings](/api/wetweathersettings)   | Wet weather settings.    |
