# Setup

Single car setup.

## Constructors

| Name  | Description  |
|-------|--------------|
| Setup()  |   |


## Properties

| Name  | Description  |
|-------|--------------|
| FrontWing  | Gets or sets the front wing setting. Allowed values between 0 and 64.  |
| RearWing  | Gets or sets the rear wing setting. Allowed values between 0 and 64.  |
| GearRatio1  | Gets or sets the ratio of the first gear. Must be 16 or greater, and less than GearRatio2.  |
| GearRatio2  | Gets or sets the ratio of the second gear. Must be greater than GearRatio1 and less than GearRatio3.  |
| GearRatio3  | Gets or sets the ratio of the third gear. Must be greater than GearRatio2 and less than GearRatio4.  |
| GearRatio4  | Gets or sets the ratio of the fourth gear. Must be greater than GearRatio3 and less than GearRatio5.  |
| GearRatio5  | Gets or sets the ratio of the fifth gear. Must be greater than GearRatio4 and less than GearRatio6.  |
| GearRatio6  | Gets or sets the ratio of the sixth gear. Must be greater than GearRatio5 and less than or equal to 80.  |
| TyreCompound  | Gets or sets the tyre compound.  |
| BrakeBalance  | Gets or sets the brake balance value. Allowed values between -32 (Rear) and 32 (Front).  |
| IsValid  | Whether the values currently entered in the setup are within allowed ranges.  |


## Methods

| Name  | Description  |
|-------|--------------|
| Copy(Setup *source*)  | Copies all setup values from the source into this Setup.<br />*source*: <br />  |


