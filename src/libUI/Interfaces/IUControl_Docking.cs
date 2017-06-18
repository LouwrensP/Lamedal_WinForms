using System.ComponentModel;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.Interfaces
{
    /// <summary>
    /// Add extra designers menu items to setup changing of docking parent.
    /// The usercontrol needs to inherit from this interface
    /// Paste the relevent code into the UserControl an the Designer
    /// </summary>
    public interface IUControl_Docking
    {

        /// <summary>
        /// Gets or sets which control borders are docked to its parent control and determines how a control is resized with its parent.
        /// </summary>
        [Category("Docking")]
        [Description("Set the Dock properties")]
        DockStyle Dock { get; set; }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        GroupBox Parent_GroupBox { get; set; }

        /// <summary>
        /// If the parent is a GroupBox then show it. When set then change the parent of the control
        /// </summary>
        [Category("Docking")]
        [Description("Set the parent container")]
        Panel Parent_Panel { get; set; }


        #region Docking in UserControl
        //// Add this code to the UserControl that needs to implement Auto Docking movement of controls
        
        ///// <summary>
        ///// Handles the OnDockChanged event. If dock change to none make sure the control is visible (on the front).
        ///// </summary>
        ///// <param name="sender">The parent object that called this method</param>
        ///// <param name="e">The event arguments</param>
        //private void OnDockChanged(object sender, EventArgs e)
        //{
        //    if (this.Dock == DockStyle.None)
        //    {
        //        var frm = this.FindForm();
        //        if (frm != null)
        //        {
        //            frm.Controls.Add(this);
        //            this.BringToFront();
        //        }
        //    }
        //}

        ///// <summary>
        ///// If the parent is a GroupBox then show it. When set then change the parent of the control
        ///// </summary>
        //[Category("Docking")]
        //[Description("Set the parent container")]
        //public GroupBox Parent_GroupBox
        //{
        //    get { return this.Parent as GroupBox; }
        //    set { IamWindows.UControl.MoveToContainer(this, value); }
        //}

        ///// <summary>
        ///// If the parent is a GroupBox then show it. When set then change the parent of the control
        ///// </summary>
        //[Category("Docking")]
        //[Description("Set the parent container")]
        //public Panel Parent_Panel
        //{
        //    get { return this.Parent as Panel; }
        //    set { IamWindows.UControl.MoveToContainer(this, value); }
        //}
        #endregion


        #region UControl_BaseInterface_Docking in Designer
        //// Add this code to the Designer that needs to implement Auto Docking movement of controls
        
        //public DockStyle Dock
        //{
        //    get { return _groupBox.Dock; }
        //    set
        //    {
        //        FireChanging();
        //        _groupBox.Dock = value;
        //        FireChanged();
        //        _designerActionUISvc.Refresh(this.Component);
        //    }
        //}

        //public GroupBox Parent_GroupBox
        //{
        //    get { return _groupBox.Parent_GroupBox; }
        //    set
        //    {
        //        FireChanging();
        //        {
        //            _groupBox.Parent_GroupBox = value;
        //            _designerActionUISvc.Refresh(this.Component);
        //        }
        //        FireChanged();
        //    }
        //}

        //// Parent_Panel
        //public Panel Parent_Panel
        //{
        //    get { return _groupBox.Parent_Panel; }
        //    set
        //    {
        //        FireChanging();
        //        {
        //            _groupBox.Parent_Panel = value;
        //            _designerActionUISvc.Refresh(this.Component);
        //        }
        //        FireChanged();
        //    }
        //}

        #endregion

        //Add this method to the GetSortedActionItems() method in the UserControl Designer
            //IamWindows.UControl.Designer_Docking_Setup(items, _Component);  // Docking menu items

    }
}