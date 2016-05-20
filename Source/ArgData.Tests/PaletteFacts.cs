using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    namespace PaletteFacts
    {
        public class SelectingColors
        {
            [Fact]
            public void FirstColorIsBlack()
            {
                Color color = Palette.GetColor(0);

                color.ToArgb().Should().Be(Color.Black.ToArgb());
            }

            [Fact]
            public void LastColorIsLightGrey()
            {
                Color color = Palette.GetColor(255);

                color.R.Should().Be(color.G);
                color.G.Should().Be(color.B);
                color.R.Should().Be(252);
            }
        }

        public class ColorRanges
        {
            [Fact]
            public void WhenBrighterColorIsAvailableNextBrighterColorInRangeIsFound()
            {
                Color color = Palette.GetColor(85);
                int brighterColorIndex = Palette.GetBrighterColor(85);
                Color brighterColor = Palette.GetColor(brighterColorIndex);

                brighterColor.R.Should().BeGreaterOrEqualTo(color.R);
                brighterColor.G.Should().BeGreaterOrEqualTo(color.G);
                brighterColor.B.Should().BeGreaterOrEqualTo(color.B);
            }

            [Fact]
            public void WhenBrighterColorIsNotAvailableThenSameColorIsReturned()
            {
                int brighterColorIndex = Palette.GetBrighterColor(95);

                brighterColorIndex.Should().Be(95);
            }

            [Fact]
            public void WhenDarkerColorIsAvailableNextDarkerColorInRangeIsReturned()
            {
                Color color = Palette.GetColor(84);
                int darkerColorIndex = Palette.GetDarkerColor(84);
                Color darkerColor = Palette.GetColor(darkerColorIndex);

                darkerColor.R.Should().BeLessOrEqualTo(color.R);
                darkerColor.G.Should().BeLessOrEqualTo(color.G);
                darkerColor.B.Should().BeLessOrEqualTo(color.B);
            }

            [Fact]
            public void WhenDarkerColorIsNotAvailableThenSameColorIsReturned()
            {
                int darkerColorIndex = Palette.GetDarkerColor(80);

                darkerColorIndex.Should().Be(80);
            }

            [Fact]
            public void ReverseRangeReturnsExpectedResults()
            {
                int brighterColorIndex = Palette.GetBrighterColor(142);

                brighterColorIndex.Should().Be(141);
            }

            [Fact]
            public void AllColorsShouldBeInSomeColorRange()
            {
                for (int i = 0; i <= 255; i++)
                {
                    List<int> range = Palette.GetRangeForColor(i);

                    range.Should().NotBeNull($"Color {i} not found in range.");
                }
            }
        }
    }
}
