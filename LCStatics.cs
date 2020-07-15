/*
    @Date			              : 11.07.2020
    @Author                       : Stein Lundbeck
*/

namespace LundbeckConsulting.Components
{
    public static class LCStatics
    {

    }

    /// <summary>
    /// Known file type prefixes
    /// </summary>
    public enum FilePrefixes
    {
        None,
        Style,
        Script,
        Image,
        Document,
        RazorView,
        SASS,
        Resource,
        CSharp
    }

    /// <summary>
    /// Known readable document types
    /// </summary>
    public enum DocumentTypes
    {
        Unknown,
        PDF,
        DOCX,
        ODT,
        TXT,
        RTF,
        MK
    }

    /// <summary>
    /// Common file types
    /// </summary>
    public enum FileTypes
    {
        None,
        Image,
        Style,
        JavaScript,
        PDF,
        Text,
        View,
        Docx,
        OpenDocument,
        RichText,
        Markdown,
        SASS
    }
}
