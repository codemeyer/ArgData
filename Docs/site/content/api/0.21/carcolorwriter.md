---
title: "ArgData API: CarColorWriter Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; CarColorWriter

# CarColorWriter Class

Writes the car colors of one or more teams.

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
    <td>CarColorWriter(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a CarColorWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a CarColorWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>WriteCarColors(<a href="/argdata/api/0.21/car/">Car</a> <em>car</em>, Int32 <em>teamIndex</em>)</td>
    <td>Writes car colors for a team.<br /><em>car</em>: Car with colors to write.<br /><em>teamIndex</em>: Index of the team to write the colors for.<br /></td>
  </tr>
  <tr>
    <td>WriteCarColors(<a href="/argdata/api/0.21/carlist/">CarList</a> <em>carList</em>)</td>
    <td>Writes car colors for all the teams.<br /><em>carList</em>: CarList with colors to write.<br /></td>
  </tr>
</tbody>
</table>


