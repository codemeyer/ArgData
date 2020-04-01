---
title: "ArgData API: DriverPerformanceWriter Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; DriverPerformanceWriter

# DriverPerformanceWriter Class

Writes the race or qualifying performance levels for computer drivers,
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
    <td>DriverPerformanceWriter(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a DriverPerformanceWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a DriverPerformanceWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>WriteGeneralGripLevel(Int32 <em>gripLevel</em>)</td>
    <td>Writes the general grip level for computer cars. Allowed values range from 1 to 100.<br />Greater values mean faster computer cars. Default value is 1.<br /><em>gripLevel</em>: General grip level.<br /></td>
  </tr>
  <tr>
    <td>WriteQualifyingPerformanceLevel(Int32 <em>driverNumber</em>, Byte <em>performanceLevel</em>)</td>
    <td>Writes the qualifying performance level for the driver with the specified number. Lower value indicates higher performance.<br /><em>driverNumber</em>: Driver number to write qualifying performance level for.<br /><em>performanceLevel</em>: Performance level.<br /></td>
  </tr>
  <tr>
    <td>WriteQualifyingPerformanceLevels(DriverPerformanceList <em>driverPerformances</em>)</td>
    <td>Writes the qualifying performance level for all drivers in numerical order. Lower value indicates higher performance.<br /><em>driverPerformances</em>: DriverPerformanceList with of performance levels.<br /></td>
  </tr>
  <tr>
    <td>WriteRacePerformanceLevel(Int32 <em>driverNumber</em>, Byte <em>performanceLevel</em>)</td>
    <td>Writes the race performance level for the driver with the specified number. Lower value indicates higher performance.<br /><em>driverNumber</em>: Driver number to write race performance level for.<br /><em>performanceLevel</em>: Performance level.<br /></td>
  </tr>
  <tr>
    <td>WriteRacePerformanceLevels(DriverPerformanceList <em>driverPerformances</em>)</td>
    <td>Writes the race performance level for all drivers in numerical order. Lower value indicates higher performance.<br /><em>driverPerformances</em>: DriverPerformanceList with performance levels.<br /></td>
  </tr>
</tbody>
</table>


