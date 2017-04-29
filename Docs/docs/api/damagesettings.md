# DamageSettings

Represents the various damage settings in the game.

## Constructors

| Name  | Description  |
|-------|--------------|
| DamageSettings()  |   |


## Properties

| Name  | Description  |
|-------|--------------|
| RetireAfterHittingWall  | Gets or sets how much damage needs to be done before a car retires from a crash with the wall.
Lower value means less damage is needed. The default value is 7424.  |
| RetireAfterHittingOtherCar  | Gets or sets how much damage needs to be done before a car retires from a crash with another car.
Lower value means less damage is needed. The default value is 8192.  |
| DamageAfterHittingWall  | Gets or sets how much damage needs to be done before a wing breaks after crashing into the wall.
Lower value means less damage is needed. The default value is 1792.  |
| DamageAfterHittingOtherCar  | Gets or sets how much damage needs to be done before a wing breaks after crashing into another car.
Lower value means less damage is needed. The default value is 1792.  |
| RetiredCarsRemovedAfterSeconds  | Gets or sets how many seconds it takes before retired cars are removed from the track.  |
| YellowFlagsForStationaryCarsAfterSeconds  | Gets or sets how many seconds it takes before marshalls show yellow flags for cars that
are stationary on track.  |
| IsValid  | Whether the specified damage setting values are within allowed ranges.  |


