# GpExeFile

Represents a GP.EXE file that will be read from or written to.



## Properties

| Name            | Description        |
|-----------------|--------------------|
| CarColorsPosition   |  Start position of car colors in the file. 
| ChanceOfRainPosition   |  Position of the value indicating the overall chance of rain at a race. 
| DriverNumbersPosition   |  Start position of driver numbers in the file. 
| DriverQualifyingPerformanceLevelsPosition   |  Start position of driver qualifying performance level values in the file. 
| DriverRacePerformanceLevelsPosition   |  Start position of driver race performance level values in the file. 
| ExePath   |  Gets the path to the GP.EXE file. 
| GeneralGripLevelPosition   |  Position of the general AI grip level. 
| HelmetColorsPosition   |  Start position of helmet colors in the file. 
| PitCrewColorsPosition   |  Start position of pit crew colors in the file. 
| PlayerHorsepowerPosition   |  Position of player horsepower value in the file. 
| RainAtFirstTrackPosition   |  Position of the value indicating the change of rain in the first race. 
| TeamHorsepowerPosition   |  Start position of team horsepower values in the file. 


## Methods

| Name            | Description        |
|-----------------|--------------------|
| At(String exePath)   |  Gets a reference to the GP.EXE file at the specified location.<br />*exePath:* <br /> 
| GetFileInfo(String exePath)   |  Gets info about the specified F1GP executable.<br />*exePath:* Path of the file to get info about.<br /> 


