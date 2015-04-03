using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    public class CarColorEditor
    {
        private readonly GpExeEditor _exeEditor;

        public CarColorEditor(GpExeEditor exeEditor)
        {
            _exeEditor = exeEditor;
        }

        public Car ReadCarColors(int teamIndex)
        {
            int position = _exeEditor.GetCarColorsPosition(teamIndex);

            byte[] colors = new FileReader(_exeEditor.ExePath).ReadBytes(position, GpExeEditor.ColorsPerTeam);

            return new Car(colors);
        }

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

        public void WriteCarColors(Car car, int teamIndex)
        {
            byte[] carBytes = car.GetColorsToWriteToFile();
            int position = _exeEditor.GetCarColorsPosition(teamIndex);

            new FileWriter(_exeEditor.ExePath).WriteBytes(carBytes, position);
        }

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
