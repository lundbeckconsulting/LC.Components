/*
    @Date			 : 28.11.2019
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Repos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LundbeckConsulting.Components.Extensions
{
    public static class StringExtensions
    {
        private readonly static IExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Transform the string so that the first letter is capital
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <returns>The string with the first letter as capital</returns>
        public static string ToTitleCase(this string str)
        {
            string[] tokens = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            foreach (string tkn in tokens)
            {
                string val = tkn.Trim().Substring(0, 1).ToUpper();

                if (tkn.Length > 1)
                {
                    val += tkn.Substring(1).ToLower();
                }

                result.Append(val + " ");
            }

            return result.ToString();
        }

        /// <summary>
        /// Transform the string so that every word has a capital first letter
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <returns>The string with the first letter of all words are capital</returns>
        public static string ToCamelCase(this string str) => ToTitleCase(str).Replace(" ", default);

        /// <summary>
        /// Returns a number indicating how many words are in the specified string
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <returns>The word count of the string</returns>
        public static int WordCount(this string str) => str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

        /// <summary>
        /// Returns a number indicating how many times the specified text appears in the string
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <param name="wordToLookFor">Word or words to count</param>
        /// <returns>The number of time the specified string was found in the string</returns>
        public static int WordCount(this string str, string wordToLookFor)
        {
            int result = 0;
            string tmp = str;

            crawlString();

            void crawlString()
            {
                if (wordExists())
                {
                    result++;

                    tmp = tmp.Substring(tmp.ToLower().IndexOf(wordToLookFor.ToLower()) + wordToLookFor.Length).Trim();

                    if (wordExists())
                    {
                        crawlString();
                    }
                }
            }

            bool wordExists()
            {
                bool rslt = tmp.ToLower().IndexOf(wordToLookFor.ToLower()) > -1;

                return rslt;
            }

            return result;
        }

        /// <summary>
        /// Transforms the specified text
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <param name="type">The type defining how to transform the string</param>
        /// <returns>The string manipulated based on type</returns>
        public static string Transform(this string str, TextTransformTypes type)
        {
            string result = str;

            switch (type)
            {
                case TextTransformTypes.Lower:
                    result = str.ToLower();
                    break;

                case TextTransformTypes.Upper:
                    result = str.ToUpper();
                    break;

                case TextTransformTypes.RemoveSpace:
                    result = result.Replace(" ", "");
                    break;

                case TextTransformTypes.TitleCase:
                    result = str.ToTitleCase();
                    break;

                case TextTransformTypes.TitleCaseAndRemoveSpace:
                    result = result.ToTitleCase().Replace(" ", "");
                    break;

                case TextTransformTypes.Normalized:
                    result = result.ToNormalized();
                    break;
            }

            return result;
        }

        /// <summary>
        /// Adds a slash to the end of the string if it doesn't exist
        /// </summary>
        /// <param name="path">String to manipulate</param>
        /// <returns>The manipulated string</returns>
        public static string AddPathSlash(this string path) => !path.EndsWith("/") ? path + "/" : path;

        /// <summary>
        /// Returns a random letter from the specified string
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <param name="length">Number of letters to return</param>
        /// <returns>A string with random letters from the specified string</returns>
        public static string Random(this string str, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= length; i++)
            {
                int position = str.Length.Random();
                string c = str.Substring(position, 1);

                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// Indicates if a string is an URL that starts with http, https or www
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <returns>Returns true if the specified string is a URL</returns>
        public static bool IsURL(this string str)
        {
            bool result = str.StartsWith("http");

            if (!result)
            {
                result = str.StartsWith("https");
            }

            if (!result)
            {
                result = str.StartsWith("www");
            }

            return result;
        }

        /// <summary>
        /// Indicates if a string is a html start tag
        /// </summary>
        /// <param name="str">String to validate</param>
        /// <returns>Returns true if the string is a start tag</returns>
        public static bool IsStartTag(this string str) => (!str.StartsWith("</") && !str.EndsWith("/>") && (str.StartsWith("<") && str.EndsWith(">")));

        /// <summary>
        /// Indicates if a string is a html end tag
        /// </summary>
        /// <param name="str">String to validate</param>
        /// <returns>Returns true if the string is a end tag</returns>
        public static bool IsEndTag(this string str) => (str.StartsWith("</") && str.EndsWith(">"));

        /// <summary>
        /// Indicates if a string is a html self closing tag
        /// </summary>
        /// <param name="str">String to validate</param>
        /// <returns>Returns true if the string is a self closing tag</returns>
        public static bool IsSelfClosingTag(this string str) => (str.StartsWith("<") && str.EndsWith("/>"));

        /// <summary>
        /// Determines if string is numeric by parsing it as Float
        /// </summary>
        /// <param name="str">String to evaluate</param>
        /// <returns>True if string can be parsed as a Float value</returns>
        public static bool IsNumeric(this string str) => float.TryParse(str, out _);

        /// <summary>
        /// Determines if string can by parsed as Int
        /// </summary>
        /// <param name="str">String to evaluate</param>
        /// <returns>True if string can be parsed as an Int value</returns>
        public static bool IsInt(this string str) => int.TryParse(str, out _);

        /// <summary>
        /// Determines if Str is empty
        /// </summary>
        /// <param name="str">String to evaluate</param>
        /// <returns>True if string is empty</returns>
        public static bool IsEmpty(this string str) => str == string.Empty;

        /// <summary>
        /// Add prefix to string
        /// </summary>
        /// <param name="str">String to process</param>
        /// <param name="prefix">Value to add as prefix</param>
        /// <returns>String with prefix applied</returns>
        public static string AddPrefix(this string str, string prefix) => prefix + str;

        /// <summary>
        /// Adds specified suffix to string
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <param name="suffix">Suffix to add</param>
        /// <returns>String with added value</returns>
        public static string AddSuffix(this string str, string suffix)
        {
            string result = str;

            if (str.Contains("."))
            {
                result = str.Substring(0, str.LastIndexOf(".")) + "." + suffix + "." + str.Substring(str.LastIndexOf("."));
            }

            return result;
        }

        /// <summary>
        /// IEnumerable<string> list created with elements from string separated by comma
        /// </summary>
        /// <param name="str">Comma separated string to process</param>
        public static IEnumerable<string> ToEnumerable(this string str) => ToEnumerable(str, new char[] { ',' });

        /// <summary>
        /// IEnumerable<string> list generated with elements from string
        /// </summary>
        /// <param name="str">String to manipulate</param>
        /// <param name="separator">Separators used to split the string</param>
        public static IEnumerable<string> ToEnumerable(this string str, char[] separator)
        {
            ICollection<string> coll = new Collection<string>();
            string[] tmp = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in tmp)
            {
                coll.Add(s.Trim());
            }

            return coll;
        }

        /// <summary>
        /// Uses the NormalizeName method of UpperInvariantLookupNormalizer to normalize value
        /// </summary>
        /// <param name="str">Value to normalize</param>
        /// <returns>Normalized string</returns>
        public static string ToNormalized(this string str)
        {
            var t = new UpperInvariantLookupNormalizer();

            return t.NormalizeName(str);
        }

        /// <summary>
        /// Returns extension if string is recognised as path
        /// </summary>
        /// <param name="str">Element to process</param>
        /// <returns>File extension</returns>
        public static string FileExtension(this string str)
        {
            string result = string.Empty;

            if (str.IndexOf(".") > 0)
            {
                result = str.Substring(str.LastIndexOf("." + 1));
            }

            return result;
        }

        /// <summary>
        /// Generates a FileInfo element with path set to string
        /// </summary>
        /// <param name="str">Filepath</param>
        /// <returns>FileInfo element with string as path</returns>
        public static FileInfo ToFile(this string str) => new FileInfo(str);

        /// <summary>
        /// CultureInfo generated from string
        /// </summary>
        /// <param name="str">Name of culture</param>
        /// <returns>CultureInfo element with name set to string</returns>
        public static CultureInfo ToCulture(this string str) => new CultureInfo(str);

        /// <summary>
        /// Returns string as slug
        /// </summary>
        /// <param name="str">Value to process</param>
        /// <returns>The defined string as slug</returns>
        public static string Slugify(this string str)
        {
            _ = _repo.RemoveDiacritics(str.ToLower());
            _ = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            _ = Regex.Replace(str, @"\s+", " ").Trim();
            _ = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();

            return Regex.Replace(str, @"\s", "-");
        }

        /// <summary>
        /// Removes occurrences of oldValue
        /// </summary>
        /// <param name="str">String to process</param>
        /// <param name="oldValue">Value to remove</param>
        /// <returns>String without any occurrences of oldValue</returns>
        public static string Replace(this string str, string oldValue) => str.Replace(oldValue, default);
    }

    /// <summary>
    /// The transform types
    /// </summary>
    public enum TextTransformTypes
    {
        TitleCase,
        Upper,
        Lower,
        RemoveSpace,
        TitleCaseAndRemoveSpace,
        Normalized,
        None
    }

    public enum EncryptionTypes
    {
        Default,
        SHA256
    }
}
