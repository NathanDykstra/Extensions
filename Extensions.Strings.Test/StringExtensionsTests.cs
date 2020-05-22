using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Strings.Test
{
    public class StringExtensionsTests
    {
        [Test]
        public void TestToNumeric()
        {
            var s = "a1b2c3";
            var actual = s.ToNumeric();
            actual.Should().Be("123");

            s = @"abcde12fgh+_=-{}[][?><!@#$%^&*()_+3|\/.,";
            actual = s.ToNumeric();
            actual.Should().Be("123");
        }
    }
}