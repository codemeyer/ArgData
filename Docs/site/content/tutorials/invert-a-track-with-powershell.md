---
title: "ArgData: Tutorials - Invert a Track with PowerShell"
---

# Invert a Track with PowerShell

For laughs, let's create an inverted track. By inverted, I mean that
where a track usually has an uphill corner or straight, it will now
go downhill, and vice versa.

In this example, we will invert Interlagos.

So instead of the first corner dropping steeply, it will now instead _rise_ steeply.

_NB: Since we do not adjust the locations of the track side objects, some of them are going to
end up in incorrect locations..._


### Step 1: Load the DLL

Open Notepad or any other PowerShell editor that you wish to use. Begin by adding the following:

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"</code></pre>

This will load the DLL in the specified path to make its API available
in PowerShell.


### Step 2: Create a TrackReader and read the track

<pre><code class="language-powershell">$trackReader = New-Object "ArgData.TrackReader"
$track = $trackReader.Read("C:\Games\GPRIX\F1CT02.DAT")
</code></pre>

The `TrackReader` class is used for reading F1GP track files.

We use its `Read` method and pass in the path to the track file.

The value that is returned is the track, as a [`Track`](/argdata/api/0.19/track) object.


### Step 3: Invert each track and pit lane section

Each track has a number of [track sections](/argdata/api/0.19/tracksection), as well as a number of pit lane sections.

Sections of an F1GP track can be likened to the sections of a [Scalextric](https://en.wikipedia.org/wiki/Scalextric) track.
Each section has a length, a curvature and a height change.

What we want to do is multiply each section's height value with -1 to make it go in the opposite direction.

<pre><code class="language-powershell">ForEach ($section in $track.TrackSections)
{
    $section.Height = $section.Height * -1
}

ForEach ($section in $track.PitLaneSections)
{
    $section.Height = $section.Height * -1
}
</code></pre>

We have now made all uphill sections go downhill, and vice versa.


### Step 4: Save the track file to disk

_NB: This will update your existing Interlagos track file. Make sure that you have a backup, or that you 
are working in a completely different folder than the original F1GP one_

<pre><code class="language-powershell">$trackWriter = New-Object "ArgData.TrackWriter"
$trackWriter.Write($track, "C:\Games\GPRIX\F1CT02.DAT")
</code></pre>

To update a track file we need a [`TrackWriter`](/argdata/api/0.19/trackwriter) object.
We then use its `Write` method, passing in the track data in `$track` and the
path to the file that we wish to save.

The complete code should now look something like this.

<!-- link to GitHub gist -->

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"

$trackReader = New-Object "ArgData.TrackReader"
$track = $trackReader.Read("C:\Games\GPRIX\F1CT02.DAT")

ForEach ($section in $track.TrackSections)
{
    $section.Height = $section.Height * -1
}

ForEach ($section in $track.PitLaneSections)
{
    $section.Height = $section.Height * -1
}

$trackWriter = New-Object "ArgData.TrackWriter"
$trackWriter.Write($track, "C:\Games\GPRIX\F1CT02.DAT")
</code></pre>


### Step 5: Run the script

By opening a PowerShell Console window and executing the `C:\Scripts\ArgData\invert.ps1` script
you will apply the changes.

The track has now been edited successfully.


### Step 6: Drive the track in F1GP

Upon leaving your pit stall and approaching the turn in the pit lane, you will now notice that it is _uphill_.

<img alt="Inverted Interlagos" src="/argdata/images/tutorials/invert-01-pitlane.png" class="img-fluid" />

Keep driving around the track. It will feel familiar, yet completely different...
