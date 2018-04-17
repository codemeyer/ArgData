using ArgData.Entities;
using ArgData.Internals;

namespace ArgData
{
    /// <summary>
    /// Reads track data into a Track object.
    /// </summary>
    public static class TrackReader
    {
        /// <summary>
        /// Reads the specified track file and returns a Track object.
        /// </summary>
        /// <param name="path">Path to track file.</param>
        /// <returns>Track object.</returns>
        public static Track Read(string path)
        {
            var track = new Track();

            track.Horizon = HorizonReader.Read(path);
            track.Offsets = OffsetReader.Read(path);
            track.ObjectShapes = ObjectShapesReader.Read(path, track.Offsets.ObjectData);
            track.ObjectSettings = TrackObjectSettingsReader.Read(path, track.Offsets.ObjectData, track.Offsets.TrackData);
            track.TrackDataHeader = TrackSectionHeaderReader.Read(path, track.Offsets.TrackData);

            var sectionReading = TrackSectionReader.Read(path, track.Offsets.TrackData + track.TrackDataHeader.GetHeaderLength());
            track.TrackSections = sectionReading.TrackSections;

            var bestLines = BestLineReader.Read(path, sectionReading.Position);
            track.BestLineSegments = bestLines.BestLineSegments;

            int posAfterBestLine = bestLines.PositionAfterReading;

            var setup = ComputerCarSetupReader.Read(path, posAfterBestLine);
            track.ComputerCarSetup = setup.Setup;

            // +38 skips entire CC setup, remaining setup data goes into RawData.DataAfterSetup
            var pitLane = TrackSectionReader.Read(path, bestLines.PositionAfterReading + 8 + 30);
            track.PitLaneSections = pitLane.TrackSections;

            track.RawData = RawDataReader.Read(path, track.Offsets, posAfterBestLine, pitLane.Position);

            int lapCountLocation = track.RawData.FinalData2.Length - 6;
            track.LapCount = track.RawData.FinalData2[lapCountLocation];

            return track;
        }

    }
}
