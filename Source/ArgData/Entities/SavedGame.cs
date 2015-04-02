using System.Collections.Generic;

namespace ArgData.Entities
{
    public class SavedGame
    {
        public int NumberOfRacesCompleted { get; set; }

        public List<SavedGameDriver> Drivers { get; set; }
    }
}