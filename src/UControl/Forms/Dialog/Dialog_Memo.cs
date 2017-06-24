using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.domain.Events;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    /// <summary>
    /// Dialog to show a memo text field
    /// </summary>
    public partial class Dialog_Memo : Form
    {
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib

        /// <summary>
        /// Initializes a new instance of the <see cref="Dialog_Memo" /> class.
        /// </summary>
        public Dialog_Memo()
        {
            InitializeComponent();
        }        

        private void standardButtons1_Event_OnClick(object sender, onStandardButtons_EventArgs e)
        {
            switch (e.Button_Type)
            {
                case enControl_StandardButtons.Ok: this.DialogResult = DialogResult.OK; break;
                case enControl_StandardButtons.Cancel: this.DialogResult = DialogResult.Cancel; break;
                case enControl_StandardButtons.Copy2Clipboard: Lines.Text.zClipboard_CopyStrTo(); break;
            }
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public string Show_Dialog(string msg, string title)
        {
            this.Text = title;
            this.Lines.Text = msg;
            this.TopMost = true;
            if (this.ShowDialog() == DialogResult.OK) return Lines.Text;
            return msg;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="outLines">The out lines.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public DialogResult Show_Dialog(string[] lines, out string[] outLines, string title)
        {
            this.Text = title;
            this.Lines.Lines = lines;
            this.TopMost = true;
            this.ShowDialog();
            outLines = this.Lines.Lines;
            return this.DialogResult;
        }
    }
}
