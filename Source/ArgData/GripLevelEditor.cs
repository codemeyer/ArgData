using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the race or qualifying grid level for computer drivers.
    /// </summary>
    public class GripLevelEditor
    {
        private readonly GpExeEditor _exeEditor;

        /// <summary>
        /// Initializes a new instance of a GripLevelEditor.
        /// </summary>
        /// <param name="exeEditor">GpExeEditor for the file to edit.</param>
        public GripLevelEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        /// <summary>
        /// Reads the race grip level of the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to read race grip level for.</param>
        /// <returns>Grip level.</returns>
        public int ReadRaceGripLevel(int driverIndex)
        {
            int position = _exeEditor.GetRaceGripLevelPositions(driverIndex);
            byte value = new FileReader(_exeEditor.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Reads the qualifying grip level of the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to read qualifying grip level for.</param>
        /// <returns>Grip level.</returns>
        public int ReadQualifyingGripLevel(int driverIndex)
        {
            int position = _exeEditor.GetQualifyingGripLevelPositions(driverIndex);
            byte value = new FileReader(_exeEditor.ExePath).ReadByte(position);

            return value;
        }

        /// <summary>
        /// Writes the race grip level for the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to write race grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteRaceGripLevel(int driverIndex, byte gripLevel)
        {
            int position = _exeEditor.GetRaceGripLevelPositions(driverIndex);
            new FileWriter(_exeEditor.ExePath).WriteByte(gripLevel, position);
        }

        /// <summary>
        /// Writes the qualifying grip level for the driver at the specified index. Lower value indicates higher grip.
        /// </summary>
        /// <param name="driverIndex">Index of driver to write qualifying grip level for.</param>
        /// <param name="gripLevel">Grip level.</param>
        public void WriteQualifyingGripLevel(int driverIndex, byte gripLevel)
        {
            int position = _exeEditor.GetQualifyingGripLevelPositions(driverIndex);
            new FileWriter(_exeEditor.ExePath).WriteByte(gripLevel, position);
        }
    }
}
