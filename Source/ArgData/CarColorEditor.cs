using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Edits the car colors of one or more teams.
    /// </summary>
    public class CarColorEditor
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Initializes a new instance of a CarColorEditor.
        /// </summary>
        /// <param name="exeFile">GpExeFile to edit.</param>
        public CarColorEditor(GpExeFile exeFile)
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

            for (int i = 0; i < Constants.NumberOfAvailableTeams; i++)
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
                GpExeFile.ColorsPerTeam * Constants.NumberOfAvailableTeams);
        }

        /// <summary>
        /// Writes car colors for a team.
        /// </summary>
        /// <param name="car">Car with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WriteCarColors(Car car, int teamIndex)
        {
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
