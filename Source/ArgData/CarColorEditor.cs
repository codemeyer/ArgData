using System.Collections;
using System.Collections.Generic;
using System.Linq;

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


        public CarColorList ReadCarColors()
        {
            int colorsPerTeam = GpExeEditor.ColorsPerTeam;

            byte[] allCarBytes = ReadAllCarColors();

            var list = new CarColorList();

            for (int i = 0; i <= 17; i++)
            {
                byte[] carBytes = allCarBytes.Skip(i * colorsPerTeam).Take(colorsPerTeam).ToArray();
                list[i].SetColors(carBytes);
            }

            return list;
        }

        private byte[] ReadAllCarColors()
        {
            return new FileReader(_exeEditor.ExePath).ReadBytes(
                _exeEditor.GetCarColorsPosition(),
                GpExeEditor.ColorsPerTeam * 18);
        }

        public void WriteCarColors(Car car, int teamIndex)
        {
            byte[] carBytes = car.GetColors();
            int position = _exeEditor.GetCarColorsPosition(teamIndex);

            new FileWriter(_exeEditor.ExePath).WriteBytes(carBytes, position);
        }

        public void WriteCarColors(CarColorList carColorList)
        {
            //byte[] allCarBytes = new byte[];

            int teamIndex = 0;

            // TODO: hur få CarCOlorList så att man kan skriva "var Car" utan att få object?
            // TODO: skriv allt på en gång, ist för bil-för-bil

            foreach (Car car in carColorList)
            {
                byte[] carBytes = car.GetColors();
                int position = _exeEditor.GetCarColorsPosition(teamIndex);

                new FileWriter(_exeEditor.ExePath).WriteBytes(carBytes, position);

                teamIndex++;
            }
        }

    }

    public class CarColorList : IEnumerable
    {
        private readonly List<Car> _list;

        public Car this[int index]
        {
            get { return _list[index]; }
        }

        public CarColorList()
        {
            _list = new List<Car>();
            for (int i = 0; i <= 17; i++)
            {
                _list.Add(new Car());
            }
            // TODO: 1991 colors
        }

        //IEnumerator<Car> IEnumerable<Car>.GetEnumerator()
        //{
        //    return _list.GetEnumerator();
        //}

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
