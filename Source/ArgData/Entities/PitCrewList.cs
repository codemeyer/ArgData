using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of PitCrew objects.
    /// </summary>
    public class PitCrewList : IEnumerable
    {
        private readonly List<PitCrew> _list;

        /// <summary>
        /// Gets the PitCrew at the specified index.
        /// </summary>
        /// <param name="index">Index of the PitCrew to return.</param>
        /// <returns>The PitCrew object at the specified index.</returns>
        public PitCrew this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of a PitCrewList.
        /// </summary>
        public PitCrewList()
        {
            _list = new List<PitCrew>();
            for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
            {
                _list.Add(new PitCrew());
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a PitCrewList collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
