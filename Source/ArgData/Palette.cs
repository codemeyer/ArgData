using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ArgData
{
    /// <summary>
    /// Color palette for F1GP.
    /// </summary>
    public static class Palette
    {
        private static Dictionary<int, Color> _palette;
        private static List<List<int>> _ranges;

        /// <summary>
        /// Get the color at the specified index in the palette.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Color GetColor(int index)
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
                {1, Color.FromArgb(188, 188, 188)},
                {2, Color.FromArgb(188, 60, 60)},
                {3, Color.FromArgb(252, 252, 0)},
                {4, Color.FromArgb(0, 156, 0)},
                {5, Color.FromArgb(60, 0, 156)},
                {6, Color.FromArgb(92, 156, 252)},
                {7, Color.FromArgb(124, 0, 0)},
                {8, Color.FromArgb(252, 252, 252)},
                {9, Color.FromArgb(252, 60, 60)},
                {10, Color.FromArgb(92, 92, 92)},
                {11, Color.FromArgb(0, 92, 0)},
                {12, Color.FromArgb(156, 156, 156)},
                {13, Color.FromArgb(188, 188, 188)},
                {14, Color.FromArgb(220, 220, 220)},
                {15, Color.FromArgb(0, 124, 0)},
                {16, Color.FromArgb(76, 136, 48)},
                {17, Color.FromArgb(80, 136, 52)},
                {18, Color.FromArgb(84, 140, 56)},
                {19, Color.FromArgb(88, 144, 60)},
                {20, Color.FromArgb(92, 144, 68)},
                {21, Color.FromArgb(100, 148, 80)},
                {22, Color.FromArgb(112, 148, 92)},
                {23, Color.FromArgb(120, 152, 104)},
                {24, Color.FromArgb(120, 120, 108)},
                {25, Color.FromArgb(124, 124, 112)},
                {26, Color.FromArgb(128, 128, 116)},
                {27, Color.FromArgb(132, 132, 120)},
                {28, Color.FromArgb(132, 132, 120)},
                {29, Color.FromArgb(136, 136, 128)},
                {30, Color.FromArgb(140, 140, 132)},
                {31, Color.FromArgb(144, 144, 140)},
                {32, Color.FromArgb(0, 0, 0)},
                {33, Color.FromArgb(28, 28, 28)},
                {34, Color.FromArgb(44, 44, 44)},
                {35, Color.FromArgb(60, 60, 60)},
                {36, Color.FromArgb(76, 76, 76)},
                {37, Color.FromArgb(92, 92, 92)},
                {38, Color.FromArgb(108, 108, 108)},
                {39, Color.FromArgb(124, 124, 124)},
                {40, Color.FromArgb(140, 140, 140)},
                {41, Color.FromArgb(156, 156, 156)},
                {42, Color.FromArgb(172, 172, 172)},
                {43, Color.FromArgb(188, 188, 188)},
                {44, Color.FromArgb(204, 204, 204)},
                {45, Color.FromArgb(220, 220, 220)},
                {46, Color.FromArgb(236, 236, 236)},
                {47, Color.FromArgb(252, 252, 252)},
                {48, Color.FromArgb(0, 0, 0)},
                {49, Color.FromArgb(28, 0, 8)},
                {50, Color.FromArgb(44, 0, 12)},
                {51, Color.FromArgb(60, 0, 12)},
                {52, Color.FromArgb(76, 0, 16)},
                {53, Color.FromArgb(92, 0, 16)},
                {54, Color.FromArgb(108, 0, 20)},
                {55, Color.FromArgb(124, 0, 20)},
                {56, Color.FromArgb(140, 0, 24)},
                {57, Color.FromArgb(156, 0, 24)},
                {58, Color.FromArgb(172, 0, 28)},
                {59, Color.FromArgb(188, 0, 28)},
                {60, Color.FromArgb(204, 0, 32)},
                {61, Color.FromArgb(220, 0, 32)},
                {62, Color.FromArgb(236, 0, 36)},
                {63, Color.FromArgb(252, 0, 36)},
                {64, Color.FromArgb(0, 0, 0)},
                {65, Color.FromArgb(8, 28, 0)},
                {66, Color.FromArgb(16, 44, 16)},
                {67, Color.FromArgb(20, 60, 20)},
                {68, Color.FromArgb(24, 76, 24)},
                {69, Color.FromArgb(24, 92, 24)},
                {70, Color.FromArgb(28, 108, 28)},
                {71, Color.FromArgb(28, 124, 28)},
                {72, Color.FromArgb(32, 140, 32)},
                {73, Color.FromArgb(32, 156, 32)},
                {74, Color.FromArgb(32, 172, 32)},
                {75, Color.FromArgb(36, 188, 36)},
                {76, Color.FromArgb(36, 204, 36)},
                {77, Color.FromArgb(36, 220, 36)},
                {78, Color.FromArgb(36, 236, 36)},
                {79, Color.FromArgb(36, 252, 36)},
                {80, Color.FromArgb(0, 0, 0)},
                {81, Color.FromArgb(8, 0, 28)},
                {82, Color.FromArgb(12, 0, 44)},
                {83, Color.FromArgb(12, 0, 60)},
                {84, Color.FromArgb(16, 0, 76)},
                {85, Color.FromArgb(16, 0, 92)},
                {86, Color.FromArgb(20, 0, 108)},
                {87, Color.FromArgb(20, 0, 124)},
                {88, Color.FromArgb(24, 0, 140)},
                {89, Color.FromArgb(24, 0, 156)},
                {90, Color.FromArgb(28, 0, 172)},
                {91, Color.FromArgb(28, 0, 188)},
                {92, Color.FromArgb(30, 0, 204)},
                {93, Color.FromArgb(32, 0, 220)},
                {94, Color.FromArgb(36, 0, 236)},
                {95, Color.FromArgb(36, 0, 252)},
                {96, Color.FromArgb(0, 0, 0)},
                {97, Color.FromArgb(28, 28, 8)},
                {98, Color.FromArgb(44, 44, 12)},
                {99, Color.FromArgb(60, 60, 12)},
                {100, Color.FromArgb(76, 76, 16)},
                {101, Color.FromArgb(92, 92, 16)},
                {102, Color.FromArgb(108, 108, 20)},
                {103, Color.FromArgb(124, 124, 24)},
                {104, Color.FromArgb(140, 140, 24)},
                {105, Color.FromArgb(156, 156, 24)},
                {106, Color.FromArgb(172, 172, 28)},
                {107, Color.FromArgb(188, 188, 28)},
                {108, Color.FromArgb(204, 204, 32)},
                {109, Color.FromArgb(220, 220, 32)},
                {110, Color.FromArgb(236, 236, 36)},
                {111, Color.FromArgb(252, 252, 36)},
                {112, Color.FromArgb(108, 16, 0)},
                {113, Color.FromArgb(124, 40, 0)},
                {114, Color.FromArgb(140, 28, 0)},
                {115, Color.FromArgb(156, 44, 0)},
                {116, Color.FromArgb(172, 60, 0)},
                {117, Color.FromArgb(188, 76, 0)},
                {118, Color.FromArgb(204, 92, 0)},
                {119, Color.FromArgb(220, 108, 0)},
                {120, Color.FromArgb(44, 16, 0)},
                {121, Color.FromArgb(60, 40, 0)},
                {122, Color.FromArgb(76, 28, 0)},
                {123, Color.FromArgb(92, 44, 0)},
                {124, Color.FromArgb(108, 60, 0)},
                {125, Color.FromArgb(124, 76, 0)},
                {126, Color.FromArgb(140, 92, 0)},
                {127, Color.FromArgb(156, 108, 0)},
                {128, Color.FromArgb(72, 148, 252)},
                {129, Color.FromArgb(76, 152, 252)},
                {130, Color.FromArgb(80, 156, 252)},
                {131, Color.FromArgb(84, 160, 252)},
                {132, Color.FromArgb(88, 164, 252)},
                {133, Color.FromArgb(92, 168, 252)},
                {134, Color.FromArgb(96, 172, 252)},
                {135, Color.FromArgb(100, 176, 252)},
                {136, Color.FromArgb(20, 68, 20)},
                {137, Color.FromArgb(24, 84, 24)},
                {138, Color.FromArgb(20, 72, 20)},
                {139, Color.FromArgb(24, 80, 24)},
                {140, Color.FromArgb(24, 88, 24)},
                {141, Color.FromArgb(244, 244, 48)},
                {142, Color.FromArgb(236, 236, 64)},
                {143, Color.FromArgb(228, 228, 76)},
                {144, Color.FromArgb(36, 84, 36)},
                {145, Color.FromArgb(52, 92, 52)},
                {146, Color.FromArgb(64, 104, 64)},
                {147, Color.FromArgb(80, 112, 80)},
                {148, Color.FromArgb(40, 92, 40)},
                {149, Color.FromArgb(52, 100, 52)},
                {150, Color.FromArgb(68, 112, 68)},
                {151, Color.FromArgb(84, 120, 84)},
                {152, Color.FromArgb(92, 140, 92)},
                {153, Color.FromArgb(108, 156, 108)},
                {154, Color.FromArgb(124, 172, 124)},
                {155, Color.FromArgb(140, 188, 140)},
                {156, Color.FromArgb(156, 204, 156)},
                {157, Color.FromArgb(172, 220, 172)},
                {158, Color.FromArgb(220, 220, 92)},
                {159, Color.FromArgb(204, 252, 204)},
                {160, Color.FromArgb(48, 16, 200)},
                {161, Color.FromArgb(60, 36, 196)},
                {162, Color.FromArgb(76, 52, 196)},
                {163, Color.FromArgb(88, 68, 192)},
                {164, Color.FromArgb(200, 16, 48)},
                {165, Color.FromArgb(196, 36, 60)},
                {166, Color.FromArgb(196, 52, 76)},
                {167, Color.FromArgb(192, 68, 88)},
                {168, Color.FromArgb(140, 140, 92)},
                {169, Color.FromArgb(156, 156, 108)},
                {170, Color.FromArgb(172, 172, 124)},
                {171, Color.FromArgb(188, 188, 140)},
                {172, Color.FromArgb(204, 204, 156)},
                {173, Color.FromArgb(220, 220, 172)},
                {174, Color.FromArgb(236, 236, 188)},
                {175, Color.FromArgb(252, 252, 236)},
                {176, Color.FromArgb(148, 148, 120)},
                {177, Color.FromArgb(160, 160, 132)},
                {178, Color.FromArgb(176, 176, 148)},
                {179, Color.FromArgb(196, 196, 160)},
                {180, Color.FromArgb(208, 208, 176)},
                {181, Color.FromArgb(220, 220, 196)},
                {182, Color.FromArgb(236, 236, 208)},
                {183, Color.FromArgb(252, 252, 208)},
                {184, Color.FromArgb(148, 148, 132)},
                {185, Color.FromArgb(160, 160, 148)},
                {186, Color.FromArgb(176, 176, 160)},
                {187, Color.FromArgb(196, 196, 176)},
                {188, Color.FromArgb(208, 208, 196)},
                {189, Color.FromArgb(220, 220, 208)},
                {190, Color.FromArgb(236, 236, 220)},
                {191, Color.FromArgb(252, 252, 236)},
                {192, Color.FromArgb(108, 124, 28)},
                {193, Color.FromArgb(124, 140, 44)},
                {194, Color.FromArgb(140, 156, 60)},
                {195, Color.FromArgb(156, 172, 76)},
                {196, Color.FromArgb(172, 188, 92)},
                {197, Color.FromArgb(188, 204, 108)},
                {198, Color.FromArgb(204, 220, 124)},
                {199, Color.FromArgb(220, 236, 140)},
                {200, Color.FromArgb(140, 92, 60)},
                {201, Color.FromArgb(156, 108, 76)},
                {202, Color.FromArgb(172, 124, 96)},
                {203, Color.FromArgb(188, 140, 108)},
                {204, Color.FromArgb(204, 156, 124)},
                {205, Color.FromArgb(220, 172, 140)},
                {206, Color.FromArgb(236, 188, 156)},
                {207, Color.FromArgb(252, 204, 172)},
                {208, Color.FromArgb(0, 4, 0)},
                {209, Color.FromArgb(0, 8, 8)},
                {210, Color.FromArgb(0, 16, 16)},
                {211, Color.FromArgb(0, 24, 24)},
                {212, Color.FromArgb(0, 32, 32)},
                {213, Color.FromArgb(0, 40, 40)},
                {214, Color.FromArgb(0, 48, 48)},
                {215, Color.FromArgb(0, 56, 56)},
                {216, Color.FromArgb(0, 64, 64)},
                {217, Color.FromArgb(0, 68, 68)},
                {218, Color.FromArgb(0, 76, 76)},
                {219, Color.FromArgb(0, 84, 84)},
                {220, Color.FromArgb(0, 92, 92)},
                {221, Color.FromArgb(0, 100, 100)},
                {222, Color.FromArgb(0, 108, 108)},
                {223, Color.FromArgb(0, 116, 116)},
                {224, Color.FromArgb(0, 124, 124)},
                {225, Color.FromArgb(0, 128, 128)},
                {226, Color.FromArgb(0, 136, 136)},
                {227, Color.FromArgb(0, 144, 144)},
                {228, Color.FromArgb(0, 152, 152)},
                {229, Color.FromArgb(0, 160, 160)},
                {230, Color.FromArgb(0, 168, 168)},
                {231, Color.FromArgb(0, 176, 176)},
                {232, Color.FromArgb(104, 180, 252)},
                {233, Color.FromArgb(108, 184, 252)},
                {234, Color.FromArgb(112, 188, 252)},
                {235, Color.FromArgb(116, 192, 252)},
                {236, Color.FromArgb(120, 196, 252)},
                {237, Color.FromArgb(124, 200, 252)},
                {238, Color.FromArgb(128, 204, 252)},
                {239, Color.FromArgb(132, 208, 252)},
                {240, Color.FromArgb(28, 32, 44)},
                {241, Color.FromArgb(32, 36, 48)},
                {242, Color.FromArgb(36, 40, 56)},
                {243, Color.FromArgb(40, 48, 60)},
                {244, Color.FromArgb(44, 52, 68)},
                {245, Color.FromArgb(52, 56, 72)},
                {246, Color.FromArgb(56, 64, 80)},
                {247, Color.FromArgb(64, 68, 88)},
                {248, Color.FromArgb(68, 76, 92)},
                {249, Color.FromArgb(72, 80, 100)},
                {250, Color.FromArgb(80, 88, 104)},
                {251, Color.FromArgb(84, 92, 112)},
                {252, Color.FromArgb(92, 96, 116)},
                {253, Color.FromArgb(96, 104, 124)},
                {254, Color.FromArgb(104, 112, 132)},
                {255, Color.FromArgb(252, 252, 252)}
            };
        }

        private static void SetupRanges()
        {
            _ranges = new List<List<int>>
            {
                new List<int> {0},
                new List<int> {1},
                new List<int> {2},
                new List<int> {3},
                new List<int> {4},
                new List<int> {5},
                new List<int> {6},
                new List<int> {7},
                new List<int> {8},
                new List<int> {9},
                new List<int> {10},
                new List<int> {11},
                new List<int> {12, 13, 14},
                new List<int> {15},
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

        private static List<int> CreateRange(int from, int to)
        {
            var range = new List<int>();

            for (int i = from; i <= to; i++)
            {
                range.Add(i);
            }

            return range;
        }

        private static List<int> CreateReverseRange(int from, int to)
        {
            var range = new List<int>();

            for (int i = to; i >= from; i--)
            {
                range.Add(i);
            }

            return range;
        }

        /// <summary>
        /// Gets the next brightest color in the color range of the specified color.
        /// </summary>
        /// <param name="index">Index of color to get brighter color for.</param>
        /// <returns>The next brightest color in the color range. If there is no brighter color, the specified color is returned.</returns>
        public static int GetBrighterColor(int index)
        {
            List<int> range = GetRangeForColor(index);
            int indexInRange = range.IndexOf(index);

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
        public static int GetDarkerColor(int index)
        {
            List<int> range = GetRangeForColor(index);
            int indexInRange = range.IndexOf(index);

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
        public static List<int> GetRangeForColor(int index)
        {
            return _ranges.FirstOrDefault(r => r.Contains(index));
        }
    }
}
