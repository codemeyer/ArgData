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

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Copy_TransfersAllColors()
        {
            var source = new Helmet
            {
                Visor = 77,
                VisorSurround = 88
            };
            source.Stripes[0] = 11;
            source.Stripes[12] = 12;

            var target = new Helmet();

            target.Copy(source);

            target.Visor.Should().Be(77);
            target.VisorSurround.Should().Be(88);
            target.Stripes[0].Should().Be(11);
            target.Stripes[12].Should().Be(12);
        }

        [Fact]
        public void Copy_NullSourceThrowsArgumentNullException()
        {
            var helmet = new Helmet();

            Action action = () => helmet.Copy(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
