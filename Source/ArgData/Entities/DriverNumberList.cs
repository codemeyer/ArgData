using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    /// <summary>
    /// List of driver numbers for 40 drivers.
    /// </summary>
    public class DriverNumberList : IEnumerable<byte>
    {
        private readonly byte[] _driverNumbers = new byte[Constants.NumberOfDrivers];

        /// <summary>
        /// Initializes a new instance of a DriverNumberList.
        /// </summary>
        public DriverNumberList()
        {
        }

        internal DriverNumberList(byte[] numbers)
        {
            _driverNumbers = numbers;
        }

        /// <summary>
        /// Gets or sets the driver number at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public byte this[byte index]
        {
            get { return _driverNumbers[index]; }
            set { _driverNumbers[index] = value; }
        }

        /// <summary>
        /// Gets or sets the driver number at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public int this[int index]
        {
            get { return _driverNumbers[index]; }
            set { _driverNumbers[index] = (byte)value; }
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
            return (IEnumerator<byte>)_driverNumbers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal byte[] GetNumbers()
        {
            return _driverNumbers;
        }
    }
}
