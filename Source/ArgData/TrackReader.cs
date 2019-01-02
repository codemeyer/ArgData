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
                track.TrackDataHeader = TrackSectionHeaderReader.Read(reader, track.Offsets.TrackData);

                var sectionReading = TrackSectionReader.Read(reader, track.Offsets.TrackData + track.TrackDataHeader.GetHeaderLength());
                track.TrackSections = sectionReading.TrackSections;

                var bestLines = BestLineReader.Read(reader, sectionReading.Position);
                track.BestLineSegments = bestLines.BestLineSegments;

                int positionAfterReadingBestLine = bestLines.PositionAfterReading;

                var computerCarData = ComputerCarDataReader.Read(reader, positionAfterReadingBestLine);
                track.ComputerCarSetup = computerCarData.Setup;
                track.ComputerCarData = computerCarData.ComputerCarData;

                var pitLane = TrackSectionReader.Read(reader, computerCarData.PositionAfterReading);
                track.PitLaneSections = pitLane.TrackSections;

                var cameras = TrackCameraReader.Read(reader, pitLane.Position);
                track.TrackCameraCommands = cameras.CameraCommands;

                var behavior = ComputerCarBehaviorReader.Read(reader, cameras.PositionAfterReading);
                track.ComputerCarBehavior = behavior;

                return track;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }
}
