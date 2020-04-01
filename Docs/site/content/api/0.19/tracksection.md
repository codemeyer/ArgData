---
title: "ArgData API: TrackSection Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; TrackSection

# TrackSection Class

Represents a small section of a track.

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
    <td>TrackSection()</td>
    <td>Initializes a new instance of a TrackSection.</td>
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
    <td>BridgedLeftFence</td>
    <td>Gets or sets whether the left fence should be bridged with the fence of the previous?next? section.</td>
  </tr>
  <tr>
    <td>BridgedRightFence</td>
    <td>Gets or sets whether the right fence should be bridged with the fence of the previous?next? section.</td>
  </tr>
  <tr>
    <td>Commands</td>
    <td>Gets the list of TrackSectionCommands.</td>
  </tr>
  <tr>
    <td>Curvature</td>
    <td>Gets or sets the curvature of the track. Positive numbers means a right turn, negative numbers means a left turn. Smaller numbers indicate a tighter turn.</td>
  </tr>
  <tr>
    <td>HasLeftKerb</td>
    <td>Gets or sets whether there is a kerb on the left side of the track in the section.</td>
  </tr>
  <tr>
    <td>HasRightKerb</td>
    <td>Gets or sets whether there is a kerb on the right side of the track in the section.</td>
  </tr>
  <tr>
    <td>Height</td>
    <td>Gets or sets the height change that occurs in the section.</td>
  </tr>
  <tr>
    <td>KerbHeight</td>
    <td>Gets or sets the height of the kerb in the section, if there is one set with the HasLeftKerb or HasRightKerb flags.</td>
  </tr>
  <tr>
    <td>LeftVergeWidth</td>
    <td>Gets or sets the width of the left verge.</td>
  </tr>
  <tr>
    <td>Length</td>
    <td>Gets or sets the length of the section. 1 unit is 16 feet (approx 4.87 meters).</td>
  </tr>
  <tr>
    <td>PitLaneEntrance</td>
    <td>Get or sets whether the PitLaneEntrance flag should be set for the section.</td>
  </tr>
  <tr>
    <td>PitLaneExit</td>
    <td>Get or sets whether the PitLaneExit flag should be set for the section.</td>
  </tr>
  <tr>
    <td>RemoveLeftWall</td>
    <td>Gets or sets whether the right wall of the section should be removed/invisible.</td>
  </tr>
  <tr>
    <td>RemoveRightWall</td>
    <td>Gets or sets whether the right wall of the section should be removed/invisible.</td>
  </tr>
  <tr>
    <td>RightVergeWidth</td>
    <td>Gets or sets the width of the right verge.</td>
  </tr>
  <tr>
    <td>RoadSignArrow</td>
    <td>Gets or sets whether an arrow sign should appear before the section.</td>
  </tr>
  <tr>
    <td>RoadSignArrow100</td>
    <td>Gets or sets whether an arrow and 100 sign should appear before the section.</td>
  </tr>
  <tr>
    <td>RoadSigns</td>
    <td>Gets or sets whether 300/200/100 signs should appear before the section.</td>
  </tr>
  <tr>
    <td>Unknown1</td>
    <td>Gets or sets the Unknown1 flag (0x100). Not used in any default track, probably has no use.</td>
  </tr>
  <tr>
    <td>Unknown2</td>
    <td>Gets or sets the Unknown2 flag (0x200). Not used in any default track, probably has no use.</td>
  </tr>
  <tr>
    <td>Unknown3</td>
    <td>Gets or sets the Unknown3 flag (0x4000).</td>
  </tr>
  <tr>
    <td>Unknown4</td>
    <td>Gets or sets the Unknown4 flag (0x8000). Not used in any default track, probably has no use.</td>
  </tr>
</tbody>
</table>


