---
title: "ArgData API: ImportExportSettings Class"
---

[API Reference](/argdata/api/) &gt; [0.19.1](/argdata/api/0.19.1/) &gt; ImportExportSettings

# ImportExportSettings Class

ImportExportSettings define what will be imported from or exported to the GP.EXE.

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
    <td>ImportExportSettings()</td>
    <td>Initializes a new instance of an ImportExportSettings object.</td>
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
    <td>CarColors</td>
    <td>Whether car colors should be imported or exported.</td>
  </tr>
  <tr>
    <td>DriverNumbers</td>
    <td>Whether to import or export driver numbers or not. Note that DriverPerformanceRace, DriverPerformanceQualifying,
HelmetColors and Names are all dependent on the driver numbers being set correctly.</td>
  </tr>
  <tr>
    <td>DriverPerformanceQualifying</td>
    <td>Whether driver performance qualifying levels should be imported/exported.</td>
  </tr>
  <tr>
    <td>DriverPerformanceRace</td>
    <td>Whether driver performance race levels should be imported/exported.</td>
  </tr>
  <tr>
    <td>HelmetColors</td>
    <td>Whether driver helmet colors should be imported/exported.</td>
  </tr>
  <tr>
    <td>Names</td>
    <td>Whether team and driver names should be imported/exported.</td>
  </tr>
  <tr>
    <td>PitCrewColors</td>
    <td>Whether pit crew colors should be imported/exported.</td>
  </tr>
  <tr>
    <td>TeamHorsepower</td>
    <td>Whether to import or export team horsepower levels.</td>
  </tr>
</tbody>
</table>


