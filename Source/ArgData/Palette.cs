using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ArgData.Entities;

namespace ArgData
{
    /// <summary>
    /// Color palette for F1GP.
    /// </summary>
    public static class Palette
    {
        private static Dictionary<int, Color> _palette;
        private static List<List<byte>> _ranges;

        /// <summary>
        /// Get the color at the specified index in the palette.
        /// </summary>
        /// <param name="index">Index of color to fetch.</param>
        /// <returns>Color.</returns>
        public static Color GetColor(byte index)
        {
            return _palette[index];
        }

        static Palette()
        {
            SetupPalette();
            SetupRanges();
        }

        private static void SetupPalette()
        {
            _palette = new Dictionary<int, Color>
            {
                {0, Color.FromArgb(0, 0, 0)},
                {1, Color.FromArgb(190, 190, 190)},
                {2, Color.FromArgb(198, 72, 58)},
                {3, Color.FromArgb(255, 239, 0)},
                {4, Color.FromArgb(0, 132, 0)},
                {5, Color.FromArgb(61, 15, 160)},
                {6, Color.FromArgb(87, 157, 255)},
                {7, Color.FromArgb(125, 125, 125)},
                {8, Color.FromArgb(255, 255, 255)},
                {9, Color.FromArgb(255, 80, 58)},
                {10, Color.FromArgb(93, 93, 93)},
                {11, Color.FromArgb(0, 78, 0)},
                {12, Color.FromArgb(158, 158, 158)},
                {13, Color.FromArgb(190, 190, 190)},
                {14, Color.FromArgb(223, 223, 223)},
                {15, Color.FromArgb(0, 105, 0)},
                {16, Color.FromArgb(73, 123, 45)},
                {17, Color.FromArgb(77, 127, 49)},
                {18, Color.FromArgb(81, 131, 53)},
                {19, Color.FromArgb(85, 135, 57)},
                {20, Color.FromArgb(90, 136, 66)},
                {21, Color.FromArgb(98, 140, 80)},
                {22, Color.FromArgb(110, 143, 90)},
                {23, Color.FromArgb(118, 147, 103)},
                {24, Color.FromArgb(130, 130, 134)},
                {25, Color.FromArgb(134, 134, 138)},
                {26, Color.FromArgb(138, 138, 142)},
                {27, Color.FromArgb(142, 142, 146)},
                {28, Color.FromArgb(142, 142, 146)},
                {29, Color.FromArgb(146, 146, 150)},
                {30, Color.FromArgb(150, 150, 150)},
                {31, Color.FromArgb(154, 154, 150)},
                {32, Color.FromArgb(0, 0, 0)},
                {33, Color.FromArgb(28, 28, 28)},
                {34, Color.FromArgb(44, 44, 44)},
                {35, Color.FromArgb(60, 60, 60)},
                {36, Color.FromArgb(77, 77, 77)},
                {37, Color.FromArgb(93, 93, 93)},
                {38, Color.FromArgb(109, 109, 109)},
                {39, Color.FromArgb(125, 125, 125)},
                {40, Color.FromArgb(142, 142, 142)},
                {41, Color.FromArgb(158, 158, 158)},
                {42, Color.FromArgb(174, 174, 174)},
                {43, Color.FromArgb(190, 190, 190)},
                {44, Color.FromArgb(207, 207, 207)},
                {45, Color.FromArgb(223, 223, 223)},
                {46, Color.FromArgb(239, 239, 239)},
                {47, Color.FromArgb(255, 255, 255)},
                {48, Color.FromArgb(0, 0, 0)},
                {49, Color.FromArgb(29, 3, 7)},
                {50, Color.FromArgb(46, 5, 10)},
                {51, Color.FromArgb(64, 6, 12)},
                {52, Color.FromArgb(81, 8, 15)},
                {53, Color.FromArgb(98, 10, 14)},
                {54, Color.FromArgb(116, 11, 19)},
                {55, Color.FromArgb(133, 13, 19)},
                {56, Color.FromArgb(151, 16, 23)},
                {57, Color.FromArgb(168, 16, 22)},
                {58, Color.FromArgb(184, 19, 26)},
                {59, Color.FromArgb(202, 20, 26)},
                {60, Color.FromArgb(221, 22, 30)},
                {61, Color.FromArgb(238, 24, 30)},
                {62, Color.FromArgb(254, 26, 33)},
                {63, Color.FromArgb(255, 28, 35)},
                {64, Color.FromArgb(0, 0, 0)},
                {65, Color.FromArgb(7, 24, 6)},
                {66, Color.FromArgb(14, 39, 14)},
                {67, Color.FromArgb(17, 53, 19)},
                {68, Color.FromArgb(20, 69, 22)},
                {69, Color.FromArgb(19, 81, 22)},
                {70, Color.FromArgb(23, 96, 26)},
                {71, Color.FromArgb(22, 108, 26)},
                {72, Color.FromArgb(25, 124, 29)},
                {73, Color.FromArgb(23, 137, 29)},
                {74, Color.FromArgb(23, 151, 30)},
                {75, Color.FromArgb(26, 165, 33)},
                {76, Color.FromArgb(25, 179, 32)},
                {77, Color.FromArgb(25, 192, 32)},
                {78, Color.FromArgb(24, 206, 32)},
                {79, Color.FromArgb(22, 220, 31)},
                {80, Color.FromArgb(0, 0, 0)},
                {81, Color.FromArgb(8, 2, 27)},
                {82, Color.FromArgb(11, 3, 44)},
                {83, Color.FromArgb(12, 4, 61)},
                {84, Color.FromArgb(16, 5, 78)},
                {85, Color.FromArgb(15, 7, 95)},
                {86, Color.FromArgb(19, 8, 111)},
                {87, Color.FromArgb(20, 9, 127)},
                {88, Color.FromArgb(23, 11, 145)},
                {89, Color.FromArgb(23, 12, 161)},
                {90, Color.FromArgb(28, 13, 177)},
                {91, Color.FromArgb(27, 14, 193)},
                {92, Color.FromArgb(31, 16, 211)},
                {93, Color.FromArgb(31, 16, 226)},
                {94, Color.FromArgb(35, 17, 242)},
                {95, Color.FromArgb(34, 18, 255)},
                {96, Color.FromArgb(0, 0, 0)},
                {97, Color.FromArgb(28, 26, 7)},
                {98, Color.FromArgb(43, 42, 11)},
                {99, Color.FromArgb(60, 57, 10)},
                {100, Color.FromArgb(76, 74, 14)},
                {101, Color.FromArgb(93, 88, 13)},
                {102, Color.FromArgb(109, 103, 16)},
                {103, Color.FromArgb(125, 119, 17)},
                {104, Color.FromArgb(142, 135, 21)},
                {105, Color.FromArgb(159, 149, 20)},
                {106, Color.FromArgb(175, 165, 24)},
                {107, Color.FromArgb(191, 180, 24)},
                {108, Color.FromArgb(209, 197, 27)},
                {109, Color.FromArgb(224, 212, 27)},
                {110, Color.FromArgb(241, 226, 30)},
                {111, Color.FromArgb(255, 242, 30)},
                {112, Color.FromArgb(115, 23, 0)},
                {113, Color.FromArgb(131, 45, 0)},
                {114, Color.FromArgb(149, 37, 0)},
                {115, Color.FromArgb(165, 53, 0)},
                {116, Color.FromArgb(182, 68, 0)},
                {117, Color.FromArgb(197, 84, 0)},
                {118, Color.FromArgb(215, 99, 0)},
                {119, Color.FromArgb(232, 113, 0)},
                {120, Color.FromArgb(45, 17, 0)},
                {121, Color.FromArgb(61, 39, 0)},
                {122, Color.FromArgb(81, 31, 0)},
                {123, Color.FromArgb(96, 46, 0)},
                {124, Color.FromArgb(112, 61, 0)},
                {125, Color.FromArgb(128, 77, 0)},
                {126, Color.FromArgb(146, 92, 0)},
                {127, Color.FromArgb(162, 107, 0)},
                {128, Color.FromArgb(66, 147, 255)},
                {129, Color.FromArgb(70, 152, 255)},
                {130, Color.FromArgb(74, 156, 255)},
                {131, Color.FromArgb(78, 159, 255)},
                {132, Color.FromArgb(82, 164, 255)},
                {133, Color.FromArgb(87, 167, 255)},
                {134, Color.FromArgb(91, 171, 255)},
                {135, Color.FromArgb(94, 174, 255)},
                {136, Color.FromArgb(17, 60, 19)},
                {137, Color.FromArgb(20, 74, 23)},
                {138, Color.FromArgb(16, 65, 18)},
                {139, Color.FromArgb(20, 71, 22)},
                {140, Color.FromArgb(19, 79, 22)},
                {141, Color.FromArgb(249, 235, 42)},
                {142, Color.FromArgb(241, 228, 61)},
                {143, Color.FromArgb(231, 222, 73)},
                {144, Color.FromArgb(33, 76, 35)},
                {145, Color.FromArgb(60, 101, 76)},
                {146, Color.FromArgb(72, 111, 87)},
                {147, Color.FromArgb(87, 119, 100)},
                {148, Color.FromArgb(49, 99, 64)},
                {149, Color.FromArgb(61, 105, 76)},
                {150, Color.FromArgb(76, 117, 90)},
                {151, Color.FromArgb(91, 126, 104)},
                {152, Color.FromArgb(97, 141, 111)},
                {153, Color.FromArgb(111, 155, 125)},
                {154, Color.FromArgb(125, 169, 139)},
                {155, Color.FromArgb(140, 184, 154)},
                {156, Color.FromArgb(154, 198, 168)},
                {157, Color.FromArgb(168, 212, 182)},
                {158, Color.FromArgb(213, 213, 110)},
                {159, Color.FromArgb(196, 241, 211)},
                {160, Color.FromArgb(60, 50, 211)},
                {161, Color.FromArgb(70, 66, 207)},
                {162, Color.FromArgb(84, 80, 207)},
                {163, Color.FromArgb(96, 93, 202)},
                {164, Color.FromArgb(206, 56, 71)},
                {165, Color.FromArgb(201, 72, 82)},
                {166, Color.FromArgb(201, 84, 97)},
                {167, Color.FromArgb(195, 96, 108)},
                {168, Color.FromArgb(142, 147, 111)},
                {169, Color.FromArgb(156, 161, 125)},
                {170, Color.FromArgb(170, 175, 139)},
                {171, Color.FromArgb(184, 188, 153)},
                {172, Color.FromArgb(199, 203, 167)},
                {173, Color.FromArgb(213, 217, 181)},
                {174, Color.FromArgb(227, 231, 195)},
                {175, Color.FromArgb(241, 245, 210)},
                {176, Color.FromArgb(148, 154, 135)},
                {177, Color.FromArgb(159, 165, 147)},
                {178, Color.FromArgb(173, 179, 161)},
                {179, Color.FromArgb(192, 196, 170)},
                {180, Color.FromArgb(202, 208, 185)},
                {181, Color.FromArgb(213, 218, 204)},
                {182, Color.FromArgb(226, 232, 215)},
                {183, Color.FromArgb(240, 246, 225)},
                {184, Color.FromArgb(149, 155, 147)},
                {185, Color.FromArgb(159, 166, 161)},
                {186, Color.FromArgb(173, 180, 172)},
                {187, Color.FromArgb(192, 197, 185)},
                {188, Color.FromArgb(210, 210, 198)},
                {189, Color.FromArgb(223, 222, 210)},
                {190, Color.FromArgb(239, 238, 222)},
                {191, Color.FromArgb(255, 254, 238)},
                {192, Color.FromArgb(109, 117, 25)},
                {193, Color.FromArgb(125, 133, 41)},
                {194, Color.FromArgb(142, 151, 57)},
                {195, Color.FromArgb(158, 166, 74)},
                {196, Color.FromArgb(174, 182, 90)},
                {197, Color.FromArgb(190, 198, 106)},
                {198, Color.FromArgb(207, 216, 122)},
                {199, Color.FromArgb(223, 231, 139)},
                {200, Color.FromArgb(145, 95, 58)},
                {201, Color.FromArgb(162, 112, 75)},
                {202, Color.FromArgb(178, 128, 91)},
                {203, Color.FromArgb(194, 144, 107)},
                {204, Color.FromArgb(210, 160, 123)},
                {205, Color.FromArgb(227, 177, 140)},
                {206, Color.FromArgb(243, 193, 156)},
                {207, Color.FromArgb(255, 209, 172)},
                {208, Color.FromArgb(0, 3, 4)},
                {209, Color.FromArgb(0, 7, 7)},
                {210, Color.FromArgb(0, 14, 15)},
                {211, Color.FromArgb(0, 21, 23)},
                {212, Color.FromArgb(0, 28, 31)},
                {213, Color.FromArgb(0, 36, 39)},
                {214, Color.FromArgb(0, 43, 48)},
                {215, Color.FromArgb(0, 50, 55)},
                {216, Color.FromArgb(0, 58, 65)},
                {217, Color.FromArgb(0, 62, 68)},
                {218, Color.FromArgb(0, 68, 77)},
                {219, Color.FromArgb(0, 76, 84)},
                {220, Color.FromArgb(0, 84, 92)},
                {221, Color.FromArgb(0, 90, 101)},
                {222, Color.FromArgb(0, 98, 109)},
                {223, Color.FromArgb(0, 106, 116)},
                {224, Color.FromArgb(0, 112, 125)},
                {225, Color.FromArgb(0, 117, 131)},
                {226, Color.FromArgb(0, 123, 138)},
                {227, Color.FromArgb(0, 131, 146)},
                {228, Color.FromArgb(0, 138, 154)},
                {229, Color.FromArgb(0, 145, 162)},
                {230, Color.FromArgb(0, 153, 170)},
                {231, Color.FromArgb(0, 159, 178)},
                {232, Color.FromArgb(98, 179, 255)},
                {233, Color.FromArgb(102, 182, 255)},
                {234, Color.FromArgb(106, 186, 255)},
                {235, Color.FromArgb(110, 190, 255)},
                {236, Color.FromArgb(114, 195, 255)},
                {237, Color.FromArgb(119, 198, 255)},
                {238, Color.FromArgb(123, 202, 255)},
                {239, Color.FromArgb(127, 205, 255)},
                {240, Color.FromArgb(27, 32, 43)},
                {241, Color.FromArgb(31, 36, 47)},
                {242, Color.FromArgb(35, 40, 56)},
                {243, Color.FromArgb(38, 47, 59)},
                {244, Color.FromArgb(43, 51, 69)},
                {245, Color.FromArgb(51, 56, 72)},
                {246, Color.FromArgb(55, 65, 80)},
                {247, Color.FromArgb(64, 70, 88)},
                {248, Color.FromArgb(68, 77, 92)},
                {249, Color.FromArgb(72, 80, 100)},
                {250, Color.FromArgb(80, 89, 104)},
                {251, Color.FromArgb(84, 92, 112)},
                {252, Color.FromArgb(92, 98, 116)},
                {253, Color.FromArgb(96, 104, 124)},
                {254, Color.FromArgb(104, 114, 133)},
                {255, Color.FromArgb(255, 255, 255)}
            };
        }

