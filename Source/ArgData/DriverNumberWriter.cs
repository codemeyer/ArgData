using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArgData
{
    public class DriverNumberWriter : FileWriter
    {
        private readonly DataPositions _dataPositions;

        public DriverNumberWriter(string exePath, DataPositions dataPositions = null)
            : base(exePath)
        {
            _dataPositions = dataPositions ?? new DataPositions();
        }

        public void WriteDriverNumbers(byte[] driverNumbers)
        {
            for(int i = 0; i < driverNumbers.Length; i++)
            {
                WriteByte(driverNumbers[i], _dataPositions.DriverNumbers + i);
            }
        }
    }
}
