using System;
using System.Collections.Generic;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class TrackCommandFactory
    {
        public static TrackCommand Create(byte command)
        {
            ValidateCommand(command);

            int count = ArgumentCount[command];
            short[] arguments = new short[count];

            return new TrackCommand(command, arguments);
        }

        private static void ValidateCommand(byte command)
        {
            if (!ArgumentCount.ContainsKey(command))
            {
                var message = $"Invalid command, must be between {MinArgumentValue} and {MaxArgumentValue}";
                throw new ArgumentOutOfRangeException(nameof(command), message);
            }
        }

        private const byte MinArgumentValue = 0x80;

        private const byte MaxArgumentValue = 0xac;

        private static readonly Dictionary<byte, int> ArgumentCount = new Dictionary<byte, int>
        {
            {0x80, 2},
            {0x81, 2},
            {0x82, 2},
            {0x83, 1},
            {0x84, 1},
            {0x85, 3},
            {0x86, 1},
            {0x87, 1},
            {0x88, 2},
            {0x89, 2},
            {0x8a, 6},
            {0x8b, 6},
            {0x8c, 2},
            {0x8d, 2},
            {0x8e, 3},
            {0x8f, 3},
            {0x90, 2},
            {0x91, 2},
            {0x92, 2},
            {0x93, 2},
            {0x94, 2},
            {0x95, 2},
            {0x96, 1},
            {0x97, 1},
            {0x98, 2},
            {0x99, 2},
            {0x9a, 3},
            {0x9b, 1},
            {0x9c, 1},
            {0x9d, 1},
            {0x9e, 1},
            {0x9f, 1},
            {0xa0, 1},
            {0xa1, 1},
            {0xa2, 1},
            {0xa3, 1},
            {0xa4, 1},
            {0xa5, 1},
            {0xa6, 3},
            {0xa7, 3},
            {0xa8, 1},
            {0xa9, 2},
            {0xaa, 4},
            {0xab, 3},
            {0xac, 5}
        };
    }
}
