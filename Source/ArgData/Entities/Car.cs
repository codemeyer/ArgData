namespace ArgData.Entities
{
    public class Car
    {
        public Car() : this(new byte[16])
        {
        }

        public Car(byte[] carBytes)
        {
            // TODO: verify that the byte[] contains the correct number of items

            SetColors(carBytes);
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

        internal byte[] GetColors()
        {
            var carBytes = new byte[]
            {
                0, //?
                EngineCover,
                CockpitFront,
                FrontWingEndplate,
                RearWingSide,
                NoseSide,
                Sidepod,
                FrontAndRearWing,
                NoseTop,
                54, // ?
                24, // ?
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
