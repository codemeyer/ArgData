namespace ArgData.Entities
{
    /// <summary>
    /// Represents the shape of 3D track objects.
    /// </summary>
    public class TrackObjectShape
    {
        /// <summary>
        /// Initializes a new instance of a TrackObjectShape.
        /// </summary>
        /// <param name="headerIndex"></param>
        /// <param name="dataIndex"></param>
        public TrackObjectShape(int headerIndex, int dataIndex)
        {
            HeaderIndex = headerIndex;
            DataIndex = dataIndex;
        }

        /// <summary>
        /// Gets or sets the header index of the object shape.
        /// </summary>
        public int HeaderIndex { get; set; }

        /// <summary>
        /// Gets or sets the data index of the object shape.
        /// </summary>
        public int DataIndex { get; set; }

        /// <summary>
        /// Gets the length of the object data.
        /// </summary>
        public int DataLength => 30 + HeaderValue6.Length + OffsetData1.Length + OffsetData2.Length +
                                 OffsetData3.Length + OffsetData4.Length + OffsetData5.Length;

        /// <summary>
        /// Gets or sets HeaderValue1. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue1 { get; set; }

        /// <summary>
        /// Gets or setse the Offset1 value. Purpose currently not fully known.
        /// </summary>
        public short Offset1 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue2. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue2 { get; set; }

        /// <summary>
        /// Gets or setse the Offset2 value. Purpose currently not fully known.
        /// </summary>
        public short Offset2 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue3. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue3 { get; set; }

        /// <summary>
        /// Gets or setse the Offset3 value. Purpose currently not fully known.
        /// </summary>
        public short Offset3 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue4. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue4 { get; set; }

        /// <summary>
        /// Gets or setse the Offset4 value. Purpose currently not fully known.
        /// </summary>
        public short Offset4 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue5. Purpose currently not fully known.
        /// </summary>
        public byte[] HeaderValue5 { get; set; }

        /// <summary>
        /// Gets or setse the Offset5 value. Purpose currently not fully known.
        /// </summary>
        public short Offset5 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue6. Purpose currently not fully known.
        /// </summary>
        public byte[] HeaderValue6 { get; set; }

        /// <summary>
        /// Gets or sets the data at Offset1. Purpose currently not fully known.
        /// </summary>
        public byte[] OffsetData1 { get; set; }

        /// <summary>
        /// Gets or sets the data at Offset2. Purpose currently not fully known.
        /// </summary>
        public byte[] OffsetData2 { get; set; }

        /// <summary>
        /// Gets or sets the data at Offset3. Purpose currently not fully known.
        /// </summary>
        public byte[] OffsetData3 { get; set; }

        /// <summary>
        /// Gets or sets the data at Offset4. Purpose currently not fully known.
        /// </summary>
        public byte[] OffsetData4 { get; set; }

        /// <summary>
        /// Gets or sets the data at Offset5 Purpose currently not fully known.
        /// </summary>
        public byte[] OffsetData5 { get; set; }
    }
}
