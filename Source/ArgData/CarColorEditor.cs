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
        private readonly GpExeEditor _exeEditor;

        /// <summary>
        /// Initializes a new instance of a CarColorEditor.
        /// </summary>
        /// <param name="exeEditor">GpExeEditor for the file to edit.</param>
        public CarColorEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        /// <summary>
        /// Reads the colors of the team at the specified index.
        /// </summary>
        /// <param name="teamIndex">Index of team to read colors of.</param>
        /// <returns>Car object with the colors of the team.</returns>
        public Car ReadCarColors(int teamIndex)
        {
            int position = _exeEditor.GetCarColorsPosition(teamIndex);

            byte[] colors = new FileReader(_exeEditor.ExePath).ReadBytes(position, GpExeEditor.ColorsPerTeam);

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

            for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
            {
                byte[] carBytes = allCarBytes.Skip(i * GpExeEditor.ColorsPerTeam)
                    .Take(GpExeEditor.ColorsPerTeam).ToArray();
                list[i].SetColors(carBytes);
            }

            return list;
        }

        private byte[] ReadAllCarColors()
        {
            return new FileReader(_exeEditor.ExePath).ReadBytes(
                _exeEditor.GetCarColorsPosition(),
                GpExeEditor.ColorsPerTeam * GpExeEditor.NumberOfTeams);
        }

        /// <summary>
        /// Writes car colors for a team.
        /// </summary>
        /// <param name="car">Car with colors to write.</param>
        /// <param name="teamIndex">Index of the team to write the colors for.</param>
        public void WriteCarColors(Car car, int teamIndex)
        {
            byte[] carBytes = car.GetColorsToWriteToFile();
            int position = _exeEditor.GetCarColorsPosition(teamIndex);

            new FileWriter(_exeEditor.ExePath).WriteBytes(carBytes, position);
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
                int position = _exeEditor.GetCarColorsPosition(teamIndex);

                new FileWriter(_exeEditor.ExePath).WriteBytes(carBytes, position);

                teamIndex++;
            }
        }
    }
}
