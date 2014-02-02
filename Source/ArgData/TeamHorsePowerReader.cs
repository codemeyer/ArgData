namespace ArgData
{
    public class TeamHorsepowerReader : FileReader
    {
        private readonly DataPositions _dataPositions;

        public TeamHorsepowerReader(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public int ReadTeamHorsepower(int teamIndex)
        {
            int position = _dataPositions.TeamHorsepower + (teamIndex * 2);
            ushort horsepower = ReadUShort(position);

            return horsepower;
        }
    }
}