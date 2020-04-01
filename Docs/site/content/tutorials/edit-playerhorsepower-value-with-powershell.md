---
title: "ArgData: Tutorials - Edit Player Horsepower Value with PowerShell"
---

# Edit Player Horsepower Value with PowerShell


In this tutorial we will edit the player horsepower value, so that you as the player have _twice_ as
much horsepower at your disposal.

Before we start editing your F1GP files, make sure that you have a backup of everything, or at least the
GP.EXE file, because you never know what might happen.


### Step 1: Load the DLL

Open Notepad or any other PowerShell editor that you wish to use. Begin by adding the following:

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"</code></pre>

This will load the DLL in the specified path to make its API available
in PowerShell.


### Step 2: Get a reference to your EXE file

First off, we need a reference to the GP.EXE that we want to edit.

<pre><code class="language-powershell">$exe = [ArgData.GpExeFile]::At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);
</code></pre>


### Step 3: Create a writer object that allows updating the game files

Once we have a reference to the EXE file that we wish to edit, we can pass it along as a parameter
for all kinds of reader and writer objects in the API.

In this case, we want to create a <code>PlayerHorsepowerWriter</code>.

<pre><code class="language-powershell">$writer = [ArgData.PlayerHorsepowerWriter]::For($exe)
</code></pre>


### Step 4: Update the horsepower value in the EXE file

We can now use the <code>writer</code> object to update the value.

<pre><code class="language-powershell">$writer.WritePlayerHorsepower(1432)</code></pre>


The complete code should now look something like this.

<!-- link to GitHub gist -->

<pre><code class="language-powershell">Add-Type -Path "C:\Scripts\ArgData\ArgData.dll"

$exe = [ArgData.GpExeFile]::At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);

$writer = [ArgData.PlayerHorsepowerWriter]::For($exe)

$writer.WritePlayerHorsepower(1432)
</code></pre>


Save the script as `player-horsepower.ps1`.


### Step 5: Run the script

By opening a PowerShell Console window and executing `C:\Scripts\ArgData\player-horsepower.ps1` you will apply the changes.

Your EXE file has now been updated.


### Step 6: Try it out!

Start the game, enter a race, and leave the other drivers in the dust!
