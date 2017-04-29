# Car

A Car represents a car with its various colors.

A car consists of a number of panels, each of which has a color index referencing
the color in the palette that it is painted in.


## Constructors

| Name  | Description  |
|-------|--------------|
| Car()  | Initializes a new instance of a Car with all colors set to 0 (black).  |
| Car(Byte[] *carColorBytes*)  | Initializes a new instance of a Car with the specified colors.<br />*carColorBytes*: Initializes a new instance of a Car with the specified colors.  |


## Properties

| Name  | Description  |
|-------|--------------|
| FrontAndRearWing  | Gets or sets the color of the front and rear wing elements.  |
| FrontWingEndplate  | Gets or sets the color of the endplate of the front wing.  |
| RearWingSide  | Gets or sets the color of the side of the rear wing.  |
| Sidepod  | Gets or sets the color of the vertical part of the sidepod.  |
| SidepodTop  | Gets or sets the color of the top part of the sidepod.  |
| EngineCover  | Gets or sets the color of the main upper part of the engine cover.  |
| EngineCoverSide  | Gets or sets the color of the lower part of the engine cover.  |
| EngineCoverRear  | Gets or sets the color of the rear, lower part of the engine cover.  |
| CockpitFront  | Gets or sets the color of the part just in front of the cockpit opening.  |
| CockpitSide  | Gets or sets the color of the side of the cockpit.  |
| NoseTop  | Gets or sets the color of the top part of the nose-cone.  |
| NoseAngle  | Gets or sets the color of the angled part between the top and side of the nose-cone.  |
| NoseSide  | Gets or sets the color of the side of the nose-cone.  |


## Methods

| Name  | Description  |
|-------|--------------|
| Copy(Car *source*)  | Copies all colors from the source into this Car.<br />*source*: Source Car to copy colors from.<br />  |


