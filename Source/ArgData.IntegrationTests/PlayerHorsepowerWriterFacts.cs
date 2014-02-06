using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    public class PlayerHorsepowerWriterFacts : IntegrationTestBase
    {
        [Fact]
        public void CorrectHorsepowerValueIsWrittenToFile()
        {
            string path = GetTempFile();
            var positions = Substitute.For<DataPositions>();
            positions.PlayerHorsepower.Returns(6);

            var writer = new PlayerHorsepowerWriter(path, positions);
            writer.WritePlayerHorsepower(717);

            var savedValue = ReadUShort(path, positions.PlayerHorsepower);
            savedValue.Should().Be(16406);

            DeleteFile(path);
        }
    }
}
