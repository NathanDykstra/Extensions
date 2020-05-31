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

        [TestCase("camelCase", "camelCase")]
        [TestCase("innerHTML", "innerHTML")]
        [TestCase("String Extensions", "stringExtensions")]
        [TestCase("STRING extensions", "sTRINGExtensions")]
        [TestCase("This is a test", "thisIsATest")]
        [TestCase("A", "a")]
        public void TestToCamelCase(string input, string expected)
        {
            var actual = input.ToCamelCase();
            actual.Should().Be(expected);
        }

        [TestCase("pascalCase", "PascalCase")]
        [TestCase("innerHTML", "InnerHTML")]
        [TestCase("String Extensions", "StringExtensions")]
        [TestCase("STRING extensions", "STRINGExtensions")]
        [TestCase("This is a test", "ThisIsATest")]
        [TestCase("a", "A")]
        public void TestToPascalCase(string input, string expected)
        {
            var actual = input.ToPascalCase();
            actual.Should().Be(expected);
        }

        [TestCase("abc123", "abc123")]
        [TestCase("abc-123", "abc123")]
        [TestCase("alpha+_-=][{};:',.<>/?123`/*-+", "alpha123")]
        public void TestToAlphaNumeric(string input, string expected)
        {
            var actual = input.ToAlphaNumeric();
            actual.Should().Be(expected);
        }
    }
}