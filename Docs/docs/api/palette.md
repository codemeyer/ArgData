# Palette

Color palette for F1GP.

The palette consists of 256 different colors.
For more details, see the [Palette Colors](./palette-colors) page.


## Methods

| Name  | Description  |
|-------|--------------|
| GetColor(Int32 *index*)  | Get the color at the specified index in the palette.<br />*index*: <br />  |
| GetBrighterColor(Int32 *index*)  | Gets the next brightest color in the color range of the specified color.<br />*index*: Index of color to get brighter color for.<br />  |
| GetDarkerColor(Int32 *index*)  | Gets the next darkest color in the color range of the specified color.<br />*index*: Index of color to get darker color for.<br />  |
| GetRangeForColor(Int32 *index*)  | Gets the range of colors for the specified color.<br />*index*: Index of color to get range for.<br />  |

