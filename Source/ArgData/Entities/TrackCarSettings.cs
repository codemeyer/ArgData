namespace ArgData.Entities
{
    /// <summary>
    /// Settings that apply both to the player's car and the computer cars.
    /// </summary>
    public class TrackCarSettings
    {
        /// <summary>
        /// Gets or sets the acceleration factor.
        /// </summary>
        public short Acceleration { get; set; } // affects player car too

        /// <summary>
        /// Gets or sets the air resistance.
        /// </summary>
        public short AirResistance { get; set; } // affects player car too

        /// <summary>
        /// Gets or sets the grip factor.
        /// </summary>
        public short GripFactor { get; set; } // affects player car too

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
    }
}
