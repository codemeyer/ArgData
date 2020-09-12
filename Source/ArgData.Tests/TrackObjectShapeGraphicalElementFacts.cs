using System.IO;
using System.Linq;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests
{
    public class TrackObjectShapeGraphicalElementFacts
    {
        [Fact]
        public void Phoenix_First_Object_Has_21_bytes_GraphicalElements()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[0];

            shape.GraphicalElements.ToBytes().Length.Should().Be(21);
        }

        [Fact]
        public void Phoenix_First_Shape_Has_Two_Header_Values()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[0];

            shape.GraphicalElements.HeaderValues.Count.Should().Be(2);
            shape.GraphicalElements.HeaderValues[0].Should().Be(0);
            shape.GraphicalElements.HeaderValues[1].Should().Be(5);
        }

        [Fact]
        public void Phoenix_First_Object_Has_Four_Elements()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[0];

            shape.GraphicalElements.Elements.Count.Should().Be(4);
        }

        [Fact]
        public void Phoenix_First_Object_Has_Two_Polygons()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[0];

            var polygon1 = shape.GraphicalElements.Elements[0] as TrackObjectShapeGraphicalElementPolygon;
            polygon1.Should().NotBeNull();
            polygon1.Color.Should().Be(15);
            polygon1.Vectors.Count.Should().Be(4);

            var polygon2 = shape.GraphicalElements.Elements[1] as TrackObjectShapeGraphicalElementPolygon;
            polygon2.Should().NotBeNull();
            polygon2.Color.Should().Be(2);
            polygon2.Vectors.Count.Should().Be(4);
        }

        [Fact]
        public void Phoenix_First_Object_GraphicalElement_Bytes()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[0];

            var bytes = shape.GraphicalElements.ToBytes();

            bytes.Length.Should().Be(21);
            bytes[0].Should().Be(0);
            bytes[6].Should().Be(250);
            bytes[10].Should().Be(3);
            bytes[14].Should().Be(0);
            bytes[18].Should().Be(160);
            bytes[19].Should().Be(8);
            bytes[20].Should().Be(1);
        }

        [Fact]
        public void Phoenix_First_Object_Has_Three_Elements()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes[1];

            shape.GraphicalElements.Elements.Count.Should().Be(3);
        }

        [Fact]
        public void Phoenix_First_Object_Adding_Line_Increases_Length()
        {
            using (var context = ExampleDataContext.GetTempFileName("TRACK.DAT"))
            {
                var targetPath = context.FilePath;
                var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT01.DAT", TestDataFileType.Tracks);
                File.Copy(sourcePath, targetPath);

                var track = new TrackReader().Read(targetPath);

                var newLine = new TrackObjectShapeGraphicalElementLine
                {
                    Value1 = 8,
                    Value2 = 1
                };

                track.ObjectShapes[0].GraphicalElements.Elements.Add(newLine);

                new TrackWriter().Write(track, targetPath);

                var originalBytes = File.ReadAllBytes(sourcePath);
                var createdBytes = File.ReadAllBytes(targetPath);

                createdBytes.Length.Should().Be(originalBytes.Length + 3);
            }
        }

        [Fact]
        public void Phoenix_PitCrew_GraphicalElements_Has_Nine_Flat_Objects()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes.Single(o => o.HeaderIndex == 10);

            shape.GraphicalElements.HeaderValues.Count.Should().Be(4);
            shape.GraphicalElements.Elements.Count.Should().Be(9);
            shape.GraphicalElements.Elements.Should().AllBeAssignableTo<TrackObjectShapeGraphicalElementBitmap>();
            var first = shape.GraphicalElements.Elements[0] as TrackObjectShapeGraphicalElementBitmap;
            first.Indicator.Should().Be(136);
            first.PointIndex.Should().Be(2);
            first.UnknownFlag.Should().Be(0xFF);
            first.ObjectIndex.Should().Be(33);
        }

        [Fact]
        public void Phoenix_PitCrew_GraphicalElements_Bytes()
        {
            var trackData = TrackFactsHelper.GetTrackPhoenix();
            var track = new TestableTrackReader().Read(trackData.Path);

            var shape = track.ObjectShapes.Single(o => o.HeaderIndex == 10);

            shape.GraphicalElements.ToBytes().Length.Should().Be(41);
        }

        // Monaco tunnel pillar
        // something in Imola (and others)
        // something in Adelaide

        [Fact]
        public void Monaco_Index_2_Has_UnknownFive()
        {
            var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
            var track = new TestableTrackReader().Read(sourcePath);

            var shape = track.ObjectShapes.Single(o => o.HeaderIndex == 2);

            shape.GraphicalElements.Elements.OfType<TrackObjectShapeGraphicalElementBitmapExtended>().Count().Should().Be(3);
            shape.GraphicalElements.Elements[11].Should().BeAssignableTo<TrackObjectShapeGraphicalElementBitmapExtended>();
            shape.GraphicalElements.Elements[12].Should().BeAssignableTo<TrackObjectShapeGraphicalElementBitmapExtended>();
            shape.GraphicalElements.Elements[13].Should().BeAssignableTo<TrackObjectShapeGraphicalElementBitmapExtended>();
        }

        [Fact]
        public void Monaco_Index_2_FinalBytes()
        {
            var sourcePath = ExampleDataHelper.GetExampleDataPath("F1CT04.DAT", TestDataFileType.Tracks);
            var track = new TestableTrackReader().Read(sourcePath);

            var shape = track.ObjectShapes.Single(o => o.HeaderIndex == 2);

            shape.GraphicalElements.ToBytes().Length.Should().Be(91);
        }
    }
}
