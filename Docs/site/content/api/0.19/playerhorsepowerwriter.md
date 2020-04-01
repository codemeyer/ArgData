---
title: "ArgData API: PlayerHorsepowerWriter Class"
---

[API Reference](/argdata/api) &gt; [0.19](/argdata/api/0.19) &gt; PlayerHorsepowerWriter

# PlayerHorsepowerWriter Class

Writes the horsepower values for the player.

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
    <td>PlayerHorsepowerWriter(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a PlayerHorsepowerWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
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
    <td>For(GpExeFile <em>exeFile</em>)</td>
    <td>Creates a PlayerHorsepowerWriter for the specified GP.EXE file.<br /><em>exeFile</em>: GpExeFile to read from.<br /></td>
  </tr>
  <tr>
    <td>WritePlayerHorsepower(Int32 <em>horsepower</em>)</td>
    <td>Writes the horsepower value for the player. The default value is 716.<br /><em>horsepower</em>: Player horsepower value. Permitted values between 1 and 1460.<br /></td>
  </tr>
</tbody>
</table>


