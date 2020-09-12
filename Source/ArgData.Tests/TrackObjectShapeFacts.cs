using System.IO;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackObjectShapeFacts
    {
        [Fact]
        public void Removing_and_Adding_ScaleValue_Creates_Identical_Files()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;
                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
                File.Copy(sourcePath, targetPath);

                // remove scale value
                var track = new TrackReader().Read(targetPath);
                var obj = track.ObjectShapes[7];

                obj.ScaleValues.Count.Should().Be(7);
                short value = obj.ScaleValues[3];

                obj.ScaleValues.RemoveAt(3);

                obj.ScaleValues.Count.Should().Be(6);

                obj.ScaleValues.Insert(3, value);

                new TrackWriter().Write(track, targetPath);

                var originalBytes = File.ReadAllBytes(sourcePath);
                var createdBytes = File.ReadAllBytes(targetPath);

                originalBytes.Length.Should().Be(createdBytes.Length);

                DiffByteArrays(originalBytes, createdBytes);
            }
        }

        [Fact]
        public void Removing_and_Adding_ScalePoint_Creates_Identical_Files()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;
                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
                File.Copy(sourcePath, targetPath);

                // remove scale point
                var track = new TrackReader().Read(targetPath);
                var obj = track.ObjectShapes[7];

                obj.Points.Count.Should().Be(24);

                var refOrig = obj.Points[0] as TrackObjectShapeScalePoint;

                obj.Points.RemoveAt(0);

                var newPoint = new TrackObjectShapeScalePoint(obj)
                {
                    XScaleValueIndex = refOrig.XScaleValueIndex,
                    XIsNegative = refOrig.XIsNegative,
                    YScaleValueIndex = refOrig.YScaleValueIndex,
                    YIsNegative = refOrig.YIsNegative,
                    Z = refOrig.Z
                };

                obj.Points.Insert(0, newPoint);

                var originalBytes = File.ReadAllBytes(sourcePath);
                var createdBytes = File.ReadAllBytes(targetPath);

                DiffByteArrays(originalBytes, createdBytes);
            }
        }

        [Fact]
        public void Removing_and_Adding_ReferencePoint_Creates_Identical_Files()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;
                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
                File.Copy(sourcePath, targetPath);

                // remove reference point
                var track = new TrackReader().Read(targetPath);
                var obj = track.ObjectShapes[7];

                obj.Points.Count.Should().Be(24);

                var refOrig = obj.Points[11] as TrackObjectShapeReferencePoint;

                obj.Points.RemoveAt(11);

                var newPoint = new TrackObjectShapeReferencePoint(obj)
                {
                    PointIndex = refOrig.PointIndex,
                    Z = refOrig.Z
                };

                obj.Points.Insert(11, newPoint);

                var originalBytes = File.ReadAllBytes(sourcePath);
                var createdBytes = File.ReadAllBytes(targetPath);

                DiffByteArrays(originalBytes, createdBytes);
            }
        }

        private void DiffByteArrays(byte[] original, byte[] updated)
        {
            original.Length.Should().Be(updated.Length);

            for (int i = 0; i < original.Length; i++)
            {
                byte o = original[i];
                byte n = updated[i];

                o.Should().Be(n, $"because data at index {i} should match");
            }
        }
    }
}
