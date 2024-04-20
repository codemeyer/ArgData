namespace ArgData.Entities;

/// <summary>
/// Represents a team with a name and engine manufacturer.
/// </summary>
public class Team
{
    /// <summary>
    /// Gets or sets the name of the team.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the engine manufacturer.
    /// </summary>
    public string Engine { get; set; } = string.Empty;
}