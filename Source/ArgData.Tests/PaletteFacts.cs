using System;
using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class PaletteFacts
    {
        [Fact]
        public void SelectColor_FirstColorIsBlack()
        {
            Color color = Palette.GetColor(0);

            color.ToArgb().Should().Be(Color.Black.ToArgb());
        }

        [Fact]
        public void SelectColor_LastColorIsLightGrey()
        {
            Color color = Palette.GetColor(255);

            color.R.Should().Be(color.G);
            color.G.Should().Be(color.B);
            color.R.Should().Be(252);
        }

        [Fact]
        public void ColorRange_BrighterColorIsAvailable_ReturnBrighterColorInRange()
        {
            Color color = Palette.GetColor(85);
            int brighterColorIndex = Palette.GetBrighterColor(85);
            Color brighterColor = Palette.GetColor(brighterColorIndex);

            brighterColor.R.Should().BeGreaterOrEqualTo(color.R);
            brighterColor.G.Should().BeGreaterOrEqualTo(color.G);
            brighterColor.B.Should().BeGreaterOrEqualTo(color.B);
        }

        // !
        [Fact]
        public void ColorRange_BrighterColorIsNotAvailable_ReturnsSameColor()
        {
            int brighterColorIndex = Palette.GetBrighterColor(95);

            brighterColorIndex.Should().Be(95);
        }

        [Fact]
        public void ColorRange_DarkerColorIsAvailable_ReturnsNextDarkerColorInRange()
        {
            Color color = Palette.GetColor(84);
            int darkerColorIndex = Palette.GetDarkerColor(84);
            Color darkerColor = Palette.GetColor(darkerColorIndex);

            darkerColor.R.Should().BeLessOrEqualTo(color.R);
            darkerColor.G.Should().BeLessOrEqualTo(color.G);
            darkerColor.B.Should().BeLessOrEqualTo(color.B);
        }

        [Fact]
        public void GetDarkerColor_DarkerColorIsNotAvailable_ReturnsSameColor()
        {
            int darkerColorIndex = Palette.GetDarkerColor(80);

            darkerColorIndex.Should().Be(80);
        }

        [Fact]
        public void GetBrighterColor_ReverseRange_ReturnsExpectedResults()
        {
            int brighterColorIndex = Palette.GetBrighterColor(142);

            brighterColorIndex.Should().Be(141);
        }

        [Fact]
        public void GetRangeForColor_AllColorsShouldBeInSomeColorRange()
        {
            for (int i = 0; i <= 255; i++)
            {
                IList<int> range = Palette.GetRangeForColor(i);

                range.Should().NotBeNull($"Color {i} not found in range.");
            }
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        public void GetColor_OutOfRange_ThrowsException(int index)
        {
            Action action = () => Palette.GetColor(index);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        public void GetDarkerColor_OutOfRange_ThrowsException(int index)
        {
            Action action = () => Palette.GetDarkerColor(index);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        public void GetBrighterColor_OutOfRange_ThrowsException(int index)
        {
            Action action = () => Palette.GetBrighterColor(index);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
