---
title: "ArgData API: DriverPerformanceList Class"
---

[API Reference](/argdata/api/) &gt; [0.19](/argdata/api/0.19/) &gt; DriverPerformanceList

# DriverPerformanceList Class

List of driver numbers for 40 drivers.

**Namespace:** ArgData.Entities

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
    <td>DriverPerformanceList()</td>
    <td>Initializes a new instance of a DriverPerformanceList.</td>
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
    <td>GetByDriverNumber(Byte <em>driverNumber</em>)</td>
    <td>Gets the performance level for the driver with the specified number.<br /><em>driverNumber</em>: Number of driver to get performance level for.<br /></td>
  </tr>
  <tr>
    <td>GetEnumerator()</td>
    <td>Returns an enumerator that iterates through the collection.</td>
  </tr>
  <tr>
    <td>SetByDriverNumber(Byte <em>driverNumber</em>, Byte <em>performanceLevel</em>)</td>
    <td>Set the performance level for the driver with the specified number.<br /><em>driverNumber</em>: Number of driver to get performance level for.<br /><em>performanceLevel</em>: Byte value representing the performance. Lower value means higher performance.<br /></td>
  </tr>
  <tr>
    <td>ToArray()</td>
    <td>Returns driver performance levels as an array.</td>
  </tr>
</tbody>
</table>


