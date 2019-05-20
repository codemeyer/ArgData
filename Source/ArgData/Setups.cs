using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads a single setup file or a multiple setups file from disk.
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

            using (var reader = new BinaryReader(StreamProvider.Invoke(path)))
            {
                byte[] setupBytes = reader.ReadBytes(10);

                return CreateSetupFromByteArray(setupBytes);
            }
        }

        /// <summary>
        /// Reads a file containing multiple car setups.
        /// </summary>
        /// <param name="path">Path to the setups file.</param>
        /// <returns>List of setups.</returns>
        public SetupList ReadMultiple(string path)
        {
            ValidateMultipleSetupFile(path);

            using (var reader = new BinaryReader(StreamProvider.Invoke(path)))
            {
                var list = new SetupList();

                byte[] allSetupBytes = reader.ReadAllBytes();

                list.SeparateSetups = allSetupBytes[0] == 255 && allSetupBytes[1] == 255;

                int position = 2;

                for (int qi = 0; qi <= 15; qi++)
                {
                    byte[] setupBytes = allSetupBytes.Skip(position).Take(10).ToArray();
                    list.QualifyingSetups[qi].Copy(CreateSetupFromByteArray(setupBytes));
                    position += 10;
                }

                for (int ri = 0; ri <= 15; ri++)
                {
                    byte[] setupBytes = allSetupBytes.Skip(position).Take(10).ToArray();
                    list.RaceSetups[ri].Copy(CreateSetupFromByteArray(setupBytes));
                    position += 10;
                }

                return list;
            }
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
                TyreCompound = GetTyreCompound(setupBytes[8]),
                BrakeBalance = GetBrakeBalanceValue(setupBytes[9])
            };
        }

        private static void ValidateSingleSetupFile(string path)
        {
            if (path == null) { throw new ArgumentNullException(nameof(path)); }
            if (!File.Exists(path)) { throw new FileNotFoundException($"Could not find setup file '{path}'"); }

            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 14)
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a setup file.");
            }
        }

        private static void ValidateMultipleSetupFile(string path)
        {
            if (path == null) { throw new ArgumentNullException(nameof(path)); }
            if (!File.Exists(path)) { throw new FileNotFoundException($"Could not find setup file '{path}'"); }

            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != 326)
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a multi-setup file.");
            }
        }

        private static sbyte GetBrakeBalanceValue(byte value)
        {
            return unchecked((sbyte)value);
        }

        private static SetupTyreCompound GetTyreCompound(byte value)
        {
            return (SetupTyreCompound)Enum.Parse(typeof(SetupTyreCompound), value.ToString());
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
    }


    /// <summary>
    /// Writes single or multiple setup files to disk.
    /// </summary>
    public class SetupWriter
    {
        /// <summary>
        /// Writes a single setup to disk.
        /// </summary>
        /// <param name="setup">Setup to save.</param>
        /// <param name="path">Path to file. Will be created or overwritten.</param>
        public void WriteSingle(Setup setup, string path)
        {
            Validate(setup);

            var byteList = new ByteList();

            byteList.AddByte(setup.FrontWing);
            byteList.AddByte(setup.RearWing);
            byteList.AddByte(setup.GearRatio1);
            byteList.AddByte(setup.GearRatio2);
            byteList.AddByte(setup.GearRatio3);
            byteList.AddByte(setup.GearRatio4);
            byteList.AddByte(setup.GearRatio5);
            byteList.AddByte(setup.GearRatio6);
            byteList.AddByte(GetTyreCompound(setup.TyreCompound));
            byteList.AddByte(GetBrakeBalance(setup.BrakeBalance));

            var checksum = new ChecksumCalculator().Calculate(byteList.GetBytes());
            byteList.AddUInt16((ushort)checksum.Checksum1);
            byteList.AddUInt16((ushort)checksum.Checksum2);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(path)))
            {
                writer.Write(byteList.GetBytes());
            }
        }

        /// <summary>
        /// Writes a file containing multiple setups to disk.
        /// </summary>
        /// <param name="setups">Setups to save.</param>
        /// <param name="path">Path to file. Will be created or overwritten.</param>
        public void WriteMultiple(SetupList setups, string path)
        {
            Validate(setups);

            var byteList = new ByteList();
            var value = Convert.ToByte(setups.SeparateSetups ? 255 : 0);
            byteList.AddByte(value);
            byteList.AddByte(value);

            foreach (var setup in setups.QualifyingSetups)
            {
                byteList.AddByte(setup.FrontWing);
                byteList.AddByte(setup.RearWing);
                byteList.AddByte(setup.GearRatio1);
                byteList.AddByte(setup.GearRatio2);
                byteList.AddByte(setup.GearRatio3);
                byteList.AddByte(setup.GearRatio4);
                byteList.AddByte(setup.GearRatio5);
                byteList.AddByte(setup.GearRatio6);
                byteList.AddByte(GetTyreCompound(setup.TyreCompound));
                byteList.AddByte(GetBrakeBalance(setup.BrakeBalance));
            }

            foreach (var setup in setups.RaceSetups)
            {
                byteList.AddByte(setup.FrontWing);
                byteList.AddByte(setup.RearWing);
                byteList.AddByte(setup.GearRatio1);
                byteList.AddByte(setup.GearRatio2);
                byteList.AddByte(setup.GearRatio3);
                byteList.AddByte(setup.GearRatio4);
                byteList.AddByte(setup.GearRatio5);
                byteList.AddByte(setup.GearRatio6);
                byteList.AddByte(GetTyreCompound(setup.TyreCompound));
                byteList.AddByte(GetBrakeBalance(setup.BrakeBalance));
            }

            var checksum = new ChecksumCalculator().Calculate(byteList.GetBytes());

            byteList.AddUInt16((ushort)checksum.Checksum1);
            byteList.AddUInt16((ushort)checksum.Checksum2);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(path)))
            {
                writer.Write(byteList.GetBytes());
            }
        }

        private static void Validate(Setup setup)
        {
            if (setup == null)
                throw new ArgumentNullException(nameof(setup));

            if (!setup.IsValid)
                throw new ArgumentOutOfRangeException(nameof(setup), "One or more setups are invalid.");
        }

        private static void Validate(SetupList setups)
        {
            if (setups == null)
                throw new ArgumentNullException(nameof(setups));

            foreach (var setup in setups.QualifyingSetups)
            {
                if (!setup.IsValid)
                    throw new ArgumentOutOfRangeException(nameof(setups), "One or more setups are invalid.");
            }

            foreach (var setup in setups.RaceSetups)
            {
                if (!setup.IsValid)
                    throw new ArgumentOutOfRangeException(nameof(setups), "One or more setups are invalid.");
            }
        }

        private static byte GetTyreCompound(SetupTyreCompound tyreCompound)
        {
            return (byte)tyreCompound;
        }

        private static byte GetBrakeBalance(sbyte value)
        {
            return (byte)value;
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