        private static void SetupRanges()
        {
            _ranges = new List<List<byte>>
            {
                new List<byte> {0},
                new List<byte> {1},
                new List<byte> {2},
                new List<byte> {3},
                new List<byte> {4},
                new List<byte> {5},
                new List<byte> {6},
                new List<byte> {7},
                new List<byte> {8},
                new List<byte> {9},
                new List<byte> {10},
                new List<byte> {11},
                new List<byte> {12, 13, 14},
                new List<byte> {15},
                CreateRange(16, 23),
                CreateRange(24, 31),
                CreateRange(32, 47),
                CreateRange(48, 63),
                CreateRange(64, 79),
                CreateRange(80, 95),
                CreateRange(96, 111),
                CreateRange(112, 119),
                CreateRange(120, 127),
                CreateRange(128, 135),
                CreateRange(136, 140),
                CreateReverseRange(141, 143),
                CreateRange(144, 159),
                CreateRange(160, 163),
                CreateRange(164, 167),
                CreateRange(168, 175),
                CreateRange(176, 183),
                CreateRange(184, 191),
                CreateRange(192, 199),
                CreateRange(200, 207),
                CreateRange(208, 231),
                CreateRange(232, 239),
                CreateRange(240, 255)
            };
        }

        private static List<byte> CreateRange(int from, int to)
        {
            var range = new List<byte>();

            for (int i = from; i <= to; i++)
            {
                range.Add((byte)i);
            }

            return range;
        }

        private static List<byte> CreateReverseRange(int from, int to)
        {
            var range = new List<byte>();

            for (int i = to; i >= from; i--)
            {
                range.Add((byte)i);
            }

            return range;
        }

        /// <summary>
        /// Gets the next brightest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get brighter color for.</param>
        /// <returns>The next brightest color in the color range. If there is no brighter color, the specified color is returned.</returns>
        public static byte GetBrighterColor(byte index)
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
        public static byte GetDarkerColor(byte index)
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
        public static ReadOnlyList<byte> GetRangeForColor(byte index)
        {
            return new ReadOnlyList<byte>(_ranges.FirstOrDefault(r => r.Contains(index)));
        }
    }
}
