using System;
using System.Diagnostics;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Diagnostics.Test
{
    public class StopwatchExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
            var sw = new Stopwatch();
            sw.ResetFormat();
        }

        /// <summary>
        /// Helper function to set the elapsed time on a <see cref="Stopwatch"/>
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="millis"></param>
        private static void SetElapsedTime(Stopwatch sw, long millis)
        {
            // use some reflection shenanigans to set the elapsed time
            var field = typeof(Stopwatch).GetField("_elapsed", BindingFlags.NonPublic | BindingFlags.Instance);
            // The value of _elapsed is in ticks.
            // There are 10000 ticks in 1 millisecond
            field.SetValue(sw, millis * 10000);
        }

        [TestCase(1000, 1.00, 2)]
        [TestCase(2000, 2, 0)]
        [TestCase(500, 0.5, 1)]
        [TestCase(225, 0.23, 2)]
        [TestCase(10, 0.0, 1)]
        [TestCase(5, .005, 3)]
        public void TestElapsedSeconds(long millis, double expected, int? decimals)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            var actual = sw.ElapsedSeconds(decimals);
            actual.Should().Be(expected);
        }

        [TestCase(600, .01, 2)]
        [TestCase(6000, .10, 2)]
        [TestCase(60000, 1.00, 2)]
        [TestCase(66000, 1.10, 2)]
        public void TestElapsedMinutes(long millis, double expected, int? decimals)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            var actual = sw.ElapsedMinutes(decimals);
            actual.Should().Be(expected);
        }

        [TestCase(1000, "00:01:0000")]
        [TestCase(1000, "00:01:0000")]
        [TestCase(2000, "00:02:0000")]
        [TestCase(3456, "00:03:4560")]
        [TestCase(1234, "00:01:2340")]
        public void TestElapsedDefaultFormat(long millis, string expected)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            var actual = sw.ElapsedFormat();
            actual.Should().Be(expected);
        }

        [TestCase(2000, @"mm\:ss", "00:02")]
        [TestCase(3456, @"mm\:ss", "00:03")]
        [TestCase(2000, null, "00:02:0000")]
        [TestCase(3456, "", "00:03:4560")]
        [TestCase(3456, "    ", "00:03:4560")]
        public void TestElapsedFormat(long millis, string format, string expected)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            var actual = sw.ElapsedFormat(format);
            actual.Should().Be(expected);
        }

        [TestCase(2000, @"mm\:ss", "00:02")]
        [TestCase(3456, @"mm\:ss", "00:03")]
        public void TestDefaultFormat(long millis, string format, string expected)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            sw.DefaultFormat(format);

            var actual = sw.ElapsedFormat();
            actual.Should().Be(expected);
        }

        [TestCase(2000, null)]
        [TestCase(3456, "")]
        [TestCase(3456, "    ")]
        public void TestDefaultFormatException(long millis, string format)
        {
            var sw = new Stopwatch();
            SetElapsedTime(sw, millis);

            Assert.Throws<FormatException>(() => sw.DefaultFormat(format));
        }
    }
}