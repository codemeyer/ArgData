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
        /// <param name="helmetColorBytes">The colors to set. Must be exactly 16.</param>
        public Helmet(byte[] helmetColorBytes)
        {
            // TODO: check helmetColorBytes.Length

            SetColors(helmetColorBytes);
        }

        internal void SetColors(byte[] helmetBytes)
        {
            // TODO: handle fewer than 0-15 in helmetBytes

            Visor = helmetBytes[0];
            VisorSurround = helmetBytes[6];
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
    }
}
