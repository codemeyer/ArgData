using System.Collections.Generic;

namespace ArgData
{
    public class CarColorReader : FileReader
    {
        private readonly DataPositions _dataPositions;
        
        private const int ColorsPerTeam = 16;

        public CarColorReader(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public byte[] ReadCarColors(int teamIndex)
        {
            int position = _dataPositions.CarColors + (teamIndex * ColorsPerTeam);

            byte[] colors = ReadBytes(position, ColorsPerTeam);

            return colors;
        }

        public List<Car> ReadCarColorsAsCars()
        {
            var cars = new List<Car>();

            for (int i = 0; i <= 17; i++)
            {
                byte[] carBytes = ReadCarColors(i);
                cars.Add(new Car(carBytes));
            }

            return cars;
        }
    }
}