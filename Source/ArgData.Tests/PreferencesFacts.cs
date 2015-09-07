using System;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PreferencesFacts
    {
        [Fact]
        public void Read_WithAutoloadNames_ReturnsPathToNameFile()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-1.dat");
            var preferencesReader = new PreferencesReader(exampleDataPath);

            string nameFile = preferencesReader.GetAutoLoadedNameFile();

            nameFile.Should().Be(@"gpsaves\F1-91.NAM");
        }

        [Fact]
        public void Read_WithoutAutoLoadedNames_ReturnsNull()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("f1prefs-2.dat");
            var preferencesReader = new PreferencesReader(exampleDataPath);

            string nameFile = preferencesReader.GetAutoLoadedNameFile();

            nameFile.Should().BeNull();
        }

        [Fact]
        public void Read_NotPreferencesFile_ThrowsException()
        {
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE");

            Action act = () => new PreferencesReader(exampleDataPath);

            act.ShouldThrow<Exception>();
        }

        [Fact]
        public void Write_SetAutoLoadedNames_ReturnsPath()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = new PreferencesWriter(context.FilePath);
                preferencesWriter.SetAutoLoadedNameFile("gpsvz\name.nam");

                var preferencesReader = new PreferencesReader(context.FilePath);
                string nameFile = preferencesReader.GetAutoLoadedNameFile();

                nameFile.Should().Be("gpsvz\name.nam");
            }
        }

        [Fact]
        public void Write_SetAutoLoadedNamesWithTooLongPath_ThrowsException()
        {
            using (var context = ExampleDataContext.PreferencesCopy())
            {
                var preferencesWriter = new PreferencesWriter(context.FilePath);
                Action act = () => preferencesWriter.SetAutoLoadedNameFile("123456789012345678901234567890123");

                act.ShouldThrow<Exception>();
            }
        }
    }
}
