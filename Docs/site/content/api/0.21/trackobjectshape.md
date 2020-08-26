---
title: "ArgData API: TrackObjectShape Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; TrackObjectShape

# TrackObjectShape Class

Represents the shape of 3D track objects.

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
    <td>TrackObjectShape(Int32 <em>headerIndex</em>, Int32 <em>dataIndex</em>)</td>
    <td>Initializes a new instance of a TrackObjectShape.<br /><em>headerIndex</em>: <br /><em>dataIndex</em>: <br /></td>
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
    <td>DataIndex</td>
    <td>Gets or sets the data index of the object shape.</td>
  </tr>
  <tr>
    <td>DataLength</td>
    <td>Gets the length of the object data.</td>
  </tr>
  <tr>
    <td>HeaderData5</td>
    <td>Gets or sets the HeaderData5 value. This must always be 10 bytes long. Purpose unknown.</td>
  </tr>
  <tr>
    <td>HeaderData6</td>
    <td>Gets or sets the HeaderData6 value. This is always either 0 bytes or 10 bytes long. Purpose unknown.</td>
  </tr>
  <tr>
    <td>HeaderIndex</td>
    <td>Gets or sets the header index of the object shape.</td>
  </tr>
  <tr>
    <td>HeaderValue1</td>
    <td>Gets or sets HeaderValue1. Purpose currently not fully known.</td>
  </tr>
  <tr>
    <td>HeaderValue2</td>
    <td>Gets or sets HeaderValue2. Purpose currently not fully known.</td>
  </tr>
  <tr>
    <td>HeaderValue3</td>
    <td>Gets or sets HeaderValue3. Purpose currently not fully known.

This value is updated when the track is saved, and should not be manipulated directly.</td>
  </tr>
  <tr>
    <td>HeaderValue4</td>
    <td>Gets or sets HeaderValue4. Purpose currently not fully known.</td>
  </tr>
  <tr>
    <td>HeaderValue5</td>
    <td>Gets or sets HeaderValue5. Purpose currently not fully known.</td>
  </tr>
  <tr>
    <td>HeaderValue6</td>
    <td>Gets or sets HeaderValue6. Purpose currently not fully known.</td>
  </tr>
  <tr>
    <td>Offset2</td>
    <td>Gets or sets the Offset2 value.

This value is updated when the track is saved, and should not be manipulated directly.</td>
  </tr>
  <tr>
    <td>Offset5</td>
    <td>Gets or sets the Offset5 value.

This value is updated when the track is saved, and should not be manipulated directly.</td>
  </tr>
  <tr>
    <td>OffsetData2</td>
    <td>Gets or sets the raw byte data at Offset2, which represents GraphicElements.</td>
  </tr>
  <tr>
    <td>OffsetData5</td>
    <td>Gets or sets the raw byte data at Offset5, which represents GraphicElementsLists.</td>
  </tr>
  <tr>
    <td>PointDataOffset</td>
    <td>Gets or sets the starting point for the Point data.

This value is updated when the track is saved, and should not be manipulated directly.

This was previously Offset3.</td>
  </tr>
  <tr>
    <td>Points</td>
    <td>Gets the list of Points in the 3D shape.

This was previously OffsetData3.</td>
  </tr>
  <tr>
    <td>PointsAdditionalBytes</td>
    <td>Gets or sets the additional "stray" point bytes that occur in a single object in the Silverstone track.</td>
  </tr>
  <tr>
    <td>ScaleValueOffset</td>
    <td>Gets or sets the starting point for the ScaleValue data.

This value is updated when the track is saved, and should not be manipulated directly.

This was previously Offset1.</td>
  </tr>
  <tr>
    <td>ScaleValues</td>
    <td>Gets the list of ScaleValues.

This was previously OffsetData1.</td>
  </tr>
  <tr>
    <td>VectorDataOffset</td>
    <td>Gets or sets the starting point for the Vector data.

This value is updated when the track is saved, and should not be manipulated directly.

This was previously Offset4.</td>
  </tr>
  <tr>
    <td>Vectors</td>
    <td>Gets the list of Vectors.

This was previously OffsetData4.</td>
  </tr>
</tbody>
</table>


