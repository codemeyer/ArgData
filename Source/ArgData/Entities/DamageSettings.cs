namespace ArgData.Entities
{
    /// <summary>
    /// Represents the various damage settings in the game.
    /// </summary>
    public class DamageSettings
    {
        /// <summary>
        /// Gets or sets how much damage needs to be done before a car retires from a crash with the wall.
        /// Lower value means less damage is needed. The default value is 7424.
        /// </summary>
        public short RetireAfterHittingWall { get; set; } = DefaultValues.RetireAfterHittingWall;

        /// <summary>
        /// Gets or sets how much damage needs to be done before a car retires from a crash with another car.
        /// Lower value means less damage is needed. The default value is 8192.
        /// </summary>
        public short RetireAfterHittingOtherCar { get; set; } = DefaultValues.RetireAfterHittingOtherCar;

        /// <summary>
        /// Gets or sets how much damage needs to be done before a wing breaks after crashing into the wall.
        /// Lower value means less damage is needed. The default value is 1792.
        /// </summary>
        public short DamageAfterHittingWall { get; set; } = DefaultValues.DamageAfterHittingWall;

        /// <summary>
        /// Gets or sets how much damage needs to be done before a wing breaks after crashing into another car.
        /// Lower value means less damage is needed. The default value is 1792.
        /// </summary>
        public short DamageAfterHittingOtherCar { get; set; } = DefaultValues.DamageAfterHittingOtherCar;

        /// <summary>
        /// Gets or sets how many seconds it takes before retired cars are removed from the track.
        /// </summary>
        public byte RetiredCarsRemovedAfterSeconds { get; set; } = DefaultValues.RetiredCarsRemovedAfterSeconds;

        /// <summary>
        /// Gets or sets how many seconds it takes before marshalls show yellow flags for cars that
        /// are stationary on track.
        /// </summary>
        public byte YellowFlagsForStationaryCarsAfterSeconds { get; set; } = DefaultValues.YellowFlagsForStationaryCarsAfterSeconds;

        /// <summary>
        /// Whether the specified damage setting values are within allowed ranges.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (RetireAfterHittingWall < 0)
                    return false;

                if (RetireAfterHittingOtherCar < 0)
                    return false;

                if (DamageAfterHittingWall < 0)
                    return false;

                if (DamageAfterHittingOtherCar < 0)
                    return false;

                if (YellowFlagsForStationaryCarsAfterSeconds < 1)
                    return false;

                if (YellowFlagsForStationaryCarsAfterSeconds > 60)
                    return false;

                if (RetiredCarsRemovedAfterSeconds < 1)
                    return false;

                if (RetiredCarsRemovedAfterSeconds > 60)
                    return false;

                return true;
            }
        }
    }
}
