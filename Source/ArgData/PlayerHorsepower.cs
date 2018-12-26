using System;
using System.IO;
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
        public PlayerHorsepowerReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PlayerHorsepowerReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PlayerHorsepowerReader.</returns>
        public static PlayerHorsepowerReader For(GpExeFile exeFile)
        {
            return new PlayerHorsepowerReader(exeFile);
        }

        /// <summary>
        /// Reads the horsepower value for the player.
        /// </summary>
        /// <returns>Player horsepower value.</returns>
        public int ReadPlayerHorsepower()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetPlayerHorsepowerPosition();
                ushort rawHorsepower = reader.ReadUInt16();

                return (rawHorsepower - 632) / 22;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
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
        public PlayerHorsepowerWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a PlayerHorsepowerWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>PlayerHorsepowerWriter.</returns>
        public static PlayerHorsepowerWriter For(GpExeFile exeFile)
        {
            return new PlayerHorsepowerWriter(exeFile);
        }

        /// <summary>
        /// Writes the horsepower value for the player. The default value is 716.
        /// </summary>
        /// <param name="horsepower">Player horsepower value. Permitted values between 1 and 1460.</param>
        public void WritePlayerHorsepower(int horsepower)
        {
            Validate(horsepower);

            ushort rawHorsepower = RawValueFromHorsepower(horsepower);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetPlayerHorsepowerPosition();
                writer.Write(rawHorsepower);
            }
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

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
