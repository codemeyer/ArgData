using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of Car objects.
    /// </summary>
    public class CarList : IEnumerable
    {
        private readonly List<Car> _list;

        /// <summary>
        /// Gets the Car at the specified index.
        /// </summary>
        /// <param name="index">Index of the Car to return.</param>
        /// <returns>The Car object at the specified index.</returns>
        public Car this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of a CarList.
        /// </summary>
        public CarList()
        {
            _list = new List<Car>();
            for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
            {
                _list.Add(new Car());
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a CarList collection.
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
