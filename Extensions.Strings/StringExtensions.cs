using System;
using System.Linq;

namespace Extensions.Strings
{
    public static class StringExtensions
    {
        public static string ToNumeric(this string s)
        {
            return new string(s.Where(char.IsDigit).ToArray());
        }
    }
}
