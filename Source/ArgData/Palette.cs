using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ArgData
{
    public static class Palette
    {
        private static Dictionary<int, Color> _palette;
        private static List<List<int>> _ranges;

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
            _palette = new Dictionary<int, Color>();
            _palette.Add(0, Color.FromArgb(0, 0, 0));
            _palette.Add(1, Color.FromArgb(188, 188, 188));
            _palette.Add(2, Color.FromArgb(188, 60, 60));
            _palette.Add(3, Color.FromArgb(252, 252, 0));
            _palette.Add(4, Color.FromArgb(0, 156, 0));
            _palette.Add(5, Color.FromArgb(60, 0, 156));
            _palette.Add(6, Color.FromArgb(92, 156, 252));
            _palette.Add(7, Color.FromArgb(124, 0, 0));
            _palette.Add(8, Color.FromArgb(252, 252, 252));
            _palette.Add(9, Color.FromArgb(252, 60, 60));
            _palette.Add(10, Color.FromArgb(92, 92, 92));
            _palette.Add(11, Color.FromArgb(0, 92, 0));
            _palette.Add(12, Color.FromArgb(156, 156, 156));
            _palette.Add(13, Color.FromArgb(188, 188, 188));
            _palette.Add(14, Color.FromArgb(220, 220, 220));
            _palette.Add(15, Color.FromArgb(0, 124, 0));

            _palette.Add(16, Color.FromArgb(76, 136, 48));
            _palette.Add(17, Color.FromArgb(80, 136, 52));
            _palette.Add(18, Color.FromArgb(84, 140, 56));
            _palette.Add(19, Color.FromArgb(88, 144, 60));
            _palette.Add(20, Color.FromArgb(92, 144, 68));
            _palette.Add(21, Color.FromArgb(100, 148, 80));
            _palette.Add(22, Color.FromArgb(112, 148, 92));
            _palette.Add(23, Color.FromArgb(120, 152, 104));
            _palette.Add(24, Color.FromArgb(120, 120, 108));
            _palette.Add(25, Color.FromArgb(124, 124, 112));
            _palette.Add(26, Color.FromArgb(128, 128, 116));
            _palette.Add(27, Color.FromArgb(132, 132, 120)); // ???
            _palette.Add(28, Color.FromArgb(132, 132, 120)); // ???
            _palette.Add(29, Color.FromArgb(136, 136, 128));
            _palette.Add(30, Color.FromArgb(140, 140, 132));
            _palette.Add(31, Color.FromArgb(144, 144, 140));

            _palette.Add(32, Color.FromArgb(0, 0, 0));
            _palette.Add(33, Color.FromArgb(28, 28, 28));
            _palette.Add(34, Color.FromArgb(44, 44, 44));
            _palette.Add(35, Color.FromArgb(60, 60, 60));
            _palette.Add(36, Color.FromArgb(76, 76, 76));
            _palette.Add(37, Color.FromArgb(92, 92, 92));
            _palette.Add(38, Color.FromArgb(108, 108, 108));
            _palette.Add(39, Color.FromArgb(124, 124, 124));
            _palette.Add(40, Color.FromArgb(140, 140, 140));
            _palette.Add(41, Color.FromArgb(156, 156, 156));
            _palette.Add(42, Color.FromArgb(172, 172, 172));
            _palette.Add(43, Color.FromArgb(188, 188, 188));
            _palette.Add(44, Color.FromArgb(204, 204, 204));
            _palette.Add(45, Color.FromArgb(220, 220, 220));
            _palette.Add(46, Color.FromArgb(236, 236, 236));
            _palette.Add(47, Color.FromArgb(252, 252, 252));

            _palette.Add(48, Color.FromArgb(0, 0, 0));
            _palette.Add(49, Color.FromArgb(28, 0, 8));
            _palette.Add(50, Color.FromArgb(44, 0, 12));
            _palette.Add(51, Color.FromArgb(60, 0, 12));
            _palette.Add(52, Color.FromArgb(76, 0, 16));
            _palette.Add(53, Color.FromArgb(92, 0, 16));
            _palette.Add(54, Color.FromArgb(108, 0, 20));
            _palette.Add(55, Color.FromArgb(124, 0, 20));
            _palette.Add(56, Color.FromArgb(140, 0, 24));
            _palette.Add(57, Color.FromArgb(156, 0, 24));
            _palette.Add(58, Color.FromArgb(172, 0, 28));
            _palette.Add(59, Color.FromArgb(188, 0, 28));
            _palette.Add(60, Color.FromArgb(204, 0, 32));
            _palette.Add(61, Color.FromArgb(220, 0, 32));
            _palette.Add(62, Color.FromArgb(236, 0, 36));
            _palette.Add(63, Color.FromArgb(252, 0, 36));

            _palette.Add(64, Color.FromArgb(0, 0, 0));
            _palette.Add(65, Color.FromArgb(8, 28, 0));
            _palette.Add(66, Color.FromArgb(16, 44, 16));
            _palette.Add(67, Color.FromArgb(20, 60, 20));
            _palette.Add(68, Color.FromArgb(24, 76, 24));
            _palette.Add(69, Color.FromArgb(24, 92, 24));
            _palette.Add(70, Color.FromArgb(28, 108, 28));
            _palette.Add(71, Color.FromArgb(28, 124, 28));
            _palette.Add(72, Color.FromArgb(32, 140, 32));
            _palette.Add(73, Color.FromArgb(32, 156, 32));
            _palette.Add(74, Color.FromArgb(32, 172, 32));
            _palette.Add(75, Color.FromArgb(36, 188, 36));
            _palette.Add(76, Color.FromArgb(36, 204, 36));
            _palette.Add(77, Color.FromArgb(36, 220, 36));
            _palette.Add(78, Color.FromArgb(36, 236, 36));
            _palette.Add(79, Color.FromArgb(36, 252, 36));

            _palette.Add(80, Color.FromArgb(0, 0, 0));
            _palette.Add(81, Color.FromArgb(8, 0, 28));
            _palette.Add(82, Color.FromArgb(12, 0, 44));
            _palette.Add(83, Color.FromArgb(12, 0, 60));
            _palette.Add(84, Color.FromArgb(16, 0, 76));
            _palette.Add(85, Color.FromArgb(16, 0, 92));
            _palette.Add(86, Color.FromArgb(20, 0, 108));
            _palette.Add(87, Color.FromArgb(20, 0, 124));
            _palette.Add(88, Color.FromArgb(24, 0, 140));
            _palette.Add(89, Color.FromArgb(24, 0, 156));
            _palette.Add(90, Color.FromArgb(28, 0, 172));
            _palette.Add(91, Color.FromArgb(28, 0, 188));
            _palette.Add(92, Color.FromArgb(30, 0, 204));
            _palette.Add(93, Color.FromArgb(32, 0, 220));
            _palette.Add(94, Color.FromArgb(36, 0, 236));
            _palette.Add(95, Color.FromArgb(36, 0, 252));

            _palette.Add(96, Color.FromArgb(0, 0, 0));
            _palette.Add(97, Color.FromArgb(28, 28, 8));
            _palette.Add(98, Color.FromArgb(44, 44, 12));
            _palette.Add(99, Color.FromArgb(60, 60, 12));
            _palette.Add(100, Color.FromArgb(76, 76, 16));
            _palette.Add(101, Color.FromArgb(92, 92, 16));
            _palette.Add(102, Color.FromArgb(108, 108, 20));
            _palette.Add(103, Color.FromArgb(124, 124, 24));
            _palette.Add(104, Color.FromArgb(140, 140, 24));
            _palette.Add(105, Color.FromArgb(156, 156, 24));
            _palette.Add(106, Color.FromArgb(172, 172, 28));
            _palette.Add(107, Color.FromArgb(188, 188, 28));
            _palette.Add(108, Color.FromArgb(204, 204, 32));
            _palette.Add(109, Color.FromArgb(220, 220, 32));
            _palette.Add(110, Color.FromArgb(236, 236, 36));
            _palette.Add(111, Color.FromArgb(252, 252, 36));

            _palette.Add(112, Color.FromArgb(108, 16, 0));
            _palette.Add(113, Color.FromArgb(124, 40, 0)); // correct Green?
            _palette.Add(114, Color.FromArgb(140, 28, 0)); // correct Green?
            _palette.Add(115, Color.FromArgb(156, 44, 0));
            _palette.Add(116, Color.FromArgb(172, 60, 0));
            _palette.Add(117, Color.FromArgb(188, 76, 0));
            _palette.Add(118, Color.FromArgb(204, 92, 0));
            _palette.Add(119, Color.FromArgb(220, 108, 0));
            _palette.Add(120, Color.FromArgb(44, 16, 0));
            _palette.Add(121, Color.FromArgb(60, 40, 0));
            _palette.Add(122, Color.FromArgb(76, 28, 0));
            _palette.Add(123, Color.FromArgb(92, 44, 0));
            _palette.Add(124, Color.FromArgb(108, 60, 0));
            _palette.Add(125, Color.FromArgb(124, 76, 0));
            _palette.Add(126, Color.FromArgb(140, 92, 0));
            _palette.Add(127, Color.FromArgb(156, 108, 0));

            _palette.Add(128, Color.FromArgb(72, 148, 252));
            _palette.Add(129, Color.FromArgb(76, 152, 252));
            _palette.Add(130, Color.FromArgb(80, 156, 252));
            _palette.Add(131, Color.FromArgb(84, 160, 252));
            _palette.Add(132, Color.FromArgb(88, 164, 252));
            _palette.Add(133, Color.FromArgb(92, 168, 252));
            _palette.Add(134, Color.FromArgb(96, 172, 252));
            _palette.Add(135, Color.FromArgb(100, 176, 252));
            _palette.Add(136, Color.FromArgb(20, 68, 20));
            _palette.Add(137, Color.FromArgb(24, 84, 24));
            _palette.Add(138, Color.FromArgb(20, 72, 20));
            _palette.Add(139, Color.FromArgb(24, 80, 24));
            _palette.Add(140, Color.FromArgb(24, 88, 24));
            _palette.Add(141, Color.FromArgb(244, 244, 48));
            _palette.Add(142, Color.FromArgb(236, 236, 64));
            _palette.Add(143, Color.FromArgb(228, 228, 76));

            _palette.Add(144, Color.FromArgb(36, 84, 36));
            _palette.Add(145, Color.FromArgb(52, 92, 52));
            _palette.Add(146, Color.FromArgb(64, 104, 64));
            _palette.Add(147, Color.FromArgb(80, 112, 80));
            _palette.Add(148, Color.FromArgb(40, 92, 40));
            _palette.Add(149, Color.FromArgb(52, 100, 52));
            _palette.Add(150, Color.FromArgb(68, 112, 68));
            _palette.Add(151, Color.FromArgb(84, 120, 84));
            _palette.Add(152, Color.FromArgb(92, 140, 92));
            _palette.Add(153, Color.FromArgb(108, 156, 108));
            _palette.Add(154, Color.FromArgb(124, 172, 124));
            _palette.Add(155, Color.FromArgb(140, 188, 140));
            _palette.Add(156, Color.FromArgb(156, 204, 156));
            _palette.Add(157, Color.FromArgb(172, 220, 172));
            _palette.Add(158, Color.FromArgb(220, 220, 92));
            _palette.Add(159, Color.FromArgb(204, 252, 204));

            _palette.Add(160, Color.FromArgb(48, 16, 200));
            _palette.Add(161, Color.FromArgb(60, 36, 196));
            _palette.Add(162, Color.FromArgb(76, 52, 196));
            _palette.Add(163, Color.FromArgb(88, 68, 192));
            _palette.Add(164, Color.FromArgb(200, 16, 48));
            _palette.Add(165, Color.FromArgb(196, 36, 60));
            _palette.Add(166, Color.FromArgb(196, 52, 76));
            _palette.Add(167, Color.FromArgb(192, 68, 88));
            _palette.Add(168, Color.FromArgb(140, 140, 92));
            _palette.Add(169, Color.FromArgb(156, 156, 108));
            _palette.Add(170, Color.FromArgb(172, 172, 124));
            _palette.Add(171, Color.FromArgb(188, 188, 140));
            _palette.Add(172, Color.FromArgb(204, 204, 156));
            _palette.Add(173, Color.FromArgb(220, 220, 172));
            _palette.Add(174, Color.FromArgb(236, 236, 188));
            _palette.Add(175, Color.FromArgb(252, 252, 236));

            _palette.Add(176, Color.FromArgb(148, 148, 120));
            _palette.Add(177, Color.FromArgb(160, 160, 132));
            _palette.Add(178, Color.FromArgb(176, 176, 148));
            _palette.Add(179, Color.FromArgb(196, 196, 160));
            _palette.Add(180, Color.FromArgb(208, 208, 176));
            _palette.Add(181, Color.FromArgb(220, 220, 196));
            _palette.Add(182, Color.FromArgb(236, 236, 208));
            _palette.Add(183, Color.FromArgb(252, 252, 208));
            _palette.Add(184, Color.FromArgb(148, 148, 132));
            _palette.Add(185, Color.FromArgb(160, 160, 148));
            _palette.Add(186, Color.FromArgb(176, 176, 160));
            _palette.Add(187, Color.FromArgb(196, 196, 176));
            _palette.Add(188, Color.FromArgb(208, 208, 196));
            _palette.Add(189, Color.FromArgb(220, 220, 208));
            _palette.Add(190, Color.FromArgb(236, 236, 220));
            _palette.Add(191, Color.FromArgb(252, 252, 236));

            _palette.Add(192, Color.FromArgb(108, 124, 28));
            _palette.Add(193, Color.FromArgb(124, 140, 44));
            _palette.Add(194, Color.FromArgb(140, 156, 60));
            _palette.Add(195, Color.FromArgb(156, 172, 76));
            _palette.Add(196, Color.FromArgb(172, 188, 92));
            _palette.Add(197, Color.FromArgb(188, 204, 108));
            _palette.Add(198, Color.FromArgb(204, 220, 124));
            _palette.Add(199, Color.FromArgb(220, 236, 140));
            _palette.Add(200, Color.FromArgb(140, 92, 60));
            _palette.Add(201, Color.FromArgb(156, 108, 76));
            _palette.Add(202, Color.FromArgb(172, 124, 96));
            _palette.Add(203, Color.FromArgb(188, 140, 108));
            _palette.Add(204, Color.FromArgb(204, 156, 124));
            _palette.Add(205, Color.FromArgb(220, 172, 140));
            _palette.Add(206, Color.FromArgb(236, 188, 156));
            _palette.Add(207, Color.FromArgb(252, 204, 172));

            _palette.Add(208, Color.FromArgb(0, 4, 0));
            _palette.Add(209, Color.FromArgb(0, 8, 8));
            _palette.Add(210, Color.FromArgb(0, 16, 16));
            _palette.Add(211, Color.FromArgb(0, 24, 24));
            _palette.Add(212, Color.FromArgb(0, 32, 32));
            _palette.Add(213, Color.FromArgb(0, 40, 40));
            _palette.Add(214, Color.FromArgb(0, 48, 48));
            _palette.Add(215, Color.FromArgb(0, 56, 56));
            _palette.Add(216, Color.FromArgb(0, 64, 64));
            _palette.Add(217, Color.FromArgb(0, 68, 68));
            _palette.Add(218, Color.FromArgb(0, 76, 76));
            _palette.Add(219, Color.FromArgb(0, 84, 84));
            _palette.Add(220, Color.FromArgb(0, 92, 92));
            _palette.Add(221, Color.FromArgb(0, 100, 100));
            _palette.Add(222, Color.FromArgb(0, 108, 108));
            _palette.Add(223, Color.FromArgb(0, 116, 116));

            _palette.Add(224, Color.FromArgb(0, 124, 124));
            _palette.Add(225, Color.FromArgb(0, 128, 128));
            _palette.Add(226, Color.FromArgb(0, 136, 136));
            _palette.Add(227, Color.FromArgb(0, 144, 144));
            _palette.Add(228, Color.FromArgb(0, 152, 152));
            _palette.Add(229, Color.FromArgb(0, 160, 160));
            _palette.Add(230, Color.FromArgb(0, 168, 168));
            _palette.Add(231, Color.FromArgb(0, 176, 176));
            _palette.Add(232, Color.FromArgb(104, 180, 252));
            _palette.Add(233, Color.FromArgb(108, 184, 252));
            _palette.Add(234, Color.FromArgb(112, 188, 252));
            _palette.Add(235, Color.FromArgb(116, 192, 252));
            _palette.Add(236, Color.FromArgb(120, 196, 252));
            _palette.Add(237, Color.FromArgb(124, 200, 252));
            _palette.Add(238, Color.FromArgb(128, 204, 252));
            _palette.Add(239, Color.FromArgb(132, 208, 252));

            _palette.Add(240, Color.FromArgb(28, 32, 44));
            _palette.Add(241, Color.FromArgb(32, 36, 48));
            _palette.Add(242, Color.FromArgb(36, 40, 56));
            _palette.Add(243, Color.FromArgb(40, 48, 60));
            _palette.Add(244, Color.FromArgb(44, 52, 68));
            _palette.Add(245, Color.FromArgb(52, 56, 72));
            _palette.Add(246, Color.FromArgb(56, 64, 80));
            _palette.Add(247, Color.FromArgb(64, 68, 88));
            _palette.Add(248, Color.FromArgb(68, 76, 92));
            _palette.Add(249, Color.FromArgb(72, 80, 100));
            _palette.Add(250, Color.FromArgb(80, 88, 104));
            _palette.Add(251, Color.FromArgb(84, 92, 112));
            _palette.Add(252, Color.FromArgb(92, 96, 116));
            _palette.Add(253, Color.FromArgb(96, 104, 124));
            _palette.Add(254, Color.FromArgb(104, 112, 132));
            _palette.Add(255, Color.FromArgb(252, 252, 252));
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

        public static List<int> GetRangeForColor(int index)
        {
            return _ranges.FirstOrDefault(r => r.Contains(index));
        }
    }
}
