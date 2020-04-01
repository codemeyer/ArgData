---
title: "ArgData API: PitCrewColorReader Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; PitCrewColorReader

# PitCrewColorReader Class

Reads pit crew colors of one or more teams.

**Namespace:** ArgData

## Constructors

<table class="table table-bordered table-striped ">
<thead>
  <tr>
    <th>Name</th>
    <th>Description</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>PitCrewColorReader(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a PitCrewColorReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
</tbody>
</table>


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
    <td>For(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a PitCrewColorReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>ReadPitCrewColors(Int32 <em>pitCrewIndex</em>)</td>
    <td>Reads the colors of the pit crew at the specified index.<br /><em>pitCrewIndex</em>: Index of pit crew to read colors of.<br /></td>
  </tr>
  <tr>
    <td>ReadPitCrewColors()</td>
    <td>Reads the colors of all the pit crews in the file.</td>
  </tr>
</tbody>
</table>


