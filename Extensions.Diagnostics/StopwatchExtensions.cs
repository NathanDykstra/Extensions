using System;
using System.Diagnostics;

namespace Extensions.Diagnostics
{
    public static class StopwatchExtensions
    {
        private const string BaseFormat = @"mm\:ss\:ffff";
        private const double MillisecondsInSeconds = 1000;
        private const double MillisecondsInMinutes = 60 * MillisecondsInSeconds;
        private static string _configuredFormat = BaseFormat;

        /// <summary>
        /// Configures the formatting for use in all calls to <see cref="ElapsedFormat"/>
        /// </summary>
        /// <param name="_"></param>
        /// <param name="format"></param>
        public static void DefaultFormat(this Stopwatch _, string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new FormatException("Input string was not in a correct format.");
            }

            _configuredFormat = format;
        }

        /// <summary>
        /// Resets the format to the base formatter.
        /// </summary>
        /// <param name="_"></param>
        public static void ResetFormat(this Stopwatch _)
        {
            _configuredFormat = BaseFormat;
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in seconds.
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static double ElapsedSeconds(this Stopwatch sw, int? decimals = null)
        {
            var result = sw.ElapsedMilliseconds / MillisecondsInSeconds;
            return decimals.HasValue ? Math.Round(result, decimals.Value, MidpointRounding.AwayFromZero) : result;
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in minutes.
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static double ElapsedMinutes(this Stopwatch sw, int? decimals = null)
        {
            var result = sw.ElapsedMilliseconds / MillisecondsInMinutes;
            return decimals.HasValue ? Math.Round(result, decimals.Value, MidpointRounding.AwayFromZero) : result;
        }

        /// <summary>
        /// Converts the value of the current <see cref="Stopwatch"/>s elapsed time to its equivalent string representation by using the specified format.
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ElapsedFormat(this Stopwatch sw, string format = null)
        {
            format = string.IsNullOrWhiteSpace(format) ? _configuredFormat : format;

            var ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            return ts.ToString(format);
        }
    }
}
