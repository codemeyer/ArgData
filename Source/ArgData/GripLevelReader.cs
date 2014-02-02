namespace ArgData
{
    public abstract class GripLevelReader : FileReader
    {
        protected GripLevelReader(string exePath)
            : base(exePath)
        {
        }

        public int ReadGripLevel(int driverIndex)
        {
            int position = GripLevelPosition + driverIndex;
            byte value = ReadByte(position);

            return value;
        }

        public abstract int GripLevelPosition { get; }
    }
}
