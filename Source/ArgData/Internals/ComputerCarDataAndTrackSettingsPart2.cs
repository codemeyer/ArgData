namespace ArgData.Internals
{
    /// <summary>
    /// Internal class that represents various computer car behavior as well as lap count.
    ///
    /// The data read here is exposed through the ComputerCarBehavior and TrackSettings properties.
    /// </summary>
    internal class ComputerCarDataAndTrackSettingsPart2
    {
        /// <summary>
        /// Gets or sets the unknown, possibly unused, data. Must be 16 bytes.
        /// </summary>
        public byte[] UnknownData { get; set; }

        /// <summary>
        /// Gets or sets the length (in track units) that computer cars will avoid steering left or right
        /// at the start of a race.
        /// </summary>
        public short FormationLength { get; set; }

        /// <summary>
        /// Gets or sets an indication of lap time (in milliseconds) that is used to determine the
        /// duration of hot-seat stints, as well as the number of simultaneous runners during a non-race sessions.
        /// </summary>
        public int LapTimeIndication { get; set; }

        /// <summary>
        /// Gets or sets the number of laps in a 100% race.
        /// </summary>
        public short LapCount { get; set; }

        /// <summary>
        /// Gets or sets the first lap that cars will start to pit.
        /// </summary>
        public short StrategyFirstPitStopLap { get; set; }

        /// <summary>
        /// Gets or sets the chance that the strategy described in StrategyFirstPitStopLap is applied.
        /// </summary>
        public short StrategyChance { get; set; }
    }
}
