using ArgData.IO;

namespace ArgData
{
    public class DriverNumberEditor
    {
        private readonly GpExeEditor _exeEditor;

        public DriverNumberEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        public byte[] ReadDriverNumbers()
        {
            int position = _exeEditor.GetDriverNumbersPosition();

            byte[] driverNumbers = new FileReader(_exeEditor.ExePath).ReadBytes(position, 36);

            return driverNumbers;
        }

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
