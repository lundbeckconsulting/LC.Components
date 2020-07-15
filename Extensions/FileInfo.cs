/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System.Collections.Generic;
using System.IO;

namespace LundbeckConsulting.Components.Extensions
{
    public static class FileInfoExtensions
    {
        private static IDictionary<string, string> _extensions = new Dictionary<string, string>()
        {
            { "Stylesheet", "CSS" },
            { "Script", "JS" },
            { "RazorView", "CSHTML" },
            { "CSharp", "CS" },
            { "Resource", "RESX" },
            { "SASS", "SCSS" },
            { "Image", "JPG, JPEG, GIF, PNG, SVG" },
            { "Document", $"{DocumentTypes.PDF}, {DocumentTypes.DOCX}, {DocumentTypes.TXT}, {DocumentTypes.RTF}, {DocumentTypes.ODT}, {DocumentTypes.MK}" }
        };

        /// <summary>
        /// Indicates if the specified file has matching extension
        /// </summary>
        /// <param name="file">File to validate</param>
        /// <param name="extension">Extension to match</param>
        /// <returns>True if supplied extension and file entesion is equal</returns>
        public static bool ExtensionEqual(this FileInfo file, string extension)
        {
            bool result = file.ExtensionName().Equal(extension);

            return result;
        }

        /// <summary>
        /// Removes the leading punctuation mark from the file extension
        /// </summary>
        /// <param name="file">File info to process extension from</param>
        /// <returns>Extesion name without leading punctuation mark as upper case</returns>
        public static string ExtensionName(this FileInfo file)
        {
            string result = string.Empty;

            if (file.Extension.Length > 0)
            {
                result = file.Extension.Substring(1).ToUpper();
            }

            return result;
        }

        /// <summary>
        /// Indicates if file is a image
        /// </summary>
        /// <returns>True if file extension is a known image extension</returns>
        public static bool IsImage(this FileInfo file) => _extensions["Image"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file a readable document
        /// </summary>
        /// <returns>True if file extension is a known readable document</returns>
        public static bool IsDocument(this FileInfo file) => _extensions["Document"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicate if file is a stylesheet
        /// </summary>
        /// <returns>True if file extension equals CSS</returns>
        public static bool IsStylesheet(this FileInfo file) => _extensions["Stylesheet"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file is a script file
        /// </summary>
        /// <returns>True if file extension equals JS</returns>
        public static bool IsScript(this FileInfo file) => _extensions["Script"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file is a razor view
        /// </summary>
        /// <returns>True if file extension is CSHTML</returns>
        public static bool IsRazorView(this FileInfo file) => _extensions["RazorView"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file is a c# file
        /// </summary>
        /// <returns>True if file extension is CS</returns>
        public static bool IsCSharp(this FileInfo file) => _extensions["CSharp"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file is a resource file
        /// </summary>
        /// <returns>True if file extension is RESX</returns>
        public static bool IsResource(this FileInfo file) => _extensions["Resource"].Contains(file.ExtensionName());

        /// <summary>
        /// Indicates if file is a SASS file
        /// </summary>
        /// <returns>True if file extension is SCSS</returns>
        public static bool IsSASS(this FileInfo file) => _extensions["SASS"].Contains(file.ExtensionName());
    }
}
