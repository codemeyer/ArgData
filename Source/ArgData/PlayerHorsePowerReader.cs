namespace ArgData
{
    public class PlayerHorsepowerReader : FileReader
    {
        private readonly DataPositions _dataPositions;

        public PlayerHorsepowerReader(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public int ReadPlayerHorsepower()
        {
            ushort rawHorsepower = ReadUShort(_dataPositions.PlayerHorsepower);

            return (rawHorsepower - 632) / 22;  // LOL
        }
    }
}