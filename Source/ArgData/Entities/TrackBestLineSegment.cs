namespace ArgData.Entities
{
    /// <summary>
    /// Represents a segment of the best line/computer car line.
    /// </summary>
    public class TrackBestLineSegment
    {
        /// <summary>
        /// Gets or sets the type of segment.
        /// </summary>
        public TrackBestLineSegmentType SegmentType { get; set; }

        /// <summary>
        /// Gets or sets the length of the segment.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the displacement value. Only used when SegmentType is Displacement.
        /// </summary>
        public short Displacement { get; set; }

        /// <summary>
        /// Gets or sets the correction value. Called Tighter/Wider in GP2 Track Editor.
        /// </summary>
        public short Correction { get; set; }

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        public short Radius { get; set; }

        /// <summary>
        /// Gets or sets the corner high radius. Only used when SegmentType is WideRadius.
        /// </summary>
        public short HighRadius { get; set; }

        /// <summary>
        /// Gets or sets the corner low radius. Only used when SegmentType is WideRadius.
        /// </summary>
        public short LowRadius { get; set; }
    }

    /// <summary>
    /// Type of best line segment.
    /// </summary>
    public enum TrackBestLineSegmentType
    {
        /// <summary>
        /// Displacement. Always the first one for a track.
        /// </summary>
        Displacement,

        /// <summary>
        /// Normal segment.
        /// </summary>
        Normal,

        /// <summary>
        /// Wide radius segment, e.g. the back straight in Montreal.
        /// </summary>
        WideRadius
    }
}
