using System;
using System.Linq;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the driver numbers, or inactives a driver.
    /// </summary>
    public class DriverNumberEditor
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a DriverNumberEditor.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public DriverNumberEditor(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the driver numbers. 0 indicates an inactivated driver.
        /// </summary>
        /// <returns>Byte array of driver numbers.</returns>
        public byte[] ReadDriverNumbers()
        {
            int position = _exeFile.GetDriverNumbersPosition();

            byte[] driverNumbers = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return driverNumbers;
        }

        /// <summary>
        /// Writes driver numbers. If set to 0, a driver is inactivated.
        /// </summary>
        /// <param name="driverNumbers">Byte array of driver numbers.</param>
        public void WriteDriverNumbers(byte[] driverNumbers)
        {
            CheckDriverNumbers(driverNumbers);

            var fileWriter = new FileWriter(_exeFile.ExePath);

            for (int i = 0; i < driverNumbers.Length; i++)
            {
                int position = _exeFile.GetDriverNumbersPosition(i);
                fileWriter.WriteByte(driverNumbers[i], position);
            }
        }

        private void CheckDriverNumbers(byte[] driverNumbers)
        {
            if (driverNumbers.Length != 40)
            {
                throw new Exception("Incorrect number of driver numbers provided. Must be exactly 40.");
            }

            int activeCount = driverNumbers.Count(driverNumber => driverNumber > 0);

            if (activeCount < 26)
            {
                throw new Exception("Too few active drivers. Must be at least 26.");
            }

            if (driverNumbers.Any(driverNumber => driverNumber > 40))
            {
                throw new Exception("Too high driver number specified. A driver number cannot be higher than 40.");
            }
        }
    }
}
