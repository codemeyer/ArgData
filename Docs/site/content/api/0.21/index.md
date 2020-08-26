---
title: "ArgData API Reference"
---

# ArgData API Reference

This is a list of the classes that make up the ArgData API.
Click on the name of a class for more information.

## Readers and Writers

The Reader and Writer classes perform the basic editing of GP.EXE and other files.
Reader classes are used to fetch data from the F1GP files into their respective representations as .NET classes.
The Writer classes update GP.EXE and other files.

<table class="table table-bordered table-striped ">
<thead>
  <tr>
    <th>Name</th>
    <th>Description</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td><a href="/argdata/api/0.21/carcolorreader/">CarColorReader</a></td>
    <td>Reads the car colors of one or more teams.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carcolorwriter/">CarColorWriter</a></td>
    <td>Writes the car colors of one or more teams.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/damagesettingsreader/">DamageSettingsReader</a></td>
    <td>Reads damage settings.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/damagesettingswriter/">DamageSettingsWriter</a></td>
    <td>Writes damage settings.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/drivernumberreader/">DriverNumberReader</a></td>
    <td>Reads the driver numbers.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/drivernumberwriter/">DriverNumberWriter</a></td>
    <td>Writes the driver numbers, or inactives a driver.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/driverperformancereader/">DriverPerformanceReader</a></td>
    <td>Reads the race and qualifying driver performance levels for computer drivers,
as well as the general grip level for computer cars.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/driverperformancewriter/">DriverPerformanceWriter</a></td>
    <td>Writes the race or qualifying performance levels for computer drivers,
as well as the general grip level for computer cars.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetcolorreader/">HelmetColorReader</a></td>
    <td>Reads driver helmet colors.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetcolorwriter/">HelmetColorWriter</a></td>
    <td>Writes driver helmet colors.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetmenuimagesreader/">HelmetMenuImagesReader</a></td>
    <td>Reads menu helmet images from an image file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetmenuimageswriter/">HelmetMenuImagesWriter</a></td>
    <td>Writes helmet menu images to a file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/mediacontainerfilereader/">MediaContainerFileReader</a></td>
    <td>Reads media container files.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/mediacontainerfilewriter/">MediaContainerFileWriter</a></td>
    <td>Class for writing to media container files, such as HELMETS.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/namefilereader/">NameFileReader</a></td>
    <td>Reads a name file from disk.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/namefilewriter/">NameFileWriter</a></td>
    <td>Writes a name file to disk.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pitcrewcolorreader/">PitCrewColorReader</a></td>
    <td>Reads pit crew colors of one or more teams.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pitcrewcolorwriter/">PitCrewColorWriter</a></td>
    <td>Writes pit crew colors of one or more teams.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/playerhorsepowerreader/">PlayerHorsepowerReader</a></td>
    <td>Reads the horsepower value for the player.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/playerhorsepowerwriter/">PlayerHorsepowerWriter</a></td>
    <td>Writes the horsepower values for the player.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pointssystemreader/">PointsSystemReader</a></td>
    <td>Reads the points system.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pointssystemwriter/">PointsSystemWriter</a></td>
    <td>Writes the points system.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/preferencesreader/">PreferencesReader</a></td>
    <td>Reads preferences from the F1PREFS.DAT file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/preferenceswriter/">PreferencesWriter</a></td>
    <td>Writes preferences to the F1PREFS.DAT file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/savedgamefilereader/">SavedGameFileReader</a></td>
    <td>Reads saved game files.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/setupreader/">SetupReader</a></td>
    <td>Reads a single setup file or a multiple setups file from disk.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/setupwriter/">SetupWriter</a></td>
    <td>Writes single or multiple setup files to disk.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/teamhorsepowerreader/">TeamHorsepowerReader</a></td>
    <td>Read the horsepower values of teams in a GP.EXE file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/teamhorsepowerwriter/">TeamHorsepowerWriter</a></td>
    <td>Writes horsepower values of teams to a GP.EXE file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackreader/">TrackReader</a></td>
    <td>Reads track data from an F1GP track file into a Track object.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackwriter/">TrackWriter</a></td>
    <td>Writes a Track object to an F1GP track file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/wetweathersettingsreader/">WetWeatherSettingsReader</a></td>
    <td>Reads the wet weather settings.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/wetweathersettingswriter/">WetWeatherSettingsWriter</a></td>
    <td>Writes wet weather settings.</td>
  </tr>
