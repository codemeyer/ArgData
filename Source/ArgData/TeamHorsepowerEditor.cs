using ArgData.IO;

namespace ArgData
{
    public class TeamHorsepowerEditor
    {
        private readonly GpExeEditor _exeEditor;

        public TeamHorsepowerEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        public int ReadTeamHorsepower(int teamIndex)
        {
            int position = _exeEditor.GetTeamHorsepowerPosition(teamIndex);

            ushort horsepower = new FileReader(_exeEditor.ExePath).ReadUShort(position);

            return horsepower;
        }

        public void WriteTeamHorsepower(int teamIndex, int horsepower)
        {
            int position = _exeEditor.GetTeamHorsepowerPosition(teamIndex);

            new FileWriter(_exeEditor.ExePath).WriteUInt16(horsepower, position);
        }
    }
}
