---
title: "ArgData API: GpExeInfo Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; GpExeInfo

# GpExeInfo Class

Contains details such as version number for a GP.EXE file.

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
    <td>GpExeInfo()</td>
    <td>Initializes a new instance of GpExeInfo.</td>
  </tr>
</tbody>
</table>


## Properties

<table class="table table-bordered table-striped ">
<thead>
  <tr>
    <th>Name</th>
    <th>Description</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>IsDecompressed</td>
    <td>Gets whether the GP.EXE is decompressed.</td>
  </tr>
  <tr>
    <td>IsEditingSupported</td>
    <td>Gets whether editing this GP.EXE file is supported by ArgData.</td>
  </tr>
  <tr>
    <td>IsKnownExeVersion</td>
    <td>Gets whether the file is a known GP.EXE file or not.</td>
  </tr>
  <tr>
    <td>Version</td>
    <td>Gets the version of the executable as a GpExeVersionInfo enum.</td>
  </tr>
</tbody>
</table>


