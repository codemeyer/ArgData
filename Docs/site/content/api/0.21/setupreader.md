---
title: "ArgData API: SetupReader Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; SetupReader

# SetupReader Class

Reads a single setup file or a multiple setups file from disk.

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
    <td>SetupReader()</td>
    <td>Initializes a new instance of SetupReader.</td>
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
    <td>ReadMultiple(String <em>path</em>)</td>
    <td>Reads a file containing multiple car setups.<br /><em>path</em>: Path to the setups file.<br /></td>
  </tr>
  <tr>
    <td>ReadSingle(String <em>path</em>)</td>
    <td>Reads a single setup file.<br /><em>path</em>: Path to the setup file.<br /></td>
  </tr>
</tbody>
</table>


