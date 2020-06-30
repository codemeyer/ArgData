using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ObjectShapesReaderFacts
    {
        [Fact]
        public void PhoenixContains35ObjectShapes()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                objects.Count.Should().Be(35);
                objects.First().DataLength.Should().Be(141);
            }
        }

        [Fact]
        public void PhoenixHasCorrectLengthOfObjectShapes()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var expected = trackData.KnownOffsets.ObjectData - (4112 + 140);

                objects.Sum(o => o.DataLength).Should().Be(expected);
            }
        }

        [Fact]
        public void PhoenixObject2HasOffsetsAndData()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var shapeData = objects[2];

                shapeData.ScaleValueOffset.Should().Be(4559);
                shapeData.Offset2.Should().Be(4563);
                shapeData.PointDataOffset.Should().Be(4592);
                shapeData.VectorDataOffset.Should().Be(4656);
                shapeData.Offset5.Should().Be(4682);

                shapeData.HeaderValue1.Should().Be(30000);
                shapeData.HeaderValue2.Should().Be(5621);
                shapeData.HeaderValue3.Should().Be(5621);
                shapeData.HeaderValue4.Should().Be(5621);
                shapeData.HeaderValue5.Should().BeEquivalentTo(
                    new byte[] { 0xF5, 0x15, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x7F, 0x00, 0xE0, 0x0D, 0x00 });
                shapeData.HeaderValue6.Should().BeEquivalentTo(
                    new byte[] { 0xF5, 0x15 });

                shapeData.ScaleValues.Count.Should().Be(2);
                shapeData.ScaleValues[0].Should().Be(3840);
                shapeData.ScaleValues[1].Should().Be(6144);

                shapeData.OffsetData2.Length.Should().Be(29);
                shapeData.OffsetData2.Should().StartWith(new byte[] { 0x02, 0x00, 0x01, 0x06 });
                shapeData.OffsetData2.Should().EndWith(new byte[] { 0x09, 0xF4, 0xFA, 0x00 });

                shapeData.RawPoints.Count.Should().Be(8);
                shapeData.RawPoints[0].XCoord.Should().Be(0);
                shapeData.RawPoints[7].ZCoord.Should().Be(3840);

                shapeData.Vectors.Count.Should().Be(13);
                shapeData.Vectors[0].From.Should().Be(0);
                shapeData.Vectors[0].To.Should().Be(0);
                shapeData.Vectors[1].From.Should().Be(0);
                shapeData.Vectors[1].To.Should().Be(1);
                shapeData.Vectors[11].From.Should().Be(2);
                shapeData.Vectors[11].To.Should().Be(6);
                shapeData.Vectors[12].From.Should().Be(3);
                shapeData.Vectors[12].To.Should().Be(7);

                shapeData.OffsetData5.Length.Should().Be(24);
                shapeData.OffsetData5.Should().StartWith(new byte[] { 0x08, 0x00, 0x10, 0x00 });
                shapeData.OffsetData5.Should().EndWith(new byte[] { 0x12, 0x00, 0x00, 0x80 });
            }
        }

        [Fact]
        public void Silverstone_Has_25_Shapes()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                objects.Count.Should().Be(25);
            }
        }

        [Fact]
        public void Silverstone_FirstObject_Has_One_ScaleValue_0x600()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.First();
                obj.ScaleValues.Count.Should().Be(1);
                obj.ScaleValues[0].Should().Be(0x600);
            }
        }

        [Fact]
        public void Silverstone_LastObject_Has_6_ScaleValues()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.Last();
                obj.ScaleValues.Count.Should().Be(6);
                obj.ScaleValues[0].Should().Be(3072);
                obj.ScaleValues[1].Should().Be(12288);
                obj.ScaleValues[2].Should().Be(0);
                obj.ScaleValues[3].Should().Be(32736);
                obj.ScaleValues[4].Should().Be(14336);
                obj.ScaleValues[5].Should().Be(16384);
            }
        }

        [Fact]
        public void Silverstone_FirstObject_Has_5_Vectors()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.First();
                obj.Vectors.Count.Should().Be(5);
                obj.Vectors[0].From.Should().Be(0);
                obj.Vectors[0].To.Should().Be(0);
                obj.Vectors[1].From.Should().Be(0);
                obj.Vectors[1].To.Should().Be(1);
                obj.Vectors[4].From.Should().Be(1);
                obj.Vectors[4].To.Should().Be(3);
            }
        }

        [Fact]
        public void Silverstone_LastObject_Has_9_Vectors()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.Last();
                obj.Vectors.Count.Should().Be(9);
                obj.Vectors[0].From.Should().Be(0);
                obj.Vectors[0].To.Should().Be(0);
                obj.Vectors[1].From.Should().Be(0);
                obj.Vectors[1].To.Should().Be(1);
                obj.Vectors[7].From.Should().Be(3);
                obj.Vectors[7].To.Should().Be(5);
                obj.Vectors[8].From.Should().Be(4);
                obj.Vectors[8].To.Should().Be(5);
            }
        }

        [Fact]
        public void Read_Imola_Remove_Scale_Values_Save_OK()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;

                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT03.DAT", TestDataFileType.Tracks);
                var track = new TrackReader().Read(sourcePath);

                var shape = track.ObjectShapes[22];
                shape.ScaleValues.Count.Should().Be(12);

                shape.ScaleValues.RemoveAt(11);
                shape.ScaleValues.RemoveAt(10);
                shape.ScaleValues.RemoveAt(9);
                shape.ScaleValues.RemoveAt(8);
                shape.ScaleValues.RemoveAt(7);
                shape.ScaleValues.RemoveAt(6);

                shape.ScaleValues.Count.Should().Be(6);

                new TrackWriter().Write(track, targetPath);

                // reread original and new
                track = new TrackReader().Read(sourcePath);
                var readAgainTrack = new TrackReader().Read(targetPath);

                var againShape = readAgainTrack.ObjectShapes[22];
                againShape.ScaleValues.Count.Should().Be(6);

                var originalShape = track.ObjectShapes[22];
                againShape.Offset2.Should().BeLessThan(originalShape.Offset2);
                againShape.PointDataOffset.Should().NotBe(originalShape.PointDataOffset);

                var nextShape = track.ObjectShapes[23];
                var nextShapeAgain = readAgainTrack.ObjectShapes[23];

                nextShape.Offset2.Should().NotBe(nextShapeAgain.Offset2);

                // file length should be smaller
                var originalLength = new FileInfo(sourcePath).Length;
                var newLength = new FileInfo(targetPath).Length;

                newLength.Should().BeLessThan(originalLength);
            }
        }

        [Fact]
        public void Silverstone_FirstObject_Has_4_RawPoints()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.First();
                obj.RawPoints.Count.Should().Be(4);
                obj.RawPoints[0].XCoord.Should().Be(34);
                obj.RawPoints[0].XReferencePointValue.Should().Be(34);
                obj.RawPoints[0].ReferencePointFlag.Should().Be(0);
                obj.RawPoints[0].YCoord.Should().Be(0);
                obj.RawPoints[0].ZCoord.Should().Be(0);
                obj.RawPoints[0].Unknown.Should().Be(0);
                obj.RawPoints[1].XCoord.Should().Be(2);
                obj.RawPoints[3].XCoord.Should().Be(-32767);
            }
        }

        [Fact]
        public void Silverstone_LastObject_Has_6_RawPoints()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.Last();
                obj.RawPoints.Count.Should().Be(6);
                obj.RawPoints[0].XCoord.Should().Be(38);
                obj.RawPoints[0].YCoord.Should().Be(40);
            }
        }

        [Fact]
        public void Silverstone_FirstObject_Has_4_Points()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.First();
                obj.Points.Count.Should().Be(4);
                obj.Points[0].X.Should().Be(-1536);
                obj.Points[0].Y.Should().Be(0);
                obj.Points[0].Z.Should().Be(0);
                obj.Points[1].X.Should().Be(1536);
                obj.Points[1].Y.Should().Be(0);
                obj.Points[1].Z.Should().Be(0);
                obj.Points[2].X.Should().Be(-1536);
                obj.Points[2].Y.Should().Be(0);
                obj.Points[2].Z.Should().Be(768);
                obj.Points[3].X.Should().Be(1536);
                obj.Points[3].Y.Should().Be(0);
                obj.Points[3].Z.Should().Be(768);
            }
        }

        [Fact]
        public void Silverstone_LastObject_Has_6_Points()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects.Last();

                obj.Points.Count.Should().Be(6);
                obj.Points[0].X.Should().Be(0);
                obj.Points[0].Y.Should().Be(-32736);
                obj.Points[0].Z.Should().Be(512);
                obj.Points[1].X.Should().Be(0);
                obj.Points[1].Y.Should().Be(-12288);
                obj.Points[1].Z.Should().Be(0);
                obj.Points[2].X.Should().Be(0);
                obj.Points[2].Y.Should().Be(12288);
                obj.Points[2].Z.Should().Be(0);
                obj.Points[3].X.Should().Be(-14336);
                obj.Points[3].Y.Should().Be(16384);
                obj.Points[3].Z.Should().Be(0);
                obj.Points[4].X.Should().Be(-3072);
                obj.Points[4].Y.Should().Be(-12288);
                obj.Points[4].Z.Should().Be(640);
                obj.Points[5].X.Should().Be(-3072);
                obj.Points[5].Y.Should().Be(12288);
                obj.Points[5].Z.Should().Be(640);
            }
        }

        [Fact]
        public void Silverstone_SecondObject_Has_12_Calculated2Points()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                var obj = objects[1];

                obj.Points.Count.Should().Be(12);
                obj.Points[0].X.Should().Be(6400);
                obj.Points[0].Y.Should().Be(960);
                obj.Points[0].Z.Should().Be(160);

                obj.Points[1].X.Should().Be(-6400);
                obj.Points[1].Y.Should().Be(960);

                obj.Points[2].Y.Should().Be(-960);
                obj.Points[3].Y.Should().Be(-960);
                obj.Points[4].Y.Should().Be(-960);
                obj.Points[5].Y.Should().Be(-960);
                obj.Points[6].Y.Should().Be(960);
                obj.Points[7].Y.Should().Be(960);
                obj.Points[8].Y.Should().Be(960);
                obj.Points[9].Y.Should().Be(960);
                obj.Points[10].Y.Should().Be(-960);
                obj.Points[11].Y.Should().Be(-960);
            }
        }

        [Fact]
        public void Silverstone_Object_13_Has_Stray_Point_Bytes()
        {
            var trackData = TrackFactsHelper.GetTrackSilverstone();

            using (var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path)))
            {
                reader.BaseStream.Position = 4110;
                var objects = ObjectShapesReader.Read(reader, trackData.KnownOffsets.ObjectData);

                objects[13].PointsAdditionalBytes.Length.Should().Be(6);
            }
        }

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
                    XPointIndex = refOrig.XPointIndex,
                    YPointIndex = refOrig.YPointIndex,
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
