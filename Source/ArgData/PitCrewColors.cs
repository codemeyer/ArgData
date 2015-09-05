using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads pit crew colors of one or more teams.
    /// </summary>
    public class PitCrewColorReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a PitCrewColorReader.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        public PitCrewColorReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the colors of the pit crew at the specified index.
        /// </summary>
        /// <param name="pitCrewIndex">Index of pit crew to read colors of.</param>
        /// <returns>PitCrew object with the colors of the pit crew.</returns>
        public PitCrew ReadPitCrewColors(int pitCrewIndex)
        {
            int position = _exeFile.GetPitCrewColorsPosition(pitCrewIndex);

            byte[] colors = new FileReader(_exeFile.ExePath).ReadBytes(position, GpExeFile.ColorsPerTeam);

            return new PitCrew(colors);
        }

        /// <summary>
        /// Reads the colors of all the pit crews in the file.
        /// </summary>
        /// <returns>PitCrewList object with the colors of all the teams.</returns>
        public PitCrewList ReadPitCrewColors()
        {
            byte[] allPitCrewBytes = ReadAllPitCrewColors();

            var list = new PitCrewList();

            for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
            {
                byte[] pitCrewBytes = allPitCrewBytes.Skip(i*GpExeFile.ColorsPerTeam)
                    .Take(GpExeFile.ColorsPerTeam).ToArray();
                list[i].SetColors(pitCrewBytes);
            }

            return list;
        }

        private byte[] ReadAllPitCrewColors()
        {
            return new FileReader(_exeFile.ExePath).ReadBytes(
                _exeFile.GetPitCrewColorsPosition(),
                GpExeFile.ColorsPerTeam*Constants.NumberOfSupportedTeams);
        }
    }

    /// <summary>
    /// Writes pit crew colors of one or more teams.
    /// </summary>
    public class PitCrewColorWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a PitCrewColorWriter.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public PitCrewColorWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes pit crew colors for a team.
        /// </summary>
        /// <param name="pitCrew">PitCrew with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WritePitCrewColors(PitCrew pitCrew, int teamIndex)
        {
            byte[] pitCrewBytes = pitCrew.GetColorsToWriteToFile();
            int position = _exeFile.GetPitCrewColorsPosition(teamIndex);

            new FileWriter(_exeFile.ExePath).WriteBytes(pitCrewBytes, position);
        }

        /// <summary>
        /// Writes pit crew colors for all the teams.
        /// </summary>
        /// <param name="pitCrewList">PitCrewList with colors to write.</param>
        public void WritePitCrewColors(PitCrewList pitCrewList)
        {
            int teamIndex = 0;

            foreach (PitCrew pitCrew in pitCrewList)
            {
                byte[] pitCrewBytes = pitCrew.GetColorsToWriteToFile();
                int position = _exeFile.GetPitCrewColorsPosition(teamIndex);

                new FileWriter(_exeFile.ExePath).WriteBytes(pitCrewBytes, position);

                teamIndex++;
            }
        }
    }
}
