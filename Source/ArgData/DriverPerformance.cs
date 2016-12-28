using System;
using ArgData.Entities;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Reads the race or qualifying driver performance levels for computer drivers.
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
    }

    /// <summary>
    /// Writes the race or qualifying performance levels for computer drivers.
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

            int position = _exeFile.GetDriverRacePerformanceLevelPositions(0);
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

            int position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(0);
            new FileWriter(_exeFile.ExePath).WriteBytes(driverPerformances.ToArray(), position);
        }
    }
}
