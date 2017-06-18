using System;
using System.Runtime.InteropServices;

namespace Lamedal_UIWinForms.libUI.Win32
{
    /// <summary>
    /// Contains information about a file object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct shell32_FileInfo
    {
        public IntPtr hIcon;                //  A handle to the icon that represents the file.
        public readonly IntPtr iIcon;       // The index of the icon image within the system image list.
        public readonly uint dwAttributes;  // An array of values that indicates the attributes of the file object.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public readonly string szDisplayName;  // A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon representing the file.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public readonly string szTypeName;  // A string that describes the type of file.
    };
}