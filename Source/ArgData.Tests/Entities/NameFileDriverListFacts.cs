using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class NameFileDriverListFacts
    {
        [Fact]
        public void NewListHas40Drivers()
        {
            var driverList = new NameFileDriverList();

            driverList.Count.Should().Be(40);
        }

        [Fact]
        public void IndexerReturnsExpectedDriver()
        {
            var driverList = new NameFileDriverList();

            var driver = driverList[11];

            driver.Name.Should().Be("Driver 12");
        }
    }
}
