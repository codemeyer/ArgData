---
title: "ArgData API: TrackOffsets Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackOffsets

# TrackOffsets Class

Offsets into the track file. These are updated automatically when the track is saved.

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
    <td>TrackOffsets()</td>
    <td>Initializes a new instance of TrackOffsets.</td>
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
    <td>BaseOffset</td>
    <td>Gets the base offset value.</td>
  </tr>
  <tr>
    <td>ChecksumPosition</td>
    <td>Gets the offset position of the file checksum.</td>
  </tr>
  <tr>
    <td>ObjectData</td>
    <td>Gets the offset position of object data.</td>
  </tr>
  <tr>
    <td>TrackData</td>
    <td>Gets the offset position of track section header and data.</td>
  </tr>
  <tr>
    <td>Unknown2</td>
    <td>Gets the Unknown2 value.

In the original tracks, this value is always identical to Unknown4.</td>
  </tr>
  <tr>
    <td>Unknown3</td>
    <td>Gets the Unknown3 value.</td>
  </tr>
  <tr>
    <td>Unknown4</td>
    <td>Gets the Unknown4 value.

In the original tracks, this value is always identical to Unknown2.</td>
  </tr>
</tbody>
</table>


