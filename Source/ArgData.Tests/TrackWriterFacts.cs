using System.IO;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackWriterFacts
    {
        [Fact]
        public void ReadAndWrite_Phoenix_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT01.DAT");
        }

        [Fact]
        public void ReadAndWrite_Montreal_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT05.DAT");
        }

        [Fact]
        public void ReadAndWrite_Mexico_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT06.DAT");
        }

        private void ReadAndWrite(string fileName)
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;

                var sourcePath = ExampleDataHelper.GetExampleDataPath(fileName, TestDataFileType.Tracks);
                var track = new TrackReader().Read(sourcePath);

                new TrackWriter().Write(track, targetPath);

                var originalBytes = File.ReadAllBytes(sourcePath);
                var createdBytes = File.ReadAllBytes(targetPath);

                originalBytes.Should().StartWith(createdBytes);
            }
        }
    }
}
