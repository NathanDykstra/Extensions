using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Collections.Test
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void TestAddOrAppend()
        {
            var dict = new Dictionary<int, List<int>>();

            dict.AddOrAppend(1, new List<int> { 1 });
            dict.Count.Should().Be(1);
            dict[1].Count.Should().Be(1);

            dict.AddOrAppend(1, new List<int> { 2 });
            dict.Count.Should().Be(1);
            dict[1].Count.Should().Be(2);
            dict[1].Should().Contain(new List<int> { 1, 2 });

            dict.AddOrAppend(2, new List<int> {1});
            dict.Count.Should().Be(2);
            dict[1].Count.Should().Be(2);
            dict[2].Count.Should().Be(1);
            dict[2].Should().Contain(new List<int> {1});
        }
    }
}