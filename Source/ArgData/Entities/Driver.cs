using System.Collections.Generic;

namespace ArgData.Entities
{
    public class Driver
    {
        public Driver()
        {
            Results = new List<int>();
        }

        public string Name { get; set; }

        public List<int> Results { get; set; }
    }
}
