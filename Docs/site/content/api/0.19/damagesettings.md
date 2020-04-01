---
title: "ArgData API: DamageSettings Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; DamageSettings

# DamageSettings Class

Represents the various damage settings in the game.

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
    <td>DamageSettings()</td>
    <td>Initializes a new instance of DamageSettings.</td>
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
    <td>DamageAfterHittingOtherCar</td>
    <td>Gets or sets how much damage needs to be done before a wing breaks after crashing into another car.
Lower value means less damage is needed. The default value is 1792.</td>
  </tr>
  <tr>
    <td>DamageAfterHittingWall</td>
    <td>Gets or sets how much damage needs to be done before a wing breaks after crashing into the wall.
Lower value means less damage is needed. The default value is 1792.</td>
  </tr>
  <tr>
    <td>IsValid</td>
    <td>Whether the specified damage setting values are within allowed ranges.</td>
  </tr>
  <tr>
    <td>RetireAfterHittingOtherCar</td>
    <td>Gets or sets how much damage needs to be done before a car retires from a crash with another car.
Lower value means less damage is needed. The default value is 8192.</td>
  </tr>
  <tr>
    <td>RetireAfterHittingWall</td>
    <td>Gets or sets how much damage needs to be done before a car retires from a crash with the wall.
Lower value means less damage is needed. The default value is 7424.</td>
  </tr>
  <tr>
    <td>RetiredCarsRemovedAfterSeconds</td>
    <td>Gets or sets how many seconds it takes before retired cars are removed from the track.</td>
  </tr>
  <tr>
    <td>YellowFlagsForStationaryCarsAfterSeconds</td>
    <td>Gets or sets how many seconds it takes before marshalls show yellow flags for cars that
are stationary on track.</td>
  </tr>
</tbody>
</table>


