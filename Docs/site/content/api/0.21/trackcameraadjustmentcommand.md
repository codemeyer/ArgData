---
title: "ArgData API: TrackCameraAdjustmentCommand Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackCameraAdjustmentCommand

# TrackCameraAdjustmentCommand Class

A camera command that adjusts the location of the camera along the track and/or side of the track.

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
    <td>TrackCameraAdjustmentCommand(Byte <em>cameraIndex</em>, Byte <em>adjustment</em>, <a href="/argdata/api/0.21/trackside/">TrackSide</a> <em>trackSide</em>)</td>
    <td>Initializes a new instance of a TrackCameraAdjustmentCommand.<br /><em>cameraIndex</em>: Index of camera to adjust.<br /><em>adjustment</em>: Adjustment along the track.<br /><em>trackSide</em>: Side of track.<br /></td>
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
    <td>Adjustment</td>
    <td>Gets or sets the amount that the camera should be moved back.</td>
  </tr>
  <tr>
    <td>CameraIndex</td>
    <td>Gets or sets the index of the camera to adjust.</td>
  </tr>
  <tr>
    <td>TrackSide</td>
    <td>Gets or sets the side of the track that the camera should be placed at.</td>
  </tr>
</tbody>
</table>


