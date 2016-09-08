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
        public byte FrontWing { get; set; } = 40;

        /// <summary>
        /// Gets or sets the rear wing setting. Allowed values between 0 and 64.
        /// </summary>
        public byte RearWing { get; set; } = 40;

        /// <summary>
        /// Gets or sets the ratio of the first gear. Must be 16 or higher, and lower than GearRatio2.
        /// </summary>
        public byte GearRatio1 { get; set; } = 24;

        /// <summary>
        /// Gets or sets the ratio of the second gear. Must be higher than GearRatio1 and lower than GearRatio3.
        /// </summary>
        public byte GearRatio2 { get; set; } = 32;

        /// <summary>
        /// Gets or sets the ratio of the third gear. Must be higher than GearRatio2 and lower than GearRatio4.
        /// </summary>
        public byte GearRatio3 { get; set; } = 39;

        /// <summary>
        /// Gets or sets the ratio of the fourth gear. Must be higher than GearRatio3 and lower than GearRatio5.
        /// </summary>
        public byte GearRatio4 { get; set; } = 46;

        /// <summary>
        /// Gets or sets the ratio of the fifth gear. Must be higher than GearRatio4 and lower than GearRatio6.
        /// </summary>
        public byte GearRatio5 { get; set; } = 53;

        /// <summary>
        /// Gets or sets the ratio of the sixth gear. Must be higher than GearRatio5 and lower than, or equal to, 80.
        /// </summary>
        public byte GearRatio6 { get; set; } = 61;

        /// <summary>
        /// Gets or sets the tyre compound.
        /// </summary>
        public SetupTyreCompound TyreCompound { get; set; } = SetupTyreCompound.C;

        /// <summary>
        /// Gets or sets the brake balance value. Allowed values between -32 (Rear) and 32 (Front).
        /// </summary>
        public sbyte BrakeBalance { get; set; }

        /// <summary>
        /// Whether the values currently entered in the setup are within allowed ranges.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (FrontWing > 64)
                    return false;

                if (RearWing > 64)
                    return false;

                if (BrakeBalance > 32)
                    return false;

                if (BrakeBalance < -32)
                    return false;

                if (GearRatio1 < 16)
                    return false;

                if (GearRatio1 >= GearRatio2)
                    return false;

                if (GearRatio2 >= GearRatio3)
                    return false;

                if (GearRatio3 >= GearRatio4)
                    return false;

                if (GearRatio4 >= GearRatio5)
                    return false;

                if (GearRatio5 >= GearRatio6)
                    return false;

                if (GearRatio6 > 80)
                    return false;

                return true;
            }
        }
    }

    /// <summary>
    /// Tyre compound in setup file. Can be A, B, C or D.
    /// </summary>
    public enum SetupTyreCompound
    {
        /// <summary>
        /// Tyre compound A, the hardest tyre.
        /// </summary>
        A = 0,

        /// <summary>
        /// Tyre compound B.
        /// </summary>
        B = 1,

        /// <summary>
        /// Tyre compound C.
        /// </summary>
        C = 2,

        /// <summary>
        /// Tyre compound D, the softest tyre (except qualifying tyres).
        /// </summary>
        D = 3
    }
}
