using System;
using System.Collections.Generic;

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
            if (helmetColorBytes.Length != 14 && helmetColorBytes.Length != 16)
            {
                throw new ArgumentOutOfRangeException(nameof(helmetColorBytes), "Helmet must be created with 14 or 16 colors");
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
                    helmetBytes[2],
                    helmetBytes[3],
                    helmetBytes[4],
                    helmetBytes[5],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10],
                    helmetBytes[10]
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

        internal byte[] GetColorsToWriteToFile(int helmetIndex)
        {
            var helmetBytes = new List<byte>
            {
                Visor,
                FixedValueForIndex1,
                Stripes[0],
                Stripes[1],
                Stripes[2],
                Stripes[3],
                VisorSurround
            };

            if (helmetIndex != 12 && helmetIndex != 14 && helmetIndex < 35)
            {
                helmetBytes.Add(Stripes[4]);
                helmetBytes.Add(Stripes[5]);
                helmetBytes.Add(Stripes[6]);
                helmetBytes.Add(Stripes[7]);
                helmetBytes.Add(Stripes[8]);
                helmetBytes.Add(Stripes[9]);
                helmetBytes.Add(Stripes[10]);
                helmetBytes.Add(Stripes[11]);
                helmetBytes.Add(Stripes[12]);
            }
            else
            {
                if (helmetIndex == 12)
                {
                    helmetBytes.Add(199);
                }
                else if (helmetIndex == 14)
                {
                    helmetBytes.Add(23);
                }
                else if (helmetIndex == 35)
                {
                    helmetBytes.Add(71);
                }
                else if (helmetIndex > 35)
                {
                    helmetBytes.Add(7);
                }

                if (helmetIndex == 35)
                {
                    helmetBytes.Add(1);
                }
                else
                {
                    helmetBytes.Add(0);
                }

                helmetBytes.Add(178);
                helmetBytes.Add(Stripes[7]);
                helmetBytes.Add(9);
                helmetBytes.Add(0);
                helmetBytes.Add(176);
            }

            return helmetBytes.ToArray();
        }
    }
}
