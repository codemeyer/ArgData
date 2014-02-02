using System.Collections.Generic;

namespace ArgData
{
    public class SavedGame
    {
        public int NumberOfRacesCompleted { get; set; }

        public List<Driver> Drivers { get; set; }
    }
}