using System;
using System.IO;
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
        public WetWeatherSettingsReader(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a WetWeatherSettingsReader for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>WetWeatherSettingsReader.</returns>
        public static WetWeatherSettingsReader For(GpExeFile exeFile)
        {
            return new WetWeatherSettingsReader(exeFile);
        }

        /// <summary>
        /// Read wet weather settings from a GP.EXE file.
        /// </summary>
        /// <returns></returns>
        public WetWeatherSettings ReadSettings()
        {
            var settings = new WetWeatherSettings();

            using (var reader = new BinaryReader(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                reader.BaseStream.Position = _exeFile.GetRainAtFirstTrackPosition();
                byte rainingInPhoenix = reader.ReadByte();

                if (rainingInPhoenix == 0)
                {
                    settings.RainAtFirstTrack = true;
                }

                reader.BaseStream.Position = _exeFile.GetChanceOfRainPosition();
                ushort chance = reader.ReadUInt16();

                decimal pctChance = 100 * (256m - chance) / 256m;
                byte roundedChance = Convert.ToByte(Math.Round(pctChance, 0));

                settings.ChanceOfRain = roundedChance;

                return settings;
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
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
        public WetWeatherSettingsWriter(GpExeFile exeFile)
        {
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            _exeFile = exeFile;
        }

        /// <summary>
        /// Creates a WetWeatherSettingsWriter for the specified GP.EXE file.
        /// </summary>
        /// <param name="exeFile">GpExeFile to read from.</param>
        /// <returns>WetWeatherSettingsWriter.</returns>
        public static WetWeatherSettingsWriter For(GpExeFile exeFile)
        {
            return new WetWeatherSettingsWriter(exeFile);
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

            byte rainAtFirstTrack = Convert.ToByte(settings.RainAtFirstTrack ? 0 : 64);
            ushort rainChance = Convert.ToUInt16((100 - settings.ChanceOfRain) * 2.56m);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_exeFile.ExePath)))
            {
                writer.BaseStream.Position = _exeFile.GetRainAtFirstTrackPosition();
                writer.Write(rainAtFirstTrack);

                writer.BaseStream.Position = _exeFile.GetChanceOfRainPosition();
                writer.Write(rainChance);
            }
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
    }
}
