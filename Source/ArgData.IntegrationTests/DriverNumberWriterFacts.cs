using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace DriverNumberWriterFacts
    {
        public class WritingDriverNumbers : IntegrationTestBase
        {
            private readonly byte[] _driverNumbers;
            private readonly string _path;
            private readonly DataPositions _positions;

            public WritingDriverNumbers()
            {
                _path = GetTempFile();
                _positions = Substitute.For<DataPositions>();
                _positions.DriverNumbers.Returns(6);

                _driverNumbers = new byte[] { 1, 2, 0, 4 };
            }

            [Fact]
            public void FirstDriverNumberWrittenToFile()
            {
                var writer = new DriverNumberWriter(_path, _positions);
                writer.WriteDriverNumbers(_driverNumbers);

                var savedValue = ReadByte(_path, _positions.DriverNumbers);
                savedValue.Should().Be(1);
            }

            [Fact]
            public void LastDriverNumberWrittenToFile()
            {
                var writer = new DriverNumberWriter(_path, _positions);
                writer.WriteDriverNumbers(_driverNumbers);

                var savedValue = ReadByte(_path, _positions.DriverNumbers + 3);
                savedValue.Should().Be(4);
            }

            [Fact]
            public void DisabledDriverNumberWrittenToFile()
            {
                var writer = new DriverNumberWriter(_path, _positions);
                writer.WriteDriverNumbers(_driverNumbers);

                var savedValue = ReadByte(_path, _positions.DriverNumbers + 2);
                savedValue.Should().Be(0);
            }
        }
    }
}
