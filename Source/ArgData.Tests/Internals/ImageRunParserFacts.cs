using System.Linq;
using ArgData.Internals;
using FluentAssertions;
using Xunit;

namespace ArgData.Tests.Internals
{
    public class ImageRunParserFacts
    {
        [Fact]
        public void ParseIntoUnlimitedLengths_SameColor_BecomesSingleLength()
        {
            var data = SetupByteArray(96, 209);

            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            list.Count.Should().Be(1);
            list.Single().Repetitions.Should().Be(96);
            list.Single().ColorIndex.Should().Be(209);
        }

        [Fact]
        public void ParseLengthsIntoSplitRuns_SameColorForDoubleMaxLength_ShouldBeTwoLines()
        {
            var data = SetupByteArray(48 * 2, 209);
            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);

            list2.Count.Should().Be(2);
            list2.Should().OnlyContain(i => i.Repetitions == 48);
            list2.Should().OnlyContain(i => i.ColorIndex == 209);
        }

        [Fact]
        public void ParseLengthsIntoSplitRuns_SameColorForTripleMaxLength_ShouldBeThreeLines()
        {
            var data = SetupByteArray(48 * 3, 209);
            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);

            list2.Count.Should().Be(3);
            list2.Should().OnlyContain(i => i.Repetitions == 48);
            list2.Should().OnlyContain(i => i.ColorIndex == 209);
        }

        [Fact]
        public void ParseIntoUnlimitedLengths_SameColorEverywhereExceptSpecificPixel_Creates3Runs()
        {
            var data = SetupByteArray(16, 209);
            data[4] = 5;

            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            list.Count.Should().Be(3);
            list[0].Repetitions.Should().Be(4);
            list[0].ColorIndex.Should().Be(209);
            list[1].Repetitions.Should().Be(1);
            list[1].ColorIndex.Should().Be(5);
            list[2].Repetitions.Should().Be(11);
            list[2].ColorIndex.Should().Be(209);
        }

        [Fact]
        public void ParseLengthsIntoSplitRuns()
        {
            var data = SetupByteArray(16, 209);
            data[4] = 5;
            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 8);
            list2.Count.Should().Be(4);
        }

        [Fact]
        public void ParseLengthsIntoSplitRuns_SameColorEverywhere_EightSinglesAcrossEndOfRun_Creates10Runs()
        {
            var data = SetupByteArray(96, 209);
            data[44] = 1;
            data[45] = 2;
            data[46] = 3;
            data[47] = 4;
            data[48] = 5;
            data[49] = 6;
            data[50] = 7;
            data[51] = 8;
            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);

            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);
            list2.Count.Should().Be(10);
        }

        [Fact]
        public void ParseConsolidateSingles_NoSingles_NoChange()
        {
            var data = SetupByteArray(48 * 2, 209);
            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);
            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);

            var list3 = ImageRunParser.ParseConsolidateSingles(list2, 48);

            list3.Count.Should().Be(2);
        }

        [Fact]
        public void Parse_SinglesFollowedByRepetitionsOnNextLine_ProducesExpectedResult()
        {
            var data = SetupByteArray(96, 209);
            data[44] = 1;
            data[45] = 2;
            data[46] = 3;
            data[47] = 4;
            data[48] = 66;
            data[49] = 66;

            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);
            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);
            var list3 = ImageRunParser.ParseConsolidateSingles(list2, 48);

            list3.Count.Should().Be(4);
        }

        [Fact]
        public void Parse_SinglesAcrossRunSplit_AreSplitIntoTwoSingleRuns()
        {
            var data = SetupByteArray(96, 209);
            data[44] = 1;
            data[45] = 2;
            data[46] = 3;
            data[47] = 4;
            data[48] = 5;
            data[49] = 6;
            data[50] = 7;
            data[51] = 8;

            var list = ImageRunParser.ParseIntoUnlimitedLengths(data);
            var list2 = ImageRunParser.ParseLengthsIntoSplitRuns(list, 48);
            var list3 = ImageRunParser.ParseConsolidateSingles(list2, 48);

            list3.Count.Should().Be(4);
            // Repeating 209, Single 1,2,3,4, Single 5,6,7,8, Repeating 209
        }

        [Fact]
        public void Bytes96_SameColorWithMaxLength48_BecomesTwoRunsWithIdenticalData()
        {
            var data = SetupByteArray(96, 209);

            var list = ImageRunParser.ParsePixelsToRuns(data, 48);

            list.Count.Should().Be(2);
        }

        private byte[] SetupByteArray(int count, byte sameValue)
        {
            var bytes = new byte[count];

            for (int i = 0; i < count; i++)
            {
                bytes[i] = sameValue;
            }

            return bytes;
        }
    }
}
