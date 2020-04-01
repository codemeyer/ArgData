---
title: "ArgData: Tutorials - Edit Car Colors for a Single Car with C#"
aliases:
    - "/guides/quick-start"
---

# Edit Car Colors for a Single Car with C&#35;

This guide will guide you step-by-step through how to edit one of the colors on a car in F1GP. This guide
assumes that you are familiar with Visual Studio, NuGet and C#.

To set the scene, imagine that you have been playing F1GP for a long time, and accepted the fact that
the Tyrrells are blue instead of grey, the Modena Team cars have the colors of the Coloni team, and the
Coloni team... well, nobody knows what that is supposed to be, their 1990 car but with the wrong wing colors?

Anyway, you've accepted all this, but you _do not_ accept the fact that the top parts of the Jordan's sidepods
are dark green. When we all know that it's mostly bright green. Just Google it. Here's the default Jordan in-game:

<img alt="Jordan 191 before editing" src="/argdata/images/tutorials/jordan-before.png" class="img-fluid" />

OK, before we start editing your F1GP files, make sure that you have a backup of everything, or at least the
GP.EXE file, because you never know what might happen.


### Step 1: Create a project and install ArgData

If you already have a C# project set up in Visual Studio, you can skip this step.

Otherwise, follow the steps in the [C# Prerequisites](/argdata/tutorials/prerequisites-for-csharp/) to do this.


### Step 2: Get a reference to your EXE file

We'll just put everything in the <code>Main()</code> method to keep it simple.

First off, we need a reference to the GP.EXE that we want to edit.

<pre><code class="language-csharp">var exeFile = GpExeFile.At(&#64;&quot;C:\Games\GPRIX\GP.EXE&quot;);
</code></pre>


### Step 3: Fetch the Car that we want to edit

ArgData uses Reader classes for fetching data from GP.EXE, and Writer classes to update GP.EXE. We want to retrieve the
Jordan that we want to edit first, then we will update the color we are unhappy with, and then we will write the
new information back to GP.EXE.

But first things first, create a <code>CarColorReader</code> and retrieve the Jordan car.

<pre><code class="language-csharp">var reader = CarColorReader.For(exeFile);
var car = reader.Read(16);
</code></pre>

The <code>reader</code> is created by using the static <code>For</code> method and passing in the reference to the <code>exeFile</code>. We then
read information for the 17th car in the game, and since the index is zero-based, that means that we pass in 16.

The <code>car</code> has a number of panels we can paint, but right now we are mostly interested in the one called
<code>SidepodTop</code>. The value that we assign to <code>SidepodTop</code> is the index of the color in the 256-color palette that
the game has. Now we just need to decide on a color.


### Step 4: Setting a new color for the top of the sidepods

But how do we know which color index to use? We will look at the [Palette Colors](/argdata/api/palette-colors) page
here and decide. Ready? Let's go...

...which color did you choose? Perhaps none of them perfectly matches the bright green of the top of the 1991 Jordan's
sidepod, but for the sake of doing <em>something</em>, let's go with 77.

<pre><code class="language-csharp">car.SidepodTop = 77;
</code></pre>

But now we need to write the data back to our GP.EXE file, and for that we need a <code>CarColorWriter</code>.


### Step 5: Writing data back to GP.EXE

The <code>CarColorWriter</code> that we use to write car colors is created in much the same way as the <code>CarColorReader</code>.
After creating the writer, we will call its <code>WriteCarColors</code> method and pass in the <code>car</code> that we have edited,
and the index of which car in the game we will update. Since we want to update the Jordan, we again pass in
index 16, just like when we read the data.

<pre><code class="language-csharp">var writer = CarColorWriter.For(exeFile);
writer.WriteCarColors(car, 16);
</code></pre>

### Step 6: How did it go?

Now run your console application. It should run without problems and since we didn't add a <code>ReadKey</code> or similar,
it will just blink and be done.

Time to start F1GP and see how the Jordan looks...

<img alt="Jordan 191 after editing" src="/argdata/images/tutorials/jordan-after.png" class="img-fluid" />

Success!

Congratulations! You have just edited F1GP successfully using ArgData!
