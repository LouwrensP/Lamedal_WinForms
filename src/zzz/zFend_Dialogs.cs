using System;
using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;

namespace Lamedal_UIWinForms.zzz
{
    /// <summary>
    /// Dialogs shortcuts
    /// </summary>
    /// <code>CTI_MLink;</code>
    public static class zFend_Dialogs
    {
        /// <summary>
        /// The dialog .
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public static zFend_DialogsX zDialog(this string msg)
        {
            return new zFend_DialogsX(msg);
        }

        /// <summary>
        /// The dialog .
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static zFend_FileDialogX zDialogFile(this string path)
        {
            return new zFend_FileDialogX(path);
        }

        /// <summary>
        /// Show a File dialog when button is clicked.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <returns></returns>
        public static void zFile_Dialog_Button(this Button button, enDialog_FileIOType filterType = enDialog_FileIOType.All,
            enDialog_FileIO dialogType = enDialog_FileIO.FileOpen)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.File_Dialog_Button(button, filterType, dialogType);
        }

        /// <summary>
        /// Show a File dialog when button is clicked.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <param name="updateButton">if set to <c>true</c> [update button].</param>
        /// <returns></returns>
        public static bool zFile_Dialog_Button_Click(this Button button, out string selectedFile,
            enDialog_FileIOType filterType = enDialog_FileIOType.All,
            enDialog_FileIO dialogType = enDialog_FileIO.FileOpen, bool updateButton = true)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.File_Dialog_Button_Click(button, out selectedFile, filterType, dialogType, updateButton);
        }

        ///// <summary>
        ///// Dumps the specified object properties.
        ///// </summary>
        ///// <param name="Object">The Object.</param>
        ///// <param name="indentSize">Size of the indent.</param>
        ///// <param name="maxLength">The maximum length.</param>
        ///// <param name="maxItemCount">The maximum item count2.</param>
        ///// <returns>System.String.</returns>
        //public static string zzObjectProperties_AsStr(this object Object, int indentSize = 2, int maxLength = 1000, int maxItemCount = 20)
        //{
        //    return Lamedal_WinForms.Instance.lib.dotNet.Stream.StrFormated_FromObject(Object, indentSize, maxLength, maxItemCount);
        //}

        /// <summary>
        /// Function to show a waitcursor dialog progress from the message string.
        /// </summary>
        /// <param name="showProgressFrm">if set to <c>true</c> [show progress FRM].</param>
        /// <returns>
        /// IDisposable
        /// </returns>
        public static IDisposable zWaitCursor(this bool showProgressFrm)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.WaitCursor(showProgressFrm);
        }

    }

    /// <summary>
    /// Dialogs shortcuts
    /// </summary>
    public sealed class zFend_DialogsX
    {
        private readonly string _msg;
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib

        /// <summary>
        /// Initializes a new instance of the <see cref="zFend_DialogsX"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public zFend_DialogsX(string msg)
        {
            _msg = msg;
        }

        /// <summary>
        /// Shows MessageBox.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public DialogResult Ok(string title, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_Ok(_msg, title, buttons, icon);
        }

        /// <summary>
        /// Yes / No MessageBox
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public bool MessageBox_YesNo(string title = "")
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_YesNo(_msg, title);
        }

        /// <summary>
        /// Ok / Cancel MessageBox.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public bool MessageBox_OkCancel(string title = "")
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.MessageBox_OkCancel(_msg, title);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public string Memo(string title = "Input")
        {
            return IamWindows.libUI.WinForms.Dialogs.Memo(_msg, title);
        }

        /// <summary>
        /// Inputs dialog box.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="result">The result.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public DialogResult InputBox(string msg, ref string result,
            string title = "", MessageBoxButtons buttons = MessageBoxButtons.OKCancel)
        {
            return IamWindows.libUI.WinForms.Dialogs.Inputbox(msg, ref result, title, buttons);
        }
    }

    public sealed class zFend_FileDialogX
    {
        private readonly string _path;

        public zFend_FileDialogX(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Show File dialog.
        /// </summary>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public bool File_Dialog(out string selectedFile,
            enDialog_FileIO dialogType = enDialog_FileIO.FileOpen,
            enDialog_FileIOType filterType = enDialog_FileIOType.All, string title = "", string filter = "")
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.File_Dialog(_path, out selectedFile, dialogType, filterType, title, filter);
        }

        /// <summary>
        /// Show a file open dialog.
        /// </summary>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns></returns>
        public bool File_OpenDialog(out string selectedFile, string title = "Open File", string filter = "", enDialog_FileIOType filterType = enDialog_FileIOType.All)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.File_OpenDialog(_path, out selectedFile, title: title, filter: filter, filterType: filterType);
        }

        /// <summary>
        /// Show a file save dialog.
        /// </summary>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public bool File_SaveDialog(out string selectedFile,
            enDialog_FileIOType filterType = enDialog_FileIOType.All, string title = "Save File", string filter = "")
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Dialog_Simple.File_SaveDialog(_path, out selectedFile, filterType, title, filter);
        }
    }
    
}
