# ArgData API Reference

This is a list of the classes that make up the ArgData API.
Click on the name of a class for more information.

## Readers and Writers

The Reader and Writer classes perform the basic editing of GP.EXE and other files.
Reader classes are used to fetch data from the F1GP files into their respective representations as .NET classes.
The Writer classes update GP.EXE and other files.

| Name  | Description  |
|-------|--------------|
| [CarColorReader](./carcolorreader)  | Reads the car colors of one or more teams.  |
| [CarColorWriter](./carcolorwriter)  | Writes the car colors of one or more teams.  |
| [DamageSettingsReader](./damagesettingsreader)  | Reads damage settings.  |
| [DamageSettingsWriter](./damagesettingswriter)  | Writes damage settings.  |
| [DriverNumberReader](./drivernumberreader)  | Reads the driver numbers.  |
| [DriverNumberWriter](./drivernumberwriter)  | Writes the driver numbers, or inactives a driver.  |
| [DriverPerformanceReader](./driverperformancereader)  | Reads the race and qualifying driver performance levels for computer drivers,<br />as well as the general grip level for computer cars.  |
| [DriverPerformanceWriter](./driverperformancewriter)  | Writes the race or qualifying performance levels for computer drivers,<br />as well as the general grip level for computer cars.  |
| [HelmetColorReader](./helmetcolorreader)  | Reads driver helmet colors.  |
| [HelmetColorWriter](./helmetcolorwriter)  | Writes driver helmet colors.  |
| [NameFileReader](./namefilereader)  | Reads a name file from disk.  |
| [NameFileWriter](./namefilewriter)  | Writes a name file to disk.  |
| [PitCrewColorReader](./pitcrewcolorreader)  | Reads pit crew colors of one or more teams.  |
| [PitCrewColorWriter](./pitcrewcolorwriter)  | Writes pit crew colors of one or more teams.  |
| [PlayerHorsepowerReader](./playerhorsepowerreader)  | Reads the horsepower value for the player.  |
| [PlayerHorsepowerWriter](./playerhorsepowerwriter)  | Writes the horsepower values for the player.  |
| [PointsSystemReader](./pointssystemreader)  | Reads the points system.  |
| [PointsSystemWriter](./pointssystemwriter)  | Writes the points system.  |
| [PreferencesReader](./preferencesreader)  | Reads preferences from the F1PREFS.DAT file.  |
| [PreferencesWriter](./preferenceswriter)  | Writes preferences to the F1PREFS.DAT file.  |
| [SavedGameFileReader](./savedgamefilereader)  | Reads saved game files.  |
| [SetupReader](./setupreader)  | Reads setup files from disk.  |
| [SetupWriter](./setupwriter)  | Writes single or multiple setup files to disk.  |
| [TeamHorsepowerReader](./teamhorsepowerreader)  | Edits horsepower values of teams.  |
| [TeamHorsepowerWriter](./teamhorsepowerwriter)  | Writes horsepower values of teams.  |
| [WetWeatherSettingsReader](./wetweathersettingsreader)  | Reads the wet weather settings.  |
| [WetWeatherSettingsWriter](./wetweathersettingswriter)  | Writes wet weather settings.  |


## Other Classes

| Name  | Description  |
|-------|--------------|
| [Car](./car)  | A Car represents a car with its various colors.  |
| [CarList](./carlist)  | Represents a list of Car objects.  |
| [CarSet](./carset)  | A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.  |
| [CarSetDriver](./carsetdriver)  | Represents a driver in a CarSet.  |
| [CarSetTeam](./carsetteam)  | Defines a team as it appears in a CarSet.  |
| [CarSetTeamList](./carsetteamlist)  | A list of CarSetTeam items.  |
| [ChecksumCalculator](./checksumcalculator)  | Class used for calculating an F1GP checksum.  |
| [Constants](./constants)  | Various constant values.  |
| [DamageSettings](./damagesettings)  | Represents the various damage settings in the game.  |
| [DefaultValues](./defaultvalues)  | Contains the default values for various data and settings in F1GP as constant values.  |
| [Driver](./driver)  | Represents a driver with a name.  |
| [DriverNumberList](./drivernumberlist)  | List of driver numbers for 40 drivers.  |
| [DriverPerformanceList](./driverperformancelist)  | List of driver numbers for 40 drivers.  |
| [GpChecksum](./gpchecksum)  | GP checksum.  |
| [GpExeFile](./gpexefile)  | Represents a GP.EXE file that will be read from or written to.  |
| [GpExeInfo](./gpexeinfo)  | Contains details such as version number for a GP.EXE file.  |
| [GpExeVersionInfo](./gpexeversioninfo)  | Info about the GP.EXE file version.  |
| [Helmet](./helmet)  | A Helmet represents a helmet with its various colors.  |
| [HelmetList](./helmetlist)  | Represents a list of Helmet objects.  |
| [ImportExportSettings](./importexportsettings)  | ImportExportSettings define what will be imported from or exported to the GP.EXE.  |
| [NameFile](./namefile)  | Represents a file containing the names of the teams, engines and drivers.  |
| [NameFileDriverList](./namefiledriverlist)  | Represents a list of 40 drivers to be saved to a name file.  |
| [NameFileTeamList](./namefileteamlist)  | Represents a list of 20 teams to be saved to a name file.  |
| [Palette](./palette)  | Color palette for F1GP.  |
| [PitCrew](./pitcrew)  | Represents the colors of the pit crew.  |
| [PitCrewList](./pitcrewlist)  | Represents a list of PitCrew objects.  |
| [PointsSystem](./pointssystem)  | Points system determines how many championship points are scored per finishing position.  |
| [PreferencesFile](./preferencesfile)  | Represents game preferences stored in F1PREFS.DAT.  |
| [SavedGame](./savedgame)  | A saved game containing a list of drivers and their results.  |
| [SavedGameDriver](./savedgamedriver)  | Represents a driver in a saved game.  |
| [SavedGameDriverList](./savedgamedriverlist)  | A list of SavedGameDrivers.  |
| [Setup](./setup)  | Single car setup.  |
| [SetupList](./setuplist)  | Represents a list of qualifying and race setups for all tracks.  |
| [SetupTyreCompound](./setuptyrecompound)  | Tyre compound in setup file. Can be A, B, C or D.  |
| [Team](./team)  | Represents a team with a name and engine manufacturer.  |
| [WetWeatherSettings](./wetweathersettings)  | Wet weather settings.  |


