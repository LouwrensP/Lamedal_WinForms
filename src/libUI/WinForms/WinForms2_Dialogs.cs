using System;
using System.Windows.Forms;
using Lamedal_UIWinForms.UControl;
using Lamedal_UIWinForms.UControl.Forms.Dialog;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    ///  Show Dialogs
    /// </summary>
    /// <code>CTI;</code>
    public sealed class WinForms2_Dialogs : WinForms_Dialog_Simple
    {
        private Dialog_Memo frmDialog;
        private Dialog_InputBox frmInputBox;

        /// <summary>Show dialog</summary>
        public DialogResult Inputbox(string msg, ref string result,
            string title = "", MessageBoxButtons buttons = MessageBoxButtons.OKCancel)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Tools.Form_Remove_TopMost();
            var frmInputbox = new Dialog_InputBox();

            return frmInputbox.Show_Dialog(msg, ref result, title);
        }

        /// <summary>Shows a simplified memo dialog.</summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public string Memo(string msg, string title)
        {
            if (frmDialog == null) frmDialog = new Dialog_Memo();
            return frmDialog.Show_Dialog(msg, title);
        }

        /// <summary>Shows a fully customised memo dialog dialog.</summary>
        /// <param name="lines">The lines.</param>
        /// <param name="outLines">The out lines.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public DialogResult Memo(string[] lines, out string[] outLines, string title)
        {
            if (frmDialog == null) frmDialog = new Dialog_Memo();
            return frmDialog.Show_Dialog(lines, out outLines, title);
        }

        /// <summary>
        /// Setup file watcher tool from the folder.
        /// </summary>
        /// <param name="folderToWatch">The folder to watch</param>
        /// <param name="syncroComponent">The syncro component</param>
        /// <param name="includeSubFolders">Include sub folders indicator. Default value = false.</param>
        /// <param name="watchFolders">Watch folders indicator. Default value = false.</param>
        /// <param name="notifyHandler">The notify handler setting. Default value = null.</param>
        /// <param name="ignoreFilter">The ignore filter optional array</param>
        /// <returns>IO_FileWatcher. This must be set as private field</returns>
        public IO_FileWatcher FileWatcher(string folderToWatch, Control syncroComponent, bool includeSubFolders = false,
            bool watchFolders = false, EventHandler notifyHandler = null, params string[] ignoreFilter)
        {
            var result = new IO_FileWatcher(folderToWatch, syncroComponent, includeSubFolders, watchFolders, notifyHandler, ignoreFilter);
            return result;
        }
    }
}
