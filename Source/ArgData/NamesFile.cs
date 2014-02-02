using System.Collections.Generic;

namespace ArgData
{
    public class NamesFile
    {
        public NamesFile()
        {
            Drivers = new List<Driver>();
            Teams = new List<Team>();
        }

        public List<Driver> Drivers { get; set; }
        public List<Team> Teams { get; set; }
    }
}