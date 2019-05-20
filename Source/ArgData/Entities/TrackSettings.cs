namespace ArgData.Entities
{
    /// <summary>
    /// Various track settings.
    /// </summary>
    public class TrackSettings
    {
        /// <summary>
        /// Gets or sets the number of laps in a 100% race.
        /// </summary>
        public short LapCount { get; set; }

        /// <summary>
        /// Gets or sets an indication of lap time (in milliseconds) that is used to determine the
        /// duration of hot-seat stints, as well as the number of simultaneous runners during a non-race sessions.
        /// </summary>
        public int LapTimeIndication { get; set; }

        /// <summary>
        /// Gets or sets the time factor in sessions that are not race sessions.
        /// </summary>
        public short TimeFactorNonRace { get; set; }

        /// <summary>
        /// Gets or sets the time factor in a race session.
        /// </summary>
        public short TimeFactorRace { get; set; }

        /// <summary>
        /// Gets or sets the unknown track distance-related value.
        /// </summary>
        public short UnknownTrackDistance { get; set; }

        /// <summary>
        /// Gets or sets the default pit lane view distance.
        /// </summary>
        public short DefaultPitLaneViewDistance { get; set; }


        /// <summary>
        /// Gets or sets the type of surrounding area for the track.
        /// </summary>
        public SurroundingArea SurroundingArea { get; set; }

        /// <summary>
        /// Gets the kerb type, describing the number of colors it has.
        /// </summary>
        public KerbType KerbType { get; set; }

        /// <summary>
        /// Gets the kerb upper color of the kerbs.
        /// </summary>
        public byte KerbUpperColor { get; set; }

        /// <summary>
        /// Gets the kerb lower color of the kerbs.
        /// </summary>
        public byte KerbLowerColor { get; set; }

        /// <summary>
        /// Gets the alternate kerb upper color of the kerbs. Only used when KerbType is TripleColor.
        /// </summary>
        public byte KerbUpperColor2 { get; set; }

        /// <summary>
        /// Gets the alternate kerb lower color of the kerbs. Only used when KerbType is TripleColor.
        /// </summary>
        public byte KerbLowerColor2 { get; set; }

        /// <summary>
        /// Gets or sets which side of track that the pole position is located.
        /// </summary>
        public TrackSide PoleSide { get; set; }

        /// <summary>
        /// Gets or sets which side of the track that the pit lane is located.
        /// </summary>
        public TrackSide PitsSide { get; set; }
    }
}
