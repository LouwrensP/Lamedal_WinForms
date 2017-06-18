using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [Description("CheckBox control")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof (UControl_Interface_Designer))] // Link the designer   
    [Docking(DockingBehavior.Ask)] // Dock in parent control
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(CheckBox))]
    public sealed class CheckBox_ : CheckBox, IUControl, IUControl_Docking
    {
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private string _topMostText;
        private bool _topMost;

        public bool TopMost
        {
            get { return _topMost; }
            set
            {
                _topMost = value;
                if (TopMost) Text = TopMost_Text;
            }
        }

        public string TopMost_Text
        {
            get { return _topMostText; }
            set
            {
                _topMostText = value;
                if (TopMost) Text = value;
            }
        }

        public CheckBox_()
        {
            TopMost = false;
            TopMost_Text = "Form is on top";
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (TopMost)
            {
                var form = this.FindForm();
                if (form == null) return;
                form.TopMost = this.Checked;
            } else base.OnCheckedChanged(e);  // Execute the default event
        }

        /// <summary>
        /// Setups the CheckBox_ class.
        /// </summary>
        public void Setup()
        {
            var form = this.FindForm();
            if (form == null) return;
            this.Checked = form.TopMost;
        }

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
            set { IamWindows.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        public Panel Parent_Panel
        {
            get { return this.Parent as Panel; }
            set { IamWindows.libUI.WinForms.Controls.Control.MoveToContainer(this, value); }
        }
        #endregion


    }
}