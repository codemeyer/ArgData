using System.Collections.Generic;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal class TrackComputerCarLineReadingResult
    {
        public TrackComputerCarLineReadingResult(short displacement,
            List<TrackComputerCarLineSegment> computerCarLineSegments, int positionAfterReading)
        {
            Displacement = displacement;
            ComputerCarLineSegments = computerCarLineSegments;
            PositionAfterReading = positionAfterReading;
        }

        public short Displacement { get; set; }

        public List<TrackComputerCarLineSegment> ComputerCarLineSegments { get; set; }

        public int PositionAfterReading { get; private set; }
    }
}
