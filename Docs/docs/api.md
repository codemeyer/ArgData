# API Documentation

This is a list of the classes that make up the ArgData API.


## Editor objects

These are the objects that are used to edit data for the game, and usually come in a pair of Reader/Writer objects.


### CarColorReader

A **CarColorReader** is used to read the colors for a single car or all 18 cars in the game.

To construct a **CarColorReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var carColorReader = CarColorReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read the colors of a single car, use

```csharp
var car = carColorReader.ReadCarColors(teamIndex);
```

where _teamIndex_ is the zero-based index of the team you want read the colors for.

To read all car colors as a list, use

```csharp
var carColors = carColorReader.ReadCarColors();
```

This will return a [CarList](#carlist) object containing a list of 18 [Car](#car) objects.

<br />



### CarColorWriter

A **CarColorWriter** is used to write the colors for a single car or all 18 cars in the game.

To construct a **CarColorWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var carColorWriter = CarColorWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write the colors of a single car, use

```csharp
carColorWriter.WriteCarColors(car, teamIndex);
```

where _car_ is a [Car](#car) object with the wanted colors, and _teamIndex_ is the zero-based index of the team you want write the colors for.

To write all car colors, use

```csharp
carColorWriter.WriteCarColors(list);
```

where _list_ is a [CarList](#carlist) object containing a list of 18 [Car](#car) objects.

<br />



### DriverNumberReader

A **DriverNumberReader** is used to read the list of driver numbers.

To construct a **DriverNumberReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var driverNumbersReader = DriverNumberReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read the list of driver numbers, use

```
var driverNumbers = driverNumbersReader.ReadDriverNumbers();
```

This will return a [DriverNumberList](#drivernumberlist).

<br />



### DriverNumberWriter

A **DriverNumberWriter** is used to write the list of driver numbers.

To construct a **DriverNumberWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var driverNumbersWriter = DriverNumberWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write the list of driver numbers, use

```
driverNumbersWriter.WriteDriverNumbers(list);
```

where _list_ is a [DriverNumberList](#drivernumberlist).

<br />



### GripLevelReader

A **GripLevelReader** is used to read the grip levels of the computer car drivers.

The grip level is a byte value between 1 and 255 that represents the grip level for the driver,
where a lower value means more grip. Think of it as a grip "penalty".

To construct a **GripLevelReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var gripLevelReader = GripLevelReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

There are two different grip levels for drivers, the qualifying levels and the race levels. Reading a whole list of all driver's
grip levels can be done with these methods:

```
var qualGripLevels = gripLevelReader.ReadQualifyingGripLevels();
var raceGripLevels = gripLevelReader.ReadRaceGripLevels();
```

These will return [GripLevelList](#griplevellist) 


It is also possible to read individual drivers' grip levels using:

```
var qualGripLevel = gripLevelReader.ReadQualifyingGripLevel(driverIndex);
var raceGripLevel = gripLevelReader.ReadRaceGripLevel(driverIndex);
```

where _driverIndex_ is the zero-based index of the driver.

<br />



### GripLevelWriter

A **GripLevelWriter** is used to write the grip levels of the computer car drivers.

The grip level is a byte value between 1 and 255 that represents the grip level for the driver,
where a lower value means more grip. Think of it as a grip "penalty".

To construct a **GripLevelWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var gripLevelWriter = GripLevelWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

There are two different grip levels for drivers, the qualifying levels and the race levels. Writing a whole list of all driver's
grip levels can be done with these methods:

```
gripLevelWriter.WriteQualifyingGripLevels(gripLevels);
gripLevelWriter.WriteRaceGripLevels(gripLevels);
```

where _gripLevels_ is a [GripLevelList](#griplevellist). 


It is also possible to write individual drivers' grip levels using:

```
gripLevelWriter.WriteQualifyingGripLevel(driverIndex, gripLevel);
gripLevelWriter.WriteRaceGripLevel(driverIndex, gripLevel);
```

where _driverIndex_ is the zero-based index of the driver and _gripLevel_ is the byte value representing the grip level.

<br />



### HelmetColorReader

A **HelmetColorReader** is used to read the colors for all driver helmets in the game.

To construct a **HelmetColorReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var helmetColorReader = HelmetColorReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read all helmet colors as a list, use

```csharp
var helmetColors = helmetColorReader.ReadHelmetColors();
```

This will return a [HelmetList](#helmetlist) object containing a list of all [Helmet](#helmet) objects.

<br />



### HelmetColorWriter

A **HelmetColorWriter** is used to write the colors for all driver helmets in the game.

To construct a **HelmetColorWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var helmetColorWriter = HelmetColorWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write all helmet colors, use

```csharp
helmetColorWriter.WriteHelmetColors(list);
```

where _list_ is a [HelmetList](#helmetlist) object containing a list of 18 [Helmet](#helmet) objects.

<br />



### NameFileReader

A **NameFileReader** is used to read a name file from disk.

The **NameFileReader** is a static class with one method, **Read** that takes a path to a name file and returns a **NameFile** objects.

```csharp
var nameFile = NameFileReader.Read(@"C:\Games\GPRIX\gpsaves\names.nam";)
``` 

<br />



### NameFileWriter

A **NameFileWriter** is used to write a name file to disk.

The **NameFileWriter** is a static class with one method, **Write** that takes a **NameFile** and a path to write to.

<br />



### PitCrewColorReader

A **PitCrewColorReader** is used to read the colors for all team pit crews in the game.

To construct a **PitCrewColorReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var pitCrewColorReader = PitCrewColorReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read all pit crew colors as a list, use

```csharp
var pitCrewColors = pitCrewColorReader.ReadPitCrewColors();
```

This will return a [PitCrewList](#pitcrewlist) object containing a list of all [PitCrew](#pitcrew) objects.

<br />



### PitCrewColorWriter

A **PitCrewColorWriter** is used to write the colors for all team pit crews in the game.

To construct a **PitCrewColorWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var pitCrewColorWriter = PitCrewColorWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write all pit crew colors, use

```csharp
pitCrewColorWriter.WritePitCrewColors(list);
```

where _list_ is a [PitCrewList](#pitcrewlist) object containing a list of [PitCrew](#pitcrew) objects.

<br />



### PlayerHorsepowerReader

A **PlayerHorsepowerReader** is used to read the horsepower value for the player.

To construct a **PlayerHorsepowerReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var reader = PlayerHorsepowerReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read the player horsepower value, use

```csharp
val hp = reader.ReadPlayerHorsepower();
```

<br />



### PlayerHorsepowerWriter

A **PlayerHorsepowerWriter** is used to write the horsepower value for the player.

To construct a **PlayerHorsepowerWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var writer = PlayerHorsepowerWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write the player horsepower value, use

```csharp
writer.WritePlayerHorsepower(716);
```

Allowed values are from 1 (standing still) to 1460 (very fast). The default value is 716 (like a 1991 McLaren or Williams).

<br />



### PreferencesReader

A **PreferencesReader** is used to read the game preferences from the F1PREFS.DAT file.

To construct a **PreferencesReader**, use the static **For** method, supplying a reference to a [PreferencesFile](#preferencesfile) object:

```csharp
var reader = PreferencesReader.For(PreferencesFile.At(@"C:\Games\GPRIX\F1PREFS.DAT"));
```

To get the name file that is being automatically loaded, use

```csharp
var file = reader.GetAutoLoadedNameFile();
```

<br />



### PreferencesWriter

A **PreferencesWriter** is used to write game preferences to the F1PREFS.DAT file.

To construct a **PreferencesWriter**, use the static **For** method, supplying a reference to a [PreferencesFile](#preferencesfile) object:

```csharp
var writer = PreferencesWriter.For(PreferencesFile.At(@"C:\Games\GPRIX\F1PREFS.DAT"));
```

To set the name file that is being automatically loaded, use

```csharp
writer.SetAutoLoadedNameFile(@"gpsaves\name.nam");
```

Note that the value cannot be longer than 31 chars, and should be relative to the F1GP folder.

<br />


### SavedGameFileReader

A **SavedGameFileReader** is used to read a saved season game file.

The **SavedGameFileReader** is a static class with one method, **ReadSavedGame** which takes a path to a saved game and returns a [SavedGame](#savedgame) object.

```csharp
var savedGame = SavedGameFileReader.ReadSavedGame(@"C:\Games\GPRIX\gpsaves\season.sav");
```

<br />



### SetupReader

A **SetupReader** is used to read setup files, both single and multiple.

**SetupReader** is a static class with two methods.

**ReadSingle** takes a path to a single saved setup and returns a [Setup](#setup) object.

```csharp
var setup = SetupReader.ReadSingle(@"C:\Games\GPRIX\gpsaves\setups\silverst.set");
```

**ReadMultiple** takes a path to a multiple setup file and returns a [SetupList](#setuplist) containing setups for all tracks.

```csharp
var setups = SetupReader.ReadMultiple(@"C:\Games\GPRIX\gpsaves\setups\all.set");
```

<br />



### SetupWriter

A **SetupWriter** is used to write setup files, both single and multiple.

**SetupWriter** is a static class with two methods.

**WriteSingle** takes a path and a [Setup](#setup) object.

```csharp
var setup = new Setup();
setup.FrontWing = 40;
setup.RearWing = 34;

SetupWriter.WriteSingle(setup, @"C:\Games\GPRIX\gpsaves\setups\silverst.set");
```

**ReadMultiple** takes a path and a [SetupList](#setuplist) containing setups for all tracks.

```csharp
var setups = new SetupList();

SetupWriter.WriteMultiple(setupList, @"C:\Games\GPRIX\gpsaves\setups\all.set");
```

<br />


### TeamHorsepowerReader

A **TeamHorsepowerReader** is used to read the horsepower value for the computer cars.

To construct a **TeamHorsepowerReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var reader = TeamHorsepowerReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read the horsepower value for a specific team, use

```csharp
val hp = reader.ReadTeamHorsepower(index);
```

Where _index_ is the zero-based index of the team to read the value for.

<br />



### TeamHorsepowerWriter

A **TeamHorsepowerWriter** is used to write the horsepower value for the computer cars.

To construct a **TeamHorsepowerWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var writer = TeamHorsepowerWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write the horsepower value, use

```csharp
writer.WriteTeamHorsepower(index, hp);
```

Where _index_ is the zero-based index of the team to read the value for, and _hp_ is the horsepower value.

<br />


### WetWeatherSettingsReader

A **WetWeatherSettingsReader** is used to read the likelihood of rain, and whether it's possible to have a wet race at the first track.

To construct a **WetWeatherSettingsReader**, use the static **For** method, supplying a reference ot a [GpExe](#gpexe) object:

```csharp
var reader = WetWeatherSettingsReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To read the settings, use

```csharp
var settings = reader.ReadSettings();
```

This will return a **WetWeatherSettings** object, where you can read the **RainAtFirstTrack** boolean and the **ChanceOfRain**
which is a rough percentage value.

<br />



### WetWeatherSettingsWriter

A **WetWeatherSettingsWriter** is used to write  the likelihood of rain, and whether it's possible to have a wet race at the first track.

To construct a **WetWeatherSettingsWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var writer = WetWeatherSettingsWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

To write the wet weather settings, use

```csharp
writer.WriteSettings(settings);
```

Where _settings_ is a **WetWeatherSettings** object with the wanted ChanceOfRain and RainAtFirstTrack values.

<br /><br />


## Other Objects

Other misc objects.


### GpChecksum

Many F1GP files have checksums that the game uses to validate them.

### GpExeFile

Represents the GP.EXE file that is being read from or written to.

### Palette

Has methods for working with the F1GP palette.

<br /><br />


## Entities

Entities that are used when editing data.

### Car
### CarList
### Driver
### DriverNumberList
### GripLevelList
### Helmet
### HelmetList
### NameFile
### NameFileDriverList
### NameFileTeamList
### PitCrew
### PitCrewList
### PreferencesFile
### SavedGame
### SavedGameDriver
### Setup
### SetupList
### Team
### WetWeatherSettings
