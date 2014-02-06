namespace ArgData
{
    public class Car
    {
        public Car(byte[] carBytes)
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

        public int FrontAndRearWing { get; set; }

        public int FrontWingEndplate { get; set; }

        public int RearWingSide { get; set; }
        
        public int Sidepod { get; set; }

        public int SidepodTop { get; set; }

        public int EngineCover { get; set; }

        public int EngineCoverSide { get; set; }

        public int EngineCoverRear { get; set; }

        public int CockpitFront { get; set; }

        public int CockpitSide { get; set; }

        public int NoseTop { get; set; }

        public int NoseAngle { get; set; }

        public int NoseSide { get; set; }
    }
}