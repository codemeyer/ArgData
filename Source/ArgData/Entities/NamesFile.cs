using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a file containing the names of the teams, engines and drivers.
    /// </summary>
    public class NamesFile
    {
        /// <summary>
        /// Initializes a new instance of a NamesFile.
        /// </summary>
        public NamesFile()
        {
            Drivers = new List<Driver>();
            Teams = new List<Team>();
        }

        /// <summary>
        /// List of drivers.
        /// </summary>
        public List<Driver> Drivers { get; set; }

        /// <summary>
        /// List of teams.
        /// </summary>
        public List<Team> Teams { get; set; }
    }
}
