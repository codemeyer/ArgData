using System;
using ArgData.Entities;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Entities
{
    public class NameFileTeamListFacts
    {
        [Fact]
        public void NewListHas20Drivers()
        {
            var teamList = new NameFileTeamList();

            teamList.Count.Should().Be(20);
        }

        [Fact]
        public void IndexerReturnsExpectedDriver()
        {
            var teamList = new NameFileTeamList();

            var team = teamList[7];

            team.Name.Should().Be("Team 8");
            team.Engine.Should().Be("Engine 8");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(19)]
        public void Indexer_InsideRange_DoesNotThrowArgumentOutOfRangeException(int index)
        {
            var teamList = new NameFileTeamList();

            Action action = () =>
            {
                var any = teamList[index];
            };

            action.ShouldNotThrow<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(20)]
        public void Indexer_OutsideRange_ThrowsArgumentOutOfRangeException(int index)
        {
            var teamList = new NameFileTeamList();

            Action action = () =>
            {
                var any = teamList[index];
            };

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}
