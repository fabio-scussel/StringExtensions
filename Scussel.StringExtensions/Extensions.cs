using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Scussel.StringExtensions
{
    /// <summary>
    /// String extensions collection
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Capitalizes the first char of a string
        /// </summary>
        /// <param name="text">The current string</param>
        /// <returns>
        /// The same string with its first letter in upper case. 
        /// Returns null if the current string is null.
        /// </returns>
        public static string CapitalizeFirstLetter(this string text)
        {
            if (text == null) return null;
            if (text == string.Empty) return text;
            return text.First().ToString().ToUpper() + text.Substring(1);
        }

        /// <summary>
        /// Verifies if the current string is equals to any item in options list
        /// </summary>
        /// <param name="text">The current string</param>
        /// <param name="options">List of string to be compared to</param>
        /// <returns>True if the current string is in the list. Otherwise false.</returns>
        public static bool Contains(this string text, IEnumerable<string> options)
        {
            if (text == null) return false;
            return options.Any(opción => text.Contains(opción));
        }

        /// <summary>
        /// Gets the firs word of the current string
        /// </summary>
        /// <param name="text">The current string</param>
        /// <returns>
        /// Returns null if the current string is null
        /// Returns empty if there is no words in the string
        /// Returns the entire string if it is just one word
        /// Returns the first word when it exists
        /// </returns>
        public static string GetFirstWord(this string text)
        {
            if (text == null) return null;
            return new Regex(@"([^\s]+)").Match(text).Value;
        }

        /// <summary>
        /// Gets the digits of the current tring
        /// </summary>
        /// <param name="text">The current string</param>
        /// <returns>Only the numbers of the current string or null if it is null.</returns>
        public static string GetNumbers(this string text) =>
            new string(text?.Where(c => char.IsDigit(c)).ToArray());

        /// <summary>
        /// Generates a hash for the current string
        /// </summary>
        /// <param name="text">The current string</param>
        /// <exception cref="ArgumentNullException">When the current string is null</exception>
        /// <returns>An integer hash of the string.</returns>
        public static int Hash(this string text)
        {
            uint uiHash = 0;

            foreach (byte letter in Encoding.Unicode.GetBytes(text))
            {
                uiHash += letter;
                uiHash += (uiHash << 10);
                uiHash ^= (uiHash >> 6);
            }

            uiHash += (uiHash << 3);
            uiHash ^= (uiHash >> 11);
            uiHash += (uiHash << 15);
            return (int)(uiHash % int.MaxValue);
        }

        /// <summary>
        /// Extracts the left part of the current strings with n characters length
        /// </summary>
        /// <param name="text">The current string</param>
        /// <param name="size">The length of the extraction</param>
        /// <returns>
        /// Returns null when the current string is null
        /// Returns the entire string when size is greater than the current string
        /// Otherwise, returns the left part as expected
        /// </returns>
        public static string Left(this string text, int size)
        {
            if (text == null) return null;
            if (size > text.Length) return text;
            return text.Substring(0, size);
        }

        /// <summary>
        /// Remove the accents from the string
        /// </summary>
        /// <param name="text">The text to be converted</param>
        /// <returns>The text without accents</returns>
        public static string RemoveDiacritics(this string text)
        {
            if (text == null) return null;
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Replaces the first occurence of a string by another term 
        /// </summary>
        /// <param name="text">The current string</param>
        /// <param name="searchText">The term to be searched</param>
        /// <param name="replacement">The term to replace</param>
        /// <exception cref="ArgumentNullException">When searchText is null</exception>
        /// <returns>The new string with the first term replaced.</returns>
        public static string ReplaceFirst(this string text, string searchText, string replacement)
        {
            if (text == null) return null;
            replacement = replacement ?? string.Empty;
            Regex regex = new Regex(searchText, RegexOptions.IgnoreCase);
            return regex.Replace(text, replacement, 1);
        }

        /// <summary>
        /// Converts the current string in integer if it is possible
        /// </summary>
        /// <param name="text">The current string</param>
        /// <returns>The integer generated</returns>
        public static int ToInt(this string text)
        {
            int result = 0;
            int.TryParse(text, out result);
            return result;
        }

        /// <summary>
        /// Converts the current string in unsigned short if it is possible
        /// </summary>
        /// <param name="text">The current string</param>
        /// <returns>The unsigned short generated</returns>
        public static ushort ToUshort(this string text)
        {
            ushort result = 0;
            ushort.TryParse(text, out result);
            return result;
        }
    }
}
