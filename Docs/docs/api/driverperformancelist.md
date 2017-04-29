# DriverPerformanceList

List of driver numbers for 40 drivers.

## Constructors

| Name  | Description  |
|-------|--------------|
| DriverPerformanceList()  | Initializes a new instance of a DriverPerformanceList.  |


## Methods

| Name  | Description  |
|-------|--------------|
| GetByDriverNumber(Byte *driverNumber*)  | Gets the performance level for the driver with the specified number.<br />*driverNumber*: Number of driver to get performance level for.<br />  |
| SetByDriverNumber(Byte *driverNumber*, Byte *performanceLevel*)  | Set the performance level for the driver with the specified number.<br />*driverNumber*: Number of driver to get performance level for.<br />*performanceLevel*: Byte value representing the performance. Lower value means higher performance.<br />  |
| GetEnumerator()  | Returns an enumerator that iterates through the collection.  |
| ToArray()  | Returns driver performance levels as an array.  |


