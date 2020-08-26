---
title: "ArgData API: PitCrew Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; PitCrew

# PitCrew Class

Represents the colors of the pit crew.

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
    <td>PitCrew()</td>
    <td>Initializes a new instance of a PitCrew with all colors set to 0 (black).</td>
  </tr>
  <tr>
    <td>PitCrew(Byte[] <em>pitCrewColorBytes</em>)</td>
    <td>Initializes a new instance of a PitCrew with the specified colors.<br /><em>pitCrewColorBytes</em>: The colors to set. Must be exactly 16.<br /></td>
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
    <td>PantsPrimary</td>
    <td>Gets or sets the primary pants color.</td>
  </tr>
  <tr>
    <td>PantsSecondary</td>
    <td>Gets or sets the secondary pants color.</td>
  </tr>
  <tr>
    <td>ShirtPrimary</td>
    <td>Gets or sets the primary shirt color.</td>
  </tr>
  <tr>
    <td>ShirtSecondary</td>
    <td>Gets or sets the secondary shirt color.</td>
  </tr>
  <tr>
    <td>Socks</td>
    <td>Gets or sets the color of the socks.</td>
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
    <td>Copy(<a href="/argdata/api/0.21/pitcrew/">PitCrew</a> <em>source</em>)</td>
    <td>Copies all colors from the source into this PitCrew.<br /><em>source</em>: Source PitCrew to copy colors from.<br /></td>
  </tr>
</tbody>
</table>


