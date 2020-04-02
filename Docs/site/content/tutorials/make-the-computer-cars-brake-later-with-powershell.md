---
title: "ArgData"
---

# Make the computer cars brake later

If you are an experienced F1GP player, you will probably agree that it is quite easy to outbrake the opponent cars.

To make the game more challenging, we can make the computer cars brake later than they
do by default.

We can use the <code>ComputerCarBehavior</code> properties of the <code>Track</code> object
to manipulate the late-braking behavior of the computer cars.


### Step 1: Load the DLL

Open Notepad or any other PowerShell editor that you wish to use. Begin by adding the following:

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"</code></pre>

This will load the DLL in the specified path to make its API available
in PowerShell.


### Step 2: Create a TrackReader and read the track

<pre><code class="language-powershell">$trackReader = New-Object "ArgData.TrackReader"
$track = $trackReader.Read("C:\Games\GPRIX\F1CT01.DAT")
</code></pre>

The `TrackReader` class is used for reading F1GP track files.

We use its `Read` method and pass in the path to the track file.

The value that is returned is the track, as a [`Track`](/argdata/api/0.19.1/track) object.

We need to manipulate some properties under [`ComputerCarBehavior`](/argdata/api/0.19.1/trackcomputercarbehavior/).


### Step 3: Update the late-braking value

There are three late-braking properties that we can manipulate, `LateBrakingFactorRace`, `LateBrakingFactorNonRace` and `LateBrakingFactorWetRace`.
In this case we will just make an adjustment for the race-specific value, `LateBrakingFactorRace`.

The default value for the Phoenix track is 16384. Let's increase it by around 3%, setting it to 16876.

<pre><code class="language-powershell">$track.ComputerCarBehavior.LateBrakingFactorRace = 16876
</code></pre>

How much you can increase the value will differ from track to track.

_NB: If you increase the value too much, the computer cars will begin to brake too late, slide too much,
and start hitting walls or going off on the exits of corners, or just spin out._

Note that the lap times of the computer cars will also decrease when you make this change.


### Step 4: Save the track file to disk

_NB: This will update your existing Phoenix track file (F1CT01.DAT). Make sure that you have a backup, or that you 
are working in a completely different folder than the original F1GP one_

<pre><code class="language-powershell">$trackWriter = New-Object "ArgData.TrackWriter"
$trackWriter.Write($track, "C:\Games\GPRIX\F1CT01.DAT")
</code></pre>

To update a track file we need a [`TrackWriter`](/argdata/api/0.19.1/trackwriter/) object.
We then use its `Write` method, passing in the track data in `$track` and the
path to the file that we wish to save.

The complete code should now look something like this.

<!-- link to GitHub gist -->

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"

$trackReader = New-Object "ArgData.TrackReader"
$track = $trackReader.Read("C:\Games\GPRIX\F1CT01.DAT")

$track.ComputerCarBehavior.LateBrakingFactorRace = 16876

$trackWriter = New-Object "ArgData.TrackWriter"
$trackWriter.Write($track, "C:\Games\GPRIX\F1CT01.DAT")
</code></pre>


### Step 5: Run the script

By opening a PowerShell Console window and executing `C:\Scripts\ArgData\late-braking.ps1` you will apply the changes.

The track has now been edited successfully.


### Step 6: Drive the track in F1GP

Now I would suggest that you start a race in Phoenix from the back. You should notice that it is slightly
more difficult to outbrake the opponents.

You may also notice that they slide slightly more when cornering.


<!-- how does changing this value affect lap times -->
