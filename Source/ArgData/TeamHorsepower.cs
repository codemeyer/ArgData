using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits horsepower values of teams.
    /// </summary>
    public class TeamHorsepowerReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a TeamHorsepowerReader.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        public TeamHorsepowerReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the horsepower value of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <returns>Team horsepower value.</returns>
        public int ReadTeamHorsepower(int teamIndex)
        {
            int position = _exeFile.GetTeamHorsepowerPosition(teamIndex);

            ushort horsepower = new FileReader(_exeFile.ExePath).ReadUShort(position);

            return horsepower;
        }
    }

    /// <summary>
    /// Writes horsepower values of teams.
    /// </summary>
    public class TeamHorsepowerWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a TeamHorsepowerWriter.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        public TeamHorsepowerWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the horsepower value for the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <param name="horsepower">Horsepower value to write.</param>
        public void WriteTeamHorsepower(int teamIndex, int horsepower)
        {
            int position = _exeFile.GetTeamHorsepowerPosition(teamIndex);

            new FileWriter(_exeFile.ExePath).WriteUInt16(horsepower, position);
        }
    }
}
