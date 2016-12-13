using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PreferencesFacts
    {
        [Fact]
        public void Read_WithAutoloadNames_ReturnsPathToNameFile()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-1.dat", TestDataFileType.Prefs);
            var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

            string nameFile = preferencesReader.GetAutoLoadedNameFile();

            nameFile.Should().Be(@"gpsaves\F1-91.NAM");
        }

        [Fact]
        public void Read_WithoutAutoLoadedNames_ReturnsNull()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-2.dat", TestDataFileType.Prefs);
            var preferencesReader = PreferencesReader.For(PreferencesFile.At(exampleDataPath));

            string nameFile = preferencesReader.GetAutoLoadedNameFile();

            nameFile.Should().BeNull();
        }

        [Fact]
        public void Read_NotPreferencesFile_ThrowsException()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE", TestDataFileType.Exe);

            Action action = () => PreferencesReader.For(PreferencesFile.At(exampleDataPath));

            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Write_SetAutoLoadedNames_ReturnsPath()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
                preferencesWriter.SetAutoLoadedNameFile("gpsvz\name.nam");

                var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
                string nameFile = preferencesReader.GetAutoLoadedNameFile();

                nameFile.Should().Be("gpsvz\name.nam");
            }
        }

        [Fact]
        public void Write_SetAutoLoadedNamesWithTooLongPath_ThrowsException()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

                Action action = () => preferencesWriter.SetAutoLoadedNameFile("123456789012345678901234567890123");

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Fact]
        public void Write_SetAutoLoadedNamesWithNullPath_ThrowsException()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));

                Action action = () => preferencesWriter.SetAutoLoadedNameFile(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Fact]
        public void Write_DisableAutoLoadedNames_SetsValueToNull()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = PreferencesWriter.For(PreferencesFile.At(context.FilePath));
                preferencesWriter.DisableAutoLoadedNameFile();

                var preferencesReader = PreferencesReader.For(PreferencesFile.At(context.FilePath));
                string nameFile = preferencesReader.GetAutoLoadedNameFile();

                nameFile.Should().BeNull();
            }
        }

        [Fact]
        public void CreateReaderFor_Null_ThrowsArgumentNullException()
        {
            Action action = () => PreferencesReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CreateWriterFor_Null_ThrowsArgumentNullException()
        {
            Action action = () => PreferencesWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
