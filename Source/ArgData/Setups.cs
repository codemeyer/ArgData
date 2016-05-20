using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads setup files from disk.
    /// </summary>
    public static class SetupReader
    {
        /// <summary>
        /// Reads a single setup file.
        /// </summary>
        /// <param name="path">Path to the setup file.</param>
        /// <returns>Setup.</returns>
        public static Setup ReadSingle(string path)
        {
            ValidateSingleSetupFile(path);

            byte[] setupBytes = new FileReader(path).ReadBytes(0, 10);

            return CreateSetupFromByteArray(setupBytes);
        }

        /// <summary>
        /// Reads a file containing multiple car setups.
        /// </summary>
        /// <param name="path">Path to the setups file.</param>
        /// <returns>List of setups.</returns>
        public static SetupList ReadMultiple(string path)
        {
            ValidateMultipleSetupFile(path);

            var list = new SetupList();

            byte[] allSetupBytes = new FileReader(path).ReadAll();

            list.SeparateSetups = allSetupBytes[0] == 255 && allSetupBytes[1] == 255;

            int position = 2;

            for (int qi = 0; qi <= 15; qi++)
            {
                byte[] setupBytes = allSetupBytes.Skip(position).Take(10).ToArray();
                list.QualifyingSetups[qi] = CreateSetupFromByteArray(setupBytes);
                position += 10;
            }

            for (int ri = 0; ri <= 15; ri++)
            {
                byte[] setupBytes = allSetupBytes.Skip(position).Take(10).ToArray();
                list.RaceSetups[ri] = CreateSetupFromByteArray(setupBytes);
                position += 10;
            }

            return list;
        }

        private static Setup CreateSetupFromByteArray(byte[] setupBytes)
        {
            return new Setup
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
        }

        private static void ValidateSingleSetupFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 14)
            {
                throw new Exception($"The file '{path}' does not appear to be a setup file.");
            }
        }

        private static void ValidateMultipleSetupFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 326)
            {
                throw new Exception($"The file '{path}' does not appear to be a multi-setup file.");
            }
        }

        private static byte GetBrakeBalanceValue(byte value)
        {
            return (value < 128)
                ? value
                : Convert.ToByte(256 - value);
        }

        private static SetupBrakeBalanceDirection GetBrakeBalanceDirection(byte value)
        {
            return (value < 128)
                ? SetupBrakeBalanceDirection.Front
                : SetupBrakeBalanceDirection.Rear;
        }

        private static SetupTyreCompound GetTyreCompound(byte value)
        {
            return (SetupTyreCompound)Enum.Parse(typeof(SetupTyreCompound), value.ToString());
        }
    }


    /// <summary>
    /// Writes single or multiple setup files to disk.
    /// </summary>
    public static class SetupWriter
    {
        /// <summary>
        /// Writes a single setup to disk.
        /// </summary>
        /// <param name="setup">Setup to save.</param>
        /// <param name="path">Path to file. Will be created or overwritten.</param>
        public static void WriteSingle(Setup setup, string path)
        {
            byte[] setupBytes = new byte[14];

            setupBytes[0] = setup.FrontWing;
            setupBytes[1] = setup.RearWing;
            setupBytes[2] = setup.GearRatio1;
            setupBytes[3] = setup.GearRatio2;
            setupBytes[4] = setup.GearRatio3;
            setupBytes[5] = setup.GearRatio4;
            setupBytes[6] = setup.GearRatio5;
            setupBytes[7] = setup.GearRatio6;
            setupBytes[8] = GetTyreCompound(setup.TyresCompound);
            setupBytes[9] = GetBrakeBalance(setup.BrakeBalanceValue, setup.BrakeBalanceDirection);

            new FileWriter(path).CreateFile().WriteBytes(setupBytes, 0);

            ChecksumCalculator.UpdateChecksum(path);
        }

        /// <summary>
        /// Writes a file containing multiple setups to disk.
        /// </summary>
        /// <param name="setups">Setups to save.</param>
        /// <param name="path">Path to file. Will be created or overwritten.</param>
        public static void WriteMultiple(SetupList setups, string path)
        {
            byte[] setupBytes = new byte[326];

            if (setups.SeparateSetups)
            {
                setupBytes[0] = 255;
                setupBytes[1] = 255;
            }

            int offset = 2;

            for (int qi = 0; qi <= 15; qi++)
            {
                var setup = setups.QualifyingSetups[qi];
                setupBytes[offset + 0] = setup.FrontWing;
                setupBytes[offset + 1] = setup.RearWing;
                setupBytes[offset + 2] = setup.GearRatio1;
                setupBytes[offset + 3] = setup.GearRatio2;
                setupBytes[offset + 4] = setup.GearRatio3;
                setupBytes[offset + 5] = setup.GearRatio4;
                setupBytes[offset + 6] = setup.GearRatio5;
                setupBytes[offset + 7] = setup.GearRatio6;
                setupBytes[offset + 8] = GetTyreCompound(setup.TyresCompound);
                setupBytes[offset + 9] = GetBrakeBalance(setup.BrakeBalanceValue, setup.BrakeBalanceDirection);

                offset += 10;
            }

            for (int ri = 0; ri <= 15; ri++)
            {
                var setup = setups.RaceSetups[ri];
                setupBytes[offset + 0] = setup.FrontWing;
                setupBytes[offset + 1] = setup.RearWing;
                setupBytes[offset + 2] = setup.GearRatio1;
                setupBytes[offset + 3] = setup.GearRatio2;
                setupBytes[offset + 4] = setup.GearRatio3;
                setupBytes[offset + 5] = setup.GearRatio4;
                setupBytes[offset + 6] = setup.GearRatio5;
                setupBytes[offset + 7] = setup.GearRatio6;
                setupBytes[offset + 8] = GetTyreCompound(setup.TyresCompound);
                setupBytes[offset + 9] = GetBrakeBalance(setup.BrakeBalanceValue, setup.BrakeBalanceDirection);

                offset += 10;
            }

            new FileWriter(path).CreateFile().WriteBytes(setupBytes, 0);

            ChecksumCalculator.UpdateChecksum(path);
        }

        private static byte GetTyreCompound(SetupTyreCompound tyresCompound)
        {
            return (byte)tyresCompound;
        }

        private static byte GetBrakeBalance(byte value, SetupBrakeBalanceDirection direction)
        {
            if (value == 0)
                return 0;

            if (direction == SetupBrakeBalanceDirection.Front)
                return value;
            else
                return Convert.ToByte(256 - value);
        }
    }
}
