using System;
using System.IO;
using ArgData.Entities;
using ArgData.IO;
using ArgData.Validation;

namespace ArgData
{
    /// <summary>
    /// Reads the car colors of one or more teams.
    /// </summary>
    public class CarColorReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a CarColorReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>CarColorReader.</returns>
        public CarColorReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a CarColorReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>CarColorReader.</returns>
        public static CarColorReader For(GpExeFile exeFile)
        {
            return new CarColorReader(exeFile);
        }

        /// <summary>
        /// Reads the colors of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read colors of.</param>
        /// <returns>Car object with the colors of the team.</returns>
        public Car ReadCarColors(int teamIndex)
        {
            TeamIndexValidator.Validate(teamIndex);

            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetCarColorsPosition(teamIndex);

                byte[] colors = reader.ReadBytes(GpExeFile.ColorsPerTeam);

                return new Car(colors);
            }
        }

        /// <summary>
        /// Reads the colors of all the teams in the file.
        /// </summary>
        /// <returns>CarList object with the colors of all the teams.</returns>
        public CarList ReadCarColors()
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetCarColorsPosition();

                var list = new CarList();

                for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                {
                    byte[] carBytes = reader.ReadBytes(GpExeFile.ColorsPerTeam);
                    list[i].SetColors(carBytes);
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
    /// Writes the car colors of one or more teams.
    /// </summary>
    public class CarColorWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a CarColorWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>CarColorWriter.</returns>
        public CarColorWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a CarColorWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>CarColorWriter.</returns>
        public static CarColorWriter For(GpExeFile exeFile)
        {
            return new CarColorWriter(exeFile);
        }

        /// <summary>
        /// Writes car colors for a team.
        /// </summary>
        /// <param name="car">Car with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WriteCarColors(Car car, int teamIndex)
        {
            TeamIndexValidator.Validate(teamIndex);
            if (car == null) { throw new ArgumentNullException(nameof(car)); }

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                byte[] carBytes = car.GetColorsToWriteToFile();
                writer.BaseStream.Position = _exeFile.GetCarColorsPosition(teamIndex);
                writer.Write(carBytes);
            }
        }

        /// <summary>
        /// Writes car colors for all the teams.
        /// </summary>
        /// <param name="carList">CarList with colors to write.</param>
        public void WriteCarColors(CarList carList)
        {
            if (carList == null) { throw new ArgumentNullException(nameof(carList)); }

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetCarColorsPosition();

                foreach (Car car in carList)
                {
                    byte[] carBytes = car.GetColorsToWriteToFile();

                    writer.Write(carBytes);
                }
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
