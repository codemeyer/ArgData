using System;
using System.IO;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class HelmetMenuImageFacts
    {
        [Fact]
        public void Read_StandardHelmetFile_ReturnsImages()
        {
            var path = ExampleDataHelper.GetExampleDataPath("HELMETS.DAT", TestDataFileType.Images);
            var helmets = HelmetMenuImagesReader.Read(path);

            helmets.Images.Count.Should().Be(39);
            helmets.Images.Should().OnlyContain(x => x.Pixels.Length == 2304);
        }

        [Fact]
        public void ReadWrite_UsingAbstraction_SameData()
        {
            var path = ExampleDataHelper.GetExampleDataPath("HELMETS.DAT", TestDataFileType.Images);
            var helmets = HelmetMenuImagesReader.Read(path);

            using (var context = ExampleDataContext.GetTempFileName("HELM.DAT"))
            {
                HelmetMenuImagesWriter.Write(context.FilePath, helmets);

                var writtenData = File.ReadAllBytes(context.FilePath);
                var originalData = File.ReadAllBytes(path);

                writtenData.Should().BeEquivalentTo(originalData);
            }
        }

        [Fact]
        public void Read_MissingFile_ThrowsFileNotFoundException()
        {
            var path = ExampleDataHelper.GetExampleDataPath("missing-file.DAT", TestDataFileType.Images);
            
            Action action = () => HelmetMenuImagesReader.Read(path);

            action.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void Read_NonHelmetItemContainerFile_ThrowsArgumentOutOfRangeException()
        {
            var path = ExampleDataHelper.GetExampleDataPath("BACKDROP.DAT", TestDataFileType.Images);

            Action action = () => HelmetMenuImagesReader.Read(path);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Write_WrongLength_ThrowsArgumentOutOfRangeException()
        {
            var helmets = new HelmetMenuImages();
            helmets.Images.Add(new HelmetMenuImage());

            using (var context = ExampleDataContext.GetTempFileName("HELM.DAT"))
            {
                Action action = () => HelmetMenuImagesWriter.Write(context.FilePath, helmets);

                action.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}
