using System;
using ArgData.Entities;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Reads the race and qualifying driver performance levels for computer drivers,
    /// as well as the general grip level for computer cars.
    /// </summary>
    public class DriverPerformanceReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DriverPerformanceReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverPerformanceReader.</returns>
        public static DriverPerformanceReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new DriverPerformanceReader(exeFile);
        }

        private DriverPerformanceReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the race performance of the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to read race performance level for.</param>
        /// <returns>Performance level.</returns>
        public byte ReadRacePerformanceLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetDriverRacePerformanceLevelPositions(driverNumber);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the race performance of all drivers. Lower value indicates higher performance.
        /// </summary>
        /// <returns>DriverPerformanceList with performance levels.</returns>
        public DriverPerformanceList ReadRacePerformanceLevels()
        {
            int position = _exeFile.GetDriverRacePerformanceLevelPosition();
            byte[] values = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return new DriverPerformanceList(values);
        }

        /// <summary>
        /// Reads the qualifying performance level of the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to read qualifying performance level for.</param>
        /// <returns>Performance level.</returns>
        public byte ReadQualifyingPerformanceLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(driverNumber);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the qualifying performance level of all drivers. Lower value indicates higher performance.
        /// </summary>
        /// <returns>DriverPerformanceList with performance levels.</returns>
        public DriverPerformanceList ReadQualifyingPerformanceLevels()
        {
            int position = _exeFile.GetDriverPerformanceQualifyingPosition();
            byte[] values = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return new DriverPerformanceList(values);
        }

        /// <summary>
        /// Reads the general grip level for computer cars. Higher values mean that the computer cars
        /// go faster. Default value is 1.
        /// </summary>
        /// <returns>General grip level.</returns>
        public int ReadGeneralGripLevel()
        {
            int position = _exeFile.GetGeneralGripLevelPosition();
            var fileReader = new FileReader(_exeFile.ExePath);
            int signature = DriverPerformanceGripLevelData.GetSignature(fileReader, position);

            if (signature == DriverPerformanceConstants.GripLevelDefaultSignature)
            {
                int rawValue = fileReader.ReadUInt16(position + 3);

                if (rawValue == 16384)
                    return 1;

                throw new Exception($"Unexpected value {rawValue} at position {position + 3}, expected 16384");
            }

            if (signature == DriverPerformanceConstants.GripLevelActivatedSignature)
            {
                int rawValue = fileReader.ReadUInt16(position + 3);

                return (rawValue + 100) / 100;
            }

            throw new Exception($"Unexpected data at position {position}!");
        }
    }

    /// <summary>
    /// Writes the race or qualifying performance levels for computer drivers,
    /// as well as the general grip level for computer cars.
    /// </summary>
    public class DriverPerformanceWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DriverPerformanceWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverPerformanceWriter.</returns>
        public static DriverPerformanceWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new DriverPerformanceWriter(exeFile);
        }

        private DriverPerformanceWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the race performance level for the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to write race performance level for.</param>
        /// <param name="performanceLevel">Performance level.</param>
        public void WriteRacePerformanceLevel(int driverNumber, byte performanceLevel)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetDriverRacePerformanceLevelPositions(driverNumber);
            new FileWriter(_exeFile.ExePath).WriteByte(performanceLevel, position);
        }

        /// <summary>
        /// Writes the race performance level for all drivers in numerical order. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverPerformances">DriverPerformanceList with performance levels.</param>
        public void WriteRacePerformanceLevels(DriverPerformanceList driverPerformances)
        {
            Validate(driverPerformances);

            int position = _exeFile.GetDriverRacePerformanceLevelPositions(1);
            new FileWriter(_exeFile.ExePath).WriteBytes(driverPerformances.ToArray(), position);
        }

        private static void Validate(DriverPerformanceList driverPerformances)
        {
            if (driverPerformances == null)
                throw new ArgumentNullException(nameof(driverPerformances));
        }

        /// <summary>
        /// Writes the qualifying performance level for the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to write qualifying performance level for.</param>
        /// <param name="performanceLevel">Performance level.</param>
        public void WriteQualifyingPerformanceLevel(int driverNumber, byte performanceLevel)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(driverNumber);
            new FileWriter(_exeFile.ExePath).WriteByte(performanceLevel, position);
        }

        /// <summary>
        /// Writes the qualifying performance level for all drivers in numerical order. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverPerformances">DriverPerformanceList with of performance levels.</param>
        public void WriteQualifyingPerformanceLevels(DriverPerformanceList driverPerformances)
        {
            Validate(driverPerformances);

            int position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(1);
            new FileWriter(_exeFile.ExePath).WriteBytes(driverPerformances.ToArray(), position);
        }

        /// <summary>
        /// Writes the general grip level for computer cars. Allowed values range from 1 to 100.
        /// Greater values mean faster computer cars. Default value is 1.
        /// </summary>
        /// <param name="gripLevel">General grip level.</param>
        public void WriteGeneralGripLevel(int gripLevel)
        {
            if (gripLevel < 1 || gripLevel > 100)
                throw new ArgumentOutOfRangeException(nameof(gripLevel), $"{nameof(gripLevel)} must be between 1 and 100.");

            var fileWriter = new FileWriter(_exeFile.ExePath);

            var byteSignature = gripLevel == 1 ? new byte[] { 0x79, 0x03, 0xb8, 0x00, 0x40 } : new byte[] { 0x90, 0x81, 0xc0 };
            int position = _exeFile.GetGeneralGripLevelPosition();
            fileWriter.WriteBytes(byteSignature, position);

            if (gripLevel > 1)
            {
                var gripValue = gripLevel * 100 - 100;
                fileWriter.WriteUInt16(gripValue, position + 3);
            }
        }
    }

    internal static class DriverPerformanceGripLevelData
    {
        internal static int GetSignature(FileReader fileReader, int position)
        {
            byte[] signatureBytes = fileReader.ReadBytes(position, 4);
            signatureBytes[3] = 0;
            return BitConverter.ToInt32(signatureBytes, 0);
        }
    }

    internal static class DriverPerformanceConstants
    {
        internal const int GripLevelDefaultSignature = 12059513;
        internal const int GripLevelActivatedSignature = 12616080;
    }
}
