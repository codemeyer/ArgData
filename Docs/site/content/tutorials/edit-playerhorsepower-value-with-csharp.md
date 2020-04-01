---
title: "ArgData: Tutorials - Edit Player Horsepower Value with C#"
---

# Edit Player Horsepower Value with C&#35;

In this tutorial we will edit the player horsepower value, so that you as the player have _twice_ as
much horsepower at your disposal.

Before we start editing your F1GP files, make sure that you have a backup of everything, or at least the
GP.EXE file, because you never know what might happen.


### Step 1: Create a project and install ArgData

If you already have a C# project set up in Visual Studio, you can skip this step.

Otherwise, follow the steps in the [C# Prerequisites](/argdata/tutorials/prerequisites-for-csharp/) to do this.


### Step 2: Get a reference to your EXE file

We'll just put everything in the <code>Main()</code> method to keep it simple.

First off, we need a reference to the GP.EXE that we want to edit.

<pre><code class="language-csharp">var exeFile = GpExeFile.At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);
</code></pre>


### Step 3: Create a writer object that allows updating the game files

Once we have a reference to the EXE file that we wish to edit, we can pass it along as a parameter
for all kinds of reader and writer objects in the API.

In this case, we want a <code>PlayerHorsepowerWriter</code>.

<pre><code class="language-csharp">var writer = PlayerHorsepowerWriter.For(exeFile);
</code></pre>


### Step 4: Update the horsepower value in the EXE file

We can now use the <code>writer</code> object to update the value.

<pre><code class="language-csharp">writer.WritePlayerHorsepower(1432);</code></pre>

Once this is done, the GP.EXE file is updated.


### Step 5: Try it out

Start the game, enter a race, and leave the other drivers in the dust!
