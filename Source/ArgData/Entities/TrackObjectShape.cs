using System;
using System.Collections.Generic;

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
            ScaleValues = new List<short>();
            RawPoints = new List<TrackObjectShapeRawPoint>();
            Vectors = new List<TrackObjectShapeVector>();
            Points = new List<ITrackObjectShapePoint>();
            PointsAdditionalBytes = new byte[0];
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
        public int DataLength
        {
            get
            {
                if (HeaderData6.Length > 0)
                {

                }

                return 32 + HeaderData6.Length + (ScaleValues.Count * 2) + OffsetData2.Length +
                       (Points.Count * 8) + PointsAdditionalBytes.Length + (Vectors.Count * 2) + OffsetData5.Length;
            }
        }

        /// <summary>
        /// Gets or sets HeaderValue1. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue1 { get; set; }

        /// <summary>
        /// Gets or sets the starting point for the ScaleValue data.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        ///
        /// This was previously Offset1.
        /// </summary>
        public short ScaleValueOffset { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue2. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue2 { get; set; }

        /// <summary>
        /// Gets or sets the Offset2 value.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        /// </summary>
        public short Offset2 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue3. Purpose currently not fully known.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        /// </summary>
        public short HeaderValue3 { get; set; }

        /// <summary>
        /// Gets or sets the starting point for the Point data.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        ///
        /// This was previously Offset3.
        /// </summary>
        public short PointDataOffset { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue4. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue4 { get; set; }

        /// <summary>
        /// Gets or sets the starting point for the Vector data.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        ///
        /// This was previously Offset4.
        /// </summary>
        public short VectorDataOffset { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue5. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue5 { get; set; }

        /// <summary>
        /// Gets or sets the HeaderData5 value. This must always be 10 bytes long. Purpose unknown.
        /// </summary>
        public byte[] HeaderData5 { get; set; }

        /// <summary>
        /// Gets or sets the Offset5 value.
        ///
        /// This value is updated when the track is saved, and should not be manipulated directly.
        /// </summary>
        public short Offset5 { get; set; }

        /// <summary>
        /// Gets or sets HeaderValue6. Purpose currently not fully known.
        /// </summary>
        public short HeaderValue6 { get; set; }

        /// <summary>
        /// Gets or sets the HeaderData6 value. This is always either 0 bytes or 10 bytes long. Purpose unknown.
        /// </summary>
        public byte[] HeaderData6 { get; set; }

        /// <summary>
        /// Gets or sets the raw byte data at Offset2, which represents GraphicElements.
        /// </summary>
        public byte[] OffsetData2 { get; set; }

        /// <summary>
        /// Gets or sets the raw byte data at Offset5, which represents GraphicElementsLists.
        /// </summary>
        public byte[] OffsetData5 { get; set; }

        /// <summary>
        /// Gets the list of ScaleValues.
        ///
        /// This was previously OffsetData1.
        /// </summary>
        public List<short> ScaleValues { get; }

        /// <summary>
        /// Gets the list of Points.
        ///
        /// This was previously OffsetData3.
        /// </summary>
        internal List<TrackObjectShapeRawPoint> RawPoints { get; }

        /// <summary>
        /// Gets the list of Points in the 3D shape.
        ///
        /// This was previously OffsetData3.
        /// </summary>
        [CLSCompliant(false)]
        public List<ITrackObjectShapePoint> Points { get; private set; }

        /// <summary>
        /// Gets or sets the additional "stray" point bytes that occur in a single object in the Silverstone track.
        /// </summary>
        public byte[] PointsAdditionalBytes { get; set; }

        /// <summary>
        /// Uses the RawPoints to update the 3D points using scale values (ScaleValues) and the raw point data (RawPoints).
        /// </summary>
        internal void UpdatePoints()
        {
            Points = new List<ITrackObjectShapePoint>();

            foreach (var point in RawPoints)
            {
                if (point.ReferencePointFlag == 0)
                {
                    var currentPoint = new TrackObjectShapeScalePoint(this);

                    if (point.XCoord >= 34)
                    {
                        short index = (short)((point.XCoord - 32 - 2) / 2);
                        currentPoint.XScaleValueIndex = index;
                        currentPoint.XIsNegative = true;
                    }
                    else if (point.XCoord != 0)
                    {
                        short index = (short)((point.XCoord - 2) / 2);
                        currentPoint.XScaleValueIndex = index;
                    }
                    else
                    {
                        currentPoint.XScaleValueIndex = -1;
                    }

                    if (point.YCoord >= 34)
                    {
                        short index = (short)((point.YCoord - 32 - 2) / 2);
                        currentPoint.YScaleValueIndex = index;
                        currentPoint.YIsNegative = true;
                    }
                    else if (point.YCoord != 0)
                    {
                        short index = (short)((point.YCoord - 2) / 2);
                        currentPoint.YScaleValueIndex = index;
                    }
                    else
                    {
                        currentPoint.YScaleValueIndex = -1;
                    }

                    currentPoint.Z = point.ZCoord;

                    Points.Add(currentPoint);
                }
                else if (point.ReferencePointFlag == 0x80)
                {
                    var currentRefPoint = new TrackObjectShapeReferencePoint(this)
                    {
                        PointIndex = point.XReferencePointValue,
                        Z = point.ZCoord
                    };

                    Points.Add(currentRefPoint);
                }
            }
        }

        /// <summary>
        /// Gets the list of Vectors.
        ///
        /// This was previously OffsetData4.
        /// </summary>
        public List<TrackObjectShapeVector> Vectors { get; }
    }
}
