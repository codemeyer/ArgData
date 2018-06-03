using ArgData.Entities;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class ImageItem1774Facts
    {
        [Fact]
        public void GetPixelData_HelmetFileFromHE_HasExpectedPixels()
        {
            var path = ExampleDataHelper.GetExampleDataPath("HELMETHE.DAT", TestDataFileType.Images);
            var images = new MediaContainerFileReader().Read(path);

            var item = images.Items[1] as ImageItem1774;
            var pixelData = item.GetPixelData();
            pixelData[192].Should().Be(0);
            pixelData[193].Should().Be(32);
        }

        [Fact]
        public void SetPixelData_AllBlueHelmet_ProducesExpectedPixels()
        {
            var images = Read("HELMETHE.DAT");
            var bytes = new byte[2304];
            for (int i = 0; i < 2304; i++)
            {
                bytes[i] = 0xDC;
            }

            var blueHelmet = images.Items[3] as ImageItem1774;

            var expectedData = blueHelmet.Data;
            blueHelmet.Data = new byte[1];
            blueHelmet.SetPixelData(bytes);

            var actualData = blueHelmet.Data;

            actualData.Should().BeEquivalentTo(expectedData);
        }

        [Fact]
        public void SetPixelData_SennaHelmet_ProducesExpectedPixels()
        {
            var images = Read("HELMETS.DAT");
            var sennaHelmet = images.Items[0] as ImageItem1774;
            var pixelPath = ExampleDataHelper.GetExampleDataPath("SENNA.PIX", TestDataFileType.Images);
            var pixels = File.ReadAllBytes(pixelPath);

            var expectedData = sennaHelmet.Data;
            sennaHelmet.Data = new byte[expectedData.Length];
            sennaHelmet.SetPixelData(pixels);
            var actualData = sennaHelmet.Data;

            actualData.Should().BeEquivalentTo(expectedData);
        }

        private MediaContainerFile Read(string fileName)
        {
            var path = ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Images);
            var images = new MediaContainerFileReader().Read(path);

            return images;
        }
    }
}
