using System;

namespace ArgData.Entities
{
    /// <summary>
    /// A Helmet represents a helmet with its various colors.
    /// </summary>
    public class Helmet
    {
        /// <summary>
        /// Initializes a new instance of a Helmet with all colors set to 0 (black).
        /// </summary>
        public Helmet()
            : this(new byte[16])
        {
        }

        /// <summary>
        /// Initializes a new instance of a Helmet with the specified colors.
        /// </summary>
        /// <param name="helmetColorBytes">The colors to set. Must be exactly 14 or 16 bytes.</param>
        public Helmet(byte[] helmetColorBytes)
        {
            if (helmetColorBytes.Length != GpExeFile.ColorsPerTeam)
            {
                throw new ArgumentOutOfRangeException("helmetColorBytes", "Helmet must be created with 14 or 16 colors");
            }

            SetColors(helmetColorBytes);
        }

        internal void SetColors(byte[] helmetBytes)
        {
            Visor = helmetBytes[0];
            VisorSurround = helmetBytes[6];

            if (helmetBytes.Length == 16)
            {
                Stripes = new byte[13]
                {
                    helmetBytes[2],
                    helmetBytes[3],
                    helmetBytes[4],
                    helmetBytes[5],
                    helmetBytes[7],
                    helmetBytes[8],
                    helmetBytes[9],
                    helmetBytes[10],
                    helmetBytes[11],
                    helmetBytes[12],
                    helmetBytes[13],
                    helmetBytes[14],
                    helmetBytes[15]
                };
            }
            else
            {
                Stripes = new byte[13]
                {
                    // TODO: fix for #13, #15 etc
                    helmetBytes[2],
                    helmetBytes[3],
                    helmetBytes[4],
                    helmetBytes[5],
                    helmetBytes[7],
                    helmetBytes[8],
                    helmetBytes[9],
                    helmetBytes[10],
                    helmetBytes[11],
                    helmetBytes[12],
                    0,
                    0,
                    0
                };
            }
        }

        /// <summary>
        /// Gets or sets the color of the visor. Default is 0.
        /// </summary>
        public byte Visor { get; set; }

        /// <summary>
        /// Gets or sets the color of the visor surround. Default is 6.
        /// </summary>
        public byte VisorSurround { get; set; }

        /// <summary>
        /// Gets or sets the color of the 13 horizontal stripes of the helmet.
        /// </summary>
        public byte[] Stripes { get; set; }


        private const byte FixedValueForIndex1 = 1;

        internal byte[] GetColorsToWriteToFile()
        {
            // TODO: support #13, #15 etc

            var helmetBytes = new[]
            {
                Visor,
                FixedValueForIndex1,
                Stripes[0],
                Stripes[1],
                Stripes[2],
                Stripes[3],
                VisorSurround,
                Stripes[4],
                Stripes[5],
                Stripes[6],
                Stripes[7],
                Stripes[8],
                Stripes[9],
                Stripes[10],
                Stripes[10],
                Stripes[11],
                Stripes[12]
            };

            return helmetBytes;
        }
    }
}
