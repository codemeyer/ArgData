using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents an F1GP track.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Initializes a new instance of a track.
        /// </summary>
        public Track()
        {
            Horizon = new TrackHorizon(new byte[4096]);
            Offsets = new TrackOffsets();
            RawData = new TrackRawData();
            TrackDataHeader = new TrackSectionHeader();
            TrackSections = new List<TrackSection>();
            BestLineSegments = new List<TrackBestLineSegment>();
            PitLaneSections = new List<TrackSection>();
            ObjectShapes = new List<TrackObjectShape>();
            ObjectSettings = new List<TrackObjectSettings>();
            ComputerCarSetup = new Setup();
            ComputerCarData = new ComputerCarData();
        }

        /// <summary>
        /// Gets the track horizon.
        /// </summary>
        public TrackHorizon Horizon { get; internal set; }

        /// <summary>
        /// Gets the data offset values.
        /// </summary>
        public TrackOffsets Offsets { get; internal set; }

        /// <summary>
        /// Gets the list of object shapes.
        /// </summary>
        public IList<TrackObjectShape> ObjectShapes { get; internal set; }

        /// <summary>
        /// Gets the list of object settings.
        /// </summary>
        public IList<TrackObjectSettings> ObjectSettings { get; internal set; }

        /// <summary>
        /// Gets the track data header.
        /// </summary>
        public TrackSectionHeader TrackDataHeader { get; internal set; }

        /// <summary>
        /// Gets the list of track sections.
        /// </summary>
        public IList<TrackSection> TrackSections { get; internal set; }

        /// <summary>
        /// Gets a list of the best line/computer car line segments.
        /// </summary>
        public IList<TrackBestLineSegment> BestLineSegments { get; internal set; }

        /// <summary>
        /// Gets the computer car setup.
        /// </summary>
        public Setup ComputerCarSetup { get; internal set; }

        /// <summary>
        /// Gets the additional computer and player car data.
        /// </summary>
        public ComputerCarData ComputerCarData { get; internal set; }

        /// <summary>
        /// Gets the list of pit lane sections.
        /// </summary>
        public IList<TrackSection> PitLaneSections { get; internal set; }

        /// <summary>
        /// Gets or sets the number of laps in a 100% race. This is part of the RawData.Final2 data.
        /// </summary>
        public byte LapCount { get; set; }

        /// <summary>
        /// Gets the "Raw" track data.
        /// </summary>
        public TrackRawData RawData { get; internal set; }
    }
}
