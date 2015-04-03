using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a driver in a saved game.
    /// </summary>
    public class SavedGameDriver : Driver
    {
        /// <summary>
        /// Initializes a new instance of a saved game driver.
        /// </summary>
        public SavedGameDriver()
        {
            Results = new List<int>();
        }

        /// <summary>
        /// Gets the results of the driver in the saved game.
        /// </summary>
        public List<int> Results { get; set; }
    }
}
