using System;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads the wet weather settings.
    /// </summary>
    public class WetWeatherSettingsReader
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a WetWeatherSettingsReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>WetWeatherSettingsReader.</returns>
        public static WetWeatherSettingsReader For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new WetWeatherSettingsReader(exeFile);
        }

        private WetWeatherSettingsReader(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Read wet weather settings from a GP.EXE file.
        /// </summary>
        /// <returns></returns>
        public WetWeatherSettings ReadSettings()
        {
            var settings = new WetWeatherSettings();
            var fileReader = new FileReader(_exeFile.ExePath);

            int position = _exeFile.GetRainAtFirstTrackPosition();
            byte rainingInPhoenix = fileReader.ReadByte(position);

            if (rainingInPhoenix == 0)
            {
                settings.RainAtFirstTrack = true;
            }

            int chanceOfRainPosition = _exeFile.GetChanceOfRainPosition();
            ushort chance = fileReader.ReadUShort(chanceOfRainPosition);

            decimal pctChance = 100 * (256m - chance) / 256m;
            byte roundedChance = Convert.ToByte(Math.Round(pctChance, 0));

            settings.ChanceOfRain = roundedChance;

            return settings;
        }
    }

    /// <summary>
    /// Writes wet weather settings.
    /// </summary>
    public class WetWeatherSettingsWriter
    {
        private readonly GpExeFile _exeFile;

        /// <summary>
        /// Creates a WetWeatherSettingsWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>WetWeatherSettingsWriter.</returns>
        public static WetWeatherSettingsWriter For(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            return new WetWeatherSettingsWriter(exeFile);
        }

        private WetWeatherSettingsWriter(GpExeFile exeFile)
        {
            _exeFile = exeFile;
        }

        /// <summary>
        /// Writes wet weather settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteSettings(WetWeatherSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (settings.ChanceOfRain > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(settings), settings.ChanceOfRain, "ChanceOfRain cannot be greater than 100%");
            }

            var fileWriter = new FileWriter(_exeFile.ExePath);

            int position = _exeFile.GetRainAtFirstTrackPosition();
            byte rainAtFirstTrack = Convert.ToByte(settings.RainAtFirstTrack ? 0 : 64);
            fileWriter.WriteByte(rainAtFirstTrack, position);

            var val = Convert.ToUInt16((100 - settings.ChanceOfRain) * 2.56m);

            int chanceOfRainPosition = _exeFile.GetChanceOfRainPosition();
            fileWriter.WriteUInt16(val, chanceOfRainPosition);
        }
    }
}
