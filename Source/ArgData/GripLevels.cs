using System;
using ArgData.Entities;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Edits the race or qualifying grip level for computer drivers.
    /// </summary>
    public class GripLevelReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a GripLevelReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>GripLevelReader.</returns>
        public static GripLevelReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new GripLevelReader(exeFile);
        }

        private GripLevelReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the race grip level of the driver with the specified number. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverNumber">Driver number to read race grip level for.</param>
        /// <returns>Grip level.</returns>
        public byte ReadRaceGripLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetRaceGripLevelPositions(driverNumber);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the race grip levels of all drivers. Lower value indicates higher grip.
        /// </summary>
        /// <returns>GripLevelList with grip levels.</returns>
        public GripLevelList ReadRaceGripLevels()
        {
            int position = _exeFile.GetRaceGripLevelPosition();
            byte[] values = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return new GripLevelList(values);
        }

        /// <summary>
        /// Reads the qualifying grip level of the driver with the specified number. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverNumber">Driver number to read qualifying grip level for.</param>
        /// <returns>Grip level.</returns>
        public byte ReadQualifyingGripLevel(int driverNumber)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetQualifyingGripLevelPositions(driverNumber);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the qualifying grip level of all drivers. Lower value indicates higher grip.
        /// </summary>
        /// <returns>GripLevelList with grip levels.</returns>
        public GripLevelList ReadQualifyingGripLevels()
        {
            int position = _exeFile.GetQualifyingGripLevelPosition();
            byte[] values = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return new GripLevelList(values);
        }
    }

    /// <summary>
    /// Edits the race or qualifying grip level for computer drivers.
    /// </summary>
    public class GripLevelWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a GripLevelWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>GripLevelWriter.</returns>
        public static GripLevelWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new GripLevelWriter(exeFile);
        }

        private GripLevelWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the race grip level for the driver with the specified number. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverNumber">Driver number to write race grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteRaceGripLevel(int driverNumber, byte gripLevel)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetRaceGripLevelPositions(driverNumber);
            new FileWriter(_exeFile.ExePath).WriteByte(gripLevel, position);
        }

        /// <summary>
        /// Writes the race grip level for all drivers in numerical order. Lower value indicates higher grip.
        /// </summary>
        /// <param name="gripLevels">GripLevelList with grip levels.</param>
        public void WriteRaceGripLevels(GripLevelList gripLevels)
        {
            int position = _exeFile.GetRaceGripLevelPositions(0);
            new FileWriter(_exeFile.ExePath).WriteBytes(gripLevels.ToArray(), position);
        }

        /// <summary>
        /// Writes the qualifying grip level for the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverNumber">Driver number to write qualifying grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteQualifyingGripLevel(int driverNumber, byte gripLevel)
        {
            DriverNumberValidator.Validate(driverNumber);

            int position = _exeFile.GetQualifyingGripLevelPositions(driverNumber);
            new FileWriter(_exeFile.ExePath).WriteByte(gripLevel, position);
        }

        /// <summary>
        /// Writes the qualifying grip level for all drivers in numerical order. Lower value indicates higher grip.
        /// </summary>
        /// <param name="gripLevels">GripLevelList with of grip levels.</param>
        public void WriteQualifyingGripLevels(GripLevelList gripLevels)
        {
            int position = _exeFile.GetQualifyingGripLevelPositions(0);
            new FileWriter(_exeFile.ExePath).WriteBytes(gripLevels.ToArray(), position);
        }
    }
}
