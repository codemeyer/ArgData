---
title: "ArgData API: TeamHorsepowerReader Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; TeamHorsepowerReader

# TeamHorsepowerReader Class

Read the horsepower values of teams in a GP.EXE file.

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
    <td>TeamHorsepowerReader(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a TeamHorsepowerReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a TeamHorsepowerReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>ReadTeamHorsepower(Int32 <em>teamIndex</em>)</td>
    <td>Reads the horsepower value of the team at the specified index.<br /><em>teamIndex</em>: Index of team to read horsepower value for.<br /></td>
  </tr>
</tbody>
</table>


