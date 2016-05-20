using System;
using System.IO;

namespace ArgData.Entities
{
    /// <summary>
    /// Represents game preferences stored in F1PREFS.DAT.
    /// </summary>
    public class PreferencesFile
    {
        internal string Path { get; }

        private PreferencesFile(string prefsPath)
        {
            Path = prefsPath;
        }

        /// <summary>
        /// Returns a reference to a Preferences file at the specified location.
        /// </summary>
        /// <param name="prefsPath"></param>
        /// <returns></returns>
        public static PreferencesFile At(string prefsPath)
        {
            ValidatePreferencesFile(prefsPath);

            return new PreferencesFile(prefsPath);
        }

        private static void ValidatePreferencesFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != PreferencesContants.PreferencesFileLength)
            {
                throw new Exception($"The file '{path}' does not appear to be a preferences file.");
            }
        }
    }
}
