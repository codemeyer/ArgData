using Xunit;

namespace ArgData.IntegrationTests
{
    public class CarColorEditorFacts : IntegrationTestBase
    {
        [Fact]
        public void ReadAndWrite()
        {
            var carColorList = new CarColorList();
            for (byte i = 0; i <= 17; i++)
            {
                var car = carColorList[i];

                car.CockpitFront =
                   car.CockpitSide =
                   car.EngineCover =
                   car.EngineCoverRear =
                   car.EngineCoverSide =
                   car.FrontAndRearWing =
                   car.FrontWingEndplate =
                   car.NoseAngle =
                   car.NoseSide =
                   car.NoseTop =
                   car.RearWingSide =
                   car.Sidepod =
                   car.SidepodTop = i;
            }

            var testableGpExe = new TestableGpExe(GetExampleDataPath("fake.gpexe"));
            var editor = new CarColorEditor(testableGpExe);

        }
    }

    public class TestableGpExe : GpExeEditor
    {
        public TestableGpExe(string exePath) : base(exePath)
        {
        }

        
    }
}
