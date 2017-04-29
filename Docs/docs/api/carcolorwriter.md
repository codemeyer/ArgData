# CarColorWriter

Writes the car colors of one or more teams.

## Methods

| Name  | Description  |
|-------|--------------|
| For(GpExeFile *exeFile*)  | Creates a CarColorWriter for the specified GP.EXE file.<br />*exeFile*: GpExeFile to read from.<br />  |
| WriteCarColors(Car *car*, Int32 *teamIndex*)  | Writes car colors for a team.<br />*car*: Car with colors to write.<br />*teamIndex*: Index of the team to write the colors for.<br />  |
| WriteCarColors(CarList *carList*)  | Writes car colors for all the teams.<br />*carList*: CarList with colors to write.<br />  |


