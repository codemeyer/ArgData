using System;
using System.IO;
using System.Linq;
using ArgData.Entities;

namespace ArgData.Internals
{
    internal class ComputerCarSetupReaderResult
    {
        public Setup Setup { get; set; }
        public byte[] RawData { get; set; }
    }

    internal static class ComputerCarSetupReader
    {
        public static ComputerCarSetupReaderResult Read(BinaryReader reader, int position)
        {
            reader.BaseStream.Position = position;
            byte[] setupBytes = reader.ReadBytes(38);

            var setup = new Setup
            {
                FrontWing = Convert.ToByte(setupBytes[0] - 151),
                RearWing = Convert.ToByte(setupBytes[1] - 151),
                GearRatio1 = Convert.ToByte(setupBytes[2] - 151),
                GearRatio2 = Convert.ToByte(setupBytes[3] - 151),
                GearRatio3 = Convert.ToByte(setupBytes[4] - 151),
                GearRatio4 = Convert.ToByte(setupBytes[5] - 151),
                GearRatio5 = Convert.ToByte(setupBytes[6] - 151),
                GearRatio6 = Convert.ToByte(setupBytes[7] - 151),
                //TyresCompound = GetTyreCompound(setupBytes[8]),
                //BrakeBalanceValue = GetBrakeBalanceValue(setupBytes[9]),
                //BrakeBalanceDirection = GetBrakeBalanceDirection(setupBytes[9])
            };

            // TODO: RawData is never used!
            // make everything proper properties instead? see GP2 docs

            return new ComputerCarSetupReaderResult
            {
                Setup = setup,
                RawData = setupBytes.Skip(8).ToArray()
            };
        }
    }
}