</tbody>
</table>



## Other Classes

<table class="table table-bordered table-striped ">
<thead>
  <tr>
    <th>Name</th>
    <th>Description</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td><a href="/argdata/api/0.21/car/">Car</a></td>
    <td>A Car represents a car with its various colors.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carlist/">CarList</a></td>
    <td>Represents a list of Car objects.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carset/">CarSet</a></td>
    <td>A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carsetdriver/">CarSetDriver</a></td>
    <td>Represents a driver in a CarSet.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carsetteam/">CarSetTeam</a></td>
    <td>Defines a team as it appears in a CarSet.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/carsetteamlist/">CarSetTeamList</a></td>
    <td>A list of CarSetTeam items.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/checksumcalculator/">ChecksumCalculator</a></td>
    <td>Class used for calculating an F1GP checksum.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/constants/">Constants</a></td>
    <td>Various constant values.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/damagesettings/">DamageSettings</a></td>
    <td>Represents the various damage settings in the game.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/defaultvalues/">DefaultValues</a></td>
    <td>Contains the default values for various data and settings in F1GP as constant values.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/deletetrackcameracommand/">DeleteTrackCameraCommand</a></td>
    <td>A camera command that deletes a specific camera.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/driver/">Driver</a></td>
    <td>Represents a driver with a name.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/drivernumberlist/">DriverNumberList</a></td>
    <td>List of driver numbers for 40 drivers.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/driverperformancelist/">DriverPerformanceList</a></td>
    <td>List of driver numbers for 40 drivers.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/gpchecksum/">GpChecksum</a></td>
    <td>GP checksum.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/gpexefile/">GpExeFile</a></td>
    <td>Represents a GP.EXE file that will be read from or written to.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/gpexeinfo/">GpExeInfo</a></td>
    <td>Contains details such as version number for a GP.EXE file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/gpexeversioninfo/">GpExeVersionInfo</a></td>
    <td>Info about the GP.EXE file version.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmet/">Helmet</a></td>
    <td>A Helmet represents a helmet with its various colors.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetlist/">HelmetList</a></td>
    <td>Represents a list of Helmet objects.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetmenuimage/">HelmetMenuImage</a></td>
    <td>A helmet image that appears in the driver selection menu.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/helmetmenuimages/">HelmetMenuImages</a></td>
    <td>Represents a list of helmet menu images.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/imageitem1769/">ImageItem1769</a></td>
    <td>Image item of type 1769, e.g. an image inside BACKDROP.DAT or TRACKPIX.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/imageitem1774/">ImageItem1774</a></td>
    <td>Image item of type 1774, e.g. an image inside HELMETS.DAT or FLAGS.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/importexportsettings/">ImportExportSettings</a></td>
    <td>ImportExportSettings define what will be imported from or exported to the GP.EXE.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/kerbheight/">KerbHeight</a></td>
    <td>Defines the type of kerb that exists in the track section.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/kerbtype/">KerbType</a></td>
    <td>Type of kerb, either two colors or three colors.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/mediacontainerfile/">MediaContainerFile</a></td>
    <td>Represents a .DAT file containing a number of items, mostly images.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/mediafileitem/">MediaFileItem</a></td>
    <td>Represents a media item stored inside a media container file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/mediaitem1768/">MediaItem1768</a></td>
    <td>Media item of type 1768, possibly video/animation related. Occurs in e.g. TROPHY.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/namefile/">NameFile</a></td>
    <td>Represents a file containing the names of the teams, engines and drivers.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/namefiledriverlist/">NameFileDriverList</a></td>
    <td>Represents a list of 40 drivers to be saved to a name file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/namefileteamlist/">NameFileTeamList</a></td>
    <td>Represents a list of 20 teams to be saved to a name file.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/palette/">Palette</a></td>
    <td>Represents a palette of 256 colors used in various places in F1GP.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/paletteitem/">PaletteItem</a></td>
    <td>Palette item, e.g. an item inside BACKDROP.DAT or TRACKPIX.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/palettewithranges/">PaletteWithRanges</a></td>
    <td>Represents a palette of 256 colors used in various places in F1GP,
