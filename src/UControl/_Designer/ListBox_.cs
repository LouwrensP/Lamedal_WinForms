using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [Description("This control show a ListBox")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(UControl_Interface_Designer))] // Link the designer   
    [Docking(DockingBehavior.Ask)] // Dock in parent control
    [ToolboxBitmap(typeof(ListBox))]
    public sealed class ListBox_ : ListBox, IUControl, IUControl_Docking, IUControl_ObjectModel
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;

        #region IUControl_ObjectModel

        [Category("\tFields")]
        [Description("Set the Field Name")]
        public string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }

        private string _Field_Name;

        [Category("\tFields")]
        [Description("Edit the Text Value")]
        public string Field_Value
        {
            get { return Value_Get(); }
            set { Value_Set(value); }
        }

        private string Value_Get()
        {
            return this.Text; //<=========================[Modify this
        }

        private void Value_Set(string value)
        {
            // Add code here to set the value
            // =============================
            this.Text = value;
        }

        #endregion

        #region Docking in UserControl
        // Add this code to the UserControl that needs to implement Auto Docking movement of controls

        /// <summary>
        /// Handles the OnDockChanged event. If dock change to none make sure the control is visible (on the front).
        /// </summary>
        /// <param name="sender">The parent object that called this method</param>
        /// <param name="e">The event arguments</param>
        private void OnDockChanged(object sender, EventArgs e)
        {
            if (this.Dock == DockStyle.None)
            {
                var frm = this.FindForm();
                if (frm != null)
                {
                    frm.Controls.Add(this);
                    this.BringToFront();
                }
            }
        }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        public GroupBox Parent_GroupBox
        {
            get { return this.Parent as GroupBox; }
            set { _lamedWin.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        public Panel Parent_Panel
        {
            get { return this.Parent as Panel; }
            set { _lamedWin.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }
        #endregion

    }
}
