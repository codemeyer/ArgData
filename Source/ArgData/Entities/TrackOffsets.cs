namespace ArgData.Entities
{
    /// <summary>
    /// Offsets into the track file. These are updated automatically when the track is saved.
    /// </summary>
    public class TrackOffsets
    {
        /// <summary>
        /// Gets the UnknownLong1 offset value.
        /// </summary>
        public int UnknownLong1 { get; internal set; }

        /// <summary>
        /// Gets the UnknownLong2 offset value.
        /// </summary>
        public int UnknownLong2 { get; internal set; }

        /// <summary>
        /// Gets the offset position of the file checksum.
        /// </summary>
        public short ChecksumPosition { get; internal set; }

        /// <summary>
        /// Gets the offset position of object data.
        /// </summary>
        public short ObjectData { get; internal set; }

        /// <summary>
        /// Gets the offset position of track section header and data.
        /// </summary>
        public short TrackData { get; internal set; }
    }
}
