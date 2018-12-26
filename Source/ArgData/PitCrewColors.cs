using System;
using System.IO;
using ArgData.Entities;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Reads pit crew colors of one or more teams.
    /// </summary>
    public class PitCrewColorReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PitCrewColorReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PitCrewColorReader.</returns>
        public PitCrewColorReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PitCrewColorReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PitCrewColorReader.</returns>
        public static PitCrewColorReader For(GpExeFile exeFile)
        {
            return new PitCrewColorReader(exeFile);
        }

        /// <summary>
        /// Reads the colors of the pit crew at the specified index.
        /// </summary>
        /// <param name="pitCrewIndex">Index of pit crew to read colors of.</param>
        /// <returns>PitCrew object with the colors of the pit crew.</returns>
        public PitCrew ReadPitCrewColors(int pitCrewIndex)
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetPitCrewColorsPosition(pitCrewIndex);
                byte[] colors = reader.ReadBytes(GpExeFile.ColorsPerTeam);

                return new PitCrew(colors);
            }
        }

        /// <summary>
        /// Reads the colors of all the pit crews in the file.
        /// </summary>
        /// <returns>PitCrewList object with the colors of all the teams.</returns>
        public PitCrewList ReadPitCrewColors()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                var list = new PitCrewList();

                reader.BaseStream.Position = _exeFile.GetPitCrewColorsPosition();

                for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                {
                    byte[] colors = reader.ReadBytes(GpExeFile.ColorsPerTeam);
                    list[i].SetColors(colors);
                }

                return list;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }

    /// <summary>
    /// Writes pit crew colors of one or more teams.
    /// </summary>
    public class PitCrewColorWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PitCrewColorWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PitCrewColorWriter.</returns>
        public PitCrewColorWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PitCrewColorWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PitCrewColorWriter.</returns>
        public static PitCrewColorWriter For(GpExeFile exeFile)
        {
            return new PitCrewColorWriter(exeFile);
        }

        /// <summary>
        /// Writes pit crew colors for a team.
        /// </summary>
        /// <param name="pitCrew">PitCrew with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WritePitCrewColors(PitCrew pitCrew, int teamIndex)
        {
            if (pitCrew == null) throw new ArgumentNullException(nameof(pitCrew));
            TeamIndexValidator.Validate(teamIndex);

            byte[] pitCrewBytes = pitCrew.GetColorsToWriteToFile();

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetPitCrewColorsPosition(teamIndex);
                writer.Write(pitCrewBytes);
            }
        }

        /// <summary>
        /// Writes pit crew colors for all the teams.
        /// </summary>
        /// <param name="pitCrewList">PitCrewList with colors to write.</param>
        public void WritePitCrewColors(PitCrewList pitCrewList)
        {
            if (pitCrewList == null) throw new ArgumentNullException(nameof(pitCrewList));

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetPitCrewColorsPosition(0);

                foreach (PitCrew pitCrew in pitCrewList)
                {
                    byte[] pitCrewBytes = pitCrew.GetColorsToWriteToFile();
                    writer.Write(pitCrewBytes);
                }
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
