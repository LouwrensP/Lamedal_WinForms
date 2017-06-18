using System;

namespace Lamedal_UIWinForms.Enumerals
{
    /// <summary>
    /// IO file types
    /// </summary>
    [Flags]
    public enum enIOFileType
    {
        /// <summary>
        /// All file types
        /// </summary>
        All,
        /// <summary>
        /// The text files
        /// </summary>
        Text,
        /// <summary>
        /// The image fi;es
        /// </summary>
        Image,
        /// <summary>
        /// The audio files
        /// </summary>
        Audio,
        /// <summary>
        /// The video files
        /// </summary>
        Video,
        /// <summary>
        /// The udl files
        /// </summary>
        UDL,
        /// <summary>
        /// The office files
        /// </summary>
        Office,
        /// <summary>
        /// The video files
        /// </summary>
        Video2
    }

}