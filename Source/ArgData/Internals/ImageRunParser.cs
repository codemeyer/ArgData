using System;
using System.Collections.Generic;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class ImageRunParser
    {
        public static byte[] ParseRunsToPixels(byte[] data)
        {
            var pixelDataStream = new MemoryStream(data);

            using (var reader = new BinaryReader(pixelDataStream))
            {
                var pixelBytes = new ByteList();

                while (reader.BaseStream.Position < data.Length)
                {
                    sbyte read = reader.ReadSByte();
                    bool repeats = read < 0;

                    if (repeats)
                    {
                        // runlength
                        byte runLength = Convert.ToByte(read * -1 + 1);
                        byte index = reader.ReadByte();

                        for (int i = 0; i < runLength; i++)
                        {
                            pixelBytes.Add(index);
                        }
                    }
                    else
                    {
                        // set of single pixels
                        for (int i = 0; i <= read; i++)
                        {
                            byte index = reader.ReadByte();
                            pixelBytes.Add(index);
                        }
                    }
                }

                return pixelBytes.GetBytes();
            }
        }
        
        public static List<IColorRun> ParsePixelsToRuns(byte[] data, int maxLength)
        {
            var list1 = ParseIntoUnlimitedLengths(data);
            var list2 = ParseLengthsIntoSplitRuns(list1, maxLength);
            var list3 = ParseConsolidateSingles(list2, maxLength);

            return list3;
        }

        public static List<ColorRun> ParseIntoUnlimitedLengths(byte[] data)
        {
            var list = new List<ColorRun>();

            byte currentVal = data[0];
            int currentRunLength = 1;

            for (int i = 1; i < data.Length; i++)
            {
                byte latestVal = data[i];

                if (currentVal == latestVal)
                {
                    currentRunLength++;
                }
                else
                {
                    list.Add(new ColorRun(currentRunLength, currentVal));

                    currentRunLength = 1;
                }

                currentVal = latestVal;

                if (i == data.Length - 1)
                {
                    // last
                    list.Add(new ColorRun(currentRunLength, currentVal));
                }
            }

            return list;
        }

        public static List<ColorRun> ParseLengthsIntoSplitRuns(List<ColorRun> lengths, int maxLength)
        {
            var list = new List<ColorRun>();

            int remainingForRun = maxLength;

            foreach (var item in lengths)
            {
                int remainingForItem = item.Repetitions;
                byte colorIndex = item.ColorIndex;

                while (remainingForItem > 0)
                {
                    int pixelsToGrab = Math.Min(remainingForRun, remainingForItem);

                    var newItem = new ColorRun(pixelsToGrab, colorIndex);
                    list.Add(newItem);

                    remainingForItem -= pixelsToGrab;
                    remainingForRun -= pixelsToGrab;

                    if (remainingForItem > 0 && remainingForRun == 0)
                    {
                        // start new run
                        remainingForRun = maxLength;
                    }

                    if (remainingForRun == 0)
                    {
                        remainingForRun = maxLength;
                    }
                }
            }

            return list;
        }

        // consolidates all singles into one SingleRun (except where split over two runs)
        public static List<IColorRun> ParseConsolidateSingles(List<ColorRun> runs, int maxLength)
        {
            var list = new List<IColorRun>();

            SingleColorRun currentSingleRun = null;

            int currentRunLength = 0;

            foreach (var item in runs)
            {
                if (item.Repetitions > 1)
                {
                    if (currentSingleRun != null)
                    {
                        // we were working on a single run
                        list.Add(currentSingleRun);
                        currentSingleRun = null;
                    }

                    list.Add(new RepeatingColorRun(item.Repetitions, item.ColorIndex));
                    currentRunLength += item.Repetitions;
                }
                else
                {
                    if (currentSingleRun == null)
                    {
                        // start new single run
                        currentSingleRun = new SingleColorRun();
                    }

                    currentSingleRun.ColorIndexes.Add(item.ColorIndex);

                    currentRunLength++;

                    if (currentRunLength == maxLength)
                    {
                        list.Add(currentSingleRun);
                        currentSingleRun = null;
                    }
                }

                if (currentRunLength >= maxLength)
                {
                    currentRunLength = 0;
                }
            }

            return list;
        }
    }
    
    internal class ColorRun
    {
        public ColorRun(int repetitions, byte colorIndex)
        {
            Repetitions = repetitions;
            ColorIndex = colorIndex;
        }

        public int Repetitions { get; }
        public byte ColorIndex { get; }
    }

    internal class RepeatingColorRun : IColorRun
    {
        public RepeatingColorRun(int repetitions, byte colorIndex)
        {
            Repetitions = repetitions;
            ColorIndex = colorIndex;
        }

        private int Repetitions { get; }
        private byte ColorIndex { get; }

        public byte[] GenerateBytesToWrite()
        {
            byte runLength = Convert.ToByte(255 - Repetitions + 2);

            return new [] {runLength, ColorIndex};
        }
    }

    internal class SingleColorRun : IColorRun
    {
        public ByteList ColorIndexes { get; } = new ByteList();

        public byte[] GenerateBytesToWrite()
        {
            var list = new ByteList();
            list.Add(Convert.ToByte(ColorIndexes.Count - 1));
            list.Add(ColorIndexes.GetBytes());

            return list.GetBytes();
        }
    }

    internal interface IColorRun
    {
        byte[] GenerateBytesToWrite();
    }
}
