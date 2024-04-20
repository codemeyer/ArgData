using System.IO;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals;

public class TrackCameraReaderFacts
{
    [Fact]
    public void Read_MexicoTrackCameras_ShouldBe20Commands()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        result.CameraCommands.Count.Should().Be(20);
    }

    [Fact]
    public void Read_MexicoTrackCameras_Command1ShouldBeAdjustment()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        var command = result.CameraCommands[1];
        command.Should().BeOfType<TrackCameraAdjustmentCommand>();

        var adjustmentCommand = (TrackCameraAdjustmentCommand)command;
        adjustmentCommand.CameraIndex.Should().Be(1);
        adjustmentCommand.Adjustment.Should().Be(7);
        adjustmentCommand.TrackSide.Should().Be(TrackSide.Left);
    }

    [Fact]
    public void Read_MexicoTrackCameras_Command10ShouldBeDelete()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        var command = result.CameraCommands[10];
        command.Should().BeOfType<DeleteTrackCameraCommand>();
        command.As<DeleteTrackCameraCommand>().CameraIndex.Should().Be(28);
    }

    [Fact]
    public void Read_MexicoTrackCameras_Command14ShouldBeMoveAndChangeSide()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        var command = result.CameraCommands[14];

        var adjustmentCommand = (TrackCameraAdjustmentCommand)command;
        adjustmentCommand.CameraIndex.Should().Be(35);
        adjustmentCommand.Adjustment.Should().Be(4);
        adjustmentCommand.TrackSide.Should().Be(TrackSide.Right);
    }

    [Fact]
    public void Read_MexicoTrackCameras_Command15ShouldBeChangeSideWithoutAdjustment()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        var command = result.CameraCommands[15];

        var adjustmentCommand = (TrackCameraAdjustmentCommand)command;
        adjustmentCommand.CameraIndex.Should().Be(40);
        adjustmentCommand.Adjustment.Should().Be(0);
        adjustmentCommand.TrackSide.Should().Be(TrackSide.Right);
    }

    [Fact]
    public void Read_MexicoTrackCameras_Command17ShouldBeRangeOfMovement()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackCameraReader.Read(reader, trackData.KnownTrackCameraDataStart);

        var command = result.CameraCommands[17];

        var adjustmentCommand = (TrackCameraRangeRightSideAdjustmentCommand)command;
        adjustmentCommand.CameraIndexFrom.Should().Be(42);
        adjustmentCommand.CameraIndexTo.Should().Be(43);
    }
}