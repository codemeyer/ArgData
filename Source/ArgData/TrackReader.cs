using System;
using System.IO;
using ArgData.Entities;
using ArgData.Internals;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads track data from an F1GP track file into a Track object.
    /// </summary>
    public class TrackReader
    {
        /// <summary>
        /// Reads the specified track file and returns a Track object.
        /// </summary>
        /// <param name="path">Path to track file.</param>
        /// <returns>Track object.</returns>
        public Track Read(string path)
        {
            var track = new Track();

            using (var reader = new BinaryReader(StreamProvider(path)))
            {
                track.Horizon = HorizonReader.Read(reader);
                track.Offsets = OffsetReader.Read(reader);
                track.ObjectShapes = ObjectShapesReader.Read(reader, track.Offsets.ObjectData);
                track.ObjectSettings = TrackObjectSettingsReader.Read(reader, track.Offsets.ObjectData, track.Offsets.TrackData);

                var internalHeader = TrackSectionHeaderReader.Read(reader, track.Offsets.TrackData);
                var header = new TrackSectionHeader
                {
                    FirstSectionAngle = internalHeader.FirstSectionAngle,
                    FirstSectionHeight = internalHeader.FirstSectionHeight,
                    LeftVergeStartWidth = internalHeader.LeftVergeStartWidth,
                    RightVergeStartWidth = internalHeader.RightVergeStartWidth,
                    StartWidth = internalHeader.StartWidth,
                    TrackCenterX = internalHeader.TrackCenterX,
                    TrackCenterY = internalHeader.TrackCenterY,
                    TrackCenterZ = internalHeader.TrackCenterZ
                };
                track.TrackDataHeader = header;

                var sectionReading = TrackSectionReader.Read(reader, track.Offsets.TrackData + internalHeader.GetHeaderLength());
                track.TrackSections = sectionReading.TrackSections;

                var bestLines = BestLineReader.Read(reader, sectionReading.Position);
                track.BestLineDisplacement = bestLines.Displacement;
                track.BestLineSegments = bestLines.BestLineSegments;

                int positionAfterReadingBestLine = bestLines.PositionAfterReading;

                var computerCarData = ComputerCarAndTrackSettingsPart1DataReader.Read(reader, positionAfterReadingBestLine);
                track.ComputerCarSetup = computerCarData.Setup;

                var pitLane = TrackSectionReader.Read(reader, computerCarData.PositionAfterReading);
                track.PitLaneSections = pitLane.TrackSections;

                var cameras = TrackCameraReader.Read(reader, pitLane.Position);
                track.TrackCameraCommands = cameras.CameraCommands;

                var behavior = ComputerCarAndTrackSettingsPart2Reader.Read(reader, cameras.PositionAfterReading);

                var newBehavior = new TrackComputerCarBehavior
                {
                    FormationLength = behavior.FormationLength,
                    LateBrakingFactorNonRace = computerCarData.ComputerCarData.ComputerCarLateBrakingFactorNonRace,
                    LateBrakingFactorRace = computerCarData.ComputerCarData.ComputerCarLateBrakingFactorRace,
                    LateBrakingFactorWetRace = computerCarData.ComputerCarData.ComputerCarLateBrakingFactorWetRace,
                    PowerFactor = computerCarData.ComputerCarData.ComputerCarPowerFactor,
                    StrategyChance = behavior.StrategyChance,
                    StrategyFirstPitStopLap = behavior.StrategyFirstPitStopLap,
                    UnknownData = behavior.UnknownData
                };
                track.ComputerCarBehavior = newBehavior;

                var newCarSettings = new TrackCarSettings
                {
                    Acceleration = computerCarData.ComputerCarData.Acceleration,
                    AirResistance = computerCarData.ComputerCarData.AirResistance,
                    FuelLoad = computerCarData.ComputerCarData.FuelLoad,
                    GripFactor = computerCarData.ComputerCarData.GripFactor,
                    TyreWearNonQualifying = computerCarData.ComputerCarData.TyreWearNonQualifying,
                    TyreWearQualifying = computerCarData.ComputerCarData.TyreWearQualifying
                };
                track.CarSettings = newCarSettings;

                var trackSettings = new TrackSettings
                {
                    DefaultPitLaneViewDistance = computerCarData.ComputerCarData.DefaultPitLaneViewDistance,
                    LapCount = behavior.LapCount,
                    LapTimeIndication = behavior.LapTimeIndication,
                    TimeFactorNonRace = computerCarData.ComputerCarData.TimeFactorNonRace,
                    TimeFactorRace = computerCarData.ComputerCarData.TimeFactorRace,
                    UnknownTrackDistance = computerCarData.ComputerCarData.UnknownTrackDistance,

                    KerbType = internalHeader.KerbType,
                    KerbLowerColor = internalHeader.KerbLowerColor,
                    KerbUpperColor = internalHeader.KerbUpperColor,
                    KerbLowerColor2 = internalHeader.KerbLowerColor2,
                    KerbUpperColor2 = internalHeader.KerbUpperColor2,
                    PitsSide = internalHeader.PitsSide,
                    PoleSide = internalHeader.PoleSide,
                    SurroundingArea = internalHeader.SurroundingArea
                };
                track.TrackSettings = trackSettings;

                return track;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }
}
