using ArgData.Entities;

namespace ArgData.Internals;

internal class ComputerCarAndTrackSettingsPart1DataReadingResult
{
    public ComputerCarAndTrackSettingsPart1DataReadingResult(Setup setup, ComputerCarDataAndTrackSettingsPart1 computerCarData, int positionAfterReading)
    {
        Setup = setup;
        ComputerCarData = computerCarData;
        PositionAfterReading = positionAfterReading;
    }

    public Setup Setup { get; private set; }

    public ComputerCarDataAndTrackSettingsPart1 ComputerCarData { get; private set; }

    public int PositionAfterReading { get; private set; }
}