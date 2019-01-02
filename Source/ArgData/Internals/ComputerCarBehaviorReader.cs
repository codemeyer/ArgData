using System.IO;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal static class ComputerCarBehaviorReader
    {
        public static ComputerCarBehavior Read(BinaryReader reader, int position)
        {
            reader.BaseStream.Position = position;

            var behavior = new ComputerCarBehavior
            {
                UnknownData = reader.ReadBytes(16),
                FormationLength = reader.ReadInt16(),
                LapTimeIndication = reader.ReadInt32(),
                LapCount = reader.ReadInt16(),
                StrategyFirstPitStopLap = reader.ReadInt16(),
                StrategyChance = reader.ReadInt16()
            };

            return behavior;
        }
    }
}
