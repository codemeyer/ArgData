namespace ArgData
{
    public class QualifyingGripLevelReader : GripLevelReader
    {
        private readonly DataPositions _dataPositions;

        public QualifyingGripLevelReader(string exePath, DataPositions dataPositions)
            : base(exePath)
        {
            _dataPositions = dataPositions;
        }

        public override int GripLevelPosition
        {
            get { return _dataPositions.QualifyingGripLevels; }
        }
    }
}