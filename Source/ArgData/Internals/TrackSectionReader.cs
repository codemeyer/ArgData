using System.Collections.Generic;
using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class TrackSectionReader
    {
        public static TrackSectionReadingResult Read(BinaryReader reader, int startPosition)
        {
            var sections = new List<TrackSection>();

            reader.BaseStream.Position = startPosition;

            var currentSection = new TrackSection();

            while (true)
            {
                byte byte1 = reader.ReadByte();
                byte byte2 = reader.ReadByte();

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
                    var command = TrackSectionCommand.Create(byte2);

                    command.Arguments[0] = byte1;

                    for (int i = 1; i < command.Arguments.Length; i++)
                    {
                        command.Arguments[i] = reader.ReadInt16();
                    }

                    currentSection.Commands.Add(command);

                    continue;
                }

                // section
                currentSection.Length = byte1;
                currentSection.Curvature = reader.ReadInt16();
                currentSection.Height = reader.ReadInt16();
                currentSection.Flags = reader.ReadInt16();

                currentSection.RightVergeWidth = reader.ReadByte();
                currentSection.LeftVergeWidth = reader.ReadByte();
                sections.Add(currentSection);

                currentSection = new TrackSection();
            }

            int position = (int)reader.BaseStream.Position;
            return new TrackSectionReadingResult(position, sections);
        }
    }
}
