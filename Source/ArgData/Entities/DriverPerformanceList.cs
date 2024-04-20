using System.Collections;

namespace ArgData.Entities;

/// <summary>
/// List of driver numbers for 40 drivers.
/// </summary>
public class DriverPerformanceList : IEnumerable<byte>
{
    private readonly byte[] _performanceLevels = new byte[Constants.NumberOfDrivers];

    /// <summary>
    /// Initializes a new instance of a DriverPerformanceList.
    /// </summary>
    public DriverPerformanceList()
    {
    }

    internal DriverPerformanceList(byte[] numbers)
    {
        _performanceLevels = numbers;
    }

    /// <summary>
    /// Gets the performance level for the driver with the specified number.
    /// </summary>
    /// <param name="driverNumber">Number of driver to get performance level for.</param>
    /// <returns>Byte value representing the performance. Lower value means higher performance.</returns>
    public byte GetByDriverNumber(byte driverNumber)
    {
        if (driverNumber == 0 || driverNumber > 40)
        {
            return 0;
        }

        return _performanceLevels[driverNumber - 1];
    }

    /// <summary>
    /// Set the performance level for the driver with the specified number.
    /// </summary>
    /// <param name="driverNumber">Number of driver to get performance level for.</param>
    /// <param name="performanceLevel">Byte value representing the performance. Lower value means higher performance.</param>
    public void SetByDriverNumber(byte driverNumber, byte performanceLevel)
    {
        _performanceLevels[driverNumber - 1] = performanceLevel;
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
        return (IEnumerator<byte>)_performanceLevels.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Returns driver performance levels as an array.
    /// </summary>
    /// <returns></returns>
    public byte[] ToArray()
    {
        return _performanceLevels;
    }
}
