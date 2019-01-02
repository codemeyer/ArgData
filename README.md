# ArgData

ArgData is a .NET library for working with [Microprose Formula One Grand Prix](https://en.wikipedia.org/wiki/Formula_One_Grand_Prix_(video_game)) (F1GP) data, such as car colors and driver performance. There is also support for working with various other game files, such as reading/writing name files and car setups.

This library currently supports the European and US (World Circuit) version 1.05 of the game.

It is used in the new F1GP editor [ArgEditor](http://www.argtools.com/argeditor).


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
* Editing track data such as track sections, object placements, computer car line
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
* Editing menu helmet images and (to a certain extent) other background images

For an introduction to how to use the API, including simple examples and a full reference section,
see the [API documentation](http://www.argtools.com/argdata).

The API is continuously (albeit slowly) being improved and extended. To see what is in the pipeline,
have a look at the [roadmap](ROADMAP.md).


### Acknowledgements

This simple piece of software stands on the shoulders of giants. Huge gratitude goes out to:

* Steve Smith - for the amazing F1Ed
* René Smit - additional research material and Chequered Flag
* Barrie Millar and Klaus Six - for Chequered Flag
* Hrvoje Štimac - additional research material
* Trevor Kellaway - for an endless number of F1GP utilities, including GPEditor
* Paul Hoad - for the C++ code for calculating F1GP file checksums he sent me in 1998, and for the GP2 Track Editor
* Maxime Labelle - for "The Grand Prix 2 Track File Format (Beta 0.5)" web page
* Craig Heath - for the F1GP Driver Selection Screen Helmet Editor
* Adrian Walti, Martijn Keizer, et al
