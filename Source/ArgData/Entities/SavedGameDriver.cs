using System.Collections.Generic;

namespace ArgData.Entities
{
    public class SavedGameDriver : Driver
    {
        public SavedGameDriver()
        {
            Results = new List<int>();
        }

        public List<int> Results { get; set; }
    }
}