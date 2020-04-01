---
title: "ArgData"
---

{{< partial "latest-version-sidebar.html" >}}

ArgData is a .NET library for working with
[Microprose Formula One Grand Prix](https://en.wikipedia.org/wiki/Formula_One_Grand_Prix_(video_game))
(F1GP) data, such as car colors and driver performance. There is also support for working with
various other game files, such as reading/writing name files and car setups.

This library currently supports the European and US (World Circuit) version 1.05 of the game,
including [decompressed](/argdata/decompressed-exe) versions.

The ArgData API is used in the F1GP editor [ArgEditor](/argeditor)
as well as the track editor [ArgTrack](/argtrack).


## Example

To give you an example of how the API can be used, let's give our own car some extra horsepower.
The default amount for the player car is 716, but to compete more effectively,
why not double that, to 1432?


<pre><code class="language-csharp">// get a reference to the GP.EXE file
var exeFile = GpExeFile.At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);

// create a writer object that allows updating the game files
var writer = PlayerHorsepowerWriter.For(exeFile);

// now let's cheat!
writer.WritePlayerHorsepower(1432);
</code></pre>

Start the game, enter a race, and leave the other drivers in the dust!


## API functionality and usage

The API allows you to edit car colors, driver numbers, horsepower levels,
computer car performance, track layouts, car setups, and much more.

For a full list of API functionality, and to get a general orientation
of how things fit together, have a look at the [Overview](/argdata/overview).

There are also a number of [tutorials](/argdata/tutorials) available for
both C# and PowerShell,
as well as a full [API reference](/argdata/api) section.


## Acknowledgements

ArgData would not have been possible without previous work and contributions by
the wider F1GP community, both past and present. Please visit
the [Acknowledgements](/acknowledgements) page for more details.

