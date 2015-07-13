using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of Helmet objects.
    /// </summary>
    public class HelmetList : IEnumerable
    {
        private readonly List<Helmet> _list;

        /// <summary>
        /// Gets the Helmet at the specified index.
        /// </summary>
        /// <param name="index">Index of the Helmet to return.</param>
        /// <returns>The Helmet object at the specified index.</returns>
        public Helmet this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of a HelmetList.
        /// </summary>
        public HelmetList()
        {
            _list = new List<Helmet>();
            for (int i = 0; i < 40; i++)
            {
                _list.Add(new Helmet());
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a HelmetList collection.
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
