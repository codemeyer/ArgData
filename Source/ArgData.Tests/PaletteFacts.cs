using System.Drawing;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PaletteFacts
    {
        [Fact]
        public void GetColor_FirstColorIsBlack()
        {
            Color color = Palette.GetColor(0);

            color.ToArgb().Should().Be(Color.Black.ToArgb());
        }

        [Fact]
        public void GetColor_LastColorIsWhite()
        {
            Color color = Palette.GetColor(255);

            color.ToArgb().Should().Be(Color.White.ToArgb());
        }

        [Fact]
        public void ColorRange_BrighterColorIsAvailable_ReturnBrighterColorInRange()
        {
            Color color = Palette.GetColor(85);
            byte brighterColorIndex = Palette.GetBrighterColor(85);
            Color brighterColor = Palette.GetColor(brighterColorIndex);

            brighterColor.R.Should().BeGreaterOrEqualTo(color.R);
            brighterColor.G.Should().BeGreaterOrEqualTo(color.G);
            brighterColor.B.Should().BeGreaterOrEqualTo(color.B);
        }

        [Fact]
        public void ColorRange_BrighterColorIsNotAvailable_ReturnsSameColor()
        {
            byte brighterColorIndex = Palette.GetBrighterColor(95);

            brighterColorIndex.Should().Be(95);
        }

        [Fact]
        public void ColorRange_DarkerColorIsAvailable_ReturnsNextDarkerColorInRange()
        {
            Color color = Palette.GetColor(84);
            byte darkerColorIndex = Palette.GetDarkerColor(84);
            Color darkerColor = Palette.GetColor(darkerColorIndex);

            darkerColor.R.Should().BeLessOrEqualTo(color.R);
            darkerColor.G.Should().BeLessOrEqualTo(color.G);
            darkerColor.B.Should().BeLessOrEqualTo(color.B);
        }

        [Fact]
        public void GetDarkerColor_DarkerColorIsNotAvailable_ReturnsSameColor()
        {
            byte darkerColorIndex = Palette.GetDarkerColor(80);

            darkerColorIndex.Should().Be(80);
        }

        [Fact]
        public void GetBrighterColor_ReverseRange_ReturnsExpectedResults()
        {
            byte brighterColorIndex = Palette.GetBrighterColor(142);

            brighterColorIndex.Should().Be(141);
        }

        [Fact]
        public void GetRangeForColor_AllColorsShouldBeInSomeColorRange()
        {
            for (int i = 0; i <= 255; i++)
            {
                ReadOnlyList<byte> range = Palette.GetRangeForColor((byte)i);

                range.Should().NotBeNull($"Color {i} not found in range.");
            }
        }
    }
}
