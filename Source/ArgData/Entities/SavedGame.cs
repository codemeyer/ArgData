using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// A saved game containing a list of drivers and their results.
    /// </summary>
    public class SavedGame
    {
        /// <summary>
        /// Gets the number of races that have been completed.
        /// </summary>
        public int NumberOfRacesCompleted { get; set; }

        /// <summary>
        /// The drivers and their results.
        /// </summary>
        public List<SavedGameDriver> Drivers { get; set; }
    }
}
