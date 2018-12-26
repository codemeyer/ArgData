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

                int posAfterBestLine = bestLines.PositionAfterReading;

                var setup = ComputerCarSetupReader.Read(reader, posAfterBestLine);
                track.ComputerCarSetup = setup.Setup;

                // +38 skips entire CC setup, remaining setup data goes into RawData.DataAfterSetup
                var pitLane = TrackSectionReader.Read(reader, bestLines.PositionAfterReading + 8 + 30);
                track.PitLaneSections = pitLane.TrackSections;

                track.RawData = RawDataReader.Read(reader, track.Offsets, posAfterBestLine, pitLane.Position);

                int lapCountLocation = track.RawData.FinalData2.Length - 6;
                track.LapCount = track.RawData.FinalData2[lapCountLocation];

                return track;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }
}
