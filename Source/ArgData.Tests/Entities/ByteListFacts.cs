using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class ByteListFacts
    {
        [Fact]
        public void AddIntAddsFourBytes()
        {
            var byteList = new ByteList();
            int value = 1234567890;

            byteList.Add(value);

            byteList.Count.Should().Be(4);
        }

        [Fact]
        public void AddShortAddsTwoBytes()
        {
            var byteList = new ByteList();
            short value = 12345;

            byteList.Add(value);

            byteList.Count.Should().Be(2);
        }
    }
}
