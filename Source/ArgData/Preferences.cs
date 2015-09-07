using System;
using System.IO;
using System.Linq;
using System.Text;
using ArgData.IO;

namespace ArgData
{
    /// <summary>
    /// Reads preferences from the F1PREFS.DAT file.
    /// </summary>
    public class PreferencesReader
    {
        private readonly string _preferencesPath;

        /// <summary>
        /// Initializes a new instance of a PreferencesReader.
        /// </summary>
        /// <param name="preferencesPath">Path to the preferences file.</param>
        public PreferencesReader(string preferencesPath)
        {
            ValidatePreferencesFile(preferencesPath);

            _preferencesPath = preferencesPath;
        }

        /// <summary>
        /// Gets the relative path and name of the name file that is auto-loaded by the game.
        /// </summary>
        /// <returns>Relative path and name of name file. If no file is set to auto-load, returns null.</returns>
        public string GetAutoLoadedNameFile()
        {
            var fileReader = new FileReader(_preferencesPath);

            byte activated = fileReader.ReadByte(PreferencesContants.AutoLoadNameFileActivatedPosition);

            if (activated == 0)
                return null;

            byte[] data = fileReader.ReadBytes(PreferencesContants.AutoLoadNameFilePathPosition, PreferencesContants.AutoLoadNameFileLength);

            return GetTextFromBytes(data);
        }

        private void ValidatePreferencesFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != PreferencesContants.PreferencesFileLength)
            {
                throw new Exception($"The file '{path}' does not appear to be a preferences file.");
            }
        }

        private static string GetTextFromBytes(byte[] nameData)
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
        private readonly string _preferencesPath;

        /// <summary>
        /// Initializes a new instance of a PreferencesWriter.
        /// </summary>
        /// <param name="preferencesPath">Path to the preferences file.</param>
        public PreferencesWriter(string preferencesPath)
        {
            ValidatePreferencesFile(preferencesPath);

            _preferencesPath = preferencesPath;
        }

        private void ValidatePreferencesFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != PreferencesContants.PreferencesFileLength)
            {
                throw new Exception($"The file '{path}' does not appear to be a preferences file.");
            }
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

            var writer = new FileWriter(_preferencesPath);

            string pathToWrite = nameFilePath.PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            writer.WriteByte(255, PreferencesContants.AutoLoadNameFileActivatedPosition);
            writer.WriteBytes(pathBytes, PreferencesContants.AutoLoadNameFilePathPosition);

            ChecksumCalculator.UpdateChecksum(_preferencesPath);
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
