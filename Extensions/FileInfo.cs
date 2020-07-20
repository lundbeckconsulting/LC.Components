/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;
using System.IO;

namespace LundbeckConsulting.Components.Extensions
{
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Indicates if the specified file has matching extension
        /// </summary>
        /// <param name="file">File to validate</param>
        /// <param name="extension">Extension to match</param>
        /// <returns>True if supplied extension and file entesion is equal</returns>
        public static bool ExtensionEqual(this FileInfo file, string extension)
        {
            bool result = file.ExtensionCustom().EndsWith(extension, StringComparison.OrdinalIgnoreCase);

            return result;
        }

        /// <summary>
        /// Removes the leading punctuation mark from the file extension
        /// </summary>
        /// <param name="file">File info to process extension from</param>
        /// <returns>Extesion name without leading punctuation mark as upper case</returns>
        public static string ExtensionCustom(this FileInfo file)
        {
            string result = string.Empty;

            if (file.Extension.Length > 0)
            {
                result = file.Extension.Substring(1).ToUpper();
            }

            return result;
        }
    }
}
