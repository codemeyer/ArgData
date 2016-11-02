using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class PitCrewFacts
    {
        [Fact]
        public void PitCrew_CreatedWithOtherThan_16_Bytes_ThrowsArgumentOutOfRangeException()
        {
            byte[] tooFewColors = new byte[5];

            Action action = () => new Car(tooFewColors);

            action.ShouldThrow<ArgumentOutOfRangeException>();

        }
    }
}
