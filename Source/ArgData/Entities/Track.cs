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
            TrackDataHeader = new TrackSectionHeader();
            TrackSections = new List<TrackSection>();
            ComputerCarLineSegments = new List<TrackComputerCarLineSegment>();
            PitLaneSections = new List<TrackSection>();
            ObjectShapes = new List<TrackObjectShape>();
            ObjectSettings = new List<TrackObjectSettings>();
            ComputerCarSetup = new Setup();
            ComputerCarBehavior = new TrackComputerCarBehavior();
            CarSettings = new TrackCarSettings();
            TrackSettings = new TrackSettings();
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
        /// Gets or sets the displacement of the computer car line.
        /// </summary>
        public short ComputerCarLineDisplacement { get; set; }

        /// <summary>
        /// Gets a list of the computer car line segments.
        /// </summary>
        public IList<TrackComputerCarLineSegment> ComputerCarLineSegments { get; internal set; }

        /// <summary>
        /// Gets the computer car setup.
        /// </summary>
        public Setup ComputerCarSetup { get; internal set; }

        /// <summary>
        /// Gets the various behaviors of the computer cars.
        /// </summary>
        public TrackComputerCarBehavior ComputerCarBehavior { get; internal set; }

        /// <summary>
        /// Gets various settings that affect both the player car and the computer controlled cars.
        /// </summary>
        public TrackCarSettings CarSettings { get; internal set; }

        /// <summary>
        /// Gets the list of pit lane sections.
        /// </summary>
        public IList<TrackSection> PitLaneSections { get; internal set; }

        /// <summary>
        /// Gets the list of track-side camera commands.
        /// </summary>
        public TrackCameraCommandList TrackCameraCommands { get; internal set; }

        /// <summary>
        /// Gets various track settings, e.g. the lap count.
        /// </summary>
        public TrackSettings TrackSettings { get; set; }
    }
}
