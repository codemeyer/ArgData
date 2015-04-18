using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits horsepower values of teams.
    /// </summary>
    public class TeamHorsepowerEditor
    {
        private readonly GpExeFile _exeEditor;

        /// <summary>
        /// Initializes a new instance of a TeamHorsepowerEditor.
        /// </summary>
        /// <param name="exeEditor">GpExeEditor for the file to edit.</param>
        public TeamHorsepowerEditor(GpExeFile exeEditor)
        {
            _exeEditor = exeEditor;
        }

        /// <summary>
        /// Reads the horsepower value of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <returns>Team horsepower value.</returns>
        public int ReadTeamHorsepower(int teamIndex)
        {
            int position = _exeEditor.GetTeamHorsepowerPosition(teamIndex);

            ushort horsepower = new FileReader(_exeEditor.ExePath).ReadUShort(position);

            return horsepower;
        }

        /// <summary>
        /// Writes the horsepower value for the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <param name="horsepower">Horsepower value to write.</param>
        public void WriteTeamHorsepower(int teamIndex, int horsepower)
        {
            int position = _exeEditor.GetTeamHorsepowerPosition(teamIndex);

            new FileWriter(_exeEditor.ExePath).WriteUInt16(horsepower, position);
        }
    }
}
