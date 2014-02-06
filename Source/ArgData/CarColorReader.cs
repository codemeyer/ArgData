using System.Collections.Generic;
using System.Linq;

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

            byte[] allCarBytes = ReadAllCarColors();
            
            for (int i = 0; i <= 17; i++)
            {
                byte[] carBytes = allCarBytes.Skip(i * ColorsPerTeam).Take(ColorsPerTeam).ToArray();
                cars.Add(new Car(carBytes));
            }

            return cars;
        }

        private byte[] ReadAllCarColors()
        {
            return ReadBytes(_dataPositions.CarColors, ColorsPerTeam * 18);
        }
    }
}