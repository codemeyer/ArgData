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
        /// Initializes a new instance of a NamesFile.
        /// </summary>
        public NamesFile(List<Driver> drivers, List<Team> teams)
        {
            Drivers = drivers;
            Teams = teams;
        }

        /// <summary>
        /// List of drivers.
        /// </summary>
        public List<Driver> Drivers { get; private set; }

        /// <summary>
        /// List of teams.
        /// </summary>
        public List<Team> Teams { get; private set; }
    }
}
