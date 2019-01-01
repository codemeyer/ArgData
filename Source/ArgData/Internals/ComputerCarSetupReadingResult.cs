using ArgData.Entities;

namespace ArgData.Internals
{
    internal class ComputerCarDataReadingResult
    {
        public ComputerCarDataReadingResult(Setup setup, ComputerCarData computerCarData, int positionAfterReading)
        {
            Setup = setup;
            ComputerCarData = computerCarData;
            PositionAfterReading = positionAfterReading;
        }

        public Setup Setup { get; private set; }

        public ComputerCarData ComputerCarData { get; private set; }

        public int PositionAfterReading { get; private set; }
    }
}
