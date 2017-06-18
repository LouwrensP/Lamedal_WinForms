using System;
using System.Runtime.InteropServices;

namespace Lamedal_UIWinForms.libUI.Win32
{
    /// <summary>
    /// Contains the native Win32 functions.
    /// </summary>
    public static class shell32
    {
        internal const uint shell32_IconHandle = 0x100;
        internal const uint shell32_LargeIconHandle = 0x0;
        internal const uint shell32_SmallIconHandle = 0x1;

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </summary>
        /// <param name="pszPath">A pointer to a null-terminated string of maximum length MAX_PATH that contains the path and file name. Both absolute and relative paths are valid.</param>
        /// <param name="dwFileAttributes">A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h).</param>
        /// <param name="psfi">The address of a SHFILEINFO structure to receive the file information.</param>
        /// <param name="cbSizeFileInfo">The size, in bytes, of the SHFILEINFO structure pointed to by the psfi parameter.</param>
        /// <param name="uFlags">The flags that specify the file information to retrieve.</param>
        /// <returns>Nonzero if successful, or zero otherwise.</returns>
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath,uint dwFileAttributes,ref shell32_FileInfo psfi,uint cbSizeFileInfo,enIconShell32Sizes uFlags);
    }
}
