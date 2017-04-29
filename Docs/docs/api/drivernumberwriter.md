# DriverNumberWriter

Writes the driver numbers, or inactives a driver.

## Methods

| Name  | Description  |
|-------|--------------|
| For(GpExeFile *exeFile*)  | Creates a DriverNumberWriter for the specified GP.EXE file.<br />*exeFile*: GpExeFile to read from.<br />  |
| WriteDriverNumbers(DriverNumberList *driverNumbers*)  | Writes driver numbers. If a driver number is set to 0, the driver is inactivated.<br />*driverNumbers*: DriverNumberList of driver numbers.<br />  |


