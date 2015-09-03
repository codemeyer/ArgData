using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class SetupEditorFacts
    {
        [Fact]
        public void Read_ReadingSetupFile1_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w40-39_bb0_tyC_ra24-32-39-46-53-61");
            var setupEditor = new SetupEditor();

            var setup = setupEditor.Read(path);

            setup.FrontWing.Should().Be(40);
            setup.RearWing.Should().Be(39);
            setup.GearRatio1.Should().Be(24);
            setup.GearRatio2.Should().Be(32);
            setup.GearRatio3.Should().Be(39);
            setup.GearRatio4.Should().Be(46);
            setup.GearRatio5.Should().Be(53);
            setup.GearRatio6.Should().Be(61);
            setup.TyresCompound.Should().Be(SetupTyreCompound.C);
            setup.BrakeBalanceValue.Should().Be(0);
            setup.BrakeBalanceDirection.Should().Be(SetupBrakeBalanceDirection.Front);
        }

        [Fact]
        public void Read_ReadingSetupFile2_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w0-15_bb32f_tyA_ra17-31-39-46-50-56");
            var setupEditor = new SetupEditor();

            var setup = setupEditor.Read(path);

            setup.FrontWing.Should().Be(0);
            setup.RearWing.Should().Be(15);
            setup.GearRatio1.Should().Be(17);
            setup.GearRatio2.Should().Be(31);
            setup.GearRatio3.Should().Be(39);
            setup.GearRatio4.Should().Be(46);
            setup.GearRatio5.Should().Be(50);
            setup.GearRatio6.Should().Be(56);
            setup.TyresCompound.Should().Be(SetupTyreCompound.A);
            setup.BrakeBalanceValue.Should().Be(32);
            setup.BrakeBalanceDirection.Should().Be(SetupBrakeBalanceDirection.Front);
        }

        [Fact]
        public void Read_ReadingSetupFile3_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w24-8_bb5f_tyB_ra25-34-42-50-57-64");
            var setupEditor = new SetupEditor();

            var setup = setupEditor.Read(path);

            setup.FrontWing.Should().Be(24);
            setup.RearWing.Should().Be(8);
            setup.GearRatio1.Should().Be(25);
            setup.GearRatio2.Should().Be(34);
            setup.GearRatio3.Should().Be(42);
            setup.GearRatio4.Should().Be(50);
            setup.GearRatio5.Should().Be(57);
            setup.GearRatio6.Should().Be(64);
            setup.TyresCompound.Should().Be(SetupTyreCompound.B);
            setup.BrakeBalanceValue.Should().Be(5);
            setup.BrakeBalanceDirection.Should().Be(SetupBrakeBalanceDirection.Front);
        }

        [Fact]
        public void Read_ReadingSetupFile4_ReturnsExpectedValues()
        {
            var path = ExampleDataHelper.GetExampleDataPath("setup-w64-60_bb6r_tyD_ra16-30-38-45-49-55");
            var setupEditor = new SetupEditor();

            var setup = setupEditor.Read(path);

            setup.FrontWing.Should().Be(64);
            setup.RearWing.Should().Be(60);
            setup.GearRatio1.Should().Be(16);
            setup.GearRatio2.Should().Be(30);
            setup.GearRatio3.Should().Be(38);
            setup.GearRatio4.Should().Be(45);
            setup.GearRatio5.Should().Be(49);
            setup.GearRatio6.Should().Be(55);
            setup.TyresCompound.Should().Be(SetupTyreCompound.D);
            setup.BrakeBalanceValue.Should().Be(6);
            setup.BrakeBalanceDirection.Should().Be(SetupBrakeBalanceDirection.Rear);
        }

        [Fact]
        public void Read_NotSingleSetupFile_Throws()
        {
            var path = ExampleDataHelper.GetExampleDataPath("GP-EU105.EXE");
            var setupEditor = new SetupEditor();

            Action act = () => setupEditor.Read(path);

            act.ShouldThrow<Exception>();
        }
    }
}
