---
title: "ArgData API: PaletteWithRanges Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; PaletteWithRanges

# PaletteWithRanges Class

Represents a palette of 256 colors used in various places in F1GP,
including a set of color ranges.

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
    <td>GetBrighterColor(Int32 <em>index</em>)</td>
    <td>Gets the next brightest color in the color range of the specified color.<br /><em>index</em>: Index of color to get brighter color for.<br /></td>
  </tr>
  <tr>
    <td>GetBrighterColor(Byte <em>index</em>)</td>
    <td>Gets the next brightest color in the color range of the specified color.<br /><em>index</em>: Index of color to get brighter color for.<br /></td>
  </tr>
  <tr>
    <td>GetColor(Byte <em>index</em>)</td>
    <td>Get the color at the specified index in the palette.<br /><em>index</em>: Index of color to fetch.<br /></td>
  </tr>
  <tr>
    <td>GetColor(Int32 <em>index</em>)</td>
    <td>Get the color at the specified index in the palette.<br /><em>index</em>: Index of color to fetch.<br /></td>
  </tr>
  <tr>
    <td>GetDarkerColor(Int32 <em>index</em>)</td>
    <td>Gets the next darkest color in the color range of the specified color.<br /><em>index</em>: Index of color to get darker color for.<br /></td>
  </tr>
  <tr>
    <td>GetDarkerColor(Byte <em>index</em>)</td>
    <td>Gets the next darkest color in the color range of the specified color.<br /><em>index</em>: Index of color to get darker color for.<br /></td>
  </tr>
  <tr>
    <td>GetRangeForColor(Byte <em>index</em>)</td>
    <td>Gets the range of colors for the specified color.<br /><em>index</em>: Index of color to get range for.<br /></td>
  </tr>
</tbody>
</table>


