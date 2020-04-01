---
title: "ArgData API: ImageItem1774 Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; ImageItem1774

# ImageItem1774 Class

Image item of type 1774, e.g. an image inside HELMETS.DAT or FLAGS.DAT.

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
    <td>ImageItem1774()</td>
    <td>Initializes a new instance of ImageItem1774.</td>
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
    <td>Data</td>
    <td></td>
  </tr>
  <tr>
    <td>Height</td>
    <td></td>
  </tr>
  <tr>
    <td>Length</td>
    <td></td>
  </tr>
  <tr>
    <td>Offset</td>
    <td></td>
  </tr>
  <tr>
    <td>Type</td>
    <td></td>
  </tr>
  <tr>
    <td>Width</td>
    <td></td>
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
    <td>GetPixelData()</td>
    <td>Gets the pixel data from the image item as a byte array.<br /><br />The size of the array will be the Width multiplied by the Height of the image.</td>
  </tr>
  <tr>
    <td>SetPixelData(Byte[] <em>pixelData</em>)</td>
    <td>Sets the pixel data for the image.<br /><em>pixelData</em>: Pixel data as a byte array, where each byte represents a menu palette index. Must be the same length as the Width multiplied by the Height of the image.<br /></td>
  </tr>
</tbody>
</table>


