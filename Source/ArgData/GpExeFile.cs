using System;
using System.Linq;

namespace ArgData
{
    /// <summary>
    /// Used for editing a GP.EXE file.
    /// </summary>
    public class GpExeFile
    {
        private readonly string _exePath;

        /// <summary>
        /// Initializes an instance of GpExeFile.
        /// </summary>
        /// <param name="exePath">Path to the GP.EXE file</param>
        public GpExeFile(string exePath)
        {
            _exePath = exePath;

            CheckFileIsSupported(exePath);
        }

        private void CheckFileIsSupported(string exePath)
        {
            var exeInfo = GetFileInfo(exePath);

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
        public static GpExeInfo GetFileInfo(string exePath)
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

        internal int GetPitCrewColorsPosition(int teamIndex)
        {
            return new DataPositions().PitCrewColors + (teamIndex * ColorsPerTeam);
        }

        internal int GetPitCrewColorsPosition()
        {
            return new DataPositions().PitCrewColors;
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

        internal int GetHelmetColorsPosition(int helmetIndex)
        {
            int bytesForPreviousHelmets = BytesPerHelmet.Take(helmetIndex).Sum(b => b);

            return new DataPositions().HelmetColors + bytesForPreviousHelmets;
        }

        internal int GetHelmetColorsPositionByteCountToRead(int helmetIndex)
        {
            return BytesPerHelmet[helmetIndex];
        }

        private readonly byte[] BytesPerHelmet = new byte[]
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 14, 16, 14, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16,
            16, 16, 16, 16, 16, 14, 14, 14, 14, 14
        };
    }
}
