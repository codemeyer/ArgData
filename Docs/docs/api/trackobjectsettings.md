# TrackObjectSettings

Represents an instance of a 3D object with related settings.

## Constructors

| Name  | Description  |
|-------|--------------|
| TrackObjectSettings()  |   |


## Properties

| Name  | Description  |
|-------|--------------|
| Id  | Gets the Id of the object.

When this is 17 or greater, it refers to the index in the track object shapes.  |
| Id2  | Gets the Id2 value. Unknown functionality.  |
| DetailLevel  | Gets the detail level that the item appears at. Is actually a Flag value.  |
| DistanceFromTrack  | Gets the distance from the center of the track. Negative values indicate left side of track.  |
| AngleX  | Gets the X angle of the object.

When Id is 5, 13 (and others) this refers to the Id of internal "billboard" objects.  |
| AngleY  | Gets the Y angle of the object.  |
| Unknown  | Gets the Unknown value. Possibly color-related.  |
| Unknown2  | Gets the Unknown2 value. Possibly draw-depth related.  |
| Height  | Gets the height from the ground that the object is placed at.  |
| Offset  | Gets or sets the object shape offset (index * 16)  |


