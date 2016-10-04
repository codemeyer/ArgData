using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class HelmetFacts
    {
        [Fact]
        public void Helmet_CreatedWithOtherThan_14_or_16_Bytes_ThrowsArgumentOutOfRangeException()
        {
            byte[] tooFewColors = new byte[5];

            Action action = () => new Helmet(tooFewColors);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
