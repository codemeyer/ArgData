namespace ArgData.Entities
{
    /// <summary>
    /// Describes various data in the track file, the purpose of which is (currently) unknown.
    /// </summary>
    public class TrackRawData
    {
        /// <summary>
        /// Gets or sets the FinalData1 bytes.
        /// </summary>
        public byte[] FinalData1 { get; set; }

        /// <summary>
        /// Gets or sets the FinalData2 bytes.
        /// </summary>
        public byte[] FinalData2 { get; set; }

        /// <summary>
        /// Gets or sets the data that appears after the computer car setup.
        /// 
        /// Possibly describes some of the computer car behavior.
        /// </summary>
        public byte[] DataAfterSetup { get; set; }
    }
}
