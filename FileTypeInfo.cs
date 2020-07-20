/*
   @Date			: 19.07.2020
   @Author         : Stein Lundbeck
*/

using LundbeckConsulting.Components.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LundbeckConsulting.Components
{
    public interface IFileTypeInfo
    {
        /// <summary>
        /// The File Endings of the file type
        /// </summary>
        IEnumerable<FileEndings> Files { get; }

        /// <summary>
        /// The File Group the file belongs to
        /// </summary>
        FileGroups Group { get; }

        /// <summary>
        /// Type of file
        /// </summary>
        FileTypes FileType { get; }

        /// <summary>
        /// The Image File Ending if current file is in the Image group
        /// </summary>
        ImageFileEndings ImageFile { get; }

        /// <summary>
        /// Indicates if a File Ending exists in current collection
        /// </summary>
        /// <param name="fileEnding">Type of file ending</param>
        /// <returns>True if File Ending exists</returns>
        bool FileEndingExists(FileEndings fileEnding);

        /// <summary>
        /// Indicates if a File Ending exists in current collection
        /// </summary>
        /// <param name="fileEnding">File ending</param>
        /// <returns>True if File Ending exists</returns>
        bool FileEndingExists(string fileEnding);
    }

    /// <summary>
    /// To be a row in the collections of file information
    /// </summary>
    public sealed class FileTypeInfo : IFileTypeInfo
    {
        private readonly ICollection<FileEndings> _files = new Collection<FileEndings>();
        private readonly FileGroups _group;
        private readonly FileTypes _type;
        private readonly ImageFileEndings _img;

        /// <summary>
        /// Default element for known single file type
        /// </summary>
        /// <param name="ending">Value of file ending</param>
        /// <param name="group">Group the file belongs to</param>
        /// <param name="fileType">Type of file</param>
        public FileTypeInfo(FileEndings file, FileGroups group, FileTypes fileType) : this(new FileEndings[] { file }, group, fileType)
        {

        }


        /// <summary>
        /// Default element for multiple known file types
        /// </summary>
        /// <remarks>For files that have multiple File Endings</remarks>
        /// <param name="files">Value of multiple file endings</param>
        /// <param name="group">Group the file belongs to</param>
        /// <param name="fileType">Type of file</param>
        public FileTypeInfo(IEnumerable<FileEndings> files, FileGroups group, FileTypes fileType)
        {
            _files.AddRange(files);
            _group = group;
            _type = fileType;
            _img = ImageFileEndings.None;
        }

        /// <summary>
        /// Element for image file endings
        /// </summary>
        /// <param name="imageEnding">Image file ending</param>
        public FileTypeInfo(ImageFileEndings imageEnding)
        {
            FileEndings ending = FileEndings.Unknown;

            switch (imageEnding)
            {
                case ImageFileEndings.JointPhotographicGroup:
                    _files.AddRange(new FileEndings[] { FileEndings.JPG, FileEndings.JPEG });
                    break;

                case ImageFileEndings.TaggedImageFileFormat:
                    _files.AddRange(new FileEndings[] { FileEndings.TIF, FileEndings.TIFF });
                    break;

                case ImageFileEndings.GraphicsInterchangeFormat:
                    _files.Add(FileEndings.GIF);
                    break;

                case ImageFileEndings.Bitmap:
                    _files.Add(FileEndings.BMP);
                    break;

                case ImageFileEndings.Icon:
                    _files.Add(FileEndings.ICO);
                    break;

                case ImageFileEndings.Photoshop:
                    _files.Add(FileEndings.PSD);
                    break;

                case ImageFileEndings.PortableNetworkGraphics:
                    _files.Add(FileEndings.PNG);
                    break;

                case ImageFileEndings.ScalableVectorGraphics:
                    _files.Add(FileEndings.SVG);
                    break;
            }

            _files.Add(ending);
            _img = imageEnding;
            _group = FileGroups.Image;
            _type = FileTypes.Image;
        }

        public IEnumerable<FileEndings> Files => _files;
        public FileGroups Group => _group;
        public FileTypes FileType => _type;
        public ImageFileEndings ImageFile => _img;
        public bool FileEndingExists(FileEndings fileEnding) => _files.Contains(fileEnding);
        public bool FileEndingExists(string fileEnding) => _files.ToStrings().Exists(str => str == fileEnding);
    }
}
