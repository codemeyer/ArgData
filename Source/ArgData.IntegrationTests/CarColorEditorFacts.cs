using System;
using ArgData.Entities;
using ArgData.IntegrationTests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class CarColorEditorFacts
    {
        [Fact]
        public void ReadingOriginalCarColorsReturnsExpectedValues()
        {
            var expectedCarColors = new DefaultCarColors();
            string exampleDataPath = ExampleDataHelper.GpExePath();
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            var carColors = carColorEditor.ReadCarColors();

            for (int i = 0; i < 1; i++)
            {
                carColors[i].ShouldBeEquivalentTo(expectedCarColors[i]);
            }
        }

        [Fact]
        public void ReadOne()
        {
            var expectedCar = new DefaultCarColors()[0];
            string exampleDataPath = ExampleDataHelper.GetExampleDataPath("gp-orig.exe");
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            var car = carColorEditor.ReadCarColors(0);

            car.CockpitFront.Should().Be(expectedCar.CockpitFront);
            car.CockpitSide.Should().Be(expectedCar.CockpitSide);
            car.EngineCover.Should().Be(expectedCar.EngineCover);
            car.EngineCoverRear.Should().Be(expectedCar.EngineCoverRear);
            car.EngineCoverSide.Should().Be(expectedCar.EngineCoverSide);
            car.FrontAndRearWing.Should().Be(expectedCar.FrontAndRearWing);
            car.FrontWingEndplate.Should().Be(expectedCar.FrontWingEndplate);
            car.NoseAngle.Should().Be(expectedCar.NoseAngle);
            car.NoseSide.Should().Be(expectedCar.NoseSide);
            car.NoseTop.Should().Be(expectedCar.NoseTop);
            car.RearWingSide.Should().Be(expectedCar.RearWingSide);
            car.Sidepod.Should().Be(expectedCar.Sidepod);
            car.SidepodTop.Should().Be(expectedCar.SidepodTop);
        }

        [Fact]
        public void WriteAndReadCars()
        {
            var carList = new CarList();
            for (int i = 0; i < GpExeEditor.NumberOfTeams; i++)
            {
                byte b = Convert.ToByte(i + 1);
                carList[i] = new Car(new [] { b, b, b, b, b, b, b, b, b, b, b, b, b, b, b, b });
            }

            string exampleDataPath = ExampleDataHelper.GetCopyOfExampleData("gp-orig.exe");
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            carColorEditor.WriteCarColors(carList);

            var readBack = new CarColorEditor(exeEditor).ReadCarColors();

            byte expectedColor = 1;
            foreach (Car car in readBack)
            {
                car.NoseTop.Should().Be(expectedColor);

                expectedColor++;
            }

            ExampleDataHelper.DeleteFile(exampleDataPath);
        }
    }
}
