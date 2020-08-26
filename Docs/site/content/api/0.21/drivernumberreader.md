---
title: "ArgData API: DriverNumberReader Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; DriverNumberReader

# DriverNumberReader Class

Reads the driver numbers.

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
    <td>DriverNumberReader(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Creates a DriverNumberReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>Creates a DriverNumberReader for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>ReadDriverNumbers()</td>
    <td>Reads the driver numbers. 0 indicates an inactivated driver.</td>
  </tr>
</tbody>
</table>


