using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArgData.Entities;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads preferences from the F1PREFS.DAT file.
    /// </summary>
    public class PreferencesReader
    {
        private readonly PreferencesFile _preferencesFile;

        /// <summary>
        /// Creates a PreferencesReader for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="preferencesFile">PreferencesFile to read from.</param>
        /// <returns>PreferencesReader.</returns>
        public PreferencesReader(PreferencesFile preferencesFile)
        {
            if (preferencesFile == null) { throw new ArgumentNullException(nameof(preferencesFile)); }

            _preferencesFile = preferencesFile;
        }

        /// <summary>
        /// Creates a PreferencesReader for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="preferencesFile">PreferencesFile to read from.</param>
        /// <returns>PreferencesReader.</returns>
        public static PreferencesReader For(PreferencesFile preferencesFile)
        {
            return new PreferencesReader(preferencesFile);
        }

        /// <summary>
        /// Gets the relative path and name of the name file that is auto-loaded by the game.
        /// </summary>
        /// <returns>Relative path and name of name file. If no file is set to auto-load, returns null.</returns>
        public string GetAutoLoadedNameFile()
        {
            var fileReader = new FileReader(_preferencesFile.Path);

            byte activated = fileReader.ReadByte(PreferencesContants.AutoLoadNameFileActivatedPosition);

            if (activated == 0)
                return null;

            byte[] data = fileReader.ReadBytes(PreferencesContants.AutoLoadNameFilePathPosition, PreferencesContants.AutoLoadNameFileLength);

            return GetTextFromBytes(data);
        }

        /// <summary>
        /// Gets the relative path and name of the setup file that is auto-loaded by the game.
        /// </summary>
        /// <returns>Relative path and name of the setup file. If no file is set to auto-load, returns null.</returns>
        public string GetAutoLoadedSetupFile()
        {
            var fileReader = new FileReader(_preferencesFile.Path);

            byte activated = fileReader.ReadByte(PreferencesContants.AutoLoadSetupFileActivatedPosition);

            if (activated == 0)
                return null;

            byte[] data = fileReader.ReadBytes(PreferencesContants.AutoLoadSetupFilePathPosition, PreferencesContants.AutoLoadSetupFileLength);

            return GetTextFromBytes(data);
        }

        private static string GetTextFromBytes(IEnumerable<byte> nameData)
        {
            byte[] nameBytes = nameData.TakeWhile(b => b != 0).ToArray();
            string name = Encoding.ASCII.GetString(nameBytes);

            return name;
        }
    }

    /// <summary>
    /// Writes preferences to the F1PREFS.DAT file.
    /// </summary>
    public class PreferencesWriter
    {
        private readonly PreferencesFile _preferencesFile;

        /// <summary>
        /// Creates a PreferencesWriter for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="preferencesFile">PreferencesFile to read from.</param>
        /// <returns>PreferencesWriter.</returns>
        public PreferencesWriter(PreferencesFile preferencesFile)
        {
            if (preferencesFile == null) { throw new ArgumentNullException(nameof(preferencesFile)); }

            _preferencesFile = preferencesFile;
        }

        /// <summary>
        /// Creates a PreferencesWriter for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="preferencesFile">PreferencesFile to read from.</param>
        /// <returns>PreferencesWriter.</returns>
        public static PreferencesWriter For(PreferencesFile preferencesFile)
        {
            return new PreferencesWriter(preferencesFile);
        }

        /// <summary>
        /// Sets the auto-loaded name file.
        /// </summary>
        /// <param name="nameFilePath">Relative path to F1GP installation. Max 31 chars.</param>
        public void SetAutoLoadedNameFile(string nameFilePath)
        {
            if (string.IsNullOrEmpty(nameFilePath))
                throw new ArgumentNullException(nameof(nameFilePath));

            if (nameFilePath.Length > 31)
                throw new ArgumentOutOfRangeException($"The path '{nameFilePath}' exceeds the max length of 31 chars.");

            var writer = new FileWriter(_preferencesFile.Path);

            string pathToWrite = nameFilePath.PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(255, PreferencesContants.AutoLoadNameFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadNameFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Sets the auto-loaded setup file.
        /// </summary>
        /// <param name="setupFilePath">Relative path to F1GP installation. Max 31 chars.</param>
        public void SetAutoLoadedSetupFile(string setupFilePath)
        {
            if (string.IsNullOrEmpty(setupFilePath))
                throw new ArgumentNullException(nameof(setupFilePath));

            if (setupFilePath.Length > 31)
                throw new ArgumentOutOfRangeException($"The path '{setupFilePath}' exceeds the max length of 31 chars.");

            var writer = new FileWriter(_preferencesFile.Path);

            string pathToWrite = setupFilePath.PadRight(PreferencesContants.AutoLoadSetupFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(255, PreferencesContants.AutoLoadSetupFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadSetupFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Disables auto-loading of any name file in the game.
        /// </summary>
        public void DisableAutoLoadedNameFile()
        {
            var writer = new FileWriter(_preferencesFile.Path);

            string pathToWrite = "".PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(0, PreferencesContants.AutoLoadNameFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadNameFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Disables auto-loading of any setup file in the game.
        /// </summary>
        public void DisableAutoLoadedSetupFile()
        {
            var writer = new FileWriter(_preferencesFile.Path);

            string pathToWrite = "".PadRight(PreferencesContants.AutoLoadSetupFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(0, PreferencesContants.AutoLoadSetupFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadSetupFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }
    }

    internal static class PreferencesContants
    {
        internal const int PreferencesFileLength = 1166;

        internal const int AutoLoadNameFileActivatedPosition = 1130;
        internal const int AutoLoadNameFilePathPosition = 1034;
        internal const int AutoLoadNameFileLength = 30;

        internal const int AutoLoadSetupFileActivatedPosition = 1131;
        internal const int AutoLoadSetupFilePathPosition = 1066;
        internal const int AutoLoadSetupFileLength = 30;
    }
}
