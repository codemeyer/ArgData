---
title: "ArgData API: Setup Class"
---

[API Reference](/argdata/api/) &gt; [0.21](/argdata/api/0.21/) &gt; Setup

# Setup Class

Single car setup.

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
    <td>Setup()</td>
    <td>Initializes a new instance of Setup.</td>
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
    <td>BrakeBalance</td>
    <td>Gets or sets the brake balance value. Allowed values between -32 (Rear) and 32 (Front).</td>
  </tr>
  <tr>
    <td>FrontWing</td>
    <td>Gets or sets the front wing setting. Allowed values between 0 and 64.</td>
  </tr>
  <tr>
    <td>GearRatio1</td>
    <td>Gets or sets the ratio of the first gear. Must be 16 or greater, and less than GearRatio2.</td>
  </tr>
  <tr>
    <td>GearRatio2</td>
    <td>Gets or sets the ratio of the second gear. Must be greater than GearRatio1 and less than GearRatio3.</td>
  </tr>
  <tr>
    <td>GearRatio3</td>
    <td>Gets or sets the ratio of the third gear. Must be greater than GearRatio2 and less than GearRatio4.</td>
  </tr>
  <tr>
    <td>GearRatio4</td>
    <td>Gets or sets the ratio of the fourth gear. Must be greater than GearRatio3 and less than GearRatio5.</td>
  </tr>
  <tr>
    <td>GearRatio5</td>
    <td>Gets or sets the ratio of the fifth gear. Must be greater than GearRatio4 and less than GearRatio6.</td>
  </tr>
  <tr>
    <td>GearRatio6</td>
    <td>Gets or sets the ratio of the sixth gear. Must be greater than GearRatio5 and less than or equal to 80.</td>
  </tr>
  <tr>
    <td>IsValid</td>
    <td>Whether the values currently entered in the setup are within allowed ranges.</td>
  </tr>
  <tr>
    <td>RearWing</td>
    <td>Gets or sets the rear wing setting. Allowed values between 0 and 64.</td>
  </tr>
  <tr>
    <td>TyreCompound</td>
    <td>Gets or sets the tyre compound.</td>
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
    <td>Copy(<a href="/argdata/api/0.21/setup/">Setup</a> <em>source</em>)</td>
    <td>Copies all setup values from the source into this Setup.<br /><em>source</em>: <br /></td>
  </tr>
</tbody>
</table>


