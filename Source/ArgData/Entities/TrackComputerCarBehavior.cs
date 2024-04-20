namespace ArgData.Entities;

/// <summary>
/// Represents various properties related to computer car behavior.
/// </summary>
public class TrackComputerCarBehavior
{
    /// <summary>
    /// Gets or sets the length (in track units) that computer cars will avoid steering left or right
    /// at the start of a race.
    /// </summary>
    public short FormationLength { get; set; }

    /// <summary>
    /// Gets or sets the computer car late-braking factor in non-race sessions.
    /// </summary>
    public short LateBrakingFactorNonRace { get; set; }

    /// <summary>
    /// Gets or sets the computer car late-braking factor in races.
    /// </summary>
    public short LateBrakingFactorRace { get; set; }

    /// <summary>
    /// Gets or sets the computer car late-braking factor in wet races.
    /// </summary>
    public short LateBrakingFactorWetRace { get; set; }

    /// <summary>
    /// Gets or sets the computer car power factor.
    /// </summary>
    public short PowerFactor { get; set; }

    /// <summary>
    /// Gets or sets the first lap that cars will start to pit.
    /// </summary>
    public short StrategyFirstPitStopLap { get; set; }

    /// <summary>
    /// Gets or sets the chance that this strategy is applied.
    /// </summary>
    public short StrategyChance { get; set; }

    /// <summary>
    /// Gets or sets the unknown, possibly unused, data. Must be 16 bytes.
    /// </summary>
    public byte[] UnknownData { get; set; } = new byte[16];
}