namespace ArgData.Entities;

/// <summary>
/// Represents a list of qualifying and race setups for all tracks.
/// </summary>
public class SetupList
{
    /// <summary>
    /// Initalizes a new instance of a SetupList.
    /// </summary>
    public SetupList()
    {
        QualifyingSetups = SetupDefaultSetups();
        RaceSetups = SetupDefaultSetups();
    }

    /// <summary>
    /// Whether setups are separate for race (incl. pre-race practice) and qualifying (incl. practice).
    /// </summary>
    public bool SeparateSetups { get; set; }

    /// <summary>
    /// List of the 16 qualifying setups.
    /// </summary>
    public ReadOnlyList<Setup> QualifyingSetups { get; private set; }

    /// <summary>
    /// List of the 16 race setups.
    /// </summary>
    public ReadOnlyList<Setup> RaceSetups { get; private set; }

    private static ReadOnlyList<Setup> SetupDefaultSetups()
    {
        var setups = new List<Setup>();
        for (int i = 0; i <= 15; i++)
        {
            setups.Add(new Setup());
        }
        return new ReadOnlyList<Setup>(setups);
    }
}