using System;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.UControl.Forms.Dialog;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    /// Purpose is to define useful Dialog forms
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public class WinForms_Dialog_Simple
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
        private readonly Lamedal_WinForms _uiWindows = Lamedal_WinForms.Instance;   // Instance to UIWindows

        /// <summary>
        /// Creates a auto disappearing waits  cursor.
        /// </summary>
        /// <param name="showProgressFrm">if set to <c>true</c> [show progress FRM].</param>
        /// <returns></returns>
        public IDisposable WaitCursor(bool showProgressFrm = false)
        {
            if (showProgressFrm) return new WinForms_WaitCursor(_frmProgress);
            return new WinForms_WaitCursor();
        }
        private readonly Progress_WaitCursor_Form _frmProgress = new Progress_WaitCursor_Form();

        #region MessageBox
        /// <summary>
        /// Shows MessageBox.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <returns></returns>
        public DialogResult MessageBox_Ok(string msg, string title = "", MessageBoxButtons buttons = MessageBoxButtons.OK, 
                                            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            _uiWindows.libUI.WinForms.Tools.Form_Remove_TopMost();
            return MessageBox.Show(msg, title, buttons, icon);
        }

        /// <summary>
        /// Simple dialog form displaying 'not implemented yet' message box.
        /// </summary>
        /// <param name="methodName">The method name</param>
        public void MessageBox_NotImplementedYet(string methodName)
        {
            if (methodName == "") methodName = "This method";
            MessageBox_Ok(methodName + " is not yet implemented!");
        }

        /// <summary>
        /// Yes / No MessageBox
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public bool MessageBox_YesNo(string msg, string title = "")
        {
            _uiWindows.libUI.WinForms.Tools.Form_Remove_TopMost();
            return (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        /// <summary>
        /// Ok / Cancel MessageBox.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public bool MessageBox_OkCancel(string msg, string title = "")
        {
            _uiWindows.libUI.WinForms.Tools.Form_Remove_TopMost();
            return (MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);
        }
        #endregion


        #region File Dialogs
        /// <summary>
        /// Show File dialog.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        [STAThread]
        public bool File_Dialog(string path, out string selectedFile, enFileDialogType dialogType = enFileDialogType.FileOpen,  
                    enIOFileType filterType = enIOFileType.All, string title = "", string filter = "")
        {
            selectedFile = path;
            FileDialog dialog = null;
            if (dialogType == enFileDialogType.FileOpen)
            {
                dialog = new OpenFileDialog();
                if (title == "") title = "Open File";
            }
            else
            {
                dialog = new SaveFileDialog();
                if (title == "") title = "Save File";
            }

            File_Dialog_Setup(dialog, title, path, filterType, filter);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = dialog.FileName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Show a File dialog.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns></returns>
        public bool File_OpenDialog(string path, out string selectedFile, string title = "Open File", string filter = "", enIOFileType filterType = enIOFileType.All)
        {
            return File_Dialog(path, out selectedFile, enFileDialogType.FileOpen, filterType, title, filter);
        }

        /// <summary>
        /// Show a File dialog when button is clicked.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <returns></returns>
        public void File_Dialog_Button(Button button, enIOFileType filterType = enIOFileType.All, 
                    enFileDialogType dialogType = enFileDialogType.FileOpen)
        {
            button.Click -= File_Dialog_ButtonClick;
            button.Click += File_Dialog_ButtonClick;
            button.Tag = new stateDialog(dialogType, filterType);
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
        public bool File_Dialog_Button_Click(Button button, out string selectedFile, enIOFileType filterType = enIOFileType.All,
            enFileDialogType dialogType = enFileDialogType.FileOpen, bool updateButton = true)
        {
            if (File_Dialog(button.Text, out selectedFile, dialogType, filterType))
            {
                if (updateButton) button.Text = selectedFile;
                return true;
            }
            return false;
        }

        private void File_Dialog_ButtonClick(object sender, EventArgs e)
        {
            // Show a file dialog form when the button is pressed!
            var button = sender as Button;
            if (_lamed.Types.Is.ObjectIsNull(button, "Error: Sender must be a button")) return;

            var state = button.Tag as stateDialog;
            if (_lamed.Types.Is.ObjectIsNull(state, "Error: Button tag not defined")) return;

            string selectedFile;
            File_Dialog_Button_Click(button, out selectedFile, state.FilterType, state.DialogType);
        }

        /// <summary>
        /// Show a file save dialog.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="selectedFile">The selected file.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="title">The title.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public bool File_SaveDialog(string path, out string selectedFile,
                    enIOFileType filterType = enIOFileType.All, string title = "Save File", string filter = "")
        {
            return File_Dialog(path, out selectedFile, enFileDialogType.FileSave, filterType, title, filter);
        }

        /// <summary>
        /// Setup the file dialog.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <param name="title">The title.</param>
        /// <param name="path">The path.</param>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="filter">The filter.</param>
        private void File_Dialog_Setup(FileDialog dialog, string title, string path, enIOFileType filterType = enIOFileType.All, string filter = "")
        {
            // Setup custom file filter types
            if ((filterType & enIOFileType.All) == enIOFileType.All) FileFilter_Setup(ref filter, "All Files","*.*");
            if ((filterType & enIOFileType.UDL) == enIOFileType.UDL) FileFilter_Setup(ref filter, "UDL Files", "*.udl");
            if ((filterType & enIOFileType.Text) == enIOFileType.Text) FileFilter_Setup(ref filter, "Text Files","*.txt");
            if ((filterType & enIOFileType.Office) == enIOFileType.Office) FileFilter_Setup(ref filter, "Office Files","*.doc;*.xls;*.ppt");
            if ((filterType & enIOFileType.Image) == enIOFileType.Image) FileFilter_Setup(ref filter, "Image Files"," *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif");
            if ((filterType & enIOFileType.Video) == enIOFileType.Video) FileFilter_Setup(ref filter, "Video Files","*.wmv; *.asf;  *.avi; *.divx; *.flv; *.m4v; *.mkv; *.mov; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg;*.mpeg4; *.mpg");
            if ((filterType & enIOFileType.Video2) == enIOFileType.Video2) FileFilter_Setup(ref filter, "Video Files2","*.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.dv; *.gxf;*.mp2;*.mpeg1; *.mpeg2;*.mpv2;*.vob");
            if ((filterType & enIOFileType.Audio) == enIOFileType.Audio) FileFilter_Setup(ref filter, "Audio Files","*.mp3; *.wma");

            dialog.Title = title;
            dialog.InitialDirectory = path;
            dialog.Filter = filter;
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = false;
            dialog.AddExtension = true;
        }

        /// <summary>
        /// Setup a Filter for the file dialogs.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="filterName">Name of the filter.</param>
        /// <param name="filterDef">The filter definition.</param>
        public void FileFilter_Setup(ref string filter, string filterName = "All Files", string filterDef = "*.*")
        {
            if (filter != "") filter = filter + "|";
            filter += filterName + "|" + filterDef;
        }

        #endregion

        /// <summary>
        /// Select a Folder.
        /// </summary>
        /// <param name="selectedPath">The selected path.</param>
        /// <param name="startFolder">The start folder.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns></returns>
        public bool Folder_Select(out string selectedPath, 
                    Environment.SpecialFolder startFolder = Environment.SpecialFolder.MyComputer, string msg = "Please Select Folder")
        {
            selectedPath = "";
            var dialog = new FolderBrowserDialog();
            dialog.Description = msg;
            dialog.RootFolder = startFolder;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedPath = dialog.SelectedPath;
                return true;
            }
            return false;
        }

    }
}
