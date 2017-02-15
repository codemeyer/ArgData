using System;
using System.IO;
using System.Linq;
using ArgData.Validation;

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
        /// <returns>GpExeInfo describing the file.</returns>
        public static GpExeInfo GetFileInfo(string exePath)
        {
            var fileInfo = new FileInfo(exePath);

            var exeInfo = new GpExeInfo();

            switch (fileInfo.Length)
            {
                case 321878:
                    exeInfo.Version = GpExeVersionInfo.European105;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = true;
                    break;

                case 321716:
                    exeInfo.Version = GpExeVersionInfo.Us105;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = true;
                    break;

                case 332890:
                    exeInfo.Version = GpExeVersionInfo.European103;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = false;
                    break;

                case 332840:
                    exeInfo.Version = GpExeVersionInfo.Us103;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = false;
                    break;

                default:
                    exeInfo.Version = GpExeVersionInfo.Unknown;
                    exeInfo.IsKnownExeVersion = false;
                    exeInfo.IsEditingSupported = false;
                    break;
            }

            return exeInfo;
        }

        internal GpExeFile(string exePath)
        {
            ExePath = exePath;
        }

        /// <summary>
        /// Gets the path to the GP.EXE file.
        /// </summary>
        public string ExePath { get; }

        /// <summary>
        /// Position of player horsepower value in the file.
        /// </summary>
        protected abstract int PlayerHorsepowerPosition { get; }

        /// <summary>
        /// Start position of team horsepower values in the file.
        /// </summary>
        protected abstract int TeamHorsepowerPosition { get; }

        /// <summary>
        /// Start position of car colors in the file.
        /// </summary>
        protected abstract int CarColorsPosition { get; }

        /// <summary>
        /// Start position of driver race performance level values in the file.
        /// </summary>
        protected abstract int DriverRacePerformanceLevelsPosition { get; }

        /// <summary>
        /// Start position of driver qualifying performance level values in the file.
        /// </summary>
        protected abstract int DriverQualifyingPerformanceLevelsPosition { get; }

        /// <summary>
        /// Position of the general AI grip level.
        /// </summary>
        protected abstract int GeneralGripLevelPosition { get; }

        /// <summary>
        /// Start position of driver numbers in the file.
        /// </summary>
        protected abstract int DriverNumbersPosition { get; }

        /// <summary>
        /// Start position of pit crew colors in the file.
        /// </summary>
        protected abstract int PitCrewColorsPosition { get; }

        /// <summary>
        /// Start position of helmet colors in the file.
        /// </summary>
        protected abstract int HelmetColorsPosition { get; }

        /// <summary>
        /// Position of the value indicating the change of rain in the first race.
        /// </summary>
        protected abstract int RainAtFirstTrackPosition { get; }

        /// <summary>
        /// Position of the value indicating the overall chance of rain at a race.
        /// </summary>
        protected abstract int ChanceOfRainPosition { get; }

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

        internal const int ColorsPerPitCrew = 16;

        internal int GetPitCrewColorsPosition(int teamIndex)
        {
            return PitCrewColorsPosition + (teamIndex * ColorsPerPitCrew);
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

        internal int GetDriverRacePerformanceLevelPosition()
        {
            return DriverRacePerformanceLevelsPosition;
        }

        internal int GetDriverRacePerformanceLevelPositions(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);
            return DriverRacePerformanceLevelsPosition + driverNumber - 1;
        }

        internal int GetDriverPerformanceQualifyingPosition()
        {
            return DriverQualifyingPerformanceLevelsPosition;
        }

        internal int GetDriverQualifyingPerformanceLevelPositions(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);
            return DriverQualifyingPerformanceLevelsPosition + driverNumber - 1;
        }

        internal int GetGeneralGripLevelPosition()
        {
            return GeneralGripLevelPosition;
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

        internal int GetRainAtFirstTrackPosition()
        {
            return RainAtFirstTrackPosition;
        }

        internal int GetChanceOfRainPosition()
        {
            return ChanceOfRainPosition;
        }
    }

    internal static class GpExeFileFactory
    {
        internal static GpExeFile CreateFromPath(string exePath)
        {
            var exeInfo = GpExeFile.GetFileInfo(exePath);

            switch (exeInfo.Version)
            {
                case GpExeVersionInfo.European105:
                    return new European105GpExeFile(exePath);
                case GpExeVersionInfo.Us105:
                    return new Us105GpExeFile(exePath);
                default:
                    string msg = $"The specified file is of type {exeInfo}. ArgData currently supports European105 and Us105.";
                    throw new ArgumentException(msg);
            }
        }
    }

    internal class Us105GpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 19848;
        protected override int TeamHorsepowerPosition => 158336;
        protected override int CarColorsPosition => 158456;
        protected override int DriverRacePerformanceLevelsPosition => 158416;
        protected override int DriverQualifyingPerformanceLevelsPosition => 158376;
        protected override int GeneralGripLevelPosition => 20183;
        protected override int DriverNumbersPosition => 154892;
        protected override int PitCrewColorsPosition => 159377;
        protected override int HelmetColorsPosition => 158751;
        protected override int RainAtFirstTrackPosition => 106319;
        protected override int ChanceOfRainPosition => 58394;

        internal Us105GpExeFile(string exePath) : base(exePath)
        {
        }
    }

    internal class European105GpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 19848;
        protected override int TeamHorsepowerPosition => 158380;
        protected override int CarColorsPosition => 158500;
        protected override int DriverRacePerformanceLevelsPosition => 158460;
        protected override int DriverQualifyingPerformanceLevelsPosition => 158420;
        protected override int GeneralGripLevelPosition => 20183;
        protected override int DriverNumbersPosition => 154936;
        protected override int PitCrewColorsPosition => 159421;
        protected override int HelmetColorsPosition => 158795;
        protected override int RainAtFirstTrackPosition => 106319;
        protected override int ChanceOfRainPosition => 58394;

        internal European105GpExeFile(string exePath) : base(exePath)
        {
        }
    }
}
