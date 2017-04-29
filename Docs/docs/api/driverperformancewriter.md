# DriverPerformanceWriter

Writes the race or qualifying performance levels for computer drivers,
as well as the general grip level for computer cars.

## Methods

| Name  | Description  |
|-------|--------------|
| For(GpExeFile *exeFile*)  | Creates a DriverPerformanceWriter for the specified GP.EXE file.<br />*exeFile*: GpExeFile to read from.<br />  |
| WriteRacePerformanceLevel(Int32 *driverNumber*, Byte *performanceLevel*)  | Writes the race performance level for the driver with the specified number. Lower value indicates higher performance.<br />*driverNumber*: Driver number to write race performance level for.<br />*performanceLevel*: Performance level.<br />  |
| WriteRacePerformanceLevels(DriverPerformanceList *driverPerformances*)  | Writes the race performance level for all drivers in numerical order. Lower value indicates higher performance.<br />*driverPerformances*: DriverPerformanceList with performance levels.<br />  |
| WriteQualifyingPerformanceLevel(Int32 *driverNumber*, Byte *performanceLevel*)  | Writes the qualifying performance level for the driver with the specified number. Lower value indicates higher performance.<br />*driverNumber*: Driver number to write qualifying performance level for.<br />*performanceLevel*: Performance level.<br />  |
| WriteQualifyingPerformanceLevels(DriverPerformanceList *driverPerformances*)  | Writes the qualifying performance level for all drivers in numerical order. Lower value indicates higher performance.<br />*driverPerformances*: DriverPerformanceList with of performance levels.<br />  |
| WriteGeneralGripLevel(Int32 *gripLevel*)  | Writes the general grip level for computer cars. Allowed values range from 1 to 100.<br />Greater values mean faster computer cars. Default value is 1.<br />*gripLevel*: General grip level.<br />  |


