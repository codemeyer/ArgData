using System;
using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class MediaContainerFileFacts
    {
        [Theory]
        [InlineData("HELMETS.DAT")]
        [InlineData("HELMET95.DAT")]
        [InlineData("HELMETHE.DAT")]
        public void Read_HelmetFile_AllHelmetsAre48x48(string fileName)
        {
            var path = ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Images);
            var images = new TestableMediaContainerFileReader().Read(path);

            images.Items.Should().OnlyContain(x => x.Width == 48);
            images.Items.Should().OnlyContain(x => x.Height == 48);
        }

        [Theory]
        [InlineData("HELMETS.DAT")]
        [InlineData("HELMET95.DAT")]
        [InlineData("HELMETHE.DAT")]
        public void Read_HelmetFileGetPixelData_PixelDataIsAlways2304(string fileName)
        {
            var path = ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Images);
            var images = new TestableMediaContainerFileReader().Read(path);

            foreach (var item in images.Items)
            {
                var pixelData = (item as ImageItem1774).GetPixelData();

                pixelData.Length.Should().Be(2304);
            }
        }

        [Fact]
        public void Read_HelmetDefault_AllImagesAreCorrect()
        {
            var container = Read("HELMETS.DAT");

            container.Items.Count.Should().Be(39);
            container.Items.Should().AllBeOfType<ImageItem1774>();
        }

        [Fact]
        public void Read_Helmet95_AllImagesAreCorrect()
        {
            var container = Read("HELMET95.DAT");

            container.Items.Count.Should().Be(40);
            container.Items.Should().AllBeOfType<ImageItem1774>();
        }

        [Fact]
        public void Read_HelmetFileFromHE_Contains40Images()
        {
            var container = Read("HELMETHE.DAT");

            container.Items.Count.Should().Be(40);
            container.Items.Should().AllBeOfType<ImageItem1774>();
        }

        [Fact]
        public void Read_TrackPix_Contains17ImagesAnd17Palettes()
        {
            var container = Read("TRACKPIX.DAT");

            container.Items.Count.Should().Be(34);
            container.Items.Count(i => i.Type == 1769).Should().Be(17);
            container.Items.Where(i => i.Type == 1769).Should().AllBeOfType<ImageItem1769>();
            container.Items.Count(i => i.Type == 1776).Should().Be(17);
            container.Items.Where(i => i.Type == 1776).Should().AllBeOfType<PaletteItem>();
        }

        [Fact]
        public void Read_Backdrop_Contains18ImagesAnd18Palettes()
        {
            var container = Read("BACKDROP.DAT");

            container.Items.Count.Should().Be(36);
            container.Items.Count(i => i.Type == 1769).Should().Be(18);
            container.Items.Where(i => i.Type == 1769).Should().AllBeOfType<ImageItem1769>();
            container.Items.Count(i => i.Type == 1776).Should().Be(18);
            container.Items.Where(i => i.Type == 1776).Should().AllBeOfType<PaletteItem>();
        }

        [Fact]
        public void Read_TrophyFile_ContainsOnePaletteAndOne1769ImageAndTheRestIs1768()
        {
            var container = Read("TROPHY.DAT");

            container.Items.Count.Should().Be(17);
            container.Items.Count(i => i.Type == 1776).Should().Be(1);
            container.Items.Count(i => i.Type == 1769).Should().Be(1);
            container.Items.Count(i => i.Type == 1768).Should().Be(15);
        }

        private MediaContainerFile Read(string fileName)
        {
            var path = ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Images);
            var images = new TestableMediaContainerFileReader().Read(path);

            return images;
        }

        [Fact]
        public void SetPixel_IncorrectAmount_ThrowsArgumentOutOfRangeException()
        {
            var item = new ImageItem1774
            {
                Width = 4,
                Height = 2
            };
            var wrongNumberOfBytes = new byte[7]; // should be 8 (4*2)

            Action action = () => item.SetPixelData(wrongNumberOfBytes);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Read_FileThatDoesNotExist_ThrowsFileNotFoundException()
        {
            string nonExistingFile =
                ExampleDataHelper.GetExampleDataPath("does-not-exist.DAT", TestDataFileType.Images);

            Action action = () => new MediaContainerFileReader().Read(nonExistingFile);

            action.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void Read_FileThatIsNotContainer_ThrowsException()
        {
            string wrongFileType = ExampleDataHelper.GetExampleDataPath("names1991.nam", TestDataFileType.Names);

            Action action = () => new MediaContainerFileReader().Read(wrongFileType);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("HELMETS.DAT")]
        [InlineData("HELMET95.DAT")]
        public void Write_ReadWrite_ProducesSameData(string fileName)
        {
            var container = Read(fileName);

            using (var context = ExampleDataContext.GetTempFileName("HELM.DAT"))
            {
                new MediaContainerFileWriter().Write(context.FilePath, container);

                var expectedBytes = File.ReadAllBytes(ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Images));
                var actualBytes = File.ReadAllBytes(context.FilePath);

                actualBytes.Should().BeEquivalentTo(expectedBytes);
            }
        }

        [Fact]
        public void Write_SameImageEverywhere_ShouldBeSameDataAndLengthEverywhereInCreatedFile()
        {
            var container = Read("BACKDROP.DAT");
            var paletteItem = container.Items[0];
            var imageItem = container.Items[1];

            using (var context = ExampleDataContext.GetTempFileName("BACKDROP2.DAT"))
            {
                for (int i = 2; i < container.Items.Count; i += 2)
                {
                    container.Items[i].Data = paletteItem.Data;
                    container.Items[i + 1].Data = imageItem.Data;
                }

                new MediaContainerFileWriter().Write(context.FilePath, container);

                var newContainer = new TestableMediaContainerFileReader().Read(context.FilePath);

                newContainer.Items.Count.Should().Be(36);
                newContainer.Items.Count(i => i.Type == 1769).Should().Be(18);
                newContainer.Items.Where(i => i.Type == 1769).Should().AllBeOfType<ImageItem1769>();
                foreach (var item in newContainer.Items.Where(i => i.Type == 1769))
                {
                    item.Length.Should().Be(imageItem.Length);
                }
                newContainer.Items.Count(i => i.Type == 1776).Should().Be(18);
                newContainer.Items.Where(i => i.Type == 1776).Should().AllBeOfType<PaletteItem>();
            }
        }
    }
}
