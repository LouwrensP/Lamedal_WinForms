using System.Windows.Forms;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    public partial class Dialog_InputBox : Form
    {
        public Dialog_InputBox()
        {
            InitializeComponent();

            buttonOK = button_Standard1.Ctrl_OkButton;
        }

        private void Dialog_Inputbox_Load(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Show the dialog.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="inputResult">The input result.</param>
        /// <param name="heading">The heading.</param>
        /// <returns></returns>
        public DialogResult Show_Dialog(string question, ref string inputResult, string heading = "Please provide input!")
        {
            this.Text = heading;
            labelQuestion.Text = question;
            textboxInput.Text = inputResult;
            var result = this.ShowDialog();
            inputResult = textboxInput.Text;
            return result;
        }
    }
}
