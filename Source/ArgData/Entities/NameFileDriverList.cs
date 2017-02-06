using System;
using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents a list of 40 drivers to be saved to a name file.
    /// </summary>
    public class NameFileDriverList : IEnumerable<Driver>
    {
        private readonly List<Driver> _drivers;

        /// <summary>
        /// Initializes a new instance of NameFileDriverList.
        /// </summary>
        public NameFileDriverList()
        {
            _drivers = new List<Driver>();
            for (int i = 1; i <= Constants.NumberOfDrivers; i++)
            {
                _drivers.Add(new Driver
                {
                    Name = $"Driver {i}"
                });
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Driver> GetEnumerator()
        {
            return _drivers.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _drivers.GetEnumerator();
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <returns>
        /// The number of elements in the collection.
        /// </returns>
        public int Count => _drivers.Count;

        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <returns>
        /// The element at the specified index in the read-only list.
        /// </returns>
        /// <param name="index">The zero-based index of the element to get. </param>
        public Driver this[int index]
        {
            get
            {
                if (index < 0 || index > Constants.NumberOfDrivers - 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 39");
                }

                return _drivers[index];
            }
        }
    }
}
