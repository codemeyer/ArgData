namespace ArgData
{
    public class PlayerHorsepowerWriter : FileWriter
    {
        private readonly DataPositions _dataPositions;

        public PlayerHorsepowerWriter(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public void WritePlayerHorsepower(int horsepower)
        {
            ushort rawHorsepower = (ushort)((horsepower * 22) + 632);

            WriteUInt16(rawHorsepower, _dataPositions.PlayerHorsepower);
        }
    }
}