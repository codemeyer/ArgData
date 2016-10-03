using System;
using System.Linq;
using ArgData.Entities;
using ArgData.IO;

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
        public static CarColorReader For(GpExeFile exeFile)
        {
            return new CarColorReader(exeFile);
        }

        private CarColorReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads the colors of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read colors of.</param>
        /// <returns>Car object with the colors of the team.</returns>
        public Car ReadCarColors(int teamIndex)
        {
            if (teamIndex < 0 || teamIndex > Constants.NumberOfSupportedTeams - 1)
                throw new IndexOutOfRangeException($"{nameof(teamIndex)} must be between 0 and 17");

            int position = _exeFile.GetCarColorsPosition(teamIndex);

            byte[] colors = new FileReader(_exeFile.ExePath).ReadBytes(position, GpExeFile.ColorsPerTeam);

            return new Car(colors);
        }

        /// <summary>
        /// Reads the colors of all the teams in the file.
        /// </summary>
        /// <returns>CarList object with the colors of all the teams.</returns>
        public CarList ReadCarColors()
        {
            byte[] allCarBytes = ReadAllCarColors();

            var list = new CarList();

            for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
            {
                byte[] carBytes = allCarBytes.Skip(i * GpExeFile.ColorsPerTeam)
                    .Take(GpExeFile.ColorsPerTeam).ToArray();
                list[i].SetColors(carBytes);
            }

            return list;
        }

        private byte[] ReadAllCarColors()
        {
            return new FileReader(_exeFile.ExePath).ReadBytes(
                _exeFile.GetCarColorsPosition(),
                GpExeFile.ColorsPerTeam * Constants.NumberOfSupportedTeams);
        }
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
        public static CarColorWriter For(GpExeFile exeFile)
        {
            return new CarColorWriter(exeFile);
        }

        private CarColorWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes car colors for a team.
        /// </summary>
        /// <param name="car">Car with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WriteCarColors(Car car, int teamIndex)
        {
            if (teamIndex < 0 || teamIndex > Constants.NumberOfSupportedTeams - 1)
                throw new IndexOutOfRangeException($"{nameof(teamIndex)} must be between 0 and 17");

            byte[] carBytes = car.GetColorsToWriteToFile();
            int position = _exeFile.GetCarColorsPosition(teamIndex);

            new FileWriter(_exeFile.ExePath).WriteBytes(carBytes, position);
        }

        /// <summary>
        /// Writes car colors for all the teams.
        /// </summary>
        /// <param name="carList">CarList with colors to write.</param>
        public void WriteCarColors(CarList carList)
        {
            int teamIndex = 0;

            foreach (Car car in carList)
            {
                byte[] carBytes = car.GetColorsToWriteToFile();
                int position = _exeFile.GetCarColorsPosition(teamIndex);

                new FileWriter(_exeFile.ExePath).WriteBytes(carBytes, position);

                teamIndex++;
            }
        }
    }
}
