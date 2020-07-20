/*
    @Date			              : 11.07.2020
    @Author                       : Stein Lundbeck
*/

using LundbeckConsulting.Components.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace LundbeckConsulting.Components
{
    /// <summary>
    /// Contains different values, properties and function for LC Component elements
    /// </summary>
    public static class LCStatics
    {
        /// <summary>
        /// The document and image file endings database
        /// </summary>
        private readonly static ICollection<IFileTypeInfo> FileTypeDB = new Collection<IFileTypeInfo>()
            {
                new FileTypeInfo(FileEndings.CSS, FileGroups.Code, FileTypes.Style),
                new FileTypeInfo(FileEndings.SCSS, FileGroups.Code, FileTypes.SASS),
                new FileTypeInfo(FileEndings.JS, FileGroups.Code, FileTypes.JavaScript),
                new FileTypeInfo(FileEndings.CSHTML, FileGroups.Code, FileTypes.View),
                new FileTypeInfo(FileEndings.CS, FileGroups.Code, FileTypes.CSharp),
                new FileTypeInfo(FileEndings.RESX, FileGroups.Resource, FileTypes.XML),
                new FileTypeInfo(FileEndings.PDF, FileGroups.Document, FileTypes.PDF),
                new FileTypeInfo(FileEndings.DOCX, FileGroups.Document, FileTypes.Docx),
                new FileTypeInfo(FileEndings.ODT, FileGroups.Document, FileTypes.OpenDocument),
                new FileTypeInfo(FileEndings.FODT, FileGroups.Document, FileTypes.OpenDocument),
                new FileTypeInfo(FileEndings.MD, FileGroups.Document, FileTypes.Markdown),
                new FileTypeInfo(FileEndings.RTF, FileGroups.Document, FileTypes.RichText),
                new FileTypeInfo(FileEndings.TXT, FileGroups.Document, FileTypes.Text),
                new FileTypeInfo(ImageFileEndings.JointPhotographicGroup),
                new FileTypeInfo(ImageFileEndings.GraphicsInterchangeFormat),
                new FileTypeInfo(ImageFileEndings.PortableNetworkGraphics),
                new FileTypeInfo(ImageFileEndings.ScalableVectorGraphics),
                new FileTypeInfo(ImageFileEndings.Bitmap),
                new FileTypeInfo(ImageFileEndings.Icon),
                new FileTypeInfo(ImageFileEndings.Photoshop),
                new FileTypeInfo(ImageFileEndings.TaggedImageFileFormat)
            };

        /// <summary>
        /// Gets the IFileTypeInfo element which has equal FileEnding
        /// </summary>
        /// <param name="filename">Filename or just file ending</param>
        /// <returns>IFileTypeInfo element for file ending</returns>
        public static IFileTypeInfo GetFileInfo(string filename)
        {
            FileInfo fi = new FileInfo(filename);

            return LCStatics.FileTypeDB.Single(inf => inf.Files.ToStrings().Contains(fi.ExtensionCustom()));
        }

        /// <summary>
        /// Gets the IFileTypeInfo element which has equal DocumentFileEndings
        /// </summary>
        /// <param name="fileEnding">Type of file endings</param>
        /// <returns>IFileTypeInfo element for the defined DocumentFileEndings</returns>
        public static IFileTypeInfo GetFileInfo(FileEndings fileEnding) => LCStatics.FileTypeDB.Single(inf => inf.Files.Contains(fileEnding));

        /// <summary>
        /// Gets a collection of IFileTypeInfo elements which has equal FileGroup
        /// </summary>
        /// <param name="fileGroup">Type of file file group</param>
        /// <returns>IFileTypeInfo element for the defined FileGtoup</returns>
        public static IEnumerable<IFileTypeInfo> GetFilesInfo(FileGroups fileGroup) => LCStatics.FileTypeDB.Where(inf => inf.Group == fileGroup);

        /// <summary>
        /// Gets a collection of IFileTypeInfo elements which has equal FileType
        /// </summary>
        /// <param name="fileType">Type of file</param>
        /// <returns>IFileTypeInfo element for the defined FileTypes</returns>
        public static IEnumerable<IFileTypeInfo> GetFilesInfo(FileTypes fileType) => LCStatics.FileTypeDB.Where(inf => inf.FileType == fileType);

        /// <summary>
        /// Gets all the File Info for images
        /// </summary>
        /// <returns>A list of all File Info entries that is an image</returns>
        public static IEnumerable<IFileTypeInfo> GetImageInfos() => LCStatics.FileTypeDB.Where(inf => inf.Group == FileGroups.Image);

        /// <summary>
        /// Get the File Type element with Image File Ending equal to defined ending
        /// </summary>
        /// <param name="imageEnding">Type of image ending</param>
        /// <returns>IfileTypeInfo element for defined Image Ending</returns>
        public static IFileTypeInfo GetImageInfo(ImageFileEndings imageEnding) => LCStatics.FileTypeDB.Single(inf => inf.ImageFile == imageEnding);
    }

    /// <summary>
    /// Known document types
    /// </summary>
    public enum FileEndings
    {
        Unknown = -1,
        PDF = 0,
        DOCX = 1,
        ODT = 2,
        FODT = 3,
        TXT = 4,
        RTF = 5,
        MD = 6,
        CSS = 7,
        JS = 8,
        CSHTML = 9,
        CS = 10,
        RESX = 11,
        SCSS = 12,
        JPG = 13,
        JPEG = 14,
        GIF = 15,
        BMP = 16,
        SVG = 17,
        PNG = 18,
        ICO = 19,
        PSD = 20,
        TIF = 21,
        TIFF = 22
    }

    /// <summary>
    /// Most common file ending for image files
    /// </summary>
    public enum ImageFileEndings
    {
        None = -1,
        JointPhotographicGroup = 0, //JPG/JPEG
        GraphicsInterchangeFormat = 1, //GIF
        PortableNetworkGraphics = 2, //PNG
        ScalableVectorGraphics = 3, //SVG
        Bitmap = 4, //BMP
        Icon = 5, //ICO
        Photoshop = 6, //PSD
        TaggedImageFileFormat = 7 //TIF/TIFF
    }

    /// <summary>
    /// Common file types
    /// </summary>
    public enum FileTypes
    {
        None = -1,
        Image = 0,
        Style = 1,
        JavaScript = 2,
        PDF = 3,
        Text = 4,
        View = 5,
        Docx = 6,
        OpenDocument = 7,
        RichText = 8,
        Markdown = 9,
        SASS = 10,
        CSharp = 11,
        XML = 12
    }

    /// <summary>
    /// Most common groups of files
    /// </summary>
    public enum FileGroups
    {
        None = -1,
        Code = 0,
        Resource = 1,
        Image = 2,
        Document = 3
    }
}
