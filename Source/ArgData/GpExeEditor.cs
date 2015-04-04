using System;

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

            CheckFileIsSupported(exePath);
        }

        private void CheckFileIsSupported(string exePath)
        {
            var exeInfo = GetGpExeInfo(exePath);

            if (exeInfo != GpExeInfo.European105)
            {
                string msg = string.Format("The specified file is of type {0}. ArgData currently only supports European105.", exeInfo);
                throw new Exception(msg);
            }
        }

        /// <summary>
        /// Gets info about the specified F1GP executable.
        /// </summary>
        /// <param name="exePath">Path of the file to get info about.</param>
        /// <returns>GpExeInfo enum describing the file.</returns>
        public static GpExeInfo GetGpExeInfo(string exePath)
        {
            return new FileInspector().GetGpExeInfo(exePath);
        }

        /// <summary>
        /// Gets the path to the GP.EXE file.
        /// </summary>
        public string ExePath
        {
            get { return _exePath; }
        }

        /// <summary>
        /// Reads the horsepower value for the player.
        /// </summary>
        /// <returns>Player horsepower value.</returns>
        public int ReadPlayerHorsepower()
        {
            return new PlayerHorsepowerEditor(this).ReadPlayerHorsepower();
        }

        /// <summary>
        /// Writes the horsepower value for the player. The default value is 716.
        /// </summary>
        /// <param name="horsepower">Player horsepower value.</param>
        public void WritePlayerHorsepower(int horsepower)
        {
            new PlayerHorsepowerEditor(this).WritePlayerHorsepower(horsepower);
        }

        /// <summary>
        /// Gets the number of teams supported by ArgData.
        /// </summary>
        public const int NumberOfTeams = 18;


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
            return new DataPositions().QualifyingGripLevels + driverIndex;
        }
    }
}
