# TrackSection

Represents a small section of a track.

## Constructors

| Name  | Description  |
|-------|--------------|
| TrackSection()  | Initializes a new instance of a TrackSection.  |


## Properties

| Name  | Description  |
|-------|--------------|
| Length  | Gets or sets the length of the section. 1 unit is 16 feet (approx 4.87 meters).  |
| Commands  | Gets the list of TrackCommands.  |
| Curvature  | Gets or sets the curvature of the track. Positive numbers means a right turn, negative numbers means a left turn. Smaller numbers indicate a tighter turn.  |
| Height  | Gets or sets the height change that occurs in the section.  |
| LeftVergeWidth  | Gets or sets the width of the left verge.  |
| RightVergeWidth  | Gets or sets the width of the right verge.  |
| PitLaneEntrance  | Get or sets whether the PitLaneEntrance flag should be set for the section.  |
| PitLaneExit  | Get or sets whether the PitLaneExit flag should be set for the section.  |
| KerbHeight  | Gets or sets the height of the kerb in the section, if there is one set with the HasLeftKerb or HasRightKerb flags.  |
| HasLeftKerb  | Gets or sets whether there is a kerb on the left side of the track in the section.  |
| HasRightKerb  | Gets or sets whether there is a kerb on the right side of the track in the section.  |
| RoadSigns  | Gets or sets whether 300/200/100 signs should appear before the section.  |
| RoadSignArrow  | Gets or sets whether an arrow sign should appear before the section.  |
| RoadSignArrow100  | Gets or sets whether an arrow and 100 sign should appear before the section.  |
| BridgedRightFence  | Gets or sets whether the right fence should be bridged with the fence of the previous?next? section.  |
| BridgedLeftFence  | Gets or sets whether the left fence should be bridged with the fence of the previous?next? section.  |
| RemoveRightWall  | Gets or sets whether the right wall of the section should be removed/invisible.  |
| RemoveLeftWall  | Gets or sets whether the right wall of the section should be removed/invisible.  |
| Unknown1  | Gets or sets the Unknown1 flag (0x100). Not used in any default track, probably has no use.  |
| Unknown2  | Gets or sets the Unknown2 flag (0x200). Not used in any default track, probably has no use.  |
| Unknown3  | Gets or sets the Unknown3 flag (0x4000).  |
| Unknown4  | Gets or sets the Unknown4 flag (0x8000). Not used in any default track, probably has no use.  |


