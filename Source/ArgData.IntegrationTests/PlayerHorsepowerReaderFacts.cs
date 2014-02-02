using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ArgData.IntegrationTests
{
    namespace PlayerHorsepowerReaderFacts
    {
        public class ReadingPlayerHorsepower : IntegrationTestBase
        {
            private readonly PlayerHorsepowerReader _reader;

            public ReadingPlayerHorsepower()
            {
                var positions = Substitute.For<DataPositions>();
                positions.PlayerHorsepower.Returns(1182);
                _reader = new PlayerHorsepowerReader(GetExampleDataPath("fake.gpexe"), positions);
            }

            [Fact]
            public void PlayerHorsepowerIs716()
            {
                int hp = _reader.ReadPlayerHorsepower();

                hp.Should().Be(716);
            }
        }
    }
}
