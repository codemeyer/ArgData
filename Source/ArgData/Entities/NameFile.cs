namespace ArgData.Entities
{
    /// <summary>
    /// Represents a file containing the names of the teams, engines and drivers.
    /// </summary>
    public class NameFile
    {
        /// <summary>
        /// Initializes a new instance of a NameFile.
        /// </summary>
        internal NameFile(NameFileDriverList drivers, NameFileTeamList teams)
        {
            Drivers = drivers;
            Teams = teams;
        }

        /// <summary>
        /// List of drivers.
        /// </summary>
        public NameFileDriverList Drivers { get; private set; }

        /// <summary>
        /// List of teams.
        /// </summary>
        public NameFileTeamList Teams { get; private set; }
    }
}
