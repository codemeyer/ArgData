using System;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Edits horsepower values of teams.
    /// </summary>
    public class TeamHorsepowerReader
    {
        /// <summary>
        /// Creates a TeamHorsepowerReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>TeamHorsepowerReader.</returns>
        public static TeamHorsepowerReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new TeamHorsepowerReader(exeFile);
        }

        private TeamHorsepowerReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Reads the horsepower value of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <returns>Team horsepower value.</returns>
        public int ReadTeamHorsepower(int teamIndex)
        {
            TeamIndexValidator.Validate(teamIndex);

            int position = _exeFile.GetTeamHorsepowerPosition(teamIndex);

            ushort horsepower = new FileReader(_exeFile.ExePath).ReadUInt16(position);

            return horsepower;
        }
    }

    /// <summary>
    /// Writes horsepower values of teams.
    /// </summary>
    public class TeamHorsepowerWriter
    {
        /// <summary>
        /// Creates a TeamHorsepowerWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        /// <returns>TeamHorsepowerWriter.</returns>
        public static TeamHorsepowerWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new TeamHorsepowerWriter(exeFile);
        }

        private TeamHorsepowerWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Writes the horsepower value for the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read horsepower value for.</param>
        /// <param name="horsepower">Horsepower value to write.</param>
        public void WriteTeamHorsepower(int teamIndex, int horsepower)
        {
            TeamIndexValidator.Validate(teamIndex);

            int position = _exeFile.GetTeamHorsepowerPosition(teamIndex);

            new FileWriter(_exeFile.ExePath).WriteUInt16((ushort)horsepower, position);
        }
    }
}
