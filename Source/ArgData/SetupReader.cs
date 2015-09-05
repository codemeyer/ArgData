using System;
using System.IO;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads setup files.
    /// </summary>
    public class SetupReader
    {
        /// <summary>
        /// Reads a single setup file.
        /// </summary>
        /// <param name="path">Path to the setup file.</param>
        /// <returns>Setup.</returns>
        public Setup ReadSingle(string path)
        {
            ValidateSingleSetupFile(path);

            byte[] setupBytes = new FileReader(path).ReadBytes(0, 14);

            var setup = new Setup
            {
                FrontWing = setupBytes[0],
                RearWing = setupBytes[1],
                GearRatio1 = setupBytes[2],
                GearRatio2 = setupBytes[3],
                GearRatio3 = setupBytes[4],
                GearRatio4 = setupBytes[5],
                GearRatio5 = setupBytes[6],
                GearRatio6 = setupBytes[7],
                TyresCompound = GetTyreCompound(setupBytes[8]),
                BrakeBalanceValue = GetBrakeBalanceValue(setupBytes[9]),
                BrakeBalanceDirection = GetBrakeBalanceDirection(setupBytes[9])
            };

            return setup;
        }

        private static void ValidateSingleSetupFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 14)
            {
                throw new Exception($"The file '{path}' does not appear to be a setup file.");
            }
        }

        private static byte GetBrakeBalanceValue(byte value)
        {
            return (value < 128)
                ? value
                : Convert.ToByte(256 - value);
        }

        private SetupBrakeBalanceDirection GetBrakeBalanceDirection(byte value)
        {
            return (value < 128)
                ? SetupBrakeBalanceDirection.Front
                : SetupBrakeBalanceDirection.Rear;
        }

        private SetupTyreCompound GetTyreCompound(byte value)
        {
            return (SetupTyreCompound)Enum.Parse(typeof(SetupTyreCompound), value.ToString());
        }
    }
}
