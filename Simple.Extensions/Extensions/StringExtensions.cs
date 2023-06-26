using System.Text.RegularExpressions;

namespace Simple.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether a specified string is empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return true if the value is empty only otherwise return false</returns>
        public static bool IsEmpty(this string str) => str == string.Empty;

        /// <summary>
        /// Indicates whether a specified string is null
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return true if the value is null only otherwise return false</returns>
        public static bool IsNull(this string str) => str == default;

        /// <summary>
        /// Indicates whether a specified string consist only of whitespace
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return true if the value is whitespace only otherwise return false</returns>
        public static bool IsWhiteSpace(this string str)
        {
            if (str == null || str == string.Empty) return false;

            for (int i = 0; i < str.Length; i++)
                if (char.IsWhiteSpace(str[i]) is false) return false;

            return true;
        }

        /// <summary>
        /// Indicates whether a specified string has any value
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return true if the string has any value, it is simply a wrapper around IsNullOrWhiteSpace without the headache of negation</returns>
        public static bool HasValue(this string str) => string.IsNullOrWhiteSpace(str) is false;

        /// <summary>
        /// Remove any special character including 
        /// ~, `, !, @, #, $, %,^, &amp;, *, (, ), \, -, _, +, =, {, }, [, ], |, /, :, ,, &lt;, >, ;, ., ?, ', "
        /// </summary>
        /// <param name="str"></param>
        /// <returns>New string contains the original value without special characters</returns>
        public static string RemoveSpecialCharacters(this string str)
            => str == default ? default : Regex.Replace(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""]+", string.Empty);

        /// <summary>
        /// Remove any spaces and special character including 
        /// ~, `, !, @, #, $, %,^, &amp;, *, (, ), \, -, _, +, =, {, }, [, ], |, /, :, ,, &lt;, >, ;, ., ?, ', "
        /// </summary>
        /// <param name="str"></param>
        /// <returns>New string contains the original value without special characters and spaces</returns>
        public static string RemoveSpecialCharactersAndSpaces(this string str)
            => str == default ? default : Regex.Replace(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""\s]+", string.Empty);

        /// <summary>
        /// Remove any spaces from the string value
        /// </summary>
        /// <param name="str"></param>
        /// <returns>New string contains the original value without spaces</returns>
        public static string RemoveSpaces(this string str)
            => str == default ? default : Regex.Replace(str, @"\s+", string.Empty);
    }
}
