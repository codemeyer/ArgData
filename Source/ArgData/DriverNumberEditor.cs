using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the driver numbers, or inactives a driver.
    /// </summary>
    public class DriverNumberEditor
    {
        private readonly GpExeEditor _exeEditor;

        /// <summary>
        /// Initializes a new instance of a DriverNumberEditor.
        /// </summary>
        /// <param name="exeEditor">GpExeEditor for the file to edit.</param>
        public DriverNumberEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        /// <summary>
        /// Reads the driver numbers. 0 indicates an inactivated driver.
        /// </summary>
        /// <returns>Byte array of driver numbers.</returns>
        public byte[] ReadDriverNumbers()
        {
            int position = _exeEditor.GetDriverNumbersPosition();

            byte[] driverNumbers = new FileReader(_exeEditor.ExePath).ReadBytes(position, 36);

            return driverNumbers;
        }

        /// <summary>
        /// Writes driver numbers. If set to 0, a driver is inactivated.
        /// </summary>
        /// <param name="driverNumbers">Byte array of driver numbers.</param>
        public void WriteDriverNumbers(byte[] driverNumbers)
        {
            var fileWriter = new FileWriter(_exeEditor.ExePath);

            for (int i = 0; i < driverNumbers.Length; i++)
            {
                int position = _exeEditor.GetDriverNumbersPosition(i);
                fileWriter.WriteByte(driverNumbers[i], position);
            }
        }
    }
}
