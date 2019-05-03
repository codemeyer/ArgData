using System.Collections.Generic;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal class TrackBestLineReadingResult
    {
        public TrackBestLineReadingResult(short displacement,
            List<TrackBestLineSegment> bestLineSegments, int positionAfterReading)
        {
            Displacement = displacement;
            BestLineSegments = bestLineSegments;
            PositionAfterReading = positionAfterReading;
        }

        public short Displacement { get; set; }

        public List<TrackBestLineSegment> BestLineSegments { get; set; }

        public int PositionAfterReading { get; private set; }
    }
}
