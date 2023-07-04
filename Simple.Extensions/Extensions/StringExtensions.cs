using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Simple.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether a specified string is empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return <see cref="bool">true</see> if the value is empty only otherwise return <see cref="bool">false</see></returns>
        public static bool IsEmpty(this string str) => str == string.Empty;

        /// <summary>
        /// Indicates whether a specified string is null
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return <see cref="bool">true</see> if the value is null only otherwise return <see cref="bool">false</see></returns>
        public static bool IsNull(this string str) => str == default;

        /// <summary>
        /// Indicates whether a specified string consist only of whitespace
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return <see cref="bool">true</see> if the value is whitespace only otherwise return <see cref="bool">false</see></returns>
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
        /// <returns>Return <see cref="bool">true</see> if the string has any value, it is simply a wrapper around IsNullOrWhiteSpace without the headache of negation</returns>
        public static bool HasValue(this string str) => string.IsNullOrWhiteSpace(str) is false;

        /// <summary>
        /// Indicates whether a specified string has any special character
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns <see cref="bool">true</see> if the string has any special character, else returns <see cref="bool">false</see></returns>
        public static bool HasSpecialCharacters(this string str)
            => str != default && Regex.Match(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""]+").Success;

        /// <summary>
        /// Indicates whether a specified string has spaces
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns <see cref="bool">true</see> if the string has spaces, else returns <see cref="bool">false</see></returns>
        public static bool HasSpaces(this string str)
            => str != default && Regex.Match(str, @"\s+").Success;

        /// <summary>
        /// Indicates whether a specified string has special characters or spaces
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns <see cref="bool">true</see> if the string has special characters or spaces, else returns <see cref="bool">false</see></returns>
        public static bool HasSpecialCharactersOrSpaces(this string str)
            => str != default && Regex.Match(str, @"[~`!@#$%^&*()\-_+={}[\]|\\/:,<>;.?'""\s]+").Success;

        /// <summary>
        /// Indicates whether a specified string has HTML tags
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns <see cref="bool">true</see> if the string has HTML tags, else returns <see cref="bool">false</see></returns
        public static bool HasHTMLTags(this string str)
            => str != default && Regex.Match(str, "<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>").Success;

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

        /// <summary>
        /// Remove any HTML tags from the string value
        /// </summary>
        /// <param name="str"></param>
        /// <returns>New string contains the original value without HTML tags</returns>
        public static string RemoveHTMLTags(this string str)
            => str == default ? default : Regex.Replace(str, @"<(?:""[^""]*""['""]*|'[^']*'['""]*|[^'"">])+>", string.Empty);

        /// <summary>
        /// Indicates whether the specified string is valid url
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return <see cref="bool">true</see> if the value is valid url otherwise return <see cref="bool">false</see></returns>HTML
        public static bool IsValidUrl(this string str)
            => str != default &&
               Regex.Match(str, "^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$").Success;

        /// <summary>
        /// Extract any valid url from the specified string
        /// </summary>
        /// <param name="str"></param>
        /// <returns><see cref="IEnumerable{T}">IEnumerable&lt;string&gt;</see> with all extracted valid urls</returns>
        public static IEnumerable<string> ExtractUrls(this string str)
        {
            if (str == default) return Enumerable.Empty<string>();

            var regex = new Regex("https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)");

            return regex.Matches(str).Cast<Match>().Select(m => m.Value);
        }

        /// <summary>
        /// Indicates whether the specified string is valid email
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Return <see cref="bool">true</see> if the value is valid email otherwise return <see cref="bool">false</see></returns>
        public static bool IsValidEmail(this string str)
            => str != default &&
               Regex.Match(str, "^[a-zA-Z0-9\\-_]+(?:\\.[a-zA-Z0-9\\-_]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$").Success;

        /// <summary>
        /// Extract any valid email from the specified string
        /// </summary>
        /// <param name="str"></param>
        /// <returns><see cref="IEnumerable{T}">IEnumerable&lt;string&gt;</see> with all extracted valid emails</returns>
        public static IEnumerable<string> ExtractEmails(this string str)
        {
            if (str == default) return Enumerable.Empty<string>();

            var regex = new Regex("[a-zA-Z0-9\\-_]+(?:\\.[a-zA-Z0-9\\-_]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");

            return regex.Matches(str).Cast<Match>().Select(m => m.Value);
        }
    }
}
