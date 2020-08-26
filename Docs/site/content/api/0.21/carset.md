---
title: "ArgData API: CarSet Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; CarSet

# CarSet Class

A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.

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
    <td>CarSet()</td>
    <td>Initializes a new instance of a CarSet.</td>
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
    <td>Teams</td>
    <td>List of 18 teams.</td>
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
    <td>Drivers()</td>
    <td>Get all Drivers as a single list.</td>
  </tr>
  <tr>
    <td>Export(<a href="/argdata/api/0.21/importexportsettings/">ImportExportSettings</a> <em>settings</em>, <a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>)</td>
    <td>Exports the CarSet to the specified GP.EXE file.<br /><br />Does not create or set a name file to use.<br /><em>settings</em>: ImportExportSettings defining what to export.<br /><em>exeFile</em>: GpExeFile.<br /></td>
  </tr>
  <tr>
    <td>Export(<a href="/argdata/api/0.21/importexportsettings/">ImportExportSettings</a> <em>settings</em>, <a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>, <a href="/argdata/api/0.21/preferencesfile/">PreferencesFile</a> <em>preferencesFile</em>, String <em>nameFilePath</em>)</td>
    <td>Exports the CarSet to the specified GP.EXE file.<br /><br />Only exports the items that have been set to true in the provided ImportExportSettings.<br />Will create the name file specified in nameFilePath, and set it to load automatically.<br /><em>settings</em>: ImportExportSettings defining what to export.<br /><em>exeFile</em>: GpExeFile<br /><em>preferencesFile</em>: PreferencesFile.<br /><em>nameFilePath</em>: Relative path to the name file to create.<br /></td>
  </tr>
  <tr>
    <td>Import(<a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>, <a href="/argdata/api/0.21/namefile/">NameFile</a> <em>nameFile</em>)</td>
    <td>Imports all settings into the current CarSet object.<br /><em>exeFile</em>: GpExeFile to import data from.<br /><em>nameFile</em>: NameFile to import team and driver names from.<br /></td>
  </tr>
  <tr>
    <td>Import(<a href="/argdata/api/0.21/importexportsettings/">ImportExportSettings</a> <em>settings</em>, <a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>, <a href="/argdata/api/0.21/namefile/">NameFile</a> <em>nameFile</em>)</td>
    <td>Imports the specified settings into the current CarSet object.<br /><em>settings</em>: ImportExportSettings defining what to import.<br /><em>exeFile</em>: GpExeFile to import data from.<br /><em>nameFile</em>: NameFile to import team and driver names from.<br /></td>
  </tr>
  <tr>
    <td>Import(<a href="/argdata/api/0.21/carset/">CarSet</a> <em>carSet</em>, <a href="/argdata/api/0.21/importexportsettings/">ImportExportSettings</a> <em>settings</em>, <a href="/argdata/api/0.21/gpexefile/">GpExeFile</a> <em>exeFile</em>, <a href="/argdata/api/0.21/namefile/">NameFile</a> <em>nameFile</em>)</td>
    <td>Imports the specified settings into an existing CarSet object.<br /><em>carSet</em>: CarSet to import data into.<br /><em>settings</em>: ImportExportSettings defining what to import.<br /><em>exeFile</em>: GpExeFile to import data from.<br /><em>nameFile</em>: NameFile to import team and driver names from.<br /></td>
  </tr>
</tbody>
</table>


