using System.IO;

namespace ArgData.Internals
{
    internal static class ComputerCarAndTrackSettingsPart2Reader
    {
        public static ComputerCarDataAndTrackSettingsPart2 Read(BinaryReader reader, int position)
        {
            reader.BaseStream.Position = position;

            var settings = new ComputerCarDataAndTrackSettingsPart2
            {
                UnknownData = reader.ReadBytes(16),
                FormationLength = reader.ReadInt16(),
                LapTimeIndication = reader.ReadInt32(),
                LapCount = reader.ReadInt16(),
                StrategyFirstPitStopLap = reader.ReadInt16(),
                StrategyChance = reader.ReadInt16()
            };

            return settings;
        }
    }
}
