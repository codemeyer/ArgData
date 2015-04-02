using ArgData.IntegrationTests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class CarColorEditorFacts : IntegrationTestBase
    {
        [Fact]
        public void ReadingOriginalCarColorsReturnsExpectedValues()
        {
            var expectedCarColors = new DefaultCarColors();
            string exampleDataPath = GetExampleDataPath("gp-orig.exe");
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            var carColors = carColorEditor.ReadCarColors();

            for(int i = 0; i < 1; i++)
            {
                carColors[i].ShouldBeEquivalentTo(expectedCarColors[i]);
            }
        }

        [Fact]
        public void ReadOne()
        {
            var expectedCarColors = new DefaultCarColors()[0];
            string exampleDataPath = GetExampleDataPath("gp-orig.exe");
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            var carColors = carColorEditor.ReadCarColors(0);

            carColors.CockpitFront.Should().Be(expectedCarColors.CockpitFront);
            carColors.CockpitSide.Should().Be(expectedCarColors.CockpitSide);
            carColors.EngineCover.Should().Be(expectedCarColors.EngineCover);
            carColors.EngineCoverRear.Should().Be(expectedCarColors.EngineCoverRear);
            carColors.EngineCoverSide.Should().Be(expectedCarColors.EngineCoverSide);
            carColors.FrontAndRearWing.Should().Be(expectedCarColors.FrontAndRearWing);
            carColors.FrontWingEndplate.Should().Be(expectedCarColors.FrontWingEndplate);
            carColors.NoseAngle.Should().Be(expectedCarColors.NoseAngle);
            carColors.NoseSide.Should().Be(expectedCarColors.NoseSide);
            carColors.NoseTop.Should().Be(expectedCarColors.NoseTop);
            carColors.RearWingSide.Should().Be(expectedCarColors.RearWingSide);
            carColors.Sidepod.Should().Be(expectedCarColors.Sidepod);
            carColors.SidepodTop.Should().Be(expectedCarColors.SidepodTop);
        }
    }
}
