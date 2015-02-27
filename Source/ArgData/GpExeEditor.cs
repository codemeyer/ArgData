namespace ArgData
{
    /// <summary>
    /// Used for editing a GP.EXE file.
    /// </summary>
    public class GpExeEditor
    {
        private readonly string _exePath;

        /// <summary>
        /// Initializes an instance of GpExeEditor.
        /// </summary>
        /// <param name="exePath"></param>
        public GpExeEditor(string exePath)
        {
            _exePath = exePath;
            // should be a valid gp.exe!
        }

        public string ExePath
        {
            get { return _exePath; }
        }

        public int ReadPlayerHorsepower()
        {
            return new PlayerHorsepowerEditor(this).ReadPlayerHorsepower();
        }

        public void WritePlayerHorsepower(int horsepower)
        {
            new PlayerHorsepowerEditor(this).WritePlayerHorsepower(horsepower);
        }





        internal int GetPlayerHorsepowerPosition()
        {
            return new DataPositions().PlayerHorsepower;
        }

        internal const int ColorsPerTeam = 16;

        internal int GetCarColorsPosition(int teamIndex)
        {
            return new DataPositions().CarColors + (teamIndex * ColorsPerTeam);
        }

        internal int GetCarColorsPosition()
        {
            return new DataPositions().CarColors;
        }

        internal int GetDriverNumbersPosition()
        {
            return new DataPositions().DriverNumbers;
        }

        internal int GetDriverNumbersPosition(int driverIndex)
        {
            return GetDriverNumbersPosition() + driverIndex;
        }

        internal int GetTeamHorsepowerPosition(int teamIndex)
        {
            return new DataPositions().TeamHorsepower + (teamIndex * 2);
        }

        internal int GetRaceGripLevelPositions(int driverIndex)
        {
            return new DataPositions().RaceGripLevels + driverIndex;
        }

        internal int GetQualifyingGripLevelPositions(int driverIndex)
        {
            return new DataPositions().RaceGripLevels + driverIndex;
        }
    }
}
