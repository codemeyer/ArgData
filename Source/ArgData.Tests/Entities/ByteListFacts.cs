using ArgData.Internals;
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

            byteList.AddInt32(value);

            byteList.Count.Should().Be(4);
        }

        [Fact]
        public void AddShortAddsTwoBytes()
        {
            var byteList = new ByteList();
            short value = 12345;

            byteList.AddInt16(value);

            byteList.Count.Should().Be(2);
        }
    }
}
