---
title: "ArgData API: PreferencesWriter Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; PreferencesWriter

# PreferencesWriter Class

Writes preferences to the F1PREFS.DAT file.

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
    <td>PreferencesWriter(PreferencesFile <em>preferencesFile</em>)</td>
    <td>Creates a PreferencesWriter for the specified F1PREFS.DAT file.<br /><em>preferencesFile</em>: PreferencesFile to read from.<br /></td>
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
    <td>DisableAutoLoadedNameFile()</td>
    <td>Disables auto-loading of any name file in the game.</td>
  </tr>
  <tr>
    <td>DisableAutoLoadedSetupFile()</td>
    <td>Disables auto-loading of any setup file in the game.</td>
  </tr>
  <tr>
    <td>For(PreferencesFile <em>preferencesFile</em>)</td>
    <td>Creates a PreferencesWriter for the specified F1PREFS.DAT file.<br /><em>preferencesFile</em>: PreferencesFile to read from.<br /></td>
  </tr>
  <tr>
    <td>SetAutoLoadedNameFile(String <em>nameFilePath</em>)</td>
    <td>Sets the auto-loaded name file.<br /><em>nameFilePath</em>: Relative path to F1GP installation. Max 31 chars.<br /></td>
  </tr>
  <tr>
    <td>SetAutoLoadedSetupFile(String <em>setupFilePath</em>)</td>
    <td>Sets the auto-loaded setup file.<br /><em>setupFilePath</em>: Relative path to F1GP installation. Max 31 chars.<br /></td>
  </tr>
</tbody>
</table>


