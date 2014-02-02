namespace ArgData
{
    public class CarColorReader : FileReader
    {
        private readonly DataPositions _dataPositions;
        
        private const int ColorsPerTeam = 16;

        public CarColorReader(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public byte[] ReadCarColors(int teamIndex)
        {
            int position = _dataPositions.CarColors + (teamIndex * ColorsPerTeam);

            byte[] colors = ReadBytes(position, ColorsPerTeam);

            return colors;
        }
    }
}