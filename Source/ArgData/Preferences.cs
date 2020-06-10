using System;
using System.Collections.Generic;
using System.IO;
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
            return ReadPathPropertyWithActivation(
                PreferencesContants.AutoLoadNameFileActivatedPosition,
                PreferencesContants.AutoLoadNameFilePathPosition,
                PreferencesContants.AutoLoadNameFileLength);
        }

        /// <summary>
        /// Gets the relative path and name of the setup file that is auto-loaded by the game.
        /// </summary>
        /// <returns>Relative path and name of the setup file. If no file is set to auto-load, returns null.</returns>
        public string GetAutoLoadedSetupFile()
        {
            return ReadPathPropertyWithActivation(
                PreferencesContants.AutoLoadSetupFileActivatedPosition,
                PreferencesContants.AutoLoadSetupFilePathPosition,
                PreferencesContants.AutoLoadSetupFileLength);
        }

        private string ReadPathPropertyWithActivation(int activatedPosition, int pathPosition, int length)
        {
            using (var reader = new BinaryReader(StreamProvider.Invoke(_preferencesFile.Path)))
            {
                reader.BaseStream.Position = activatedPosition;

                byte activated = reader.ReadByte();

                if (activated == 0)
                    return null;

                reader.BaseStream.Position = pathPosition;
                byte[] data = reader.ReadBytes(length);

                return GetTextFromBytes(data);
            }
        }

        private static string GetTextFromBytes(IEnumerable<byte> nameData)
        {
            byte[] nameBytes = nameData.TakeWhile(b => b != 0).ToArray();
            string name = Encoding.ASCII.GetString(nameBytes);

            return name;
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.Open;
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

            string pathToWrite = nameFilePath.PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_preferencesFile.Path)))
            {
                writer.BaseStream.Position = PreferencesContants.AutoLoadNameFileActivatedPosition;
                writer.Write((byte)255);

                writer.BaseStream.Position = PreferencesContants.AutoLoadNameFilePathPosition;
                writer.Write(pathBytes);
            }

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

            string pathToWrite = setupFilePath.PadRight(PreferencesContants.AutoLoadSetupFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_preferencesFile.Path)))
            {
                writer.BaseStream.Position = PreferencesContants.AutoLoadSetupFileActivatedPosition;
                writer.Write((byte)255);

                writer.BaseStream.Position = PreferencesContants.AutoLoadSetupFilePathPosition;
                writer.Write(pathBytes);
            }

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Disables auto-loading of any name file in the game.
        /// </summary>
        public void DisableAutoLoadedNameFile()
        {
            string pathToWrite = "".PadRight(PreferencesContants.AutoLoadNameFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_preferencesFile.Path)))
            {
                writer.BaseStream.Position = PreferencesContants.AutoLoadNameFileActivatedPosition;
                writer.Write((byte)0);

                writer.BaseStream.Position = PreferencesContants.AutoLoadNameFilePathPosition;
                writer.Write(pathBytes);
            }

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Disables auto-loading of any setup file in the game.
        /// </summary>
        public void DisableAutoLoadedSetupFile()
        {
            string pathToWrite = "".PadRight(PreferencesContants.AutoLoadSetupFileLength, '\0');
            byte[] pathBytes = Encoding.ASCII.GetBytes(pathToWrite);

            using (var writer = new BinaryWriter(StreamProvider.Invoke(_preferencesFile.Path)))
            {
                writer.BaseStream.Position = PreferencesContants.AutoLoadSetupFileActivatedPosition;
                writer.Write((byte)0);

                writer.BaseStream.Position = PreferencesContants.AutoLoadSetupFilePathPosition;
                writer.Write(pathBytes);
            }

            ChecksumCalculator.UpdateChecksum(_preferencesFile.Path);
        }

        /// <summary>
        /// Default FileStream provider. Can be overridden in tests.
        /// </summary>
        internal Func<string, Stream> StreamProvider = FileStreamProvider.OpenWriter;
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
