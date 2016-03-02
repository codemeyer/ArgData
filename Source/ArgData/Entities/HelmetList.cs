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
        /// Gets the Helmet for the driver with the specified driver number.
        /// </summary>
        /// <param name="driverNumber">Driver number.</param>
        /// <returns>The Helmet at the specified index.</returns>
        public Helmet GetByDriverNumber(byte driverNumber)
        {
            return _list[driverNumber - 1];
        }

        /// <summary>
        /// Sets the Helmet for the driver with the specified driver number.
        /// </summary>
        /// <param name="driverNumber">Driver number.</param>
        /// <param name="helmet"></param>
        public void SetByDriverNumber(byte driverNumber, Helmet helmet)
        {
            _list[driverNumber - 1] = helmet;
        }

        /// <summary>
        /// Initializes a new instance of a HelmetList.
        /// </summary>
        public HelmetList()
        {
            _list = new List<Helmet>();
            for (int i = 0; i < Constants.NumberOfDrivers; i++)
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
