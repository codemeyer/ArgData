using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ArgData.Entities;
using ArgData.Internals;

namespace ArgData
{
    /// <summary>
    /// Represents a palette of 256 colors used in various places in F1GP.
    /// </summary>
    public class Palette
    {
        internal Palette(List<Color> colors)
        {
            _colors = colors;
        }

        private readonly List<Color> _colors;

        /// <summary>
        /// Returns an instance of a PaletteWithRanges that represents
        /// the color palette that is used when driving in the game.
        /// </summary>
        /// <returns>Palette.</returns>
        public static PaletteWithRanges CreateDrivingPalette()
        {
            return PaletteData.CreateDrivingPalette();
        }

        /// <summary>
        /// Returns an instance of a Palette that represents the color palette
        /// that is used in the driver selection menu.
        /// </summary>
        /// <returns>Palette.</returns>
        public static Palette CreateMenuPalette()
        {
            return PaletteData.CreateMenuPalette();
        }

        /// <summary>
        /// Get the color at the specified index in the palette.
        /// </summary>
        /// <param name="index">Index of color to fetch.</param>
        /// <returns>Color.</returns>
        public Color GetColor(byte index)
        {
            return _colors[index];
        }

        /// <summary>
        /// Get the color at the specified index in the palette.
        /// </summary>
        /// <param name="index">Index of color to fetch.</param>
        /// <returns>Color.</returns>
        public Color GetColor(int index)
        {
            if (index < 0 || index > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 255.");
            }

            return _colors[index];
        }
    }

    /// <summary>
    /// Represents a palette of 256 colors used in various places in F1GP,
    /// including a set of color ranges.
    /// </summary>
    public class PaletteWithRanges : Palette
    {
        internal PaletteWithRanges(List<Color> colors, List<List<byte>> ranges)
            : base(colors)
        {
            _ranges = ranges;
        }

        private readonly List<List<byte>> _ranges;

        /// <summary>
        /// Gets the next brightest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get brighter color for.</param>
        /// <returns>The next brightest color in the color range. If there is no brighter color, the specified color is returned.</returns>
        public byte GetBrighterColor(int index)
        {
            if (index < 0 || index > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 255.");
            }

            return GetBrighterColor((byte)index);
        }

        /// <summary>
        /// Gets the next brightest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get brighter color for.</param>
        /// <returns>The next brightest color in the color range. If there is no brighter color, the specified color is returned.</returns>
        public byte GetBrighterColor(byte index)
        {
            ReadOnlyList<byte> range = GetRangeForColor(index);
            int indexInRange = range.List.IndexOf(index);

            if (indexInRange < range.Count - 1)
            {
                return range[indexInRange + 1];
            }

            return index;
        }

        /// <summary>
        /// Gets the next darkest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get darker color for.</param>
        /// <returns>The next darkest color in the color range. If there is no darkest color, the specified color is returned.</returns>
        public byte GetDarkerColor(int index)
        {
            if (index < 0 || index > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 255.");
            }

            return GetDarkerColor((byte)index);
        }

        /// <summary>
        /// Gets the next darkest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get darker color for.</param>
        /// <returns>The next darkest color in the color range. If there is no darkest color, the specified color is returned.</returns>
        public byte GetDarkerColor(byte index)
        {
            ReadOnlyList<byte> range = GetRangeForColor(index);
            int indexInRange = range.List.IndexOf(index);

            if (indexInRange > 0)
            {
                return range[indexInRange - 1];
            }

            return index;
        }

        /// <summary>
        /// Gets the range of colors for the specified color.
        /// </summary>
        /// <param name="index">Index of color to get range for.</param>
        /// <returns>The color range as a list of indexes.</returns>
        public ReadOnlyList<byte> GetRangeForColor(byte index)
        {
            return new ReadOnlyList<byte>(_ranges.FirstOrDefault(r => r.Contains(index)));
        }
    }
}
