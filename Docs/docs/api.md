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

A **DriverNumberReader** is used to read the list of driver numbers. The [DriverNumberList](#drivernumberlist) contains
a list of 40 "slots", where each slot represents the number of the driver in that slot. To disable a driver slot, set
the number to 0. See more details and restrictions in the [DriverNumberList](#drivernumberlist) section.

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

A **DriverNumberWriter** is used to write the list of driver numbers. The [DriverNumberList](#drivernumberlist) contains
a list of 40 "slots", where each slot represents the number of the driver in that slot. To disable a driver slot, set
the number to 0. See more details and restrictions in the [DriverNumberList](#drivernumberlist) section.

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



### DriverPerformanceReader

A **DriverPerformanceReader** is used to read the performance levels of the computer car drivers and the general AI grip.

The performance level is a byte value between 1 and 255 that represents the performance level for the driver,
where a lower value means better performance and faster lap times. Think of the value as a performance "penalty".

The general AI grip represents a level of grip that affects all computer cars.

To construct a **DriverPerformanceReader**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var performanceReader = DriverPerformanceReader.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

There are two different performance levels for drivers, the qualifying levels and the race levels. Reading a whole list of all driver's
performance levels can be done with these methods:

```
var qualLevels = performanceReader.ReadQualifyingPerformanceLevels();
var raceLevels = performanceReader.ReadRacePerformanceLevels();
```

These will return [DriverPerformanceList](#driverperformancelist) 


It is also possible to read individual drivers' performance levels using:

```
var qualLevel = performanceReader.ReadQualifyingPerformanceLevel(driverNumber);
var raceLevel = performanceReader.ReadRacePerformanceLevel(driverNumber);
```

where _driverNumber_ is the number of the driver.


To read the general AI grip level, use:

```
var gripLevel = performanceReader.ReadGeneralGripLevel();
```

<br />



### DriverPerformanceWriter

A **DriverPerformanceWriter** is used to write the performance levels of the computer car drivers.

The performance level is a byte value between 1 and 255 that represents the performance of the driver,
where a lower value means better performance and faster lap times. Think of the value as a performance "penalty".

To construct a **DriverPerformanceWriter**, use the static **For** method, supplying a reference to a [GpExe](#gpexe) object:

```csharp
var performanceWriter = DriverPerformanceWriter.For(GpExeFile.At(@"C:\Games\GPRIX\GP.EXE"));
```

There are two different performance levels for drivers, the qualifying levels and the race levels. Writing a whole list of all driver's
performance levels can be done with these methods:

```
performanceWriter.WriteQualifyingPerformanceLevels(performanceLevels);
performanceWriter.WriteRacePerformanceLevels(performanceLevels);
```

where _performanceLevels_ is a [DriverPerformanceList](#driverperformancelist). 


It is also possible to write individual drivers' performance levels using:

```
performanceWriter.WriteQualifyingPerformanceLevels(driverNumber, performanceLevel);
performanceWriter.WriteRacePerformanceLevels(driverNumber, performanceLevel);
```

where _driverNumber_ is the number of the driver and _performanceLevel_ is the byte value representing the performance level.


To write the general AI grip level, use:

```
performanceWriter.WriteGeneralGripLevel(gripLevel);
```

Where _gripLevel_ is a value between 1 and 100. The default value is 1.

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

**WriteMultiple** takes a path and a [SetupList](#setuplist) containing setups for all tracks.

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

A **Car** represents each team's car in the game. There are 13 panels
that can be painted.

<br />


### CarList
### Driver
### DriverNumberList

A **DriverNumberList** is a list of 40 driver "slots", where each slot contains
the number that the driver will have in-game.

To disable a "slot", set the number to 0.

Some restrictions apply:
- There must be at least 26 enabled drivers or the game will crash
- Two drivers cannot share numbers
- The available numbers range from 1 to 40

It is not recommended to use the last four slots, since these cannot be properly
accessed in the menu. Therefore, the actual maximum number of drivers is 36.

<br />


### DriverPerformanceList
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

<br />


### WetWeatherSettings

Represents the settings that concern wet weather racing.

**RainAtFirstTrack** is a bool that specifies
if wet weather is possible for races that take place on the first track (i.e. Phoenix). The default value
is false.

**ChanceOfRain** states the risk of wet weather races in percent. Values are slightly rounded to adhere
to a 0-100% range. The default value is 6% (which is actually 6.25%)

<br />