---
title: "ArgData API: Helmet Class"
---

[API Reference](/argdata/api/) &gt; [0.19.1](/argdata/api/0.19.1/) &gt; Helmet

# Helmet Class

A Helmet represents a helmet with its various colors.

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
    <td>Helmet()</td>
    <td>Initializes a new instance of a Helmet with all colors set to 0 (black).</td>
  </tr>
  <tr>
    <td>Helmet(Byte[] <em>helmetColorBytes</em>)</td>
    <td>Initializes a new instance of a Helmet with the specified colors.<br /><em>helmetColorBytes</em>: The colors to set. Must be exactly 14 or 16 bytes.<br /></td>
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
    <td>Stripes</td>
    <td>Gets or sets the color of the 13 horizontal stripes of the helmet.</td>
  </tr>
  <tr>
    <td>Visor</td>
    <td>Gets or sets the color of the visor. Default is 0.</td>
  </tr>
  <tr>
    <td>VisorSurround</td>
    <td>Gets or sets the color of the visor surround. Default is 6.</td>
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
    <td>Copy(Helmet <em>source</em>)</td>
    <td>Copies all colors from the source into this Helmet.<br /><em>source</em>: Source Helmet to copy colors from.<br /></td>
  </tr>
</tbody>
</table>


