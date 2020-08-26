---
title: "ArgData API: TrackObjectShapeReferencePoint Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackObjectShapeReferencePoint

# TrackObjectShapeReferencePoint Class

The TrackObjectShapeReferencePoint class represents a 3D point that is defined by using references
to other previously defined X and Y coordinates, but with a separate Z value.

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
    <td>TrackObjectShapeReferencePoint(<a href="/argdata/api/0.21/trackobjectshape/">TrackObjectShape</a> <em>shape</em>)</td>
    <td>Initializes an instance of a TrackObjectShapeReferencePoint.<br /><em>shape</em>: Related TrackObjectShape.<br /></td>
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
    <td>PointIndex</td>
    <td>Gets or sets the index of the other point that this point uses for X and Y coordinates.</td>
  </tr>
  <tr>
    <td>X</td>
    <td>Gets the actual X point coordinate using the referenced value.</td>
  </tr>
  <tr>
    <td>Y</td>
    <td>Gets the actual Y point coordinate using the referenced value.</td>
  </tr>
  <tr>
    <td>Z</td>
    <td>Gets the Z point coordinate.</td>
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


