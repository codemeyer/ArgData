using System;
using System.IO;
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
        public DriverPerformanceReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a DriverPerformanceReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverPerformanceReader.</returns>
        public static DriverPerformanceReader For(GpExeFile exeFile)
        {
            return new DriverPerformanceReader(exeFile);
        }

        /// <summary>
        /// Reads the race performance of the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to read race performance level for.</param>
        /// <returns>Performance level.</returns>
        public byte ReadRacePerformanceLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetDriverRacePerformanceLevelPositions(driverNumber);
                byte value = reader.ReadByte();

                return value;
            }
        }

        /// <summary>
        /// Reads the race performance of all drivers. Lower value indicates higher performance.
        /// </summary>
        /// <returns>DriverPerformanceList with performance levels.</returns>
        public DriverPerformanceList ReadRacePerformanceLevels()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetDriverRacePerformanceLevelPosition();
                byte[] values = reader.ReadBytes(Constants.NumberOfDrivers);

                return new DriverPerformanceList(values);
            }
        }

        /// <summary>
        /// Reads the qualifying performance level of the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to read qualifying performance level for.</param>
        /// <returns>Performance level.</returns>
        public byte ReadQualifyingPerformanceLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(driverNumber);
                byte value = reader.ReadByte();

                return value;
            }
        }

        /// <summary>
        /// Reads the qualifying performance level of all drivers. Lower value indicates higher performance.
        /// </summary>
        /// <returns>DriverPerformanceList with performance levels.</returns>
        public DriverPerformanceList ReadQualifyingPerformanceLevels()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetDriverPerformanceQualifyingPosition();
                byte[] values = reader.ReadBytes(Constants.NumberOfDrivers);

                return new DriverPerformanceList(values);
            }
        }

        /// <summary>
        /// Reads the general grip level for computer cars. Higher values mean that the computer cars
        /// go faster. Default value is 1.
        /// </summary>
        /// <returns>General grip level.</returns>
        public int ReadGeneralGripLevel()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetGeneralGripLevelPosition();
                int signature = DriverPerformanceGripLevelData.GetSignature(reader);
                int rawValuePosition = _exeFile.GetGeneralGripLevelPosition() + 3;

                if (signature == DriverPerformanceConstants.GripLevelDefaultSignature)
                {
                    reader.BaseStream.Position = rawValuePosition;
                    int rawValue = reader.ReadInt16();

                    if (rawValue == 16384)
                        return 1;

                    throw new Exception($"Unexpected value {rawValue} at position {rawValuePosition}, expected 16384");
                }

                if (signature == DriverPerformanceConstants.GripLevelActivatedSignature)
                {
                    reader.BaseStream.Position = rawValuePosition;
                    int rawValue = reader.ReadInt16();

                    return (rawValue + 100) / 100;
                }

                throw new Exception($"Unexpected data at position {rawValuePosition}!");
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
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
        public DriverPerformanceWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a DriverPerformanceWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DriverPerformanceWriter.</returns>
        public static DriverPerformanceWriter For(GpExeFile exeFile)
        {
            return new DriverPerformanceWriter(exeFile);
        }

        /// <summary>
        /// Writes the race performance level for the driver with the specified number. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverNumber">Driver number to write race performance level for.</param>
        /// <param name="performanceLevel">Performance level.</param>
        public void WriteRacePerformanceLevel(int driverNumber, byte performanceLevel)
        {
            DriverNumberValidator.Validate(driverNumber);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetDriverRacePerformanceLevelPositions(driverNumber);
                writer.Write(performanceLevel);
            }
        }

        /// <summary>
        /// Writes the race performance level for all drivers in numerical order. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverPerformances">DriverPerformanceList with performance levels.</param>
        public void WriteRacePerformanceLevels(DriverPerformanceList driverPerformances)
        {
            Validate(driverPerformances);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetDriverRacePerformanceLevelPositions(1);
                writer.Write(driverPerformances.ToArray());
            }
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

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(driverNumber);
                writer.Write(performanceLevel);
            }
        }

        /// <summary>
        /// Writes the qualifying performance level for all drivers in numerical order. Lower value indicates higher performance.
        /// </summary>
        /// <param name="driverPerformances">DriverPerformanceList with of performance levels.</param>
        public void WriteQualifyingPerformanceLevels(DriverPerformanceList driverPerformances)
        {
            Validate(driverPerformances);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetDriverQualifyingPerformanceLevelPositions(1);
                writer.Write(driverPerformances.ToArray());
            }
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

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                var byteSignature = gripLevel == 1
                    ? new byte[] { 0x79, 0x03, 0xb8, 0x00, 0x40 }
                    : new byte[] { 0x90, 0x81, 0xc0 };

                writer.BaseStream.Position = _exeFile.GetGeneralGripLevelPosition();
                writer.Write(byteSignature);

                if (gripLevel > 1)
                {
                    var gripValue = gripLevel * 100 - 100;
                    writer.Write((ushort)gripValue);
                }
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }

    internal static class DriverPerformanceGripLevelData
    {
        internal static int GetSignature(BinaryReader reader)
        {
            byte[] signatureBytes = reader.ReadBytes(4);
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
