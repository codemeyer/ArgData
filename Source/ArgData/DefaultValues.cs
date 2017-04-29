namespace ArgData
{
    /// <summary>
    /// Contains the default values for various data and settings in F1GP as constant values.
    /// </summary>
    public static class DefaultValues
    {
        /// <summary>
        /// The default player horsepower value.
        /// </summary>
        public const int PlayerHorsepowerValue = 716;

        /// <summary>
        /// The default general grip level for AI cars.
        /// </summary>
        public const int GeneralGripLevel = 1;

        /// <summary>
        /// The default chance of a wet race.
        /// </summary>
        public const byte ChanceOfRain = 6;

        /// <summary>
        /// The default possibility of wet races at the first track.
        /// </summary>
        public const bool RainAtFirstTrack = false;

        /// <summary>
        /// The default value for how likely a driver is to retire after hitting the wall.
        /// </summary>
        public const short RetireAfterHittingWall = 7424;

        /// <summary>
        /// The default value for how likely a driver is to retire after hitting another car.
        /// </summary>
        public const short RetireAfterHittingOtherCar = 8192;

        /// <summary>
        /// The default value for how likely a car is to be damaged after hitting a wall.
        /// </summary>
        public const short DamageAfterHittingWall = 1792;

        /// <summary>
        /// The default value for how likely a car is to be damaged after hitting another car.
        /// </summary>
        public const short DamageAfterHittingOtherCar = 1792;

        /// <summary>
        /// The default value for how many seconds it takes for retired cars to be removed.
        /// </summary>
        public const byte RetiredCarsRemovedAfterSeconds = 15;

        /// <summary>
        /// The default value for how many seconds it takes for the marshalls to show flags for stationary cars.
        /// </summary>
        public const byte YellowFlagsForStationaryCarsAfterSeconds = 20;
    }
}
