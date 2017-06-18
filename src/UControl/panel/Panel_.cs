using System;
using System.ComponentModel;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl.panel
{
    [Description("Input Panel Control")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(Panel_Designer))]   // Link the designer   
    [Docking(DockingBehavior.Ask)]
    public class Panel_ : Panel, IUControl_Autosize, IUControl_Docking
    {
        private readonly UIWindows IamWindows = UIWindows.Instance; // Set reference to Blueprint Windows lib

        #region Docking

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
