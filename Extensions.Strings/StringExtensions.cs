using System;
using System.Linq;

namespace Extensions.Strings
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes any non-numeric characters from the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToNumeric(this string s)
        {
            return new string(s.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Converts the string to camelCase.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("String cannot be empty", nameof(s));
            }

            var words = s.Split(" ").Select(x => char.ToUpperInvariant(x[0]) + (x.Length > 1 ? x.Substring(1) : string.Empty));
            s = string.Join(string.Empty, words);

            return char.ToLowerInvariant(s[0]) + (s.Length > 1 ? s.Substring(1) : string.Empty);
        }

        /// <summary>
        /// Converts the string to PascalCase.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string s)
        {
            s = s.ToCamelCase();
            return char.ToUpperInvariant(s[0]) + (s.Length > 1 ? s.Substring(1) : string.Empty);
        }

        /// <summary>
        /// Removes any non alpha-numeric characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToAlphaNumeric(this string s)
        {
            return new string(s.Where(char.IsLetterOrDigit).ToArray());
        }
    }
}
