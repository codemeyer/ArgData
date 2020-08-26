---
title: "ArgData API: DriverNumberWriter Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; DriverNumberWriter

# DriverNumberWriter Class

Writes the driver numbers, or inactives a driver.

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
    <td>DriverNumberWriter(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a DriverNumberWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a DriverNumberWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>WriteDriverNumbers(<a href="/argdata/api/0.21/drivernumberlist/">DriverNumberList</a> <em>driverNumbers</em>)</td>
    <td>Writes driver numbers. If a driver number is set to 0, the driver is inactivated.<br /><em>driverNumbers</em>: DriverNumberList of driver numbers.<br /></td>
  </tr>
</tbody>
</table>


