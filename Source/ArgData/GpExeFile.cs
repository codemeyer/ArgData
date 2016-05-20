using System;
using System.IO;
using System.Linq;

namespace ArgData
{
    /// <summary>
    /// Represents a GP.EXE file that will be read from or written to.
    /// </summary>
    public abstract class GpExeFile
    {
        /// <summary>
        /// Gets a reference to the GP.EXE file at the specified location.
        /// </summary>
        /// <param name="exePath"></param>
        /// <returns></returns>
        public static GpExeFile At(string exePath)
        {
            return GpExeFileFactory.CreateFromPath(exePath);
        }

        /// <summary>
        /// Gets info about the specified F1GP executable.
        /// </summary>
        /// <param name="exePath">Path of the file to get info about.</param>
        /// <returns>GpExeVersionInfo enum describing the file.</returns>
        public static GpExeVersionInfo GetFileInfo(string exePath)
        {
            var fileInfo = new FileInfo(exePath);

            switch (fileInfo.Length)
            {
                case 321878:
                    return GpExeVersionInfo.European105;

                case 321716:
                    return GpExeVersionInfo.Us105;

                default:
                    return GpExeVersionInfo.Unknown;
            }
        }

        internal GpExeFile(string exePath)
        {
            ExePath = exePath;
        }

        /// <summary>
        /// Gets the path to the GP.EXE file.
        /// </summary>
        public string ExePath { get; }

        protected abstract int PlayerHorsepowerPosition { get; }
        protected abstract int TeamHorsepowerPosition { get; }
        protected abstract int CarColorsPosition { get; }
        protected abstract int RaceGripLevelsPosition { get; }
        protected abstract int QualifyingGripLevelsPosition { get; }
        protected abstract int DriverNumbersPosition { get; }
        protected abstract int PitCrewColorsPosition { get; }
        protected abstract int HelmetColorsPosition { get; }

        internal int GetPlayerHorsepowerPosition()
        {
            return PlayerHorsepowerPosition;
        }

        internal const int ColorsPerTeam = 16;

        internal int GetCarColorsPosition(int teamIndex)
        {
            return CarColorsPosition + (teamIndex * ColorsPerTeam);
        }

        internal int GetCarColorsPosition()
        {
            return CarColorsPosition;
        }

        internal int GetPitCrewColorsPosition(int teamIndex)
        {
            return PitCrewColorsPosition + (teamIndex * ColorsPerTeam);
        }

        internal int GetPitCrewColorsPosition()
        {
            return PitCrewColorsPosition;
        }

        internal int GetDriverNumbersPosition()
        {
            return DriverNumbersPosition;
        }

        internal int GetDriverNumbersPosition(int driverIndex)
        {
            return DriverNumbersPosition + driverIndex;
        }

        internal int GetTeamHorsepowerPosition(int teamIndex)
        {
            return TeamHorsepowerPosition + (teamIndex * 2);
        }

        internal int GetRaceGripLevelPosition()
        {
            return RaceGripLevelsPosition;
        }

        internal int GetRaceGripLevelPositions(int driverNumber)
        {
            return RaceGripLevelsPosition + driverNumber - 1;
        }

        internal int GetQualifyingGripLevelPosition()
        {
            return QualifyingGripLevelsPosition;
        }

        internal int GetQualifyingGripLevelPositions(int driverNumber)
        {
            return QualifyingGripLevelsPosition + driverNumber - 1;
        }

        internal int GetHelmetColorsPosition(int helmetIndex)
        {
            int bytesForPreviousHelmets = _bytesPerHelmet.Take(helmetIndex).Sum(b => b);

            return HelmetColorsPosition + bytesForPreviousHelmets;
        }

        internal int GetHelmetColorsPositionByteCountToRead(int helmetIndex)
        {
            return _bytesPerHelmet[helmetIndex];
        }

        private readonly byte[] _bytesPerHelmet =
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 16, 14, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 14, 14, 14, 14
        };
    }

    internal static class GpExeFileFactory
    {
        internal static GpExeFile CreateFromPath(string exePath)
        {
            var exeInfo = GpExeFile.GetFileInfo(exePath);

            switch (exeInfo)
            {
                case GpExeVersionInfo.European105:
                    return new European105GpExeFile(exePath);
                case GpExeVersionInfo.Us105:
                    return new Us105GpExeFile(exePath);
                default:
                    string msg = $"The specified file is of type {exeInfo}. ArgData currently supports European105 and Us105.";
                    throw new Exception(msg);
            }
        }
    }

    internal class Us105GpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 19848;
        protected override int TeamHorsepowerPosition => 158336;
        protected override int CarColorsPosition => 158456;
        protected override int RaceGripLevelsPosition => 158416;
        protected override int QualifyingGripLevelsPosition => 158376;
        protected override int DriverNumbersPosition => 154892;
        protected override int PitCrewColorsPosition => 159377;
        protected override int HelmetColorsPosition => 158751;

        internal Us105GpExeFile(string exePath) : base(exePath)
        {
        }
    }

    internal class European105GpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 19848;
        protected override int TeamHorsepowerPosition => 158380;
        protected override int CarColorsPosition => 158500;
        protected override int RaceGripLevelsPosition => 158460;
        protected override int QualifyingGripLevelsPosition => 158420;
        protected override int DriverNumbersPosition => 154936;
        protected override int PitCrewColorsPosition => 159421;
        protected override int HelmetColorsPosition => 158795;

        internal European105GpExeFile(string exePath) : base(exePath)
        {
        }
    }
}
