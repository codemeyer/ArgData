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
        private readonly PreferencesFile _prefsFile;

        /// <summary>
        /// Creates a PreferencesReader for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="prefsFile">PreferencesFile to read from.</param>
        /// <returns>PreferencesReader.</returns>
        public static PreferencesReader For(PreferencesFile prefsFile)
        {
            if (prefsFile == null) { throw new ArgumentNullException(nameof(prefsFile)); }

            return new PreferencesReader(prefsFile);
        }

        private PreferencesReader(PreferencesFile prefsFile)
        {
            _prefsFile = prefsFile;
        }

        /// <summary>
        /// Gets the relative path and name of the name file that is auto-loaded by the game.
        /// </summary>
        /// <returns>Relative path and name of name file. If no file is set to auto-load, returns null.</returns>
        public string GetAutoLoadedNameFile()
        {
            var fileReader = new FileReader(_prefsFile.Path);

            byte activated = fileReader.ReadByte(PreferencesContants.AutoLoadNameFileActivatedPosition);

            if (activated == 0)
                return null;

            byte[] data = fileReader.ReadBytes(PreferencesContants.AutoLoadNameFilePathPosition, PreferencesContants.AutoLoadNameFileLength);

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
        private readonly PreferencesFile _prefsFile;

        /// <summary>
        /// Creates a PreferencesWriter for the specified F1PREFS.DAT file.
        /// </summary>
        /// <param name="prefsFile">PreferencesFiles to read from.</param>
        /// <returns>PreferencesWriter.</returns>
        public static PreferencesWriter For(PreferencesFile prefsFile)
        {
            if (prefsFile == null) { throw new ArgumentNullException(nameof(prefsFile)); }

            return new PreferencesWriter(prefsFile);
        }

        private PreferencesWriter(PreferencesFile prefsFile)
        {
            _prefsFile = prefsFile;
        }

        /// <summary>
        /// Sets the auto-loaded name file.
        /// </summary>
        /// <param name="nameFilePath">Relative path to F1GP installation. Max 31 chars.</param>
        public void SetAutoLoadedNameFile(string nameFilePath)
        {
            if (nameFilePath.Length > 31)
            {
                throw new Exception($"The path '{nameFilePath}' exceeds the max length of 31 chars.");
            }

            var writer = new FileWriter(_prefsFile.Path);

            string pathToWrite = nameFilePath.PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(255, PreferencesContants.AutoLoadNameFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadNameFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_prefsFile.Path);
        }
    }

    internal static class PreferencesContants
    {
        internal const int PreferencesFileLength = 1166;

        internal const int AutoLoadNameFileActivatedPosition = 1130;
        internal const int AutoLoadNameFilePathPosition = 1034;
        internal const int AutoLoadNameFileLength = 30;
    }
}
