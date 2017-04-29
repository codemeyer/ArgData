# DriverPerformanceReader

Reads the race and qualifying driver performance levels for computer drivers,
as well as the general grip level for computer cars.

## Methods

| Name  | Description  |
|-------|--------------|
| For(GpExeFile *exeFile*)  | Creates a DriverPerformanceReader for the specified GP.EXE file.<br />*exeFile*: GpExeFile to read from.<br />  |
| ReadRacePerformanceLevel(Int32 *driverNumber*)  | Reads the race performance of the driver with the specified number. Lower value indicates higher performance.<br />*driverNumber*: Driver number to read race performance level for.<br />  |
| ReadRacePerformanceLevels()  | Reads the race performance of all drivers. Lower value indicates higher performance.  |
| ReadQualifyingPerformanceLevel(Int32 *driverNumber*)  | Reads the qualifying performance level of the driver with the specified number. Lower value indicates higher performance.<br />*driverNumber*: Driver number to read qualifying performance level for.<br />  |
| ReadQualifyingPerformanceLevels()  | Reads the qualifying performance level of all drivers. Lower value indicates higher performance.  |
| ReadGeneralGripLevel()  | Reads the general grip level for computer cars. Higher values mean that the computer cars<br />go faster. Default value is 1.  |


