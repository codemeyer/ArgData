using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class TrackSectionCommandFacts
    {
        [Fact]
        public void Create_CreatingCommand_ReturnsExpectedArgumentCount()
        {
            var command = TrackSectionCommand.Create(0x80);

            command.Arguments.Length.Should().Be(2);
        }

        [Theory]
        [InlineData(127)]
        [InlineData(173)]
        public void Create_CommandOutOfRange_ThrowsArgumentOutOfRangeException(byte commandOutOfRange)
        {
            Action action = () => TrackSectionCommand.Create(commandOutOfRange);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
