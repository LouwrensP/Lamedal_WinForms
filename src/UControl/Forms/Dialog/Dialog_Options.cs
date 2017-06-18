using System;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Events;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    public partial class Dialog_Options : Form
    {
        private int _Height = 170;

        public Dialog_Options()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create a dailog form.
        /// </summary>
        /// <param name="items">The items array</param>
        /// <returns></returns>
        public static string Create(params string[] items)
        {
            string item;
            Create(out item, items);
            return item;
        }

        /// <summary>
        /// Create a dailog form.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="items">The items array</param>
        /// <returns></returns>
        public static bool Create(out string item, params string[] items)
        {
            var frmDialog = new Dialog_Options();
            frmDialog.TopMost = true;
            items.zTo_IList(frmDialog.listBox_Items.Items);
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.Width(frmDialog.listBox_Items, frmDialog);

            frmDialog.listBox_Items.SelectedIndex = 0;
            int height = frmDialog._Height;

            if (items.Length > 5)
            {
                int total = items.Length - 5;
                for (int tt = 0; tt < total; tt++)
                {
                    height += 20;
                }
            }
            frmDialog.Height = height;
            DialogResult dialogResult = frmDialog.ShowDialog();
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes)
            {
                item = frmDialog.listBox_Items.Text;
                return true;
            }
            item = "";
            return false;
        }

        

        private void button_Standard1_Event_OnClick(object sender, evStandardButtons_EventArgs e)
        {
            //if (e.Button_Type == StandardButtons.Ok) this.DialogResult = DialogResult.OK;
        }

        private void listBox_Items_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void listBox_Items_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') this.DialogResult = DialogResult.OK;
        }
    }
}
