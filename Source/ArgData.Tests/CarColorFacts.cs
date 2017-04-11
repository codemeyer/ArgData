using System;
using ArgData.Entities;
using ArgData.Tests.DefaultData;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class CarColorFacts
    {
        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadCarColors_OriginalCarColors_ReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var carColorReader = CarColorReader.For(GpExeFile.At(exampleDataPath));

            var carColors = carColorReader.ReadCarColors();

            for (int i = 0; i < 1; i++)
            {
                carColors[i].ShouldBeEquivalentTo(DefaultCarColors.GetByIndex(i));
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadCarColors_SingleOriginalCarColor_ReturnsExpectedValues(GpExeVersionInfo exeVersionInfo)
        {
            var expectedCar = DefaultCarColors.GetByIndex(0);
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var carColorReader = CarColorReader.For(GpExeFile.At(exampleDataPath));

            var car = carColorReader.ReadCarColors(0);

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

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_KnownColors_ReadReturnsKnownColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carList = new CarList();
                for (int i = 0; i < Constants.NumberOfSupportedTeams; i++)
                {
                    byte b = Convert.ToByte(i + 1);
                    carList[i] = new Car(new[] {b, b, b, b, b, b, b, b, b, b, b, b, b, b, b, b});
                }

                var carColorWriter = CarColorWriter.For(context.ExeFile);

                carColorWriter.WriteCarColors(carList);

                var carColorReader = CarColorReader.For(context.ExeFile).ReadCarColors();

                byte expectedColor = 1;
                foreach (Car car in carColorReader)
                {
                    car.NoseTop.Should().Be(expectedColor);

                    expectedColor++;
                }
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_WriteSingleKnownCarColors_ReadSingleReturnsKnownColors(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carList = new CarList();
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

                var carColorWriter = CarColorWriter.For(context.ExeFile);

                carColorWriter.WriteCarColors(carList[0], 0);

                var carColorReader = CarColorReader.For(context.ExeFile).ReadCarColors();
                var actualCar = carColorReader[0];

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
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadCarColors_IndexLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var carColorReader = CarColorReader.For(GpExeFile.At(exampleDataPath));

            Action action = () => carColorReader.ReadCarColors(-1);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void ReadCarColors_IndexGreaterThan_17_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            string exampleDataPath = ExampleDataHelper.GpExePath(exeVersionInfo);
            var carColorReader = CarColorReader.For(GpExeFile.At(exampleDataPath));

            Action action = () => carColorReader.ReadCarColors(18);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_IndexLessThan_0_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carColorWriter = CarColorWriter.For(context.ExeFile);

                Action action = () => carColorWriter.WriteCarColors(new Car(), -1);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_IndexGreaterThan_17_ThrowsArgumentOutOfRangeException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carColorWriter = CarColorWriter.For(context.ExeFile);

                Action action = () => carColorWriter.WriteCarColors(new Car(), 18);

                action.ShouldThrow<ArgumentOutOfRangeException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_SingleCarNull_ThrowsArgumentNullException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carColorWriter = CarColorWriter.For(context.ExeFile);

                Action action = () => carColorWriter.WriteCarColors(null, 4);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Theory]
        [InlineData(GpExeVersionInfo.European105)]
        [InlineData(GpExeVersionInfo.European105Decompressed)]
        [InlineData(GpExeVersionInfo.Us105)]
        [InlineData(GpExeVersionInfo.Us105Decompressed)]
        public void WriteCarColors_CarListNull_ThrowsArgumentNullException(GpExeVersionInfo exeVersionInfo)
        {
            using (var context = ExampleDataContext.ExeCopy(exeVersionInfo))
            {
                var carColorWriter = CarColorWriter.For(context.ExeFile);

                Action action = () => carColorWriter.WriteCarColors(null);

                action.ShouldThrow<ArgumentNullException>();
            }
        }

        [Fact]
        public void CreateReaderFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => CarColorReader.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CreateWriterFor_NullGpExe_ThrowsArgumentNullException()
        {
            Action action = () => CarColorWriter.For(null);

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
