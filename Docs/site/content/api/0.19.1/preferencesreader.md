---
title: "ArgData API: PreferencesReader Class"
---

[API Reference](/argdata/api/) &gt; [0.19.1](/argdata/api/0.19.1/) &gt; PreferencesReader

# PreferencesReader Class

Reads preferences from the F1PREFS.DAT file.

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
    <td>PreferencesReader(PreferencesFile <em>preferencesFile</em>)</td>
    <td>Creates a PreferencesReader for the specified F1PREFS.DAT file.<br /><em>preferencesFile</em>: PreferencesFile to read from.<br /></td>
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
    <td>For(PreferencesFile <em>preferencesFile</em>)</td>
    <td>Creates a PreferencesReader for the specified F1PREFS.DAT file.<br /><em>preferencesFile</em>: PreferencesFile to read from.<br /></td>
  </tr>
  <tr>
    <td>GetAutoLoadedNameFile()</td>
    <td>Gets the relative path and name of the name file that is auto-loaded by the game.</td>
  </tr>
  <tr>
    <td>GetAutoLoadedSetupFile()</td>
    <td>Gets the relative path and name of the setup file that is auto-loaded by the game.</td>
  </tr>
</tbody>
</table>


