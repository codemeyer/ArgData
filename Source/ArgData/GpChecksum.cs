namespace ArgData
{
    /// <summary>
    /// GP checksum.
    /// </summary>
    public struct GpChecksum
    {
        /// <summary>
        /// First part of checksum.
        /// </summary>
        public int Checksum1 { get; set; }

        /// <summary>
        /// Second part of checksum.
        /// </summary>
        public int Checksum2 { get; set; }
    }
}
