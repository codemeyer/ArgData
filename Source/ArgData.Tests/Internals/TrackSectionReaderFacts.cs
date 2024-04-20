using System.IO;
using System.Linq;
using ArgData.Entities;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals;

public class TrackSectionReaderFacts
{
    [Fact]
    public void PhoenixTrackDataHas67Sections()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        result.TrackSections.Count.Should().Be(67);
        result.Position.Should().Be(trackData.KnownComputerCarLineSectionDataStart); // 16342
    }

    [Fact]
    public void PhoenixTrackData_FirstSection_TrackSectionAttributes()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var firstSection = result.TrackSections.First();
        firstSection.Length.Should().Be(24);
    }

    [Fact]
    public void PhoenixTrackData_FirstSectionHas_14_Commands()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var firstSection = result.TrackSections.First();
        firstSection.Commands.Count.Should().Be(14);
    }

    [Fact]
    public void PhoenixTrack_FirstTurn_FirstSection()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var turn1 = result.TrackSections[5];
        turn1.Length.Should().Be(2);
        turn1.Curvature.Should().Be(2731);
        turn1.Height.Should().Be(0);
        turn1.LeftVergeWidth.Should().Be(2);
        turn1.RightVergeWidth.Should().Be(2);
    }

    [Fact]
    public void PhoenixTrack_FirstTurn_HasFlags()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var turn1 = result.TrackSections[5];
        turn1.BridgedLeftFence.Should().BeFalse();
        turn1.BridgedRightFence.Should().BeFalse();
        turn1.HasLeftKerb.Should().BeFalse();
        turn1.HasRightKerb.Should().BeFalse();
    }

    [Fact]
    public void PhoenixTrackData_FirstSection_CommandDetails()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var firstCommand = result.TrackSections.First().Commands.First();
        firstCommand.Command.Should().Be(0xAC);
        firstCommand.Arguments.Length.Should().Be(5);
        firstCommand.Arguments.Should().ContainInOrder([0, 26, 32, 32, 29]);

        var lastCommand = result.TrackSections.First().Commands.Last();
        lastCommand.Command.Should().Be(0x81);
        lastCommand.Arguments.Length.Should().Be(2);
        lastCommand.Arguments.Should().ContainInOrder([0, 148]);
    }

    [Fact]
    public void PhoenixTrackData_SomeSection_HasRoadSignArrow100()
    {
        var trackData = TrackFactsHelper.GetTrackPhoenix();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var section = result.TrackSections[23];
        section.RoadSignArrow100.Should().BeTrue();
    }

    [Fact]
    public void MexicoTrackData_LastSection_ZeroLength()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var last = result.TrackSections.Last();
        last.Length.Should().Be(0);
    }

    [Fact]
    public void MexicoTrackData_FirstRightTurn_HasKerbFlags()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var turn = result.TrackSections[8];
        turn.HasRightKerb.Should().BeTrue();
        turn.KerbHeight.Should().Be(KerbHeight.High);
        turn.RoadSigns.Should().BeTrue();
        turn.RoadSignArrow.Should().BeTrue();
    }

    [Fact]
    public void MexicoTrackData_FirstLeftTurn_HasKerbFlags()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var turn = result.TrackSections[10];
        turn.HasLeftKerb.Should().BeTrue();
        turn.KerbHeight.Should().Be(KerbHeight.High);
        turn.RemoveLeftWall.Should().BeTrue();
    }

    [Fact]
    public void MexicoTrackData_EarlySection_HasNoRightWall()
    {
        var trackData = TrackFactsHelper.GetTrackMexico();

        using var reader = new BinaryReader(MemoryStreamProvider.Open(trackData.Path));
        var result = TrackSectionReader.Read(reader, trackData.KnownTrackSectionDataStart);

        var turn = result.TrackSections[4];
        turn.RemoveRightWall.Should().BeTrue();
    }
}
