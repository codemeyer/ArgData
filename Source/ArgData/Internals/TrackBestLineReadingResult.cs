using System.Collections.Generic;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal class TrackBestLineReadingResult
    {
        public TrackBestLineReadingResult(List<TrackBestLineSegment> bestLineSegments, int positionAfterReading)
        {
            BestLineSegments = bestLineSegments;
            PositionAfterReading = positionAfterReading;
        }

        public List<TrackBestLineSegment> BestLineSegments { get; set; }

        public int PositionAfterReading { get; private set; }
    }
}
