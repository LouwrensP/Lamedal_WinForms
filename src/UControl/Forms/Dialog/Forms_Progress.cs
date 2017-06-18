using System.Windows.Forms;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    public partial class Form_Progress : Form
    {
        private static int _frmProgressItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form_Progress"/> class.
        /// </summary>
        private Form_Progress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The close progress method.
        /// </summary>
        public void Progress_Close()
        {
            this.Close();
            Application.UseWaitCursor = false;
        }

        /// <summary>
        /// Continue to the next progress step.
        /// </summary>
        public void Progress_Next()
        {
            _frmProgressItem++;
            if (_frmProgressItem < listItems.Items.Count)
                listItems.SetItemChecked(_frmProgressItem, true);
            else Progress_Close();
        }

        /// <summary>
        /// Function to define a progress form to show progress of a long operation.
        /// </summary>
        /// <param name="heading">The heading</param>
        /// <param name="items">The items array</param>
        /// <returns>Form_Progress</returns>
        public static Form_Progress Create(string heading, params string[] items)
        {
            // Setup the form
            var frmProgress = new Form_Progress();
            _frmProgressItem = -1;
            frmProgress.Text = heading;
            frmProgress.Show();
            frmProgress.TopMost = true;
            frmProgress.listItems.CheckOnClick = true;
            frmProgress.listItems.SelectionMode = SelectionMode.One;
            frmProgress.listItems.ThreeDCheckBoxes = true;
            //Add the items
            foreach (string item in items)
            {
                frmProgress.listItems.Items.Add(item);
            }

            Application.UseWaitCursor = true;
            Application.DoEvents();
            return frmProgress;
        }

    }
}
