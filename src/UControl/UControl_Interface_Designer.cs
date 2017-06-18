using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using LamedalCore.zz;
using Lamedal_UIWinForms.libUI.Interfaces;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class UControl_Interface_Designer : ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            // Use pull model to populate smart tag menu.
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new Designers_UControls_BaseInterface_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class Designers_UControls_BaseInterface_ActionList : DesignerActionList
    {
        #region Init

        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly IUControl _userControlBase;
        private readonly IUControl_Docking _userControlDock;
        private readonly CheckBox_ _userCustomCheckBox;
        private readonly IComponent _Component;

        private readonly DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Designers_UControls_BaseInterface_ActionList"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public Designers_UControls_BaseInterface_ActionList(IComponent component) : base(component)
        {
            _Component = component;

            if (component == null) return;
            this._userControlBase = component as IUControl;
            if (_userControlBase == null)
            {
                var msg = component.ToString();
                msg += "".NL() + "Should inherit from 'UControl_BaseInterface'!";
                msg.zClipboard_CopyStrTo();
                //msg.zOk();
            }
            _userControlDock = component as IUControl_Docking;
            _userCustomCheckBox = component as CheckBox_;

            this._designerActionUISvc = GetService(typeof (DesignerActionUIService)) as DesignerActionUIService;
        }

        #endregion
        #region Private

        private void FireChanging()
        {
            IComponentChangeService service = GetComponentChangeService();
            if (service != null) service.OnComponentChanging(this, null);
        }

        private void FireChanged()
        {
            IComponentChangeService service = GetComponentChangeService();
            if (service != null) service.OnComponentChanged(this, null, null, null);
        }

        private IComponentChangeService GetComponentChangeService()
        {
            return GetService(typeof(IComponentChangeService)) as IComponentChangeService;
        }

        #endregion
        
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //! Define static section header entries.
            IamWindows.UIDesigner.Menu.Designer_Base_Setup(items);   // Base items
            IamWindows.UIDesigner.Menu.Designer_Docking_Setup(items, _Component);  // Docking menu items
            IamWindows.UIDesigner.Menu.Designer_AutoSize_Setup(items, _Component);  // Auto size items

            if (_userCustomCheckBox != null)
            {
                items.Add(new DesignerActionPropertyItem("Checked", "Checked", "Action"));
                items.Add(new DesignerActionPropertyItem("TopMost", "TopMost", "Action"));
            }
            return items;
        }

        #region Autosize
        
        public AutoSizeMode AutoSizeMode
        {
            get
            {
                return ((IUControl_Autosize)_Component).AutoSizeMode;
            }
            set
            {
                FireChanging();
                ((IUControl_Autosize)_Component).AutoSizeMode = value;
                FireChanged();
            }
        }

        public bool AutoSize
        {
            get { return ((IUControl_Autosize)_Component).AutoSize; }
            set
            {
                FireChanging();
                ((IUControl_Autosize)_Component).AutoSize = value;
                FireChanged();
            }
        }
        #endregion

        #region Base Menu
        public int Top
        {
            get { return _userControlBase.Top; }
            set
            {
                FireChanging();
                _userControlBase.Top = value;
                FireChanged();
            }
        }
        public int Left
        {
            get { return _userControlBase.Left; }
            set
            {
                FireChanging();
                _userControlBase.Left = value;
                FireChanged();
            }
        }
        public AnchorStyles Anchor
        {
            get { return _userControlBase.Anchor; }
            set
            {
                FireChanging();
                _userControlBase.Anchor = value;
                FireChanged();
            }
        }
        public string Text
        {
            get { return _userControlBase.Text; }
            set
            {
                FireChanging();
                _userControlBase.Text = value;
                FireChanged();
            }
        }
        public ContextMenuStrip ContextMenuStrip
        {
            get { return _userControlBase.ContextMenuStrip; }
            set
            {
                FireChanging();
                _userControlBase.ContextMenuStrip = value;
                FireChanged();
            }
        }

        #endregion

        #region UControl_BaseInterface_Docking in Designer
        // Add this code to the Designer that needs to implement Auto Docking movement of controls

        public DockStyle Dock
        {
            get { return _userControlDock.Dock; }
            set
            {
                FireChanging();
                if (_userControlDock != null) _userControlDock.Dock = value;
                FireChanged();
                _designerActionUISvc.Refresh(this.Component);
            }
        }

        public GroupBox Parent_GroupBox
        {
            get { return _userControlDock.Parent_GroupBox; }
            set
            {
                FireChanging();
                {
                    if (_userControlDock != null) _userControlDock.Parent_GroupBox = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        // Parent_Panel
        public Panel Parent_Panel
        {
            get { return _userControlDock.Parent_Panel; }
            set
            {
                FireChanging();
                {
                    if (_userControlDock != null) _userControlDock.Parent_Panel = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        #endregion

        #region Custom Checkbox
        public bool Checked
        {
            get { return _userCustomCheckBox.Checked; }
            set
            {
                FireChanging();
                _userCustomCheckBox.Checked = value;
                FireChanged();
            }
        }
        public bool TopMost
        {
            get { return _userCustomCheckBox.TopMost; }
            set
            {
                FireChanging();
                _userCustomCheckBox.TopMost = value;
                FireChanged();
            }
        }
        #endregion
    }
}
