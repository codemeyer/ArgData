namespace ArgData.Internals
{
    /// <summary>
    /// Internal class that contains various properties that affect the computer car (and player car) in various ways.
    ///
    /// The data read here is exposed through the CarSettings, ComputerCarBehavior and TrackSettings properties.
    /// </summary>
    internal class ComputerCarDataAndTrackSettingsPart1
    {
        /// <summary>
        /// Gets or sets the grip factor.
        /// </summary>
        public short GripFactor { get; set; } // affects player car too

        /// <summary>
        /// Gets or sets the computer car late-braking factor in non-race sessions.
        /// </summary>
        public short ComputerCarLateBrakingFactorNonRace { get; set; }

        /// <summary>
        /// Gets or sets the computer car late-braking factor in races.
        /// </summary>
        public short ComputerCarLateBrakingFactorRace { get; set; }

        /// <summary>
        /// Gets or sets the computer car late-braking factor in wet races.
        /// </summary>
        public short ComputerCarLateBrakingFactorWetRace { get; set; }

        /// <summary>
        /// Gets or sets the time factor in sessions that are not race sessions.
        /// </summary>
        public short TimeFactorNonRace { get; set; }

        /// <summary>
        /// Gets or sets the time factor in a race session.
        /// </summary>
        public short TimeFactorRace { get; set; }

        /// <summary>
        /// Gets or sets the acceleration factor.
        /// </summary>
        public short Acceleration { get; set; } // affects player car too

        /// <summary>
        /// Gets or sets the air resistance.
        /// </summary>
        public short AirResistance { get; set; } // affects player car too

        /// <summary>
        /// Gets or sets the tyre wear in qualifying sessions.
        /// </summary>
        public short TyreWearQualifying { get; set; }

        /// <summary>
        /// Gets or sets the tyre wear in sessions that are not a qualifying session.
        /// </summary>
        public short TyreWearNonQualifying { get; set; }

        /// <summary>
        /// Gets or sets the fuel load, measured in pounds (lbs).
        /// </summary>
        public short FuelLoad { get; set; }

        /// <summary>
        /// Gets or sets the computer car power factor.
        /// </summary>
        public short ComputerCarPowerFactor { get; set; } // little effect?

        /// <summary>
        /// Gets or sets the unknown track distance-related value.
        /// </summary>
        public short UnknownTrackDistance { get; set; }

        /// <summary>
        /// Gets or sets the default pit lane view distance.
        /// </summary>
        public short DefaultPitLaneViewDistance { get; set; }
    }
}
