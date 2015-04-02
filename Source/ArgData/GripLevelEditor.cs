using ArgData.IO;

namespace ArgData
{
    public class GripLevelEditor
    {
        private readonly GpExeEditor _exeEditor;

        public GripLevelEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        public int ReadRaceGripLevel(int driverIndex)
        {
            int position = _exeEditor.GetRaceGripLevelPositions(driverIndex);
            byte value = new FileReader(_exeEditor.ExePath).ReadByte(position);

            return value;
        }

        public int ReadQualifyingGripLevel(int driverIndex)
        {
            int position = _exeEditor.GetQualifyingGripLevelPositions(driverIndex);
            byte value = new FileReader(_exeEditor.ExePath).ReadByte(position);

            return value;
        }
    }
}
