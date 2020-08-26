---
title: "ArgData API: Palette Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; Palette

# Palette Class

Represents a palette of 256 colors used in various places in F1GP.

**Namespace:** ArgData

## Methods

<table class="table table-bordered table-striped ">
<thead>
  <tr>
    <th>Name</th>
    <th>Description</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>CreateDrivingPalette()</td>
    <td>Returns an instance of a PaletteWithRanges that represents<br />the color palette that is used when driving in the game.</td>
  </tr>
  <tr>
    <td>CreateMenuPalette()</td>
    <td>Returns an instance of a Palette that represents the color palette<br />that is used in the driver selection menu.</td>
  </tr>
  <tr>
    <td>GetColor(Byte <em>index</em>)</td>
    <td>Get the color at the specified index in the palette.<br /><em>index</em>: Index of color to fetch.<br /></td>
  </tr>
  <tr>
    <td>GetColor(Int32 <em>index</em>)</td>
    <td>Get the color at the specified index in the palette.<br /><em>index</em>: Index of color to fetch.<br /></td>
  </tr>
</tbody>
</table>


