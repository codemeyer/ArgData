namespace ArgData.Entities
{
    /// <summary>
    /// Single car setup.
    /// </summary>
    public class Setup
    {
        /// <summary>
        /// Gets or sets the front wing setting. Allowed values between 0 and 64.
        /// </summary>
        public byte FrontWing { get; set; }

        /// <summary>
        /// Gets or sets the rear wing setting. Allowed values between 0 and 64.
        /// </summary>
        public byte RearWing { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the first gear.
        /// </summary>
        public byte GearRatio1 { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the second gear.
        /// </summary>
        public byte GearRatio2 { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the third gear.
        /// </summary>
        public byte GearRatio3 { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the fourth gear.
        /// </summary>
        public byte GearRatio4 { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the fifth gear.
        /// </summary>
        public byte GearRatio5 { get; set; }

        /// <summary>
        /// Gets or sets the ratio of the sixth gear.
        /// </summary>
        public byte GearRatio6 { get; set; }
        
        /// <summary>
        /// Gets or sets the tyre compound.
        /// </summary>
        public SetupTyreCompound TyresCompound { get; set; }

        /// <summary>
        /// Gets or sets the brake balance value. Allowed values between 0 and 32.
        /// </summary>
        public byte BrakeBalanceValue { get; set; }

        /// <summary>
        /// Gets or sets the brake balance direction, front or rear. If the brake balance is set to 0, direction does not matter.
        /// </summary>
        public SetupBrakeBalanceDirection BrakeBalanceDirection { get; set; }
    }

    /// <summary>
    /// Tyre compound in setup file. Can be A, B, C or D.
    /// </summary>
    public enum SetupTyreCompound
    {
        /// <summary>
        /// Tyre compound A, the hardest tyre.
        /// </summary>
        A,

        /// <summary>
        /// Tyre compound B.
        /// </summary>
        B,

        /// <summary>
        /// Tyre compound C.
        /// </summary>
        C,

        /// <summary>
        /// Tyre compound D, the softest tyre (except qualifying tyres).
        /// </summary>
        D
    }

    /// <summary>
    /// Brake balance direction, Front or Rear.
    /// </summary>
    public enum SetupBrakeBalanceDirection
    {
        /// <summary>
        /// Front brake balance.
        /// </summary>
        Front,

        /// <summary>
        /// Rear brake balance.
        /// </summary>
        Rear
    }
}
