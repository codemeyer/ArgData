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

        private PreferencesFile(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Returns a reference to a Preferences file at the specified location.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PreferencesFile At(string path)
        {
            ValidatePreferencesFile(path);

            return new PreferencesFile(path);
        }

        private static void ValidatePreferencesFile(string path)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Length != PreferencesContants.PreferencesFileLength)
            {
                throw new ArgumentException($"The file '{path}' does not appear to be a preferences file.");
            }
        }

        internal string GetFullPath(string relative)
        {
            var prefsPath = System.IO.Path.GetDirectoryName(Path);
            var targetDirectory = System.IO.Path.GetDirectoryName(relative);
            var targetFullPath = System.IO.Path.Combine(prefsPath, targetDirectory);
            var fullPath = System.IO.Path.Combine(targetFullPath, System.IO.Path.GetFileName(relative));

            return fullPath;
        }
    }
}
