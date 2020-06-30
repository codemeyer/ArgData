namespace ArgData.Entities
{
    /// <summary>
    /// Represents a connection between two points in the object shape 3D definition.
    /// </summary>
    public class TrackObjectShapeVector
    {
        /// <summary>
        /// Gets or sets the index of the point the vector is going from.
        /// </summary>
        public byte From { get; set; }

        /// <summary>
        /// Gets or sets the index of the point the vector is going to.
        /// </summary>
        public byte To { get; set; }
    }
}
