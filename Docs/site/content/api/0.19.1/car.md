---
title: "ArgData API: Car Class"
---

[API Reference](/argdata/api) &gt; [0.19.1](/argdata/api/0.19.1) &gt; Car

# Car Class

A Car represents a car with its various colors.

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
    <td>Car()</td>
    <td>Initializes a new instance of a Car with all colors set to 0 (black).</td>
  </tr>
  <tr>
    <td>Car(Byte[] <em>carColorBytes</em>)</td>
    <td>Initializes a new instance of a Car with the specified colors.<br /><em>carColorBytes</em>: The colors to set. Must be exactly 16.<br /></td>
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
    <td>CockpitFront</td>
    <td>Gets or sets the color of the part just in front of the cockpit opening.</td>
  </tr>
  <tr>
    <td>CockpitSide</td>
    <td>Gets or sets the color of the side of the cockpit.</td>
  </tr>
  <tr>
    <td>EngineCover</td>
    <td>Gets or sets the color of the main upper part of the engine cover.</td>
  </tr>
  <tr>
    <td>EngineCoverRear</td>
    <td>Gets or sets the color of the rear, lower part of the engine cover.</td>
  </tr>
  <tr>
    <td>EngineCoverSide</td>
    <td>Gets or sets the color of the lower part of the engine cover.</td>
  </tr>
  <tr>
    <td>FrontAndRearWing</td>
    <td>Gets or sets the color of the front and rear wing elements.</td>
  </tr>
  <tr>
    <td>FrontWingEndplate</td>
    <td>Gets or sets the color of the endplate of the front wing.</td>
  </tr>
  <tr>
    <td>NoseAngle</td>
    <td>Gets or sets the color of the angled part between the top and side of the nose-cone.</td>
  </tr>
  <tr>
    <td>NoseSide</td>
    <td>Gets or sets the color of the side of the nose-cone.</td>
  </tr>
  <tr>
    <td>NoseTop</td>
    <td>Gets or sets the color of the top part of the nose-cone.</td>
  </tr>
  <tr>
    <td>RearWingSide</td>
    <td>Gets or sets the color of the side of the rear wing.</td>
  </tr>
  <tr>
    <td>Sidepod</td>
    <td>Gets or sets the color of the vertical part of the sidepod.</td>
  </tr>
  <tr>
    <td>SidepodTop</td>
    <td>Gets or sets the color of the top part of the sidepod.</td>
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
    <td>Copy(Car <em>source</em>)</td>
    <td>Copies all colors from the source into this Car.<br /><em>source</em>: Source Car to copy colors from.<br /></td>
  </tr>
</tbody>
</table>


