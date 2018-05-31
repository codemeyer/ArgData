using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class CarSetFacts
    {
        [Fact]
        public void Export_ExportCarSetWithNames()
        {
            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            using (var prefsContext = ExampleDataContext.PreferencesCopy())
            {
                var carSet = SetupCarSetForTest();

                var preferencesFile = PreferencesFile.At(prefsContext.FilePath);
                carSet.Export(new ImportExportSettings(), exeContext.ExeFile, preferencesFile, "gpsaves/DRVS.NAM");

                AssertExportedCarColors(exeContext.ExeFile);
                AssertExportedTeamHorsepower(exeContext.ExeFile);
                AssertExportedDriverNumbers(exeContext.ExeFile);
                AssertExportedDriverPerformance(exeContext.ExeFile);
                AssertExportedPitCrewColors(exeContext.ExeFile);
                AssertExportedHelmetColors(exeContext.ExeFile);
                AssertExportedDriverNames(prefsContext.FilePath);
            }
        }

        [Fact]
        public void ExportNothing_DoesNothingToExeFile()
        {
            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var bytesBefore = File.ReadAllBytes(exeContext.FilePath);
                var checksumBefore = new ChecksumCalculator().Calculate(bytesBefore);

                var carSet = SetupCarSetForTest();

                var nothing = new ImportExportSettings
                {
                    DriverNumbers = false,
                    Names = false,
                    CarColors = false,
                    PitCrewColors = false,
                    DriverPerformanceRace = false,
                    DriverPerformanceQualifying = false,
                    TeamHorsepower = false,
                    HelmetColors = false
                };

                carSet.Export(nothing, exeContext.ExeFile);

                var bytesAfter = File.ReadAllBytes(exeContext.FilePath);
                var checksumAfter = new ChecksumCalculator().Calculate(bytesAfter);

                checksumAfter.Checksum1.Should().Be(checksumBefore.Checksum1);
                checksumAfter.Checksum2.Should().Be(checksumBefore.Checksum2);
            }
        }

        private CarSet SetupCarSetForTest()
        {
            var carSet = new CarSet();
            byte driverNumber = 1;

            for (byte b = 0; b <= 17; b++)
            {
                var team = carSet.Teams[b];
                team.Car.CockpitFront = b;
                team.Car.CockpitSide = (byte)(b + 5);
                team.PitCrew.ShirtPrimary = b;
                team.PitCrew.PantsPrimary = (byte)(b + 5);
                team.Horsepower = 700 + b;
                team.Name = $"TeamTeam {b + 1}";
                team.Engine = $"EngEng {b + 1}";
                team.Drivers[0].Number = driverNumber;
                team.Drivers[0].Name = $"Drv {driverNumber}";
                team.Drivers[0].RacePerformance = driverNumber;
                team.Drivers[0].QualifyingPerformance = driverNumber;
                team.Drivers[0].Helmet.Visor = driverNumber;
                team.Drivers[0].Helmet.Stripes[0] = driverNumber;
                driverNumber++;
                team.Drivers[1].Number = driverNumber;
                team.Drivers[1].Name = $"Drv {driverNumber}";
                team.Drivers[1].RacePerformance = driverNumber;
                team.Drivers[1].QualifyingPerformance = driverNumber;
                team.Drivers[1].Helmet.Visor = driverNumber;
                team.Drivers[1].Helmet.Stripes[0] = driverNumber;
                driverNumber++;
            }

            return carSet;
        }

        private void AssertExportedDriverNames(string prefsContextFilePath)
        {
            var preferencesFile = PreferencesFile.At(prefsContextFilePath);
            var reader = PreferencesReader.For(preferencesFile);

            var fileName = reader.GetAutoLoadedNameFile();

            fileName.Should().Be("gpsaves/DRVS.NAM");

            var prefsDir = Path.GetDirectoryName(preferencesFile.Path);
            var fullPath = Path.Combine(prefsDir, fileName);

            var nameFile = new NameFileReader().Read(fullPath);
            nameFile.Drivers[0].Name.Should().Be("Drv 1");
            nameFile.Teams[0].Name.Should().Be("TeamTeam 1");
            nameFile.Teams[0].Engine.Should().Be("EngEng 1");
        }

        private static void AssertExportedCarColors(GpExeFile exeFile)
        {
            var carColorReader = CarColorReader.For(exeFile);

            var cars = carColorReader.ReadCarColors();

            for (byte b = 0; b <= 17; b++)
            {
                cars[b].CockpitFront.Should().Be(b);
                cars[b].CockpitSide.Should().Be((byte)(b + 5));
            }
        }

        private static void AssertExportedTeamHorsepower(GpExeFile exeFile)
        {
            var horsepowerReader = TeamHorsepowerReader.For(exeFile);

            for (int i = 0; i <= 17; i++)
            {
                var horsepower = horsepowerReader.ReadTeamHorsepower(i);
                horsepower.Should().Be(700 + i);
            }
        }

        private static void AssertExportedDriverNumbers(GpExeFile exeFile)
        {
            var driverNumbers = DriverNumberReader.For(exeFile);

            var list = driverNumbers.ReadDriverNumbers();

            for (byte b = 0; b <= 35; b++)
            {
                list[b].Should().Be((byte)(b + 1));
            }
        }

        private static void AssertExportedDriverPerformance(GpExeFile exeFile)
        {
            var performanceReader = DriverPerformanceReader.For(exeFile);
            var race = performanceReader.ReadRacePerformanceLevels();
            var qual = performanceReader.ReadQualifyingPerformanceLevels();

            for (byte b = 1; b <= 36; b++)
            {
                race.GetByDriverNumber(b).Should().Be(b);
                qual.GetByDriverNumber(b).Should().Be(b);
            }
        }

        private static void AssertExportedPitCrewColors(GpExeFile exeFile)
        {
            var pitCrewReader = PitCrewColorReader.For(exeFile);
            var pitCrews = pitCrewReader.ReadPitCrewColors();

            for (byte b = 0; b <= 17; b++)
            {
                pitCrews[b].ShirtPrimary.Should().Be(b);
                pitCrews[b].PantsPrimary.Should().Be((byte)(b + 5));
            }
        }

        private static void AssertExportedHelmetColors(GpExeFile exeFile)
        {
            var helmetReader = HelmetColorReader.For(exeFile);
            var helmets = helmetReader.ReadHelmetColors();

            for (byte b = 1; b <= 36; b++)
            {
                helmets.GetByDriverNumber(b).Visor.Should().Be(b);
                helmets.GetByDriverNumber(b).Stripes[0].Should().Be(b);
            }
        }

        [Fact]
        public void Export_ExportSettingsNull_ThrowsArgumentNullException()
        {
            var carSet = new CarSet();

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                Action action = () => carSet.Export(null, exeContext.ExeFile);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Export_ExeFileNull_ThrowsArgumentNullException()
        {
            var carSet = new CarSet();

            using (ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                Action action = () => carSet.Export(new ImportExportSettings(), null);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Export_NamesTrueButPreferencesFileNull_ThrowsArgumentNullException()
        {
            var carSet = new CarSet();

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                Action action = () => carSet.Export(new ImportExportSettings(), exeContext.ExeFile, null, "gpsaves/any");

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Export_NamesTrueButNameFilePathNull_ThrowsArgumentNullException()
        {
            var carSet = new CarSet();

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            using (var prefsContext = ExampleDataContext.PreferencesCopy())
            {
                var preferencesFile = PreferencesFile.At(prefsContext.FilePath);

                Action action = () => carSet.Export(new ImportExportSettings(), exeContext.ExeFile, preferencesFile, null);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Import_ImportAllValues()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var carSet = new CarSet();

                carSet.Import(exeContext.ExeFile, nameFile);

                AssertImportedDriverNumbers(carSet);
                AssertImportedTeamHorsepower(carSet);
                AssertImportedDriverPerformance(carSet);
                AssertImportedHelmets(carSet);
                AssertImportedCarColors(carSet);
                AssertImportedPitCrewColors(carSet);
                AssertImportedNames(carSet);
            }
        }

        [Fact]
        public void Import_ImportAllValuesWithSettings()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var carSet = new CarSet();

                carSet.Import(new ImportExportSettings(), exeContext.ExeFile, nameFile);

                AssertImportedDriverNumbers(carSet);
                AssertImportedTeamHorsepower(carSet);
                AssertImportedDriverPerformance(carSet);
                AssertImportedHelmets(carSet);
                AssertImportedCarColors(carSet);
                AssertImportedPitCrewColors(carSet);
                AssertImportedNames(carSet);
            }
        }

        [Fact]
        public void Import_ImportAllValuesExistingCarSet()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var carSet = new CarSet();

                CarSet.Import(carSet, new ImportExportSettings(), exeContext.ExeFile, nameFile);

                AssertImportedDriverNumbers(carSet);
                AssertImportedTeamHorsepower(carSet);
                AssertImportedDriverPerformance(carSet);
                AssertImportedHelmets(carSet);
                AssertImportedCarColors(carSet);
                AssertImportedPitCrewColors(carSet);
                AssertImportedNames(carSet);
            }
        }

        private static void AssertImportedDriverPerformance(CarSet carSet)
        {
            carSet.Teams[2].Drivers[0].QualifyingPerformance.Should().Be(3);
            carSet.Teams[2].Drivers[0].RacePerformance.Should().Be(2);
            carSet.Teams[2].Drivers[1].QualifyingPerformance.Should().Be(2);
            carSet.Teams[2].Drivers[1].RacePerformance.Should().Be(3);
        }

        private static void AssertImportedDriverNumbers(CarSet carSet)
        {
            carSet.Teams[0].Drivers[0].Number.Should().Be(1);
            carSet.Teams[6].Drivers[0].Number.Should().Be(14);
            carSet.Teams[6].Drivers[1].Number.Should().Be(0);
        }

        private static void AssertImportedTeamHorsepower(CarSet carSet)
        {
            carSet.Teams[0].Horsepower.Should().Be(716);
        }

        private static void AssertImportedHelmets(CarSet carSet)
        {
            var helmet = carSet.Drivers().Single(d => d.Number == 1).Helmet;

            helmet.Stripes[2].Should().Be(111);
        }

        private void AssertImportedCarColors(CarSet carSet)
        {
            carSet.Teams[0].Car.NoseSide.Should().Be(32);
            carSet.Teams[0].Car.EngineCoverSide.Should().Be(47);
        }

        private void AssertImportedPitCrewColors(CarSet carSet)
        {
            carSet.Teams[0].PitCrew.PantsPrimary.Should().Be(56);
            carSet.Teams[1].PitCrew.PantsPrimary.Should().Be(70);
            carSet.Teams[3].PitCrew.PantsPrimary.Should().Be(70);
        }

        private static void AssertImportedNames(CarSet carSet)
        {
            carSet.Teams[0].Name.Should().Be("McLaren");
            carSet.Teams[0].Engine.Should().Be("Honda");
            carSet.Teams[2].Drivers[0].Name.Should().Be("Nigel Mansell");
        }

        [Fact]
        public void Import_NullCarSet_ThrowsArgumentNullException()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));
            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                Action action = () => CarSet.Import(null, new ImportExportSettings(), exeContext.ExeFile, nameFile);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Import_NullImportExportSettings_ThrowsArgumentNullException()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));
            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                Action action = () => CarSet.Import(new CarSet(), null, exeContext.ExeFile, nameFile);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void Import_NullGpExeFile_ThrowsArgumentNullException()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));

            Action action = () => CarSet.Import(new CarSet(), new ImportExportSettings(), null, nameFile);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Import_NullNameFileWhenNamesShouldBeImported_ThrowsArgumentNullException()
        {
            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var settings = new ImportExportSettings
                {
                    Names = true
                };

                Action action = () => CarSet.Import(new CarSet(), settings, exeContext.ExeFile, null);

                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void ImportNothing_DoesNothingToCarSet()
        {
            var nameFile = new NameFileReader().Read(ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names));

            using (var exeContext = ExampleDataContext.ExeCopy(GpExeVersionInfo.European105))
            {
                var nothing = new ImportExportSettings
                {
                    DriverNumbers = false,
                    Names = false,
                    CarColors = false,
                    PitCrewColors = false,
                    DriverPerformanceRace = false,
                    DriverPerformanceQualifying = false,
                    TeamHorsepower = false,
                    HelmetColors = false
                };

                var carSet = SetupCarSetForTest();

                CarSet.Import(carSet, nothing, exeContext.ExeFile, nameFile);

                carSet.Teams[6].Drivers[0].Number.Should().Be(13);      // not 14
                carSet.Teams[0].Name.Should().Be("TeamTeam 1");         // not McLaren
                carSet.Teams[0].Drivers[0].Name.Should().Be("Drv 1");   // not Ayrton Senna
                carSet.Teams[0].Car.CockpitFront.Should().Be(0);
                carSet.Teams[0].PitCrew.PantsSecondary.Should().Be(0);
                carSet.Teams[0].Drivers[1].RacePerformance.Should().Be(2);
                carSet.Teams[0].Drivers[1].QualifyingPerformance.Should().Be(2);
                carSet.Teams[0].Horsepower.Should().Be(700);
                carSet.Teams[0].Drivers[0].Helmet.VisorSurround.Should().Be(0);
            }
        }
    }
}
