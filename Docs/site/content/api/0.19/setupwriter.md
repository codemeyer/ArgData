---
title: "ArgData API: SetupWriter Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; SetupWriter

# SetupWriter Class

Writes single or multiple setup files to disk.

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
    <td>SetupWriter()</td>
    <td>Initializes a new instance of SetupWriter.</td>
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
    <td>WriteMultiple(SetupList <em>setups</em>, String <em>path</em>)</td>
    <td>Writes a file containing multiple setups to disk.<br /><em>setups</em>: Setups to save.<br /><em>path</em>: Path to file. Will be created or overwritten.<br /></td>
  </tr>
  <tr>
    <td>WriteSingle(Setup <em>setup</em>, String <em>path</em>)</td>
    <td>Writes a single setup to disk.<br /><em>setup</em>: Setup to save.<br /><em>path</em>: Path to file. Will be created or overwritten.<br /></td>
  </tr>
</tbody>
</table>


