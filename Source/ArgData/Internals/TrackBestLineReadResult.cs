using System.Collections.Generic;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal class TrackBestLineReadResult
    {
        public TrackBestLineReadResult(int positionAfterReading, List<TrackBestLineSegment> bestLineSegments)
        {
            PositionAfterReading = positionAfterReading;
            BestLineSegments = bestLineSegments;
        }

        public int PositionAfterReading { get; private set; }

        public List<TrackBestLineSegment> BestLineSegments { get; set; }
    }
}
