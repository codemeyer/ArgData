using System;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads the horsepower value for the player.
    /// </summary>
    public class PlayerHorsepowerReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PlayerHorsepowerReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PlayerHorsepowerReader.</returns>
        public static PlayerHorsepowerReader For(GpExeFile exeFile)
        {
            return new PlayerHorsepowerReader(exeFile);
        }

        private PlayerHorsepowerReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the horsepower value for the player.
        /// </summary>
        /// <returns>Player horsepower value.</returns>
        public int ReadPlayerHorsepower()
        {
            var fileReader = new FileReader(_exeFile.ExePath);
            ushort rawHorsepower = fileReader.ReadUInt16(_exeFile.GetPlayerHorsepowerPosition());

            return (rawHorsepower - 632) / 22;
        }
    }


    /// <summary>
    /// Writes the horsepower values for the player.
    /// </summary>
    public class PlayerHorsepowerWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a PlayerHorsepowerWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PlayerHorsepowerWriter.</returns>
        public static PlayerHorsepowerWriter For(GpExeFile exeFile)
        {
            return new PlayerHorsepowerWriter(exeFile);
        }

        private PlayerHorsepowerWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes the horsepower value for the player. The default value is 716.
        /// </summary>
        /// <param name="horsepower">Player horsepower value. Permitted values between 1 and 1460.</param>
        public void WritePlayerHorsepower(int horsepower)
        {
            Validate(horsepower);

            ushort rawHorsepower = RawValueFromHorsepower(horsepower);

            new FileWriter(_exeFile.ExePath).WriteUInt16(rawHorsepower, _exeFile.GetPlayerHorsepowerPosition());
        }

        private void Validate(int horsepower)
        {
            if (horsepower < 1)
                throw new ArgumentOutOfRangeException(nameof(horsepower));

            if (RawValueFromHorsepower(horsepower) > short.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(horsepower));
        }

        private static ushort RawValueFromHorsepower(int horsepower)
        {
            return (ushort)(horsepower * 22 + 632);
        }
    }
}
