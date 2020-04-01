---
title: "ArgData API: TrackObjectSettings Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; TrackObjectSettings

# TrackObjectSettings Class

Represents an instance of a 3D object with related settings.

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
    <td>TrackObjectSettings()</td>
    <td>Initializes a new instance of TrackObjectSettings.</td>
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
    <td>AngleX</td>
    <td>Gets the X angle of the object.

When Id is 5, 13 (and others) this refers to the Id of internal "billboard" objects.</td>
  </tr>
  <tr>
    <td>AngleY</td>
    <td>Gets the Y angle of the object.</td>
  </tr>
  <tr>
    <td>DetailLevel</td>
    <td>Gets the detail level that the item appears at. Is actually a Flag value.</td>
  </tr>
  <tr>
    <td>DistanceFromTrack</td>
    <td>Gets the distance from the center of the track. Negative values indicate left side of track.</td>
  </tr>
  <tr>
    <td>Height</td>
    <td>Gets the height from the ground that the object is placed at.</td>
  </tr>
  <tr>
    <td>Id</td>
    <td>Gets the Id of the object.

When this is 17 or greater, it refers to the index in the track object shapes.</td>
  </tr>
  <tr>
    <td>Id2</td>
    <td>Gets the Id2 value. Unknown functionality.</td>
  </tr>
  <tr>
    <td>Offset</td>
    <td>Gets or sets the object shape offset (index * 16)</td>
  </tr>
  <tr>
    <td>Unknown</td>
    <td>Gets the Unknown value. Possibly color-related.</td>
  </tr>
  <tr>
    <td>Unknown2</td>
    <td>Gets the Unknown2 value. Possibly draw-depth related.</td>
  </tr>
</tbody>
</table>


