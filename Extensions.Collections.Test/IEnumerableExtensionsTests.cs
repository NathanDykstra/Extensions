using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Collections.Test
{
    [TestFixture]
    public class IEnumerableExtensionsTests
    {
        [TestCase(100, 10, 10)]
        [TestCase(6000, 10, 600)]
        [TestCase(10000000, 10000, 1000)]
        [TestCase(1234567890, 1, 1234567890)]
        [TestCase(65, 10, 7)]
        public void TestBatchBy(int listCount, int batchSize, int expectedBatches)
        {
            var testList = Enumerable.Range(0, listCount);
            var results = testList.BatchBy(batchSize);

            foreach (var result in results)
            {
                result.Count().Should().BeLessOrEqualTo(batchSize);
            }

            results.Count().Should().Be(expectedBatches);
        }
    }
}
