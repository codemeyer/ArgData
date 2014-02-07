namespace ArgData
{
    public class DriverNumberReader : FileReader
    {
        private readonly DataPositions _dataPositions;

        public DriverNumberReader(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public byte[] ReadDriverNumbers()
        {
            int position = _dataPositions.DriverNumbers;

            byte[] colors = ReadBytes(position, 36);

            return colors;
        }
    }
}