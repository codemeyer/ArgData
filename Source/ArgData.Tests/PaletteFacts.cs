using System;
using System.Drawing;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests;

public class PaletteFacts
{
    [Fact]
    public void GetColor_DrivingPalette_FirstColorIsBlack()
    {
        var palette = Palette.CreateDrivingPalette();

        var color = palette.GetColor(0);

        color.ToArgb().Should().Be(Color.Black.ToArgb());
    }

    [Fact]
    public void GetColor_DrivingPalette_LastColorIsWhite()
    {
        var palette = Palette.CreateDrivingPalette();

        var color = palette.GetColor(255);

        color.ToArgb().Should().Be(Color.White.ToArgb());
    }

    [Fact]
    public void ColorRange_BrighterColorIsAvailable_ReturnBrighterColorInRange()
    {
        var palette = Palette.CreateDrivingPalette();

        Color color = palette.GetColor(85);
        byte brighterColorIndex = palette.GetBrighterColor((byte)85);
        Color brighterColor = palette.GetColor(brighterColorIndex);

        brighterColor.R.Should().BeGreaterOrEqualTo(color.R);
        brighterColor.G.Should().BeGreaterOrEqualTo(color.G);
        brighterColor.B.Should().BeGreaterOrEqualTo(color.B);
    }

    [Fact]
    public void ColorRange_BrighterColorIsNotAvailable_ReturnsSameColor()
    {
        var palette = Palette.CreateDrivingPalette();

        byte brighterColorIndex = palette.GetBrighterColor(95);

        brighterColorIndex.Should().Be(95);
    }

    [Fact]
    public void ColorRange_DarkerColorIsAvailable_ReturnsNextDarkerColorInRange()
    {
        var palette = Palette.CreateDrivingPalette();

        Color color = palette.GetColor(84);
        byte darkerColorIndex = palette.GetDarkerColor((byte)84);
        Color darkerColor = palette.GetColor(darkerColorIndex);

        darkerColor.R.Should().BeLessOrEqualTo(color.R);
        darkerColor.G.Should().BeLessOrEqualTo(color.G);
        darkerColor.B.Should().BeLessOrEqualTo(color.B);
    }

    [Fact]
    public void GetDarkerColor_DarkerColorIsNotAvailable_ReturnsSameColor()
    {
        var palette = Palette.CreateDrivingPalette();

        byte darkerColorIndex = palette.GetDarkerColor(80);

        darkerColorIndex.Should().Be(80);
    }

    [Fact]
    public void GetBrighterColor_ReverseRange_ReturnsExpectedResults()
    {
        var palette = Palette.CreateDrivingPalette();

        byte brighterColorIndex = palette.GetBrighterColor(142);

        brighterColorIndex.Should().Be(141);
    }

    [Fact]
    public void GetRangeForColor_AllColorsShouldBeInSomeColorRange()
    {
        var palette = Palette.CreateDrivingPalette();

        for (int i = 0; i <= 255; i++)
        {
            ReadOnlyList<byte> range = palette.GetRangeForColor((byte)i);

            range.Should().NotBeNull($"Color {i} not found in range.");
        }
    }

    [Fact]
    public void GetColor_MenuPalette_FirstColorIsBlack()
    {
        var palette = Palette.CreateMenuPalette();

        var color = palette.GetColor(0);

        color.ToArgb().Should().Be(Color.Black.ToArgb());
    }

    [Fact]
    public void GetColor_MenuPalette_LastColorIsCrazyPink()
    {
        var palette = Palette.CreateMenuPalette();

        var color = palette.GetColor(255);

        color.R.Should().Be(255);
        color.G.Should().Be(41);
        color.B.Should().Be(255);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(256)]
    public void GetColorInt_IndexNotValid_ThrowsArgumentOutOfRangeException(int index)
    {
        var palette = Palette.CreateDrivingPalette();

        Action action = () => palette.GetColor(index);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(256)]
    public void GetBrighterColorInt_IndexNotValid_ThrowsArgumentOutOfRangeException(int index)
    {
        var palette = Palette.CreateDrivingPalette();

        Action action = () => palette.GetBrighterColor(index);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(256)]
    public void GetDarkerColorInt_IndexNotValid_ThrowsArgumentOutOfRangeException(int index)
    {
        var palette = Palette.CreateDrivingPalette();

        Action action = () => palette.GetDarkerColor(index);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
