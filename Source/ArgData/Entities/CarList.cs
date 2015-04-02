using System.Collections;
using System.Collections.Generic;

namespace ArgData.Entities
{
    public class CarList : IEnumerable
    {
        private readonly List<Car> _list;

        public Car this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public CarList()
        {
            _list = new List<Car>();
            for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
            {
                _list.Add(new Car());
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
