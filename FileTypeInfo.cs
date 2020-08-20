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
        IEnumerable<FileEnding> Files { get; }

        /// <summary>
        /// The File Group the file belongs to
        /// </summary>
        FileGroup Group { get; }

        /// <summary>
        /// Type of file
        /// </summary>
        FileType FileType { get; }

        /// <summary>
        /// The Image File Ending if current file is in the Image group
        /// </summary>
        ImageFileEnding ImageFile { get; }

        /// <summary>
        /// Indicates if a File Ending exists in current collection
        /// </summary>
        /// <param name="fileEnding">Type of file ending</param>
        /// <returns>True if File Ending exists</returns>
        bool FileEndingExists(FileEnding fileEnding);

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
        private readonly ICollection<FileEnding> _files = new Collection<FileEnding>();
        private readonly FileGroup _group;
        private readonly FileType _type;
        private readonly ImageFileEnding _img;

        /// <summary>
        /// Default element for known single file type
        /// </summary>
        /// <param name="ending">Value of file ending</param>
        /// <param name="group">Group the file belongs to</param>
        /// <param name="fileType">Type of file</param>
        public FileTypeInfo(FileEnding file, FileGroup group, FileType fileType) : this(new FileEnding[] { file }, group, fileType)
        {

        }


        /// <summary>
        /// Default element for multiple known file types
        /// </summary>
        /// <remarks>For files that have multiple File Endings</remarks>
        /// <param name="files">Value of multiple file endings</param>
        /// <param name="group">Group the file belongs to</param>
        /// <param name="fileType">Type of file</param>
        public FileTypeInfo(IEnumerable<FileEnding> files, FileGroup group, FileType fileType)
        {
            _files.AddRange(files);
            _group = group;
            _type = fileType;
            _img = ImageFileEnding.None;
        }

        /// <summary>
        /// Element for image file endings
        /// </summary>
        /// <param name="imageEnding">Image file ending</param>
        public FileTypeInfo(ImageFileEnding imageEnding)
        {
            FileEnding ending = FileEnding.Unknown;

            switch (imageEnding)
            {
                case ImageFileEnding.JointPhotographicGroup:
                    _files.AddRange(new FileEnding[] { FileEnding.JPG, FileEnding.JPEG });
                    break;

                case ImageFileEnding.TaggedImageFileFormat:
                    _files.AddRange(new FileEnding[] { FileEnding.TIF, FileEnding.TIFF });
                    break;

                case ImageFileEnding.GraphicsInterchangeFormat:
                    _files.Add(FileEnding.GIF);
                    break;

                case ImageFileEnding.Bitmap:
                    _files.Add(FileEnding.BMP);
                    break;

                case ImageFileEnding.Icon:
                    _files.Add(FileEnding.ICO);
                    break;

                case ImageFileEnding.Photoshop:
                    _files.Add(FileEnding.PSD);
                    break;

                case ImageFileEnding.PortableNetworkGraphics:
                    _files.Add(FileEnding.PNG);
                    break;

                case ImageFileEnding.ScalableVectorGraphics:
                    _files.Add(FileEnding.SVG);
                    break;
            }

            _files.Add(ending);
            _img = imageEnding;
            _group = FileGroup.Image;
            _type = FileType.Image;
        }

        public IEnumerable<FileEnding> Files => _files;
        public FileGroup Group => _group;
        public FileType FileType => _type;
        public ImageFileEnding ImageFile => _img;
        public bool FileEndingExists(FileEnding fileEnding) => _files.Contains(fileEnding);
        public bool FileEndingExists(string fileEnding) => _files.ToStrings().Exists(str => str == fileEnding);
    }
}
