using System.Drawing;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class MenuPaletteFacts
    {
        [Fact]
        public void GetColor_FirstColorIsBlack()
        {
            var color = MenuPalette.GetColor(0);

            color.ToArgb().Should().Be(Color.Black.ToArgb());
        }

        [Fact]
        public void SelectColor_LastColorIsCrazyPink()
        {
            var color = MenuPalette.GetColor(255);

            color.R.Should().Be(255);
            color.G.Should().Be(41);
            color.B.Should().Be(255);
        }
    }
}
