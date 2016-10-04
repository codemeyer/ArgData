using System;

namespace ArgData.Entities
{
    /// <summary>
    /// A Car represents a car with its various colors.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Initializes a new instance of a Car with all colors set to 0 (black).
        /// </summary>
        public Car()
            : this(new byte[16])
        {
        }

        /// <summary>
        /// Initializes a new instance of a Car with the specified colors.
        /// </summary>
        /// <param name="carColorBytes">The colors to set. Must be exactly 16.</param>
        public Car(byte[] carColorBytes)
        {
            if (carColorBytes.Length != GpExeFile.ColorsPerTeam)
            {
                throw new ArgumentOutOfRangeException(nameof(carColorBytes), $"Car must be created with {GpExeFile.ColorsPerTeam} colors");
            }

            SetColors(carColorBytes);
        }

        /// <summary>
        /// Gets or sets the color of the front and rear wing elements.
        /// </summary>
        public byte FrontAndRearWing { get; set; }

        /// <summary>
        /// Gets or sets the color of the endplate of the front wing.
        /// </summary>
        public byte FrontWingEndplate { get; set; }

        /// <summary>
        /// Gets or sets the color of the side of the rear wing.
        /// </summary>
        public byte RearWingSide { get; set; }

        /// <summary>
        /// Gets or sets the color of the vertical part of the sidepod.
        /// </summary>
        public byte Sidepod { get; set; }

        /// <summary>
        /// Gets or sets the color of the top part of the sidepod.
        /// </summary>
        public byte SidepodTop { get; set; }

        /// <summary>
        /// Gets or sets the color of the main upper part of the engine cover.
        /// </summary>
        public byte EngineCover { get; set; }

        /// <summary>
        /// Gets or sets the color of the lower part of the engine cover.
        /// </summary>
        public byte EngineCoverSide { get; set; }

        /// <summary>
        /// Gets or sets the color of the rear, lower part of the engine cover.
        /// </summary>
        public byte EngineCoverRear { get; set; }

        /// <summary>
        /// Gets or sets the color of the part just in front of the cockpit opening.
        /// </summary>
        public byte CockpitFront { get; set; }

        /// <summary>
        /// Gets or sets the color of the side of the cockpit.
        /// </summary>
        public byte CockpitSide { get; set; }

        /// <summary>
        /// Gets or sets the color of the top part of the nose-cone.
        /// </summary>
        public byte NoseTop { get; set; }

        /// <summary>
        /// Gets or sets the color of the angled part between the top and side of the nose-cone.
        /// </summary>
        public byte NoseAngle { get; set; }

        /// <summary>
        /// Gets or sets the color of the side of the nose-cone.
        /// </summary>
        public byte NoseSide { get; set; }

        internal void SetColors(byte[] carBytes)
        {
            // 0, 9 and 10 are not used
            EngineCover = carBytes[1];
            CockpitFront = carBytes[2];
            FrontWingEndplate = carBytes[3];
            RearWingSide = carBytes[4];
            NoseSide = carBytes[5];
            Sidepod = carBytes[6];
            FrontAndRearWing = carBytes[7];
            NoseTop = carBytes[8];
            NoseAngle = carBytes[11];
            CockpitSide = carBytes[12];
            EngineCoverSide = carBytes[13];
            EngineCoverRear = carBytes[14];
            SidepodTop = carBytes[15];
        }

        private const byte FixedValueForIndex0 = 33;   // 0 in F1Ed;
        private const byte FixedValueForIndex9 = 54;   // varies in GP.EXE
        private const byte FixedValueForIndex10 = 36;  // 24 in F1Ed

        internal byte[] GetColorsToWriteToFile()
        {
            var carBytes = new[]
            {
                FixedValueForIndex0,
                EngineCover,
                CockpitFront,
                FrontWingEndplate,
                RearWingSide,
                NoseSide,
                Sidepod,
                FrontAndRearWing,
                NoseTop,
                FixedValueForIndex9,
                FixedValueForIndex10,
                NoseAngle,
                CockpitSide,
                EngineCoverSide,
                EngineCoverRear,
                SidepodTop
            };

            return carBytes;
        }
    }
}
