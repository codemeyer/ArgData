using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class DriverNumberEditorFacts
    {
        [Fact]
        public void ReadingOriginalDriverNumbersReturnsExpectedValues()
        {
            var driverNumberEditor = ExampleDataHelper.DriverNumberEditorForDefault();

            byte[] driverNumbers = driverNumberEditor.ReadDriverNumbers();

            driverNumbers[0].Should().Be(1);
            driverNumbers[12].Should().Be(14, "Grouillard is number 14 in slot 13 (i.e. index 12)");
            driverNumbers[13].Should().Be(0);
            driverNumbers[30].Should().Be(31);
            driverNumbers[31].Should().Be(0, "Coloni only has one driver");
            driverNumbers[32].Should().Be(32);
        }
    }
}
