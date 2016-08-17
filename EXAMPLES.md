# ArgData API Usage Examples

The ArgData API currently supports the following:

- Updating [car colors](#car-colors)
- Updating [helmet colors](#helmet-colors) (in-game, not menu)
- Updating [pit crew colors](#pit-crew-colors)
- Changing [driver numbers](#driver-numbers)/which drivers are enabled in-game
- Changing computer car horsepower levels
- Changing player car horsepower level
- Updating computer car grip levels for race and qualifying
- Reading and creating new name files
- Reading and creating new single-setup and multiple-setup files
- Changing the likelihood of wet races
- Enabling/disabling the possibility of rain at the US GP
- Reading race results from a saved season game
- Set a name file to be read automatically when the game starts
- Updating the checksum of existing files (names, tracks, setups)


## Car colors

F1GP has support for 18 teams, each of which has a car with a fixed number of panels you can paint.

Reading car colors requires you to create a new `CarColorReader` object.

```csharp
var exePath = "C:\path\to\GP.EXE"
var carColorReader = CarColorReader.For(GpExeFile.At(exePath));
```

You can then either read a single car by using `ReadCarColors(int teamIndex)` or read out a `CarList` of all 18 cars by using the `ReadCarColors()` overload.

Each `Car` has properties such as `FrontAndRearWing`, `FrontWingEndplate` and `Sidepod`. These properties are byte values, and represent the color in the fixed 256 color palette that the game has.

Writing car colors requires you to create a `CarColorWriter`.

```csharp
var exePath = "C:\path\to\GP.EXE"
var carColorWriter = CarColorWriter.For(GpExeFile.At(exePath));
```


## Helmet colors

Reading helmet colors requires you to create a new `HelmetColorReader` object.

```csharp
var exePath = "C:\path\to\GP.EXE"
var helmetColorReader = HelmetColorReader.For(GpExeFile.At(exePath));
```

Note that helmets for drivers with numbers 13, 15, 36, 37, 38, 39 and 40 will always have a large portion of the
helmet set to the same color, and so cannot be painted in the same way as the others.


## Pit crew colors

Reading pit crew colors requires you to create a new `PitCrewColorReader` object.

```csharp
var exePath = "C:\path\to\GP.EXE"
var pitCrewColorReader = PitCrewColorReader.For(GpExeFile.At(exePath));
```

Each pit crew has five parts that can be painted: two shirt colors, two pants colors and the socks.


## Driver numbers

The game has 40 driver "slots", where each driver can have a number between 1 and 40. If a driver is not active in the game, it is set to 0.

Note that the game will crash if less than 26 drivers are active.
