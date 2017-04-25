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
        internal readonly GpExeInfo ExeInfo;

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
                    exeInfo.IsDecompressed = false;
                    break;

                case 600480:
                    exeInfo.Version = GpExeVersionInfo.European105Decompressed;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = true;
                    exeInfo.IsDecompressed = true;
                    break;

                case 321716:
                    exeInfo.Version = GpExeVersionInfo.Us105;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = true;
                    exeInfo.IsDecompressed = false;
                    break;

                case 600304:
                    exeInfo.Version = GpExeVersionInfo.Us105Decompressed;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = true;
                    exeInfo.IsDecompressed = true;
                    break;

                case 332890:
                    exeInfo.Version = GpExeVersionInfo.European103;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = false;
                    exeInfo.IsDecompressed = false;
                    break;

                case 332840:
                    exeInfo.Version = GpExeVersionInfo.Us103;
                    exeInfo.IsKnownExeVersion = true;
                    exeInfo.IsEditingSupported = false;
                    exeInfo.IsDecompressed = false;
                    break;

                default:
                    exeInfo.Version = GpExeVersionInfo.Unknown;
                    exeInfo.IsKnownExeVersion = false;
                    exeInfo.IsEditingSupported = false;
                    exeInfo.IsDecompressed = false;
                    break;
            }

            return exeInfo;
        }

        internal GpExeFile(string exePath)
        {
            ExePath = exePath;
            ExeInfo = GpExeFile.GetFileInfo(exePath);
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

        /// <summary>
        /// Start position of the values that indicate points scored per finishing position.
        /// </summary>
        protected abstract int PointsSystemPosition { get; }

        /// <summary>
        /// Position of value indicating amount of damage needed for retiring after hitting the wall.
        /// </summary>
        protected abstract int RetireAfterHittingWallPosition { get; }

        /// <summary>
        /// Position of value indicating amount of damage needed for retiring after hitting another car.
        /// </summary>
        protected abstract int RetireAfterHittingOtherCarPosition { get; }

        /// <summary>
        /// Position of value indicating amount of damage needed for breaking a wing after hitting the wall.
        /// </summary>
        protected abstract int DamageAfterHittingWallPosition { get; }

        /// <summary>
        /// Position of value indicating amount of damage needed for breaking a wing after hitting another car.
        /// </summary>
        protected abstract int DamageAfterHittingOtherCarPosition { get; }

        /// <summary>
        /// Position of value indicating the number of seconds before retired cars are removed.
        /// </summary>
        protected abstract int RetiredCarsRemovedAfterSecondsPosition { get; }

        /// <summary>
        /// Position of value indicating the number of seconds before yellow flags are shown for stationary cars.
        /// </summary>
        protected abstract int YellowFlagsForStationaryCarsAfterSecondsPosition { get; }


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
            int bytesForPreviousHelmets =
                ExeInfo.IsDecompressed
                ? _bytesPerHelmetDecompressed.Take(helmetIndex).Sum(b => b)
                : _bytesPerHelmet.Take(helmetIndex).Sum(b => b);

            return HelmetColorsPosition + bytesForPreviousHelmets;
        }

        internal int GetHelmetColorsPositionByteCountToRead(int helmetIndex)
        {
            return ExeInfo.IsDecompressed
                ? _bytesPerHelmetDecompressed[helmetIndex]
                : _bytesPerHelmet[helmetIndex];
        }

        private readonly byte[] _bytesPerHelmet =
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 16, 14, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 14, 14, 14, 14, 14
        };

        private readonly byte[] _bytesPerHelmetDecompressed =
        {
            16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16
        };

        internal int GetRainAtFirstTrackPosition()
        {
            return RainAtFirstTrackPosition;
        }

        internal int GetChanceOfRainPosition()
        {
            return ChanceOfRainPosition;
        }

        internal int GetPointsSystemPosition()
        {
            return PointsSystemPosition;
        }

        internal int GetRetireAfterHittingWallPosition()
        {
            return RetireAfterHittingWallPosition;
        }

        internal int GetRetireAfterHittingOtherCarPosition()
        {
            return RetireAfterHittingOtherCarPosition;
        }

        internal int GetDamageAfterHittingWallPosition()
        {
            return DamageAfterHittingWallPosition;
        }

        internal int GetDamageAfterHittingOtherCarPosition()
        {
            return DamageAfterHittingOtherCarPosition;
        }

        internal int GetRetiredCarsRemovedAfterSecondsPosition()
        {
            return RetiredCarsRemovedAfterSecondsPosition;
        }

        internal int GetYellowFlagsForStationaryCarsAfterSecondsPosition()
        {
            return YellowFlagsForStationaryCarsAfterSecondsPosition;
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
                case GpExeVersionInfo.European105Decompressed:
                    return new European105DecompressedGpExeFile(exePath);
                case GpExeVersionInfo.Us105:
                    return new Us105GpExeFile(exePath);
                case GpExeVersionInfo.Us105Decompressed:
                    return new Us105DecompressedGpExeFile(exePath);
                default:
                    string msg = $"The specified file is of type {exeInfo}. ArgData currently supports European105, European105Decompressed, Us105 and Us105Decompressed.";
                    throw new ArgumentException(msg);
            }
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
        protected override int PointsSystemPosition => 158341;
        protected override int RetireAfterHittingWallPosition => 125420;
        protected override int RetireAfterHittingOtherCarPosition => 125422;
        protected override int DamageAfterHittingWallPosition => 125428;
        protected override int DamageAfterHittingOtherCarPosition => 125426;
        protected override int RetiredCarsRemovedAfterSecondsPosition => 23631;
        protected override int YellowFlagsForStationaryCarsAfterSecondsPosition => 23517;

        internal European105GpExeFile(string exePath) : base(exePath)
        {
        }
    }

    internal class European105DecompressedGpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 24600;
        protected override int TeamHorsepowerPosition => 183996;
        protected override int CarColorsPosition => 184116;
        protected override int DriverRacePerformanceLevelsPosition => 184076;
        protected override int DriverQualifyingPerformanceLevelsPosition => 184036;
        protected override int GeneralGripLevelPosition => 24935;
        protected override int DriverNumbersPosition => 180210;
        protected override int PitCrewColorsPosition => 185076;
        protected override int HelmetColorsPosition => 184436;
        protected override int RainAtFirstTrackPosition => 111746;
        protected override int ChanceOfRainPosition => 63146;
        protected override int PointsSystemPosition => 183940;
        protected override int RetireAfterHittingWallPosition => 131948;
        protected override int RetireAfterHittingOtherCarPosition => 131950;
        protected override int DamageAfterHittingWallPosition => 131956;
        protected override int DamageAfterHittingOtherCarPosition => 131954;
        protected override int RetiredCarsRemovedAfterSecondsPosition => 28383;
        protected override int YellowFlagsForStationaryCarsAfterSecondsPosition => 28269;

        internal European105DecompressedGpExeFile(string exePath) : base(exePath)
        {
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
        protected override int PointsSystemPosition => 158297;
        protected override int RetireAfterHittingWallPosition => 125376;
        protected override int RetireAfterHittingOtherCarPosition => 125378;
        protected override int DamageAfterHittingWallPosition => 125384;
        protected override int DamageAfterHittingOtherCarPosition => 125382;
        protected override int RetiredCarsRemovedAfterSecondsPosition => 23631;
        protected override int YellowFlagsForStationaryCarsAfterSecondsPosition => 23517;

        internal Us105GpExeFile(string exePath) : base(exePath)
        {
        }
    }

    internal class Us105DecompressedGpExeFile : GpExeFile
    {
        protected override int PlayerHorsepowerPosition => 24584;
        protected override int TeamHorsepowerPosition => 183932;
        protected override int CarColorsPosition => 184052;
        protected override int DriverRacePerformanceLevelsPosition => 184012;
        protected override int DriverQualifyingPerformanceLevelsPosition => 183972;
        protected override int GeneralGripLevelPosition => 24919;
        protected override int DriverNumbersPosition => 180146;
        protected override int PitCrewColorsPosition => 185012;
        protected override int HelmetColorsPosition => 184372;
        protected override int RainAtFirstTrackPosition => 111730;
        protected override int ChanceOfRainPosition => 63130;
        protected override int PointsSystemPosition => 183876;
        protected override int RetireAfterHittingWallPosition => 131884;
        protected override int RetireAfterHittingOtherCarPosition => 131886;
        protected override int DamageAfterHittingWallPosition => 131892;
        protected override int DamageAfterHittingOtherCarPosition => 131890;
        protected override int RetiredCarsRemovedAfterSecondsPosition => 28367;
        protected override int YellowFlagsForStationaryCarsAfterSecondsPosition => 28253;

        internal Us105DecompressedGpExeFile(string exePath) : base(exePath)
        {
        }
    }
}
