﻿using System.Collections.Generic;
using System.Drawing;

namespace ArgData
{
    /// <summary>
    /// Color palette for the menu screens.
    ///
    /// This is actually the palette stored as item 10 in BACKDROP.DAT, belonging to image item 11.
    /// </summary>
    public static class MenuPalette
    {
        private static Dictionary<int, Color> _palette;

        /// <summary>
        /// Get the color at the specified index in the palette.
        /// </summary>
        /// <param name="index">Index of color to fetch.</param>
        /// <returns>Color.</returns>
        public static Color GetColor(byte index)
        {
            return _palette[index];
        }

        static MenuPalette()
        {
            SetupPalette();
        }

        private static void SetupPalette()
        {
            _palette = new Dictionary<int, Color>
            {
                {0, Color.FromArgb(0, 0, 0)},
                {1, Color.FromArgb(0, 0, 0)},
                {2, Color.FromArgb(10, 19, 31)},
                {3, Color.FromArgb(17, 39, 60)},
                {4, Color.FromArgb(29, 63, 98)},
                {5, Color.FromArgb(45, 79, 114)},
                {6, Color.FromArgb(62, 96, 131)},
                {7, Color.FromArgb(95, 113, 130)},
                {8, Color.FromArgb(111, 129, 146)},
                {9, Color.FromArgb(128, 146, 161)},
                {10, Color.FromArgb(144, 162, 177)},
                {11, Color.FromArgb(160, 178, 195)},
                {12, Color.FromArgb(176, 194, 211)},
                {13, Color.FromArgb(211, 211, 211)},
                {14, Color.FromArgb(227, 227, 227)},
                {15, Color.FromArgb(243, 243, 243)},
                {16, Color.FromArgb(115, 11, 0)},
                {17, Color.FromArgb(138, 12, 0)},
                {18, Color.FromArgb(155, 14, 0)},
                {19, Color.FromArgb(190, 18, 0)},
                {20, Color.FromArgb(207, 19, 0)},
                {21, Color.FromArgb(243, 22, 0)},
                {22, Color.FromArgb(255, 24, 0)},
                {23, Color.FromArgb(211, 204, 110)},
                {24, Color.FromArgb(228, 220, 118)},
                {25, Color.FromArgb(244, 236, 130)},
                {26, Color.FromArgb(0, 40, 114)},
                {27, Color.FromArgb(0, 51, 130)},
                {28, Color.FromArgb(0, 92, 179)},
                {29, Color.FromArgb(130, 55, 0)},
                {30, Color.FromArgb(189, 90, 0)},
                {31, Color.FromArgb(252, 129, 0)},
                {32, Color.FromArgb(20, 20, 24)},
                {33, Color.FromArgb(4, 4, 8)},
                {34, Color.FromArgb(0, 12, 73)},
                {35, Color.FromArgb(95, 105, 242)},
                {36, Color.FromArgb(179, 202, 226)},
                {37, Color.FromArgb(205, 214, 222)},
                {38, Color.FromArgb(214, 218, 219)},
                {39, Color.FromArgb(219, 214, 201)},
                {40, Color.FromArgb(198, 202, 197)},
                {41, Color.FromArgb(189, 194, 207)},
                {42, Color.FromArgb(172, 186, 202)},
                {43, Color.FromArgb(169, 180, 185)},
                {44, Color.FromArgb(185, 185, 181)},
                {45, Color.FromArgb(170, 166, 165)},
                {46, Color.FromArgb(154, 150, 153)},
                {47, Color.FromArgb(137, 138, 150)},
                {48, Color.FromArgb(119, 133, 145)},
                {49, Color.FromArgb(112, 117, 142)},
                {50, Color.FromArgb(104, 112, 130)},
                {51, Color.FromArgb(109, 109, 113)},
                {52, Color.FromArgb(106, 91, 100)},
                {53, Color.FromArgb(92, 96, 83)},
                {54, Color.FromArgb(77, 76, 84)},
                {55, Color.FromArgb(59, 65, 85)},
                {56, Color.FromArgb(47, 52, 68)},
                {57, Color.FromArgb(52, 52, 56)},
                {58, Color.FromArgb(55, 48, 38)},
                {59, Color.FromArgb(71, 39, 42)},
                {60, Color.FromArgb(93, 40, 35)},
                {61, Color.FromArgb(109, 46, 27)},
                {62, Color.FromArgb(127, 36, 6)},
                {63, Color.FromArgb(142, 29, 0)},
                {64, Color.FromArgb(154, 38, 0)},
                {65, Color.FromArgb(162, 45, 0)},
                {66, Color.FromArgb(174, 53, 0)},
                {67, Color.FromArgb(186, 65, 0)},
                {68, Color.FromArgb(195, 72, 0)},
                {69, Color.FromArgb(207, 84, 0)},
                {70, Color.FromArgb(220, 96, 0)},
                {71, Color.FromArgb(231, 106, 0)},
                {72, Color.FromArgb(235, 121, 0)},
                {73, Color.FromArgb(238, 135, 0)},
                {74, Color.FromArgb(241, 150, 0)},
                {75, Color.FromArgb(245, 162, 0)},
                {76, Color.FromArgb(248, 177, 0)},
                {77, Color.FromArgb(252, 195, 0)},
                {78, Color.FromArgb(255, 213, 0)},
                {79, Color.FromArgb(4, 48, 0)},
                {80, Color.FromArgb(1, 38, 0)},
                {81, Color.FromArgb(23, 24, 36)},
                {82, Color.FromArgb(35, 36, 51)},
                {83, Color.FromArgb(36, 36, 40)},
                {84, Color.FromArgb(50, 22, 19)},
                {85, Color.FromArgb(72, 7, 0)},
                {86, Color.FromArgb(81, 8, 0)},
                {87, Color.FromArgb(94, 11, 0)},
                {88, Color.FromArgb(107, 13, 0)},
                {89, Color.FromArgb(128, 25, 0)},
                {90, Color.FromArgb(106, 24, 2)},
                {91, Color.FromArgb(81, 28, 23)},
                {92, Color.FromArgb(73, 57, 39)},
                {93, Color.FromArgb(85, 69, 47)},
                {94, Color.FromArgb(111, 75, 42)},
                {95, Color.FromArgb(120, 74, 22)},
                {96, Color.FromArgb(103, 223, 255)},
                {97, Color.FromArgb(255, 229, 0)},
                {98, Color.FromArgb(0, 7, 65)},
                {99, Color.FromArgb(0, 11, 90)},
                {100, Color.FromArgb(11, 72, 0)},
                {101, Color.FromArgb(213, 122, 45)},
                {102, Color.FromArgb(136, 151, 183)},
                {103, Color.FromArgb(0, 2, 52)},
                {104, Color.FromArgb(255, 239, 0)},
                {105, Color.FromArgb(245, 251, 254)},
                {106, Color.FromArgb(12, 11, 19)},
                {107, Color.FromArgb(146, 31, 22)},
                {108, Color.FromArgb(163, 33, 22)},
                {109, Color.FromArgb(175, 38, 22)},
                {110, Color.FromArgb(187, 49, 38)},
                {111, Color.FromArgb(206, 44, 34)},
                {112, Color.FromArgb(185, 72, 67)},
                {113, Color.FromArgb(175, 90, 80)},
                {114, Color.FromArgb(153, 95, 101)},
                {115, Color.FromArgb(148, 112, 113)},
                {116, Color.FromArgb(142, 133, 116)},
                {117, Color.FromArgb(137, 146, 161)},
                {118, Color.FromArgb(132, 139, 169)},
                {119, Color.FromArgb(119, 138, 170)},
                {120, Color.FromArgb(120, 127, 162)},
                {121, Color.FromArgb(143, 120, 137)},
                {122, Color.FromArgb(177, 115, 112)},
                {123, Color.FromArgb(203, 128, 112)},
                {124, Color.FromArgb(210, 145, 136)},
                {125, Color.FromArgb(205, 156, 165)},
                {126, Color.FromArgb(175, 148, 149)},
                {127, Color.FromArgb(150, 139, 137)},
                {128, Color.FromArgb(120, 128, 121)},
                {129, Color.FromArgb(87, 100, 112)},
                {130, Color.FromArgb(80, 86, 104)},
                {131, Color.FromArgb(76, 81, 97)},
                {132, Color.FromArgb(73, 62, 72)},
                {133, Color.FromArgb(90, 53, 56)},
                {134, Color.FromArgb(120, 58, 55)},
                {135, Color.FromArgb(138, 68, 72)},
                {136, Color.FromArgb(146, 79, 83)},
                {137, Color.FromArgb(144, 107, 78)},
                {138, Color.FromArgb(150, 132, 74)},
                {139, Color.FromArgb(160, 132, 54)},
                {140, Color.FromArgb(180, 140, 49)},
                {141, Color.FromArgb(220, 150, 41)},
                {142, Color.FromArgb(248, 165, 69)},
                {143, Color.FromArgb(29, 98, 162)},
                {144, Color.FromArgb(24, 72, 143)},
                {145, Color.FromArgb(16, 60, 136)},
                {146, Color.FromArgb(4, 33, 101)},
                {147, Color.FromArgb(2, 25, 94)},
                {148, Color.FromArgb(1, 19, 85)},
                {149, Color.FromArgb(22, 37, 81)},
                {150, Color.FromArgb(21, 52, 114)},
                {151, Color.FromArgb(36, 73, 151)},
                {152, Color.FromArgb(47, 89, 168)},
                {153, Color.FromArgb(70, 109, 170)},
                {154, Color.FromArgb(73, 104, 150)},
                {155, Color.FromArgb(113, 105, 83)},
                {156, Color.FromArgb(109, 102, 55)},
                {157, Color.FromArgb(148, 109, 46)},
                {158, Color.FromArgb(157, 98, 21)},
                {159, Color.FromArgb(180, 84, 26)},
                {160, Color.FromArgb(179, 88, 37)},
                {161, Color.FromArgb(155, 79, 37)},
                {162, Color.FromArgb(144, 55, 38)},
                {163, Color.FromArgb(143, 51, 14)},
                {164, Color.FromArgb(160, 67, 18)},
                {165, Color.FromArgb(120, 77, 75)},
                {166, Color.FromArgb(49, 69, 113)},
                {167, Color.FromArgb(49, 84, 143)},
                {168, Color.FromArgb(37, 110, 175)},
                {169, Color.FromArgb(46, 120, 183)},
                {170, Color.FromArgb(54, 136, 196)},
                {171, Color.FromArgb(58, 147, 205)},
                {172, Color.FromArgb(64, 163, 215)},
                {173, Color.FromArgb(180, 159, 82)},
                {174, Color.FromArgb(216, 144, 70)},
                {175, Color.FromArgb(218, 168, 70)},
                {176, Color.FromArgb(226, 192, 94)},
                {177, Color.FromArgb(249, 212, 101)},
                {178, Color.FromArgb(109, 149, 195)},
                {179, Color.FromArgb(122, 159, 196)},
                {180, Color.FromArgb(144, 164, 181)},
                {181, Color.FromArgb(153, 162, 177)},
                {182, Color.FromArgb(148, 151, 182)},
                {183, Color.FromArgb(147, 174, 203)},
                {184, Color.FromArgb(168, 190, 228)},
                {185, Color.FromArgb(209, 218, 230)},
                {186, Color.FromArgb(225, 230, 239)},
                {187, Color.FromArgb(246, 246, 242)},
                {188, Color.FromArgb(214, 217, 252)},
                {189, Color.FromArgb(211, 204, 215)},
                {190, Color.FromArgb(226, 224, 230)},
                {191, Color.FromArgb(243, 238, 213)},
                {192, Color.FromArgb(255, 239, 171)},
                {193, Color.FromArgb(178, 166, 102)},
                {194, Color.FromArgb(178, 120, 74)},
                {195, Color.FromArgb(202, 89, 84)},
                {196, Color.FromArgb(182, 124, 133)},
                {197, Color.FromArgb(180, 144, 111)},
                {198, Color.FromArgb(184, 143, 78)},
                {199, Color.FromArgb(248, 175, 74)},
                {200, Color.FromArgb(90, 64, 25)},
                {201, Color.FromArgb(213, 175, 119)},
                {202, Color.FromArgb(208, 179, 137)},
                {203, Color.FromArgb(215, 197, 144)},
                {204, Color.FromArgb(236, 213, 144)},
                {205, Color.FromArgb(255, 235, 142)},
                {206, Color.FromArgb(239, 221, 168)},
                {207, Color.FromArgb(255, 249, 147)},
                {208, Color.FromArgb(255, 202, 70)},
                {209, Color.FromArgb(255, 255, 110)},
                {210, Color.FromArgb(255, 244, 81)},
                {211, Color.FromArgb(255, 255, 255)},
                {212, Color.FromArgb(16, 12, 15)},
                {213, Color.FromArgb(0, 3, 45)},
                {214, Color.FromArgb(0, 12, 107)},
                {215, Color.FromArgb(0, 13, 123)},
                {216, Color.FromArgb(0, 15, 140)},
                {217, Color.FromArgb(0, 16, 156)},
                {218, Color.FromArgb(0, 12, 174)},
                {219, Color.FromArgb(0, 14, 188)},
                {220, Color.FromArgb(0, 13, 230)},
                {221, Color.FromArgb(25, 40, 234)},
                {222, Color.FromArgb(57, 69, 239)},
                {223, Color.FromArgb(132, 140, 244)},
                {224, Color.FromArgb(173, 178, 247)},
                {225, Color.FromArgb(168, 177, 189)},
                {226, Color.FromArgb(120, 126, 146)},
                {227, Color.FromArgb(119, 28, 18)},
                {228, Color.FromArgb(66, 174, 0)},
                {229, Color.FromArgb(42, 133, 0)},
                {230, Color.FromArgb(27, 107, 0)},
                {231, Color.FromArgb(23, 97, 0)},
                {232, Color.FromArgb(16, 82, 0)},
                {233, Color.FromArgb(7, 62, 0)},
                {234, Color.FromArgb(115, 17, 0)},
                {235, Color.FromArgb(50, 148, 0)},
                {236, Color.FromArgb(33, 123, 0)},
                {237, Color.FromArgb(58, 159, 0)},
                {238, Color.FromArgb(78, 186, 0)},
                {239, Color.FromArgb(86, 200, 0)},
                {240, Color.FromArgb(97, 211, 0)},
                {241, Color.FromArgb(110, 225, 0)},
                {242, Color.FromArgb(137, 148, 138)},
                {243, Color.FromArgb(26, 84, 155)},
                {244, Color.FromArgb(12, 53, 122)},
                {245, Color.FromArgb(8, 41, 113)},
                {246, Color.FromArgb(29, 62, 134)},
                {247, Color.FromArgb(88, 97, 112)},
                {248, Color.FromArgb(73, 177, 223)},
                {249, Color.FromArgb(84, 193, 235)},
                {250, Color.FromArgb(92, 208, 244)},
                {251, Color.FromArgb(255, 41, 255)},
                {252, Color.FromArgb(255, 41, 255)},
                {253, Color.FromArgb(255, 41, 255)},
                {254, Color.FromArgb(255, 41, 255)},
                {255, Color.FromArgb(255, 41, 255)}
            };
        }
    }
}
