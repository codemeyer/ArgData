---
title: "ArgData API: TrackObjectShapeScalePoint Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackObjectShapeScalePoint

# TrackObjectShapeScalePoint Class

Represents a 3D point that uses the scale values to define its X, Y and Z coordinates.

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
    <td>TrackObjectShapeScalePoint(<a href="/argdata/api/0.21/trackobjectshape/">TrackObjectShape</a> <em>shape</em>)</td>
    <td>Initializes an instance of a TrackObjectShapeScalePoint.<br /><em>shape</em>: Related TrackObjectShape.<br /></td>
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
    <td>X</td>
    <td>Gets the actual X point coordinate using the scale value index.</td>
  </tr>
  <tr>
    <td>XIsNegative</td>
    <td>Gets or sets whether the X coordinate value is positive or negative.</td>
  </tr>
  <tr>
    <td>XScaleValueIndex</td>
    <td>Gets or sets the index of the scale value to use for the X coordinate.</td>
  </tr>
  <tr>
    <td>Y</td>
    <td>Gets the actual Y point coordinate using the scale value index.</td>
  </tr>
  <tr>
    <td>YIsNegative</td>
    <td>Gets or sets whether the Y coordinate value is positive or negative.</td>
  </tr>
  <tr>
    <td>YScaleValueIndex</td>
    <td>Gets or sets the index of the scale value to use for the Y coordinate.</td>
  </tr>
  <tr>
    <td>Z</td>
    <td>Gets or sets the value of the Z coordinate.</td>
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
    <td>GetBytes()</td>
    <td>Returns the bytes that represent the point in the track file.</td>
  </tr>
</tbody>
</table>


