using System;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents the colors of the pit crew.
    /// </summary>
    public class PitCrew
    {
        /// <summary>
        /// Initializes a new instance of a PitCrew with all colors set to 0 (black).
        /// </summary>
        public PitCrew()
            : this(new byte[16])
        {
        }

        /// <summary>
        /// Initializes a new instance of a PitCrew with the specified colors.
        /// </summary>
        /// <param name="pitCrewColorBytes">The colors to set. Must be exactly 16.</param>
        public PitCrew(byte[] pitCrewColorBytes)
        {
            if (pitCrewColorBytes.Length != GpExeFile.ColorsPerTeam)
            {
                throw new Exception($"PitCrew must be created with {GpExeFile.ColorsPerTeam} colors");
            }

            SetColors(pitCrewColorBytes);
        }

        /// <summary>
        /// Gets or sets the primary shirt color.
        /// </summary>
        public byte ShirtPrimary { get; set; }

        /// <summary>
        /// Gets or sets the secondary shirt color.
        /// </summary>
        public byte ShirtSecondary { get; set; }

        /// <summary>
        /// Gets or sets the primary pants color.
        /// </summary>
        public byte PantsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the secondary pants color.
        /// </summary>
        public byte PantsSecondary { get; set; }

        /// <summary>
        /// Gets or sets the color of the socks.
        /// </summary>
        public byte Socks { get; set; }

        internal void SetColors(byte[] pitCrewBytes)
        {
            // 0, 1, 2, 7, 8, 9, 10, 12, 13, 14, 15 are not used
            ShirtPrimary = pitCrewBytes[6];
            ShirtSecondary = pitCrewBytes[5];
            PantsPrimary = pitCrewBytes[11];
            PantsSecondary = pitCrewBytes[4];
            Socks = pitCrewBytes[3];
        }

        private const byte FixedValueForIndex0 = 0;
        private const byte FixedValueForIndex1 = 1;
        private const byte FixedValueForIndex2 = 202;   // CA
        private const byte FixedValueForIndex7 = 7;
        private const byte FixedValueForIndex8 = 8;
        private const byte FixedValueForIndex9 = 205;   // CD
        private const byte FixedValueForIndex10 = 10;
        private const byte FixedValueForIndex12 = 12;
        private const byte FixedValueForIndex13 = 13;
        private const byte FixedValueForIndex14 = 14;
        private const byte FixedValueForIndex15 = 15;

        internal byte[] GetColorsToWriteToFile()
        {
            var carBytes = new[]
            {
                FixedValueForIndex0,
                FixedValueForIndex1,
                FixedValueForIndex2,
                Socks,
                PantsSecondary,
                ShirtSecondary,
                ShirtPrimary,
                FixedValueForIndex7,
                FixedValueForIndex8,
                FixedValueForIndex9,
                FixedValueForIndex10,
                PantsPrimary,
                FixedValueForIndex12,
                FixedValueForIndex13,
                FixedValueForIndex14,
                FixedValueForIndex15
            };

            return carBytes;
        }
    }
}
