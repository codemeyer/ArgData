using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArgData.Entities
{
    /// <summary>
    /// A CarSet represents a set of teams and drivers that can be exported together to a GP.EXE.
    /// </summary>
    public class CarSet
    {
        /// <summary>
        /// Initializes a new instance of a CarSet.
        /// </summary>
        public CarSet()
        {
            for (int i = 0; i <= 17; i++)
            {
                _teams.Add(new CarSetTeam());
            }
        }

        private readonly List<CarSetTeam> _teams = new List<CarSetTeam>();

        /// <summary>
        /// List of 18 teams.
        /// </summary>
        public IReadOnlyList<CarSetTeam> Teams => _teams;

        /// <summary>
        /// Exports the CarSet to the specified GP.EXE file.
        ///
        /// Does not create or set a name file to use.
        /// </summary>
        /// <param name="settings">ImportExportSettings defining what to export.</param>
        /// <param name="exeFile">GpExeFile.</param>
        public void Export(ImportExportSettings settings, GpExeFile exeFile)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }

            var internalSettings = new ImportExportSettings
            {
                Names = false,
                DriverNumbers = settings.DriverNumbers,
                DriverPerformanceRace = settings.DriverPerformanceRace,
                DriverPerformanceQualifying = settings.DriverPerformanceQualifying,
                CarColors = settings.CarColors,
                PitCrewColors = settings.PitCrewColors,
                HelmetColors = settings.HelmetColors,
                TeamHorsepower = settings.TeamHorsepower
            };

            Export(internalSettings, exeFile, null, null);
        }

        /// <summary>
        /// Exports the CarSet to the specified GP.EXE file.
        ///
        /// Only exports the items that have been set to true in the provided ImportExportSettings.
        /// Will create the name file specified in nameFilePath, and set it to load automatically.
        /// </summary>
        /// <param name="settings">ImportExportSettings defining what to export.</param>
        /// <param name="exeFile">GpExeFile</param>
        /// <param name="preferencesFile">PreferencesFile.</param>
        /// <param name="nameFilePath">Relative path to the name file to create.</param>
        public void Export(ImportExportSettings settings, GpExeFile exeFile, PreferencesFile preferencesFile, string nameFilePath)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }
            if (settings.Names)
            {
                if (preferencesFile == null) { throw new ArgumentNullException(nameof(preferencesFile)); }
                if (string.IsNullOrEmpty(nameFilePath)) { throw new ArgumentNullException(nameof(nameFilePath)); }
            }

            var driverNumbers = new DriverNumberList();
            byte driverIndex = 0;

            int teamIndex = 0;
            var carList = new CarList();
            var pitCrewList = new PitCrewList();

            var horsepowerWriter = TeamHorsepowerWriter.For(exeFile);
            var teamNameList = new NameFileTeamList();

            foreach (var team in _teams)
            {
                carList[teamIndex].Copy(team.Car);
                pitCrewList[teamIndex].Copy(team.PitCrew);

                if (settings.TeamHorsepower)
                {
                    horsepowerWriter.WriteTeamHorsepower(teamIndex, team.Horsepower);
                }

                teamNameList[teamIndex].Name = team.Name;
                teamNameList[teamIndex].Engine = team.Engine;

                teamIndex++;

                driverNumbers[driverIndex] = team.Drivers[0].Number;
                driverNumbers[(byte)(driverIndex + 1)] = team.Drivers[1].Number;
                driverIndex += 2;
            }

            if (settings.CarColors)
            {
                var carColorWriter = CarColorWriter.For(exeFile);
                carColorWriter.WriteCarColors(carList);
            }

            if (settings.PitCrewColors)
            {
                var pitCrewWriter = PitCrewColorWriter.For(exeFile);
                pitCrewWriter.WritePitCrewColors(pitCrewList);
            }

            if (settings.DriverNumbers)
            {
                var numberWriter = DriverNumberWriter.For(exeFile);
                numberWriter.WriteDriverNumbers(driverNumbers);
            }

            var racePerformanceList = new DriverPerformanceList();
            var qualifyingPerformanceList = new DriverPerformanceList();
            var helmetList = new HelmetList();
            var driverNameList = new NameFileDriverList();

            foreach (var driver in Drivers())
            {
                racePerformanceList.SetByDriverNumber(driver.Number, driver.RacePerformance);
                qualifyingPerformanceList.SetByDriverNumber(driver.Number, driver.QualifyingPerformance);
                helmetList.SetByDriverNumber(driver.Number, driver.Helmet);

                if (driver.Number > 0)
                {
                    driverNameList[driver.Number - 1].Name = driver.Name;
                }
            }

            var performanceWriter = DriverPerformanceWriter.For(exeFile);
            if (settings.DriverPerformanceRace)
            {
                performanceWriter.WriteRacePerformanceLevels(racePerformanceList);
            }
            if (settings.DriverPerformanceQualifying)
            {
                performanceWriter.WriteQualifyingPerformanceLevels(qualifyingPerformanceList);
            }

            if (settings.HelmetColors)
            {
                var helmetColorWriter = HelmetColorWriter.For(exeFile);
                helmetColorWriter.WriteHelmetColors(helmetList);
            }

            if (settings.Names)
            {
                var fullPath = preferencesFile.GetFullPath(nameFilePath);
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                NameFileWriter.Write(fullPath, driverNameList, teamNameList);

                var preferencesWriter = PreferencesWriter.For(preferencesFile);
                preferencesWriter.SetAutoLoadedNameFile(nameFilePath);
            }
        }

        /// <summary>
        /// Imports all settings into the current CarSet object.
        /// </summary>
        /// <param name="exeFile">GpExeFile to import data from.</param>
        /// <param name="nameFile">NameFile to import team and driver names from.</param>
        public void Import(GpExeFile exeFile, NameFile nameFile)
        {
            Import(this, new ImportExportSettings(), exeFile, nameFile);
        }

        /// <summary>
        /// Imports the specified settings into the current CarSet object.
        /// </summary>
        /// <param name="settings">ImportExportSettings defining what to import.</param>
        /// <param name="exeFile">GpExeFile to import data from.</param>
        /// <param name="nameFile">NameFile to import team and driver names from.</param>
        public void Import(ImportExportSettings settings, GpExeFile exeFile, NameFile nameFile)
        {
            Import(this, settings, exeFile, nameFile);
        }

        /// <summary>
        /// Imports the specified settings into an existing CarSet object.
        /// </summary>
        /// <param name="carSet">CarSet to import data into.</param>
        /// <param name="settings">ImportExportSettings defining what to import.</param>
        /// <param name="exeFile">GpExeFile to import data from.</param>
        /// <param name="nameFile">NameFile to import team and driver names from.</param>
        public static void Import(CarSet carSet, ImportExportSettings settings, GpExeFile exeFile, NameFile nameFile)
        {
            if (carSet == null) { throw new ArgumentNullException(nameof(carSet)); }
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }
            if (exeFile == null) { throw new ArgumentNullException(nameof(exeFile)); }
            if (settings.Names && nameFile == null) { throw new ArgumentNullException(nameof(nameFile)); }

            int driverIndex = 0;


            if (settings.DriverNumbers)
            {
                var driverNumbers = DriverNumberReader.For(exeFile);

                var numberList = driverNumbers.ReadDriverNumbers();

                for (int i = 0; i <= Constants.NumberOfSupportedTeams - 1; i++)
                {
                    carSet.Teams[i].Drivers[0].Number = numberList[(byte)driverIndex];
                    carSet.Teams[i].Drivers[1].Number = numberList[(byte)(driverIndex + 1)];
                    driverIndex += 2;
                }
            }

            var performanceReader = DriverPerformanceReader.For(exeFile);
            var raceLevels = performanceReader.ReadRacePerformanceLevels();
            var qualifyingLevels = performanceReader.ReadQualifyingPerformanceLevels();

            var helmetColorReader = HelmetColorReader.For(exeFile);
            var helmetColors = helmetColorReader.ReadHelmetColors();

            foreach (var driver in carSet.Drivers())
            {
                if (settings.DriverPerformanceRace)
                {
                    driver.RacePerformance = raceLevels.GetByDriverNumber(driver.Number);
                }

                if (settings.DriverPerformanceQualifying)
                {
                    driver.QualifyingPerformance = qualifyingLevels.GetByDriverNumber(driver.Number);
                }

                if (driver.Number > 0)
                {
                    if (settings.HelmetColors)
                    {
                        driver.Helmet.Copy(helmetColors.GetByDriverNumber(driver.Number));
                    }

                    if (settings.Names)
                    {
                        driver.Name = nameFile.Drivers[driver.Number - 1].Name;
                    }
                }
            }

            var horsepowerReader = TeamHorsepowerReader.For(exeFile);
            var carColorReader = CarColorReader.For(exeFile);
            var carList = carColorReader.ReadCarColors();
            var pitCrewColorReader = PitCrewColorReader.For(exeFile);
            var pitCrewList = pitCrewColorReader.ReadPitCrewColors();

            for (int i = 0; i <= Constants.NumberOfSupportedTeams - 1; i++)
            {
                if (settings.TeamHorsepower)
                {
                    carSet.Teams[i].Horsepower = horsepowerReader.ReadTeamHorsepower(i);
                }

                if (settings.CarColors)
                {
                    carSet.Teams[i].Car.Copy(carList[i]);
                }

                if (settings.PitCrewColors)
                {
                    carSet.Teams[i].PitCrew.Copy(pitCrewList[i]);
                }

                if (settings.Names)
                {
                    carSet.Teams[i].Name = nameFile.Teams[i].Name;
                    carSet.Teams[i].Engine = nameFile.Teams[i].Engine;
                }
            }
        }

        /// <summary>
        /// Get all Drivers as a single list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CarSetDriver> Drivers()
        {
            return Teams.SelectMany(team => team.Drivers);
        }
    }

    /// <summary>
    /// ImportExportSettings define what will be imported from or exported to the GP.EXE.
    /// </summary>
    public class ImportExportSettings
    {
        /// <summary>
        /// Initializes a new instance of an ImportExportSettings object.
        /// </summary>
        public ImportExportSettings()
        {
            DriverNumbers = true;
            TeamHorsepower = true;
            CarColors = true;
            PitCrewColors = true;
            DriverPerformanceRace = true;
            DriverPerformanceQualifying = true;
            HelmetColors = true;
            Names = true;
        }

        /// <summary>
        /// Whether to import or export driver numbers or not. Note that DriverPerformanceRace, DriverPerformanceQualifying,
        /// HelmetColors and Names are all dependent on the driver numbers being set correctly.
        /// </summary>
        public bool DriverNumbers { get; set; }

        /// <summary>
        /// Whether to import or export team horsepower levels.
        /// </summary>
        public bool TeamHorsepower { get; set; }

        /// <summary>
        /// Whether car colors should be imported or exported.
        /// </summary>
        public bool CarColors { get; set; }

        /// <summary>
        /// Whether pit crew colors should be imported/exported.
        /// </summary>
        public bool PitCrewColors { get; set; }

        /// <summary>
        /// Whether driver performance race levels should be imported/exported.
        /// </summary>
        public bool DriverPerformanceRace { get; set; }

        /// <summary>
        /// Whether driver performance qualifying levels should be imported/exported.
        /// </summary>
        public bool DriverPerformanceQualifying { get; set; }

        /// <summary>
        /// Whether driver helmet colors should be imported/exported.
        /// </summary>
        public bool HelmetColors { get; set; }

        /// <summary>
        /// Whether team and driver names should be imported/exported.
        /// </summary>
        public bool Names { get; set; }
    }

    /// <summary>
    /// Defines a team as it appears in a CarSet.
    /// </summary>
    public class CarSetTeam : Team
    {
        private readonly List<CarSetDriver> _drivers;

        /// <summary>
        /// Initializes a new CarSetTeam.
        /// </summary>
        public CarSetTeam()
        {
            Car = new Car();
            PitCrew = new PitCrew();
            _drivers = new List<CarSetDriver>
            {
                new CarSetDriver(),
                new CarSetDriver()
            };
        }

        /// <summary>
        /// Gets or sets the horsepower value of the team's car.
        /// </summary>
        public int Horsepower { get; set; }

        /// <summary>
        /// Drivers in the team.
        /// </summary>
        public IReadOnlyList<CarSetDriver> Drivers => _drivers;

        /// <summary>
        /// Car with colors.
        /// </summary>
        public Car Car { get; }

        /// <summary>
        /// PitCrew with colors.
        /// </summary>
        public PitCrew PitCrew { get; }
    }

    /// <summary>
    /// Represents a driver in a CarSet.
    /// </summary>
    public class CarSetDriver : Driver
    {
        /// <summary>
        /// Initializes a new instance of a CarSetDriver.
        /// </summary>
        public CarSetDriver()
        {
            Helmet = new Helmet();
        }

        /// <summary>
        /// Race performance level. Lower is better.
        /// </summary>
        public byte RacePerformance { get; set; }

        /// <summary>
        /// Qualifying performance level. Lower is better.
        /// </summary>
        public byte QualifyingPerformance { get; set; }

        /// <summary>
        /// Driver number. If set to 0, the driver is disabled.
        /// </summary>
        public byte Number { get; set; }

        /// <summary>
        /// Helmet with colors.
        /// </summary>
        public Helmet Helmet { get; }
    }
}
