# PointsSystemWriter

Writes the points system.

If you use a decompressed EXE, the points system that you read can contain points for
all 26 finishers. When running a normal EXE, only the top 6 finishers can have points
assigned to them, the remaining finishers will receive 0 points.


## Methods

| Name  | Description  |
|-------|--------------|
| For(GpExeFile *exeFile*)  | Creates a PointsSystemWriter for the specified GP.EXE file.<br />*exeFile*: GpExeFile to write to.<br />  |
| Write(PointsSystem *pointsSystem*)  | Writes a points system to the EXE.<br />*pointsSystem*: PointsSystem to write.<br />  |


