# ArgData

ArgData is a .NET library for working with [Microprose Formula One Grand Prix](https://en.wikipedia.org/wiki/Formula_One_Grand_Prix_(video_game)) (F1GP) data, such as car colors and driver performance. There is also support for working with various other game files, such as reading/writing name files and car setups.

This library currently supports the European and US (World Circuit) version 1.05 of the game, including [decompressed](./decompressed-exe) versions.

It is used in the new F1GP editor [ArgEditor](http://manicomio.se/argeditor).


### API functionality and usage

The ArgData API currently supports the following:

* Updating car colors
* Updating helmet colors (in-game, not menu)
* Updating pit crew colors
* Changing driver numbers/which drivers are enabled in-game
* Changing computer car horsepower levels
* Changing player car horsepower level
* Updating computer car performance levels for races and qualifying sessions
* Updating the general computer car grip level
* Reading and creating new name files
* Reading and creating new single-setup and multiple-setup files
* Updating the points system
* Changing the likelihood of wet races
* Enabling/disabling the possibility of rain at the US GP
* Reading race results from a saved season game
* Set a name file to be read automatically when the game starts
* Updating the checksum of existing files (names, tracks, setups)
* Support for decompressed GP.EXE files
* Changing probability of wing damage/out-of-race damage when crashing
* Changing amount of time before retired cars are removed

Before you begin to code, you may want to have a look at the [overview](./overview).
The provides general information on which files in F1GP that you edit, and a guide to
the basic way that the API provides interaction with these files.

For a step-by-step guide to some simple editing, see the [Quick Start guide](./quick-start).

There is also a full [reference section](./api/reference.md).


### Acknowledgements

This simple piece of software stands on the shoulders of giants. Huge gratitude goes out to:

* Steve Smith - for the amazing F1Ed
* Trevor Kellaway - for an endless number of F1GP utilities, including GPEditor
* Paul Hoad - for the C++ code for calculating F1GP file checksums he sent me in 1998
* Hrvoje Štimac - additional research material
* Barrie Millar - additional research material
