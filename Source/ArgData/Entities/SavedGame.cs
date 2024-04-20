namespace ArgData.Entities;

/// <summary>
/// A saved game containing a list of drivers and their results.
/// </summary>
public class SavedGame
{
    /// <summary>
    /// Initializes a new instance of a SavedGame.
    /// </summary>
    /// <param name="drivers">Drivers who have competed.</param>
    /// <param name="numberOfRacesCompleted">Number of races completed.</param>
    internal SavedGame(SavedGameDriverList drivers, int numberOfRacesCompleted)
    {
        Drivers = drivers;
        NumberOfRacesCompleted = numberOfRacesCompleted;
    }

    /// <summary>
    /// Gets the number of races that have been completed.
    /// </summary>
    public int NumberOfRacesCompleted { get; private set; }

    /// <summary>
    /// The drivers and their results.
    /// </summary>
    public SavedGameDriverList Drivers { get; private set; }
}