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

            byte[] driverNumbers = ReadBytes(position, 36);

            return driverNumbers;
        }
    }
}