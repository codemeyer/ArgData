---
title: "ArgData: Working with Decompressed EXE files"
---

# Working with decompressed EXE files


To bring the file size (and perhaps memory usage) down, the original GP.EXE file
(just like many other old DOS games) is compressed with EXEPACK.
This means that repeating byte data is "compressed" by replacing it with a special
byte sequence which indicates which value has been compressed, and how many instances
of it that there originally was.

This is highly effective, bringing the size of the European 1.05 GP.EXE down
from 587 KB to 314 KB. However, in the case of editing Microprose Formula One Grand Prix,
this brings about some limitations.

- Helmets for drivers with number #13, #15, #36, #37, #38, #39 and #40 are forced to have the same colour for the bottom third of the helmet.
- The points system can only be edited for the top six finishers.

ArgData now has support for working with decompressed EXE files. These files work fine to run in e.g. DOSBox. 

## Decompressing the EXE file

To enable/enhance various parts of F1GP, you can decompress the EXE file,
e.g. using using UNP v4.11, which can be downloaded
from <a href="http://unp.bencastricum.nl" target="_blank">unp.bencastricum.nl</a>.

Since UNP is a 16-bit tool, it won't work out-of-the-box on 64-bit versions of Windows.
So the simplest way to run it is to put it in your F1GP folder and run the tool through DOSBox.

Run UNP by specifying your original GP.EXE and a name for the new, decompressed file (in this example GPDECOMP.EXE)

<pre>
    <code>&gt; UNP.EXE GP.EXE GPDECOMP.EXE</code>
</pre>

This will decompress the file, and you should see some data written to the screen, like this (at least for a European 1.05 EXE file)

<pre>
<code>
processing file : GP.EXE
DOS file size   : 321878
file-structure  : executable (EXE)
EXE part sizes  : header 512 bytes, image 321366 bytes, overlay 0 bytes
processed with  : LINK V3.69 /EXEPACK
action          : decompressing... done
new file size   : 600480
writing to file : GPDECOMP.EXE
</code>
</pre>

The GPDECOMP.EXE file is now ready to roll!
