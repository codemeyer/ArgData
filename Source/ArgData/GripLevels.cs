using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the race or qualifying grip level for computer drivers.
    /// </summary>
    public class GripLevelReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a GripLevelReader.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public GripLevelReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the race grip level of the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverNumber">Driver number to read race grip level for.</param>
        /// <returns>Grip level.</returns>
        public byte ReadRaceGripLevel(int driverNumber)
        {
            int position = _exeFile.GetRaceGripLevelPositions(driverNumber);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the race grip levels of all drivers. Lower value indicates higher grip.
        /// </summary>
        /// <returns>Byte array of grip levels.</returns>
        public GripLevelList ReadRaceGripLevels()
        {
            int position = _exeFile.GetRaceGripLevelPosition();
            byte[] values = new FileReader(_exeFile.ExePath).ReadBytes(position, 40);

            return new GripLevelList(values);
        }

        /// <summary>
        /// Reads the qualifying grip level of the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to read qualifying grip level for.</param>
        /// <returns>Grip level.</returns>
        public byte ReadQualifyingGripLevel(int driverIndex)
        {
            int position = _exeFile.GetQualifyingGripLevelPositions(driverIndex);
            byte value = new FileReader(_exeFile.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the qualifying grip level of all drivers. Lower value indicates higher grip.
        /// </summary>
        /// <returns>Byte array of grip levels.</returns>
        public GripLevelList ReadQualifyingGripLevels()
        {
            int position = _exeFile.GetQualifyingGripLevelPositions(0);
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
        /// Initializes a new instance of a GripLevelWriter.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public GripLevelWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the race grip level for the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to write race grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteRaceGripLevel(int driverIndex, byte gripLevel)
        {
            int position = _exeFile.GetRaceGripLevelPositions(driverIndex);
            new FileWriter(_exeFile.ExePath).WriteByte(gripLevel, position);
        }

        /// <summary>
        /// Writes the race grip level for all drivers in numerical order. Lower value indicates higher grip.
        /// </summary>
        /// <param name="gripLevels">Grip levels.</param>
        public void WriteRaceGripLevels(GripLevelList gripLevels)
        {
            int position = _exeFile.GetRaceGripLevelPositions(0);
            new FileWriter(_exeFile.ExePath).WriteBytes(gripLevels.ToArray(), position);
        }

        /// <summary>
        /// Writes the qualifying grip level for the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to write qualifying grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteQualifyingGripLevel(int driverIndex, byte gripLevel)
        {
            int position = _exeFile.GetQualifyingGripLevelPositions(driverIndex);
            new FileWriter(_exeFile.ExePath).WriteByte(gripLevel, position);
        }

        /// <summary>
        /// Writes the qualifying grip level for all drivers in numerical order. Lower value indicates higher grip.
        /// </summary>
        /// <param name="gripLevels">Byte array of grip levels.</param>
        public void WriteQualifyingGripLevels(GripLevelList gripLevels)
        {
            int position = _exeFile.GetQualifyingGripLevelPositions(0);
            new FileWriter(_exeFile.ExePath).WriteBytes(gripLevels.ToArray(), position);
        }
    }
}
