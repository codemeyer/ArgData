---
title: "ArgData API: ChecksumCalculator Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; ChecksumCalculator

# ChecksumCalculator Class

Class used for calculating an F1GP checksum.

**Namespace:** ArgData

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
    <td>ChecksumCalculator()</td>
    <td>Initializes a new instance of ChecksumCalculator.</td>
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
    <td>Calculate(Byte[] <em>allBytes</em>)</td>
    <td>Calculates the first and second checksums for the specified file data.<br /><em>allBytes</em>: Array of all file bytes except last four.<br /></td>
  </tr>
  <tr>
    <td>UpdateChecksum(String <em>path</em>)</td>
    <td>Updates the checksum (i.e. the last four bytes) of the specified file.<br /><em>path</em>: Path to file.<br /></td>
  </tr>
</tbody>
</table>


