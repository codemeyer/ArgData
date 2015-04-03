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

            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            var exeEditor = new GpExeEditor(exampleDataPath);
            var carColorEditor = new CarColorEditor(exeEditor);

            carColorEditor.WriteCarColors(carList);

            var carColors = new CarColorEditor(exeEditor).ReadCarColors();

            byte expectedColor = 1;
            foreach (Car car in carColors)
            {
                car.NoseTop.Should().Be(expectedColor);

                expectedColor++;
            }

            ExampleDataHelper.DeleteFile(exampleDataPath);
        }

        [Fact]
        public void WriteAndReadCar()
        {
            var carList = new CarList();
            string exampleDataPath = ExampleDataHelper.CopyOfGpExePath();
            var exeEditor = new GpExeEditor(exampleDataPath);
            var car = new Car
            {
                CockpitFront = 1,
                CockpitSide = 2,
                EngineCover = 3,
                EngineCoverRear = 4,
                EngineCoverSide = 5,
                FrontAndRearWing = 6,
                FrontWingEndplate = 7,
                NoseAngle = 8,
                NoseSide = 9,
                NoseTop = 10,
                RearWingSide = 11,
                Sidepod = 12,
                SidepodTop = 13
            };
            carList[0] = car;

            var carColorEditor = new CarColorEditor(exeEditor);

            carColorEditor.WriteCarColors(carList);

            var carColors = new CarColorEditor(exeEditor).ReadCarColors();
            var actualCar = carColors[0];

            actualCar.CockpitFront.Should().Be(1);
            actualCar.CockpitSide.Should().Be(2);
            actualCar.EngineCover.Should().Be(3);
            actualCar.EngineCoverRear.Should().Be(4);
            actualCar.EngineCoverSide.Should().Be(5);
            actualCar.FrontAndRearWing.Should().Be(6);
            actualCar.FrontWingEndplate.Should().Be(7);
            actualCar.NoseAngle.Should().Be(8);
            actualCar.NoseSide.Should().Be(9);
            actualCar.NoseTop.Should().Be(10);
            actualCar.RearWingSide.Should().Be(11);
            actualCar.Sidepod.Should().Be(12);
            actualCar.SidepodTop.Should().Be(13);

            ExampleDataHelper.DeleteFile(exampleDataPath);
        }
    }
}
