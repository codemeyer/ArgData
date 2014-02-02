namespace ArgData
{
    public class RaceGripLevelReader : GripLevelReader
    {
        private readonly DataPositions _dataPositions;

        public RaceGripLevelReader(string exePath, DataPositions dataPositions)
            : base(exePath)
        {
            _dataPositions = dataPositions;
        }

        public override int GripLevelPosition
        {
            get { return _dataPositions.RaceGripLevels; }
        }
    }
}