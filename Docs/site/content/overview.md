---
title: "ArgData: Overview"
---

# Overview of the ArgData API

The introduction provides a general overview of which files in
F1GP that you edit, and a guide to
the basic way that the API provides interaction with these files.


## Functionality

First of all, the API has support for the following functionality:

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

This functionality is covered both in the
[tutorials](/argdata/tutorials/) available for
both C# and PowerShell, as well as the
full [API reference](/argdata/api/) section.


## Readers and Writers

The ArgData API provides a number of classes and functions for editing various parts
of the game Formula One Grand Prix (F1GP). Classes that perform editing
comes in pairs, a Reader and a Writer. If the API can only
read some data, there will only be a Reader class.

The API is generally discoverable, and the goal is that classes have straightforward names
that describe what they do. For instance, to read car colors you use the <code>CarColorReader</code> class.

Reader and Writer classes are initialized through static <code>For</code> methods that require
references to the files that are being edited.

As en example, the <code>For</code> method in the <code>CarColorReader</code> takes an instance of a <code>GpExeFile</code> as its
input parameter. In this way, the API signals clearly what is required to construct a working
<code>CarColorReader</code> objects.

F1GP files that need to be referenced are initialized through static <code>At</code> methods that take the
path to the file.

Thus, a <code>CarColorReader</code> for a GP.EXE file at <code>C:\Games\GPRIX\GP.EXE</code> can be instantiated with:

<pre>
<code class="language-csharp">var reader = CarColorReader.For(GpExeFile.At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;));</code>
</pre>

With apologies to anyone who hates fluent APIs... and for those who do,
there are more traditional ways to use, e.g.

<pre>
<code class="language-csharp">var exeFile = new GpExeFile(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);
var reader = new CarColorReader(exeFile);
</code></pre>


## The CarSet abstraction

Note that there is also a <code>CarSet</code> abstraction over all these "detailed" Reader/Writer classes.
A <code>CarSet</code> contains a number of teams, each with a car, two drivers, etc.
These can be exported into the game EXE file or imported from the game EXE.

A simple example would be:

<pre>
<code class="language-csharp">var exeFile = GpExeFile.At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);
var nameFile = new NameFileReader().Read(&#64;&quot;C:\Games\GPRIX\gpsaves\F1-1991.NAM&quot;);
var carSet = new CarSet();
carSet.Import(exeFile, nameFile);</code>
</pre>

The <code>carSet</code> object will now be populated with data from the EXE file and the names from the
provided name file.


## What next?

Have a look at the [tutorials](/argdata/tutorials/) or dive into
the full [API reference](/argdata/api/).
