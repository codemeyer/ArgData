---
title: "ArgData API: TeamHorsepowerWriter Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TeamHorsepowerWriter

# TeamHorsepowerWriter Class

Writes horsepower values of teams to a GP.EXE file.

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
    <td>TeamHorsepowerWriter(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a TeamHorsepowerWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to write to.<br /></td>
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
    <td>For(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a TeamHorsepowerWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to write to.<br /></td>
  </tr>
  <tr>
    <td>WriteTeamHorsepower(Int32 <em>teamIndex</em>, Int32 <em>horsepower</em>)</td>
    <td>Writes the horsepower value for the team at the specified index.<br /><em>teamIndex</em>: Index of team to read horsepower value for.<br /><em>horsepower</em>: Horsepower value to write.<br /></td>
  </tr>
</tbody>
</table>


