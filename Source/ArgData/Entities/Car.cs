using System;

namespace ArgData.Entities
{
    public class Car
    {
        public Car() : this(new byte[16])
        {
        }

        public Car(byte[] carColorBytes)
        {
            if (carColorBytes.Length != GpExeEditor.ColorsPerTeam)
            {
                throw new Exception(string.Format("Car must be created with {0} colors", GpExeEditor.ColorsPerTeam));
            }

            SetColors(carColorBytes);
        }

        public byte FrontAndRearWing { get; private set; }

        public byte FrontWingEndplate { get; private set; }

        public byte RearWingSide { get; private set; }

        public byte Sidepod { get; private set; }

        public byte SidepodTop { get; private set; }

        public byte EngineCover { get; private set; }

        public byte EngineCoverSide { get; private set; }

        public byte EngineCoverRear { get; private set; }

        public byte CockpitFront { get; private set; }

        public byte CockpitSide { get; private set; }

        public byte NoseTop { get; private set; }

        public byte NoseAngle { get; private set; }

        public byte NoseSide { get; private set; }

        internal void SetColors(byte[] carBytes)
        {
            // 0, 9 and 10 are not used
            EngineCover = carBytes[1];
            CockpitFront = carBytes[2];
            FrontWingEndplate = carBytes[3];
            RearWingSide = carBytes[4];
            NoseSide = carBytes[5];
            Sidepod = carBytes[6];
            FrontAndRearWing = carBytes[7];
            NoseTop = carBytes[8];
            NoseAngle = carBytes[11];
            CockpitSide = carBytes[12];
            EngineCoverSide = carBytes[13];
            EngineCoverRear = carBytes[14];
            SidepodTop = carBytes[15];
        }

        private const byte FixedValueForIndex0 = 33;   // 0 in F1Ed;
        private const byte FixedValueForIndex9 = 54;   // varies in GP.EXE
        private const byte FixedValueForIndex10 = 36;  // 24 in F1Ed

        internal byte[] GetColorsToWriteToFile()
        {
            var carBytes = new byte[]
            {
                FixedValueForIndex0,
                EngineCover,
                CockpitFront,
                FrontWingEndplate,
                RearWingSide,
                NoseSide,
                Sidepod,
                FrontAndRearWing,
                NoseTop,
                FixedValueForIndex9,
                FixedValueForIndex10,
                NoseAngle,
                CockpitSide,
                EngineCoverSide,
                EngineCoverRear,
                SidepodTop
            };

            return carBytes;
        }
    }
}