including a set of color ranges.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pitcrew/">PitCrew</a></td>
    <td>Represents the colors of the pit crew.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pitcrewlist/">PitCrewList</a></td>
    <td>Represents a list of PitCrew objects.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/pointssystem/">PointsSystem</a></td>
    <td>Points system determines how many championship points are scored per finishing position.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/preferencesfile/">PreferencesFile</a></td>
    <td>Represents game preferences stored in F1PREFS.DAT.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/savedgame/">SavedGame</a></td>
    <td>A saved game containing a list of drivers and their results.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/savedgamedriver/">SavedGameDriver</a></td>
    <td>Represents a driver in a saved game.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/savedgamedriverlist/">SavedGameDriverList</a></td>
    <td>A list of SavedGameDrivers.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/setup/">Setup</a></td>
    <td>Single car setup.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/setuplist/">SetupList</a></td>
    <td>Represents a list of qualifying and race setups for all tracks.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/setuptyrecompound/">SetupTyreCompound</a></td>
    <td>Tyre compound in setup file. Can be A, B, C or D.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/surroundingarea/">SurroundingArea</a></td>
    <td>Represents the color of the surrounding area around the track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/team/">Team</a></td>
    <td>Represents a team with a name and engine manufacturer.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/track/">Track</a></td>
    <td>Represents an F1GP track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcameraadjustmentcommand/">TrackCameraAdjustmentCommand</a></td>
    <td>A camera command that adjusts the location of the camera along the track and/or side of the track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcameracommand/">TrackCameraCommand</a></td>
    <td>Track-side camera adjustment base class.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcameracommandlist/">TrackCameraCommandList</a></td>
    <td>Represents a list of TrackCameraCommands.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcamerarangerightsideadjustmentcommand/">TrackCameraRangeRightSideAdjustmentCommand</a></td>
    <td>Camera command that moves a range of track-side cameras to the right side of the track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcarsettings/">TrackCarSettings</a></td>
    <td>Settings that apply both to the player's car and the computer cars.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcomputercarbehavior/">TrackComputerCarBehavior</a></td>
    <td>Represents various properties related to computer car behavior.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcomputercarlinesegment/">TrackComputerCarLineSegment</a></td>
    <td>Represents a segment of the computer car line.

This line around the track is also used to provide steering help.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackcomputercarlinesegmenttype/">TrackComputerCarLineSegmentType</a></td>
    <td>Type of computer car line segment.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackhorizon/">TrackHorizon</a></td>
    <td>Represents the horizon of a track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackobjectsettings/">TrackObjectSettings</a></td>
    <td>Represents an instance of a 3D object with related settings.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackobjectshape/">TrackObjectShape</a></td>
    <td>Represents the shape of 3D track objects.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackobjectshapereferencepoint/">TrackObjectShapeReferencePoint</a></td>
    <td>The TrackObjectShapeReferencePoint class represents a 3D point that is defined by using references
to other previously defined X and Y coordinates, but with a separate Z value.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackobjectshapescalepoint/">TrackObjectShapeScalePoint</a></td>
    <td>Represents a 3D point that uses the scale values to define its X, Y and Z coordinates.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackobjectshapevector/">TrackObjectShapeVector</a></td>
    <td>Represents a connection between two points in the object shape 3D definition.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackoffsets/">TrackOffsets</a></td>
    <td>Offsets into the track file. These are updated automatically when the track is saved.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/tracksection/">TrackSection</a></td>
    <td>Represents a small section of a track.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/tracksectioncommand/">TrackSectionCommand</a></td>
    <td>Track section command that adds features to the track section it belongs to.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/tracksectionheader/">TrackSectionHeader</a></td>
    <td>Class that contains properties that are related to the initial state of the track sections.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/tracksettings/">TrackSettings</a></td>
    <td>Represents various track settings.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/trackside/">TrackSide</a></td>
    <td>Track side.</td>
  </tr>
  <tr>
    <td><a href="/argdata/api/0.21/wetweathersettings/">WetWeatherSettings</a></td>
    <td>Wet weather settings.</td>
  </tr>
</tbody>
</table>



