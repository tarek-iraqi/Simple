using System.Text.RegularExpressions;

namespace Simple.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str) => str == string.Empty;
        public static bool IsNull(this string str) => str == default;
        public static bool IsWhiteSpace(this string str)
        {
            if (str == null || str == string.Empty) return false;

            for (int i = 0; i < str.Length; i++)
                if (char.IsWhiteSpace(str[i]) is false) return false;

            return true;
        }
        public static bool HasValue(this string str) => string.IsNullOrWhiteSpace(str) is false;

        public static string RemoveSpecialCharacters(this string str)
            => str == default ? default : Regex.Replace(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""]+", string.Empty);

        public static string RemoveSpecialCharactersAndSpaces(this string str)
            => str == default ? default : Regex.Replace(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""\s]+", string.Empty);

        public static string RemoveSpaces(this string str)
            => str == default ? default : Regex.Replace(str, @"\s+", string.Empty);
    }
}
