using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [Description("Input Panel Control")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(GroupBox_Designer))]   // Link the designer
    [Docking(DockingBehavior.Ask)]
    //[Designer(typeof(System.Windows.Forms.Design.ComboBoxDesigner)]
    [ToolboxBitmap(typeof(GroupBox))]
    public partial class GroupBox_ : GroupBox, IUControl_Autosize, IUControl_Docking
    {

        /// <summary>
        /// Initializes a new instance of the &lt;see cref=&quot;GroupBox_&quot;/&gt; class.
        /// </summary>
        public GroupBox_()
        {
            this.Click += OnClick;
            this.DockChanged += OnDockChanged;
            Initialize();   // Run the partial code class
        }

        /// <summary>
        /// Occurs when the GroupBox is clicked.
        /// </summary>
        public event EventHandler Notify_Click;

        /// <summary>
        /// Handles the OnClick event.
        /// </summary>
        /// <param name="sender">The parent object that called this method</param>
        /// <param name="e">The event arguments</param>
        private void OnClick(object sender, EventArgs e)
        {
            if (Notify_Click != null) Notify_Click(sender, e);
        }


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
