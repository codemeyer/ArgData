using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// List of driver numbers for 40 drivers.
    /// </summary>
    public class GripLevelList : IEnumerable<byte>
    {
        private readonly byte[] _gripLevels = new byte[Constants.NumberOfDrivers];

        /// <summary>
        /// Initializes a new instance of a DriverNumberList.
        /// </summary>
        public GripLevelList()
        {
        }

        internal GripLevelList(byte[] numbers)
        {
            _gripLevels = numbers;
        }

        /// <summary>
        /// Gets the grip level for the driver with the specified number.
        /// </summary>
        /// <param name="driverNumber">Number of driver to get grip level for.</param>
        /// <returns>Byte value representing the grip level. Lower value means higher grip.</returns>
        public byte GetByDriverNumber(byte driverNumber)
        {
            if (driverNumber == 0 || driverNumber > 40)
            {
                return 0;
            }

            return _gripLevels[driverNumber - 1];
        }

        /// <summary>
        /// Set the grip level for the driver with the specified number.
        /// </summary>
        /// <param name="driverNumber">Number of driver to get grip level for.</param>
        /// <param name="gripLevel">Byte value representing the grip level. Lower value means higher grip.</param>
        public void SetByDriverNumber(byte driverNumber, byte gripLevel)
        {
            _gripLevels[driverNumber - 1] = gripLevel;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<byte> GetEnumerator()
        {
            return (IEnumerator<byte>)_gripLevels.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns GripLevels as an array.
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            return _gripLevels;
        }
    }
}
