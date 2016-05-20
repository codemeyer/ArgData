using System;
using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads the driver numbers.
    /// </summary>
    public class DriverNumberReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DriverNumberReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverNumberReader.</returns>
        public static DriverNumberReader For(GpExeFile exeFile)
        {
            return new DriverNumberReader(exeFile);
        }

        private DriverNumberReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the driver numbers. 0 indicates an inactivated driver.
        /// </summary>
        /// <returns>DriverNumberList containing all driver numbers.</returns>
        public DriverNumberList ReadDriverNumbers()
        {
            int position = _exeFile.GetDriverNumbersPosition();

            byte[] driverNumbers = new FileReader(_exeFile.ExePath).ReadBytes(position, Constants.NumberOfDrivers);

            return new DriverNumberList(driverNumbers);
        }
    }

    /// <summary>
    /// Writes the driver numbers, or inactives a driver.
    /// </summary>
    public class DriverNumberWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DriverNumberWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverNumberWriter.</returns>
        public static DriverNumberWriter For(GpExeFile exeFile)
        {
            return new DriverNumberWriter(exeFile);
        }

        private DriverNumberWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes driver numbers. If a driver number is set to 0, the driver is inactivated.
        /// </summary>
        /// <param name="driverNumbers">DriverNumberList of driver numbers.</param>
        public void WriteDriverNumbers(DriverNumberList driverNumbers)
        {
            CheckDriverNumbers(driverNumbers);

            var fileWriter = new FileWriter(_exeFile.ExePath);

            for (byte b = 0; b < Constants.NumberOfDrivers; b++)
            {
                int position = _exeFile.GetDriverNumbersPosition(b);
                fileWriter.WriteByte(driverNumbers[b], position);
            }
        }

        private void CheckDriverNumbers(DriverNumberList driverNumbers)
        {
            byte[] numbers = driverNumbers.GetNumbers();

            int activeCount = numbers.Count(driverNumber => driverNumber > 0);

            if (activeCount < 26)
            {
                throw new Exception("Too few active drivers. Must be at least 26.");
            }

            if (numbers.Any(driverNumber => driverNumber > 40))
            {
                throw new Exception("Too high driver number specified. A driver number cannot be higher than 40.");
            }
        }
    }
}
