using System;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads damage settings.
    /// </summary>
    public class DamageSettingsReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DamageSettingsReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>DamageSettingsReader.</returns>
        public static DamageSettingsReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new DamageSettingsReader(exeFile);
        }

        private DamageSettingsReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Reads damage settings.
        /// </summary>
        /// <returns>DamageSettings.</returns>
        public DamageSettings Read()
        {
            var fileReader = new FileReader(_exeFile.ExePath);

            int retireWall = _exeFile.GetRetireAfterHittingWallPosition();
            int retireCar =_exeFile.GetRetireAfterHittingOtherCarPosition();
            int damageWall =_exeFile.GetDamageAfterHittingWallPosition();
            int damageCar = _exeFile.GetDamageAfterHittingOtherCarPosition();
            int yellow = _exeFile.GetYellowFlagsForStationaryCarsAfterSecondsPosition();
            int removed =_exeFile.GetRetiredCarsRemovedAfterSecondsPosition();

            byte yellowValue = Convert.ToByte(fileReader.ReadUInt16(yellow) / 1000);
            byte removedValue = Convert.ToByte(fileReader.ReadUInt16(removed) / 1000);

            var settings = new DamageSettings
            {
                RetireAfterHittingWall = fileReader.ReadInt16(retireWall),
                RetireAfterHittingOtherCar = fileReader.ReadInt16(retireCar),
                DamageAfterHittingWall = fileReader.ReadInt16(damageWall),
                DamageAfterHittingOtherCar = fileReader.ReadInt16(damageCar),
                YellowFlagsForStationaryCarsAfterSeconds = yellowValue,
                RetiredCarsRemovedAfterSeconds = removedValue
            };

            return settings;
        }
    }

    /// <summary>
    /// Writes damage settings.
    /// </summary>
    public class DamageSettingsWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a DamageSettingsWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to write to.</param>
        /// <returns>DamageSettingsWriter.</returns>
        public static DamageSettingsWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new DamageSettingsWriter(exeFile);
        }

        private DamageSettingsWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes damage settings to the EXE.
        /// </summary>
        /// <param name="settings">DamageSettings to write.</param>
        public void Write(DamageSettings settings)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }

            if (!settings.IsValid)
                throw new ArgumentOutOfRangeException(nameof(settings), "One or more damage settings are invalid.");

            var fileWriter = new FileWriter(_exeFile.ExePath);

            int retireWall = _exeFile.GetRetireAfterHittingWallPosition();
            int retireCar = _exeFile.GetRetireAfterHittingOtherCarPosition();
            int damageWall = _exeFile.GetDamageAfterHittingWallPosition();
            int damageCar = _exeFile.GetDamageAfterHittingOtherCarPosition();
            int yellow = _exeFile.GetYellowFlagsForStationaryCarsAfterSecondsPosition();
            int removed = _exeFile.GetRetiredCarsRemovedAfterSecondsPosition();

            ushort yellowValue = Convert.ToUInt16(settings.YellowFlagsForStationaryCarsAfterSeconds * 1000);
            ushort removedValue = Convert.ToUInt16(settings.RetiredCarsRemovedAfterSeconds * 1000);

            fileWriter.WriteInt16(settings.RetireAfterHittingWall, retireWall);
            fileWriter.WriteInt16(settings.RetireAfterHittingOtherCar, retireCar);
            fileWriter.WriteInt16(settings.DamageAfterHittingWall, damageWall);
            fileWriter.WriteInt16(settings.DamageAfterHittingOtherCar, damageCar);
            fileWriter.WriteUInt16(yellowValue, yellow);
            fileWriter.WriteUInt16(removedValue, removed);
        }
    }
}
