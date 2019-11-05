using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.Internals;
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
        public DriverNumberReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a DriverNumberReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverNumberReader.</returns>
        public static DriverNumberReader For(GpExeFile exeFile)
        {
            return new DriverNumberReader(exeFile);
        }

        /// <summary>
        /// Reads the driver numbers. 0 indicates an inactivated driver.
        /// </summary>
        /// <returns>DriverNumberList containing all driver numbers.</returns>
        public DriverNumberList ReadDriverNumbers()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetDriverNumbersPosition();

                byte[] driverNumbers = reader.ReadBytes(Constants.NumberOfDrivers);

                return new DriverNumberList(driverNumbers);
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
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
        public DriverNumberWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a DriverNumberWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverNumberWriter.</returns>
        public static DriverNumberWriter For(GpExeFile exeFile)
        {
            return new DriverNumberWriter(exeFile);
        }

        /// <summary>
        /// Writes driver numbers. If a driver number is set to 0, the driver is inactivated.
        /// </summary>
        /// <param name="driverNumbers">DriverNumberList of driver numbers.</param>
        public void WriteDriverNumbers(DriverNumberList driverNumbers)
        {
            if (driverNumbers == null) { throw new ArgumentNullException(nameof(driverNumbers)); }
            CheckDriverNumbers(driverNumbers);

            var allDriverNumberBytes = new ByteList();

            for (byte b = 0; b < Constants.NumberOfDrivers; b++)
            {
                allDriverNumberBytes.AddByte(driverNumbers[b]);
            }

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetDriverNumbersPosition(0);
                writer.Write(allDriverNumberBytes.GetBytes());
            }
        }

        private static void CheckDriverNumbers(DriverNumberList driverNumbers)
        {
            byte[] numbers = driverNumbers.GetNumbers();

            int activeCount = numbers.Count(driverNumber => driverNumber > 0);

            if (activeCount < 26)
            {
                throw new ArgumentException("Too few active drivers. Must be at least 26.");
            }

            if (numbers.Any(driverNumber => driverNumber > 40))
            {
                throw new ArgumentException("Too high driver number specified. A driver number cannot be higher than 40.");
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
