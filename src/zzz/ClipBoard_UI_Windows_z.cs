
namespace Lamedal_UIWinForms.zzz
{
    /// <code>CTI_MLink;</code>
    public static class ClipBoard_UI_Windows_z
    {
        
        /// <summary>
        /// Copy string to the Clipboard.
        /// </summary>
        /// <param name="copyStr">The copy string.</param>
        public static void zClipboard_CopyStrTo(this string copyStr)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Tools.Clipboard_CopyStrTo(copyStr);
        }

        /// <summary>
        /// Get string from the Clipboard.
        /// </summary>
        /// <returns></returns>
        public static string zClipboard_GetStrFrom(this string notUsed)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Tools.Clipboard_GetStrFrom();
        }
    }
}
