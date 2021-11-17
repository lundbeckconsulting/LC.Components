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
        public const string LCLogoPath = "http://shared.lundbeckconsulting.com/image/lc-logo-md.png";
        public const string CreatorLogoPath = "http://shared.lundbeckconsulting.com/image/creator-logo-md.png";

        /// <summary>
        /// The document and image file endings database
        /// </summary>
        private readonly static ICollection<IFileTypeInfo> FileTypeDB = new Collection<IFileTypeInfo>()
            {
                new FileTypeInfo(FileEnding.CSS, FileGroup.Code, FileType.Style),
                new FileTypeInfo(FileEnding.SCSS, FileGroup.Code, FileType.SASS),
                new FileTypeInfo(FileEnding.JS, FileGroup.Code, FileType.JavaScript),
                new FileTypeInfo(FileEnding.CSHTML, FileGroup.Code, FileType.View),
                new FileTypeInfo(FileEnding.CS, FileGroup.Code, FileType.CSharp),
                new FileTypeInfo(FileEnding.RESX, FileGroup.Resource, FileType.XML),
                new FileTypeInfo(FileEnding.PDF, FileGroup.Document, FileType.PDF),
                new FileTypeInfo(FileEnding.DOCX, FileGroup.Document, FileType.Docx),
                new FileTypeInfo(FileEnding.ODT, FileGroup.Document, FileType.OpenDocument),
                new FileTypeInfo(FileEnding.FODT, FileGroup.Document, FileType.OpenDocument),
                new FileTypeInfo(FileEnding.MD, FileGroup.Document, FileType.Markdown),
                new FileTypeInfo(FileEnding.RTF, FileGroup.Document, FileType.RichText),
                new FileTypeInfo(FileEnding.TXT, FileGroup.Document, FileType.Text),
                new FileTypeInfo(ImageFileEnding.JointPhotographicGroup),
                new FileTypeInfo(ImageFileEnding.GraphicsInterchangeFormat),
                new FileTypeInfo(ImageFileEnding.PortableNetworkGraphics),
                new FileTypeInfo(ImageFileEnding.ScalableVectorGraphics),
                new FileTypeInfo(ImageFileEnding.Bitmap),
                new FileTypeInfo(ImageFileEnding.Icon),
                new FileTypeInfo(ImageFileEnding.Photoshop),
                new FileTypeInfo(ImageFileEnding.TaggedImageFileFormat)
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
        public static IFileTypeInfo GetFileInfo(FileEnding fileEnding) => LCStatics.FileTypeDB.Single(inf => inf.Files.Contains(fileEnding));

        /// <summary>
        /// Gets a collection of IFileTypeInfo elements which has equal FileGroup
        /// </summary>
        /// <param name="fileGroup">Type of file file group</param>
        /// <returns>IFileTypeInfo element for the defined FileGtoup</returns>
        public static IEnumerable<IFileTypeInfo> GetFilesInfo(FileGroup fileGroup) => LCStatics.FileTypeDB.Where(inf => inf.Group == fileGroup);

        /// <summary>
        /// Gets a collection of IFileTypeInfo elements which has equal FileType
        /// </summary>
        /// <param name="fileType">Type of file</param>
        /// <returns>IFileTypeInfo element for the defined FileTypes</returns>
        public static IEnumerable<IFileTypeInfo> GetFilesInfo(FileType fileType) => LCStatics.FileTypeDB.Where(inf => inf.FileType == fileType);

        /// <summary>
        /// Gets all the File Info for images
        /// </summary>
        /// <returns>A list of all File Info entries that is an image</returns>
        public static IEnumerable<IFileTypeInfo> GetImageInfos() => LCStatics.FileTypeDB.Where(inf => inf.Group == FileGroup.Image);

        /// <summary>
        /// Get the File Type element with Image File Ending equal to defined ending
        /// </summary>
        /// <param name="imageEnding">Type of image ending</param>
        /// <returns>IfileTypeInfo element for defined Image Ending</returns>
        public static IFileTypeInfo GetImageInfo(ImageFileEnding imageEnding) => LCStatics.FileTypeDB.Single(inf => inf.ImageFile == imageEnding);
    }

    /// <summary>
    /// Known document types
    /// </summary>
    public enum FileEnding
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
    public enum ImageFileEnding
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
    public enum FileType
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
    public enum FileGroup
    {
        None = -1,
        Code = 0,
        Resource = 1,
        Image = 2,
        Document = 3
    }
}
