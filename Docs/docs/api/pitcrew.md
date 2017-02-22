# PitCrew

Represents the colors of the pit crew.



## Constructors

| Name            | Description        |
|-----------------|--------------------|
| PitCrew() |  Initializes a new instance of a PitCrew with all colors set to 0 (black). 
| PitCrew(Byte[] pitCrewColorBytes) |  Initializes a new instance of a PitCrew with the specified colors.<br />*pitCrewColorBytes:* The colors to set. Must be exactly 16.<br /> 


## Properties

| Name            | Description        |
|-----------------|--------------------|
| PantsPrimary   |  Gets or sets the primary pants color. 
| PantsSecondary   |  Gets or sets the secondary pants color. 
| ShirtPrimary   |  Gets or sets the primary shirt color. 
| ShirtSecondary   |  Gets or sets the secondary shirt color. 
| Socks   |  Gets or sets the color of the socks. 


## Methods

| Name            | Description        |
|-----------------|--------------------|
| Copy(Entities.PitCrew source)   |  Copies all colors from the source into this PitCrew.<br />*source:* Source PitCrew to copy colors from.<br /> 


