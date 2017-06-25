
using System;
using System.Runtime.CompilerServices;
using LamedalCore;

namespace Lamedal_UIWinForms.zzz
{
    /// <code>CTI_MLink;</code>
    public static class UI_Windows_System
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

        /// <summary>Simple logger. Logs the specified message.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        internal static string zLogLibraryMsg(this Exception ex,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null,
            [CallerFilePath] string filepath = "")
        {
            return LamedalCore_.Instance.Logger.LogLibraryMsg(ex, lineNumber, caller, filepath);
        }
    }
}
