---
title: "ArgData API: CarColorReader Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; CarColorReader

# CarColorReader Class

Reads the car colors of one or more teams.

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
    <td>CarColorReader(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a CarColorReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a CarColorReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>ReadCarColors(Int32 <em>teamIndex</em>)</td>
    <td>Reads the colors of the team at the specified index.<br /><em>teamIndex</em>: Index of team to read colors of.<br /></td>
  </tr>
  <tr>
    <td>ReadCarColors()</td>
    <td>Reads the colors of all the teams in the file.</td>
  </tr>
</tbody>
</table>


