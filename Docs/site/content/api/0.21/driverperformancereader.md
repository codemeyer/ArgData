---
title: "ArgData API: DriverPerformanceReader Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; DriverPerformanceReader

# DriverPerformanceReader Class

Reads the race and qualifying driver performance levels for computer drivers,
as well as the general grip level for computer cars.

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
    <td>DriverPerformanceReader(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a DriverPerformanceReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a DriverPerformanceReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>ReadGeneralGripLevel()</td>
    <td>Reads the general grip level for computer cars. Higher values mean that the computer cars<br />go faster. Default value is 1.</td>
  </tr>
  <tr>
    <td>ReadQualifyingPerformanceLevel(Int32 <em>driverNumber</em>)</td>
    <td>Reads the qualifying performance level of the driver with the specified number. Lower value indicates higher performance.<br /><em>driverNumber</em>: Driver number to read qualifying performance level for.<br /></td>
  </tr>
  <tr>
    <td>ReadQualifyingPerformanceLevels()</td>
    <td>Reads the qualifying performance level of all drivers. Lower value indicates higher performance.</td>
  </tr>
  <tr>
    <td>ReadRacePerformanceLevel(Int32 <em>driverNumber</em>)</td>
    <td>Reads the race performance of the driver with the specified number. Lower value indicates higher performance.<br /><em>driverNumber</em>: Driver number to read race performance level for.<br /></td>
  </tr>
  <tr>
    <td>ReadRacePerformanceLevels()</td>
    <td>Reads the race performance of all drivers. Lower value indicates higher performance.</td>
  </tr>
</tbody>
</table>


