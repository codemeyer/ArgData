using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities;

public class PitCrewFacts
{
    [Fact]
    public void PitCrew_CreatedWithOtherThan_16_Bytes_ThrowsArgumentOutOfRangeException()
    {
        byte[] tooFewColors = new byte[5];

        Action action = () => _ = new Car(tooFewColors);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Copy_TransfersAllColors()
    {
        var source = new PitCrew
        {
            ShirtPrimary = 11,
            ShirtSecondary = 22,
            PantsPrimary = 33,
            PantsSecondary = 44,
            Socks = 55
        };
        var target = new PitCrew();

        target.Copy(source);

        target.ShirtPrimary.Should().Be(11);
        target.ShirtSecondary.Should().Be(22);
        target.PantsPrimary.Should().Be(33);
        target.PantsSecondary.Should().Be(44);
        target.Socks.Should().Be(55);
    }

    [Fact]
    public void Copy_NullReference_ThrowsArgumentNullException()
    {
        var pitCrew = new PitCrew();

        Action action = () => pitCrew.Copy(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
