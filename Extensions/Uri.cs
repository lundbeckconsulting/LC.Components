/*
    @Date			 : 15.07.2020
    @Author			 : Stein Lundbeck
*/

using System;
using System.Text;

namespace LundbeckConsulting.Components.Extensions
{
    public static class UriExtensions
    {
        /// <summary>
        /// Creates a relative URI based on Uri and appends Block
        /// </summary>
        /// <returns>An URI based on specified Uri and Block</returns>
        public static Uri ToRelativeUri(this Uri uri, string block) => ToRelativeUri(uri, new string[1] { block });

        /// <summary>
        /// Creates a relative URI based on Uri and appends items in Blocks
        /// </summary>
        /// <returns>Created URI based on specified Uri and Blocks</returns>
        public static Uri ToRelativeUri(this Uri uri, params string[] blocks)
        {
            StringBuilder url = new StringBuilder();
            int i = 0;

            foreach (string s in blocks)
            {
                string tmp = TrimEnd(s);

                if (!tmp.Null())
                {
                    if (i == 0)
                    {
                        if (tmp.Substring(0, 1) != "/")
                        {
                            url.Append("/");
                        }
                    }
                    else
                    {
                        url.Append("/");
                    }

                    url.Append(tmp);

                    i++;
                }
            }

            return new Uri(url.ToString(), UriKind.Relative);
        }

        /// <summary>
        /// Removes '\\' and '/' from end of string
        /// </summary>
        /// <returns>The supplied string with '\\' and '/' removed from end</returns>
        private static string TrimEnd(string s) => s.TrimEnd(new char[] { '\\', '/' });

        /// <summary>
        /// Removes a string from the active string
        /// </summary>
        /// <param name="remove">String to remove</param>
        /// <returns>The string without defined string</returns>
        public static string Remove(this string str, string remove) => str.Remove(new string[1] { remove });

        /// <summary>
        /// Removes the strings in remove from the active string
        /// </summary>
        /// <param name="remove">Strings to remove</param>
        /// <returns>The string without the strings in remove</returns>
        public static string Remove(this string str, params string[] remove)
        {
            string result = str;

            foreach (string s in remove)
            {
                result = result.Replace(s, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Adds an item to the querystring of an Uri
        /// </summary>
        /// <param name="uri">Uri to process</param>
        /// <param name="name">Name of querystring value</param>
        /// <param name="value">Value of querystring element</param>
        /// <returns>Original uri with new element added to the querystring</returns>
        public static Uri AddToQueryString(this Uri uri, string name, string value)
        {
            string tmp = uri.AbsoluteUri;
            tmp += uri.GetComponents(UriComponents.Query, UriFormat.UriEscaped).Length > 0 ? "&" : "?";
            tmp += $"{name}={value}";

            return new Uri(tmp);            
        }

        /// <summary>
        /// Removes www from Uri if oresent
        /// </summary>
        /// <param name="uri">Uri to process</param>
        /// <returns>Uri to root domain if host equals www</returns>
        public static Uri ToRoot(this Uri uri)
        {
            StringBuilder url = new StringBuilder();
            url.Append(uri.Scheme + "://");

            if (uri.Host.ToString().StartsWith("www"))
            {
                url.Append(uri.Host.ToString().Substring(4));
            }
            else
            {
                url.Append(uri.Host.ToString());
            }

            url.Append(uri.PathAndQuery);

            return new Uri(url.ToString());
        }

        /// <summary>
        /// Replaces scheme http value with https
        /// </summary>
        /// <param name="uri">Uri to process</param>
        /// <param name="directToRoot">If true Uri.ToRootUri is invoked</param>
        /// <returns>If scheme equals http it's replaced with https</returns>
        public static Uri ToHTTPS(this Uri uri, bool directToRoot = true)
        {
            StringBuilder url = new StringBuilder();
            url.Append("https://");

            if (directToRoot)
            {
                url.Append(uri.ToRoot().Host);
            }

            url.Append(uri.PathAndQuery);

            return new Uri(url.ToString());
        }
    }
}
