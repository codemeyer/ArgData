using System.Collections.Generic;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData.Internals
{
    internal static class TrackSectionReader
    {
        public static TrackSectionReadingResult Read(string path, int startPosition)
        {
            var sections = new List<TrackSection>();

            int currentPosition = startPosition;

            var currentSection = new TrackSection();

            var trackFileReader = new FileReader(path);

            while (true)
            {
                byte byte1 = trackFileReader.ReadByte(currentPosition);
                byte byte2 = trackFileReader.ReadByte(currentPosition + 1);

                if (byte1 == 255 && byte2 == 255)
                {
                    if (currentSection.Commands.Count > 0)
                    {
                        // section with len 0 etc, but has commands
                        sections.Add(currentSection);
                    }

                    break;
                }

                if (byte2 > 0)
                {
                    var argCount = TrackCommandFactory.GetArgumentCountForCommand(byte2);

                    short[] arguments = new short[argCount];

                    arguments[0] = byte1;

                    for (int i = 1; i < argCount; i++)
                    {
                        currentPosition += 2;
                        arguments[i] = trackFileReader.ReadInt16(currentPosition);
                    }

                    currentSection.Commands.Add(TrackCommandFactory.Get(byte2, arguments));

                    currentPosition += 2;

                    continue;
                }

                if (byte1 > 0)
                {
                    // section
                    currentSection.Length = byte1;
                    currentSection.Curvature = trackFileReader.ReadInt16(currentPosition + 2);
                    currentSection.Height = trackFileReader.ReadInt16(currentPosition + 4);
                    currentSection.Flags = trackFileReader.ReadInt16(currentPosition + 6);

                    currentSection.RightVergeWidth = trackFileReader.ReadByte(currentPosition + 8);
                    currentSection.LeftVergeWidth = trackFileReader.ReadByte(currentPosition + 9);
                    sections.Add(currentSection);

                    currentSection = new TrackSection();

                    currentPosition += 10;
                }
            }

            return new TrackSectionReadingResult(currentPosition + 2, sections);
        }
    }
}
