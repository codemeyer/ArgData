using System;
using System.IO;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class SetupFacts
    {
        [Fact]
        public void ReadSingle_ReadingSetupFile1_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w40-39_bb0_tyC_ra24-32-39-46-53-61", TestDataFileType.Setups);

            var setup = SetupReader.ReadSingle(path);

            setup.FrontWing.Should().Be(40);
            setup.RearWing.Should().Be(39);
            setup.GearRatio1.Should().Be(24);
            setup.GearRatio2.Should().Be(32);
            setup.GearRatio3.Should().Be(39);
            setup.GearRatio4.Should().Be(46);
            setup.GearRatio5.Should().Be(53);
            setup.GearRatio6.Should().Be(61);
            setup.TyreCompound.Should().Be(SetupTyreCompound.C);
            setup.BrakeBalance.Should().Be(0);
        }

        [Fact]
        public void ReadSingle_ReadingSetupFile2_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w0-15_bb32f_tyA_ra17-31-39-46-50-56", TestDataFileType.Setups);

            var setup = SetupReader.ReadSingle(path);

            setup.FrontWing.Should().Be(0);
            setup.RearWing.Should().Be(15);
            setup.GearRatio1.Should().Be(17);
            setup.GearRatio2.Should().Be(31);
            setup.GearRatio3.Should().Be(39);
            setup.GearRatio4.Should().Be(46);
            setup.GearRatio5.Should().Be(50);
            setup.GearRatio6.Should().Be(56);
            setup.TyreCompound.Should().Be(SetupTyreCompound.A);
            setup.BrakeBalance.Should().Be(32);
        }

        [Fact]
        public void ReadSingle_ReadingSetupFile3_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w24-8_bb5f_tyB_ra25-34-42-50-57-64", TestDataFileType.Setups);

            var setup = SetupReader.ReadSingle(path);

            setup.FrontWing.Should().Be(24);
            setup.RearWing.Should().Be(8);
            setup.GearRatio1.Should().Be(25);
            setup.GearRatio2.Should().Be(34);
            setup.GearRatio3.Should().Be(42);
            setup.GearRatio4.Should().Be(50);
            setup.GearRatio5.Should().Be(57);
            setup.GearRatio6.Should().Be(64);
            setup.TyreCompound.Should().Be(SetupTyreCompound.B);
            setup.BrakeBalance.Should().Be(5);
        }

        [Fact]
        public void ReadSingle_ReadingSetupFile4_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w64-60_bb6r_tyD_ra16-30-38-45-49-55", TestDataFileType.Setups);

            var setup = SetupReader.ReadSingle(path);

            setup.FrontWing.Should().Be(64);
            setup.RearWing.Should().Be(60);
            setup.GearRatio1.Should().Be(16);
            setup.GearRatio2.Should().Be(30);
            setup.GearRatio3.Should().Be(38);
            setup.GearRatio4.Should().Be(45);
            setup.GearRatio5.Should().Be(49);
            setup.GearRatio6.Should().Be(55);
            setup.TyreCompound.Should().Be(SetupTyreCompound.D);
            setup.BrakeBalance.Should().Be(-6);
        }

        [Fact]
        public void ReadSingle_NotSingleSetupFile_Throws()
        {
            var path = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE", TestDataFileType.Exe);

            Action action = () => SetupReader.ReadSingle(path);

            action.ShouldThrow<Exception>();
        }

        [Fact]
        public void ReadMultiple_MultipleSetupsNotSeparate_ReturnsFalse()
        {
            var path = ExampleDataHelper.GetExampleDataPath("multi-setups", TestDataFileType.Setups);

            var list = SetupReader.ReadMultiple(path);

            list.SeparateSetups.Should().BeFalse();
        }

        [Fact]
        public void ReadMultiple_MultipleSetupsSeparate_ReturnsTrue()
        {
            var path = ExampleDataHelper.GetExampleDataPath("multi-setups-separate", TestDataFileType.Setups);

            var list = SetupReader.ReadMultiple(path);

            list.SeparateSetups.Should().BeTrue();
        }

        [Fact]
        public void ReadMultiple_MultipleSetups_ReturnsCorrectWingLevels()
        {
            var path = ExampleDataHelper.GetExampleDataPath("multi-setups", TestDataFileType.Setups);

            var list = SetupReader.ReadMultiple(path);

            byte index = 1;

            foreach (var setup in list.QualifyingSetups)
            {
                setup.FrontWing.Should().Be(index);
                setup.RearWing.Should().Be(index);
                index++;
            }

            foreach (var setup in list.RaceSetups)
            {
                setup.FrontWing.Should().Be(index);
                setup.RearWing.Should().Be(index);
                index++;
            }
        }

        [Fact]
        public void ReadMultiple_NotMultipleSetupFile_Throws()
        {
            var path = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE", TestDataFileType.Exe);

            Action action = () => SetupReader.ReadMultiple(path);

            action.ShouldThrow<Exception>();
        }

        [Fact]
        public void WriteSingle_KnownValues_AreStoredCorrectly()
        {
            var setup = new Setup
            {
                FrontWing = 19,
                RearWing = 60,
                BrakeBalance = -5,
                GearRatio1 = 25,
                GearRatio2 = 28,
                GearRatio3 = 33,
                GearRatio4 = 38,
                GearRatio5 = 40,
                GearRatio6 = 46,
                TyreCompound = SetupTyreCompound.D
            };

            using (var context = ExampleDataContext.GetTempFileName(".set"))
            {
                SetupWriter.WriteSingle(setup, context.FilePath);

                var setupOnDisk = SetupReader.ReadSingle(context.FilePath);

                setupOnDisk.FrontWing.Should().Be(setup.FrontWing);
                setupOnDisk.RearWing.Should().Be(setup.RearWing);
                setupOnDisk.GearRatio1.Should().Be(setup.GearRatio1);
                setupOnDisk.GearRatio2.Should().Be(setup.GearRatio2);
                setupOnDisk.GearRatio3.Should().Be(setup.GearRatio3);
                setupOnDisk.GearRatio4.Should().Be(setup.GearRatio4);
                setupOnDisk.GearRatio5.Should().Be(setup.GearRatio5);
                setupOnDisk.GearRatio6.Should().Be(setup.GearRatio6);
                setupOnDisk.TyreCompound.Should().Be(setup.TyreCompound);
                setupOnDisk.BrakeBalance.Should().Be(setup.BrakeBalance);
            }
        }

        [Theory]
        [InlineData("setup-w24-8_bb5f_tyB_ra25-34-42-50-57-64")]
        [InlineData("setup-w0-15_bb32f_tyA_ra17-31-39-46-50-56")]
        [InlineData("setup-w64-60_bb6r_tyD_ra16-30-38-45-49-55")]
        public void WriteSingle_KnownSetup_StoredCorrectly(string knownSetupFile)
        {
            var setup = SetupReader.ReadSingle(ExampleDataHelper.GetExampleDataPath(knownSetupFile, TestDataFileType.Setups));

            using (var context = ExampleDataContext.GetTempFileName(".set"))
            {
                SetupWriter.WriteSingle(setup, context.FilePath);

                var setupOnDisk = SetupReader.ReadSingle(context.FilePath);

                setupOnDisk.FrontWing.Should().Be(setup.FrontWing);
                setupOnDisk.RearWing.Should().Be(setup.RearWing);
                setupOnDisk.GearRatio1.Should().Be(setup.GearRatio1);
                setupOnDisk.GearRatio2.Should().Be(setup.GearRatio2);
                setupOnDisk.GearRatio3.Should().Be(setup.GearRatio3);
                setupOnDisk.GearRatio4.Should().Be(setup.GearRatio4);
                setupOnDisk.GearRatio5.Should().Be(setup.GearRatio5);
                setupOnDisk.GearRatio6.Should().Be(setup.GearRatio6);
                setupOnDisk.TyreCompound.Should().Be(setup.TyreCompound);
                setupOnDisk.BrakeBalance.Should().Be(setup.BrakeBalance);
            }
        }

        [Fact]
        public void WriteMultiple_KnownValues_StoresExpectedValues()
        {
            var setups = CreateSetupListForTest(true);

            using (var context = ExampleDataContext.GetTempFileName(".set"))
            {
                SetupWriter.WriteMultiple(setups, context.FilePath);

                var setupsOnDisk = SetupReader.ReadMultiple(context.FilePath);

                setupsOnDisk.SeparateSetups.Should().BeTrue();

                byte index = 1;

                for (int qi = 0; qi <= 15; qi++)
                {
                    var setup = setupsOnDisk.QualifyingSetups[qi];
                    setup.FrontWing.Should().Be(index);
                    setup.RearWing.Should().Be(Convert.ToByte(index + 10));
                    setup.GearRatio1.Should().Be(30);
                    setup.GearRatio2.Should().Be(31);
                    setup.GearRatio3.Should().Be(32);
                    setup.GearRatio4.Should().Be(33);
                    setup.GearRatio5.Should().Be(34);
                    setup.GearRatio6.Should().Be(45);
                    setup.TyreCompound.Should().Be(SetupTyreCompound.B);
                    setup.BrakeBalance.Should().Be(10);
                    index++;
                }

                for (int ri = 0; ri <= 15; ri++)
                {
                    var setup = setupsOnDisk.RaceSetups[ri];
                    setup.FrontWing.Should().Be(index);
                    setup.RearWing.Should().Be(Convert.ToByte(index + 10));
                    setup.GearRatio1.Should().Be(30);
                    setup.GearRatio2.Should().Be(31);
                    setup.GearRatio3.Should().Be(32);
                    setup.GearRatio4.Should().Be(33);
                    setup.GearRatio5.Should().Be(34);
                    setup.GearRatio6.Should().Be(45);
                    setup.TyreCompound.Should().Be(SetupTyreCompound.C);
                    setup.BrakeBalance.Should().Be(-25);

                    index++;
                }
            }
        }

        private SetupList CreateSetupListForTest(bool separate)
        {
            var setups = new SetupList
            {
                SeparateSetups = separate
            };

            byte index = 1;

            for (int qi = 0; qi <= 15; qi++)
            {
                var setup = setups.QualifyingSetups[qi];
                setup.FrontWing = index;
                setup.RearWing = Convert.ToByte(index + 10);
                setup.GearRatio1 = 30;
                setup.GearRatio2 = 31;
                setup.GearRatio3 = 32;
                setup.GearRatio4 = 33;
                setup.GearRatio5 = 34;
                setup.GearRatio6 = 45;
                setup.TyreCompound = SetupTyreCompound.B;
                setup.BrakeBalance = 10;

                index++;
            }

            for (int ri = 0; ri <= 15; ri++)
            {
                var setup = setups.RaceSetups[ri];
                setup.FrontWing = index;
                setup.RearWing = Convert.ToByte(index + 10);
                setup.GearRatio1 = 30;
                setup.GearRatio2 = 31;
                setup.GearRatio3 = 32;
                setup.GearRatio4 = 33;
                setup.GearRatio5 = 34;
                setup.GearRatio6 = 45;
                setup.TyreCompound = SetupTyreCompound.C;
                setup.BrakeBalance = -25;

                index++;
            }

            return setups;
        }

        [Fact]
        public void WriteSingle_SetupInvalid_ThrowsException()
        {
            var setup = new Setup
            {
                GearRatio1 = 1
            };

            Action action = () => SetupWriter.WriteSingle(setup, ExampleDataHelper.GetTempFileName(".set"));

            action.ShouldThrow<Exception>();
        }

        [Fact]
        public void WriteMultiple_QualifyingSetupInvalid_ThrowsException()
        {
            var setups = new SetupList();
            setups.QualifyingSetups[10].GearRatio1 = 1;

            Action action = () => SetupWriter.WriteMultiple(setups, ExampleDataHelper.GetTempFileName(".set"));

            action.ShouldThrow<Exception>();
        }

        [Fact]
        public void WriteMultiple_RaceSetupInvalid_ThrowsException()
        {
            var setups = new SetupList();
            setups.RaceSetups[5].GearRatio1 = 1;

            Action action = () => SetupWriter.WriteMultiple(setups, ExampleDataHelper.GetTempFileName(".set"));

            action.ShouldThrow<Exception>();
        }

        [Fact]
        public void ReadSingle_FileNull_ThrowsArgumentNullException()
        {
            Action action = () => SetupReader.ReadSingle(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReadSingle_FileNotFound_ThrowsFileNotFoundException()
        {
            var nonExistingFile = ExampleDataHelper.GetExampleDataPath("setup-does-not-exist.setup", TestDataFileType.Setups);

            Action action = () => SetupReader.ReadSingle(nonExistingFile);

            action.ShouldThrow<FileNotFoundException>();
        }

        [Fact]
        public void ReadMultiple_FileNull_ThrowsArgumentNullException()
        {
            Action action = () => SetupReader.ReadMultiple(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReadMultiple_FileNotFound_ThrowsFileNotFoundException()
        {
            var nonExistingFile = ExampleDataHelper.GetExampleDataPath("setup-does-not-exist.setup", TestDataFileType.Setups);

            Action action = () => SetupReader.ReadMultiple(nonExistingFile);

            action.ShouldThrow<FileNotFoundException>();
        }

        [Fact]
        public void WriteSingle_SetupNull_ThrowsArgumentNullException()
        {
            Action action = () => SetupWriter.WriteSingle(null, "any-path.set");

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void WriteMultiple_SetupNull_ThrowsArgumentNullException()
        {
            Action action = () => SetupWriter.WriteMultiple(null, "any-path.set");

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
