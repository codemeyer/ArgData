---
title: "ArgData API: TrackComputerCarLineSegment Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackComputerCarLineSegment

# TrackComputerCarLineSegment Class

Represents a segment of the computer car line.

This line around the track is also used to provide steering help.

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
    <td>TrackComputerCarLineSegment()</td>
    <td>Initializes a new instance of TrackComputerCarLineSegment.</td>
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
    <td>Correction</td>
    <td>Gets or sets the correction value. Called Tighter/Wider in GP2 Track Editor.</td>
  </tr>
  <tr>
    <td>HighRadius</td>
    <td>Gets or sets the corner high radius. Only used when SegmentType is WideRadius.</td>
  </tr>
  <tr>
    <td>Length</td>
    <td>Gets or sets the length of the segment.</td>
  </tr>
  <tr>
    <td>LowRadius</td>
    <td>Gets or sets the corner low radius. Only used when SegmentType is WideRadius.</td>
  </tr>
  <tr>
    <td>Radius</td>
    <td>Gets or sets the corner radius. Only used when SegmentType is Normal.</td>
  </tr>
  <tr>
    <td>SegmentType</td>
    <td>Gets or sets the type of segment.</td>
  </tr>
</tbody>
</table>


