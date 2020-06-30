using System.IO;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackWriterFacts
    {
        [Fact]
        public void ReadAndWrite_01_Phoenix_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT01.DAT");
        }

        [Fact]
        public void ReadAndWrite_02_Interlagos_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT02.DAT");
        }

        [Fact]
        public void ReadAndWrite_03_Imola_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT03.DAT");
        }

        [Fact]
        public void ReadAndWrite_04_Monaco_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT04.DAT");
        }

        [Fact]
        public void ReadAndWrite_05_Montreal_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT05.DAT");
        }

        [Fact]
        public void ReadAndWrite_06_Mexico_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT06.DAT");
        }

        [Fact]
        public void ReadAndWrite_07_MagnyCours_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT07.DAT");
        }

        [Fact]
        public void ReadAndWrite_08_Silverstone_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT08.DAT");
        }

        [Fact]
        public void ReadAndWrite_09_Hockenheim_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT09.DAT");
        }

        [Fact]
        public void ReadAndWrite_10_Hungaroring_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT10.DAT");
        }

        [Fact]
        public void ReadAndWrite_11_Spa_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT11.DAT");
        }

        [Fact]
        public void ReadAndWrite_12_Monza_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT12.DAT");
        }

        [Fact]
        public void ReadAndWrite_13_Estoril_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT13.DAT");
        }

        [Fact]
        public void ReadAndWrite_14_Barcelona_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT14.DAT");
        }

        [Fact]
        public void ReadAndWrite_15_Suzuka_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT15.DAT");
        }

        [Fact]
        public void ReadAndWrite_16_Adelaide_GeneratesIdenticalFiles()
        {
            ReadAndWrite("F1CT16.DAT");
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

                originalBytes.Length.Should().Be(createdBytes.Length);

                for (int i = 0; i < originalBytes.Length; i++)
                {
                    byte o = originalBytes[i];
                    byte n = createdBytes[i];

                    o.Should().Be(n, $"because data at index {i} should match");
                }
            }
        }

        [Fact]
        public void RemoveTrackSectionCommandFromExistingTrackMakesFileSmaller()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;
                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
                File.Copy(sourcePath, targetPath);

                var lengthBefore = new FileInfo(sourcePath).Length;

                // remove track section command
                var track = new TrackReader().Read(targetPath);
                track.TrackSections[71].Commands.RemoveAt(1);
                new TrackWriter().Write(track, targetPath);

                var lengthAfterRemoval = new FileInfo(targetPath).Length;

                lengthBefore.Should().Be(20497);
                lengthAfterRemoval.Should().Be(20493);
            }
        }
    }
}
