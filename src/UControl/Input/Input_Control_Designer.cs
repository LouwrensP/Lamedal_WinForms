using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Lamedal_UIWinForms.Enumerals;

namespace Lamedal_UIWinForms.UControl.Input
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class Input_Control_Designer : ControlDesigner
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
                    actionLists.Add(new InputControl_Windows_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public sealed class InputControl_Windows_ActionList : DesignerActionList
    {
        #region Init

        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly Input_Control _inputControl;
        private readonly DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputControl_Windows_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public InputControl_Windows_ActionList(IComponent component)
            : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._inputControl = component as Input_Control;
            this._designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
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

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Layout"));
            items.Add(new DesignerActionPropertyItem("Caption", "Caption", "Layout"));
            items.Add(new DesignerActionPropertyItem("Value", "Value", "Layout"));
            items.Add(new DesignerActionPropertyItem("Type", "Type", "Layout"));
            items.Add(new DesignerActionHeaderItem("Actions"));
            items.Add(new DesignerActionPropertyItem("Action_Button", "Action Button", "Actions"));
            items.Add(new DesignerActionPropertyItem("Action_AutoSave", "Auto Save", "Actions"));
            items.Add(new DesignerActionPropertyItem("Action_Custom", "Custom Action", "Actions"));
            items.Add(new DesignerActionHeaderItem("Sync"));
            items.Add(new DesignerActionPropertyItem("Sync", "Sync", "Sync"));
            items.Add(new DesignerActionPropertyItem("Centre", "Centre", "Sync"));
            //items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Sync"));
            items.Add(new DesignerActionPropertyItem("DockTop", "DockTop", "Sync"));
            IamWindows.UIDesigner.Menu.Designer_Docking_Setup(items, _inputControl);  // Docking menu items
            return items;
        }
        public bool Action_Button
        {
            get
            {
                return _inputControl._Control_Action;
            }
            set
            {
                FireChanging();
                _inputControl._Control_Action = value;
                FireChanged();
            }
        }
        public bool Action_AutoSave
        {
            get
            {
                return _inputControl.Action_AutoSave;
            }
            set
            {
                FireChanging();
                _inputControl.Action_AutoSave = value;
                FireChanged();
            }
        }
        public enInputControl_CustomAction Action_Custom
        {
            get
            {
                return _inputControl.Action_Custom;
            }
            set
            {
                FireChanging();
                _inputControl.Action_Custom = value;
                FireChanged();
            }
        }
        public int Centre
        {
            get
            {
                return _inputControl._Control_Centre;
            }
            set
            {
                FireChanging();
                _inputControl._Control_Centre = value;
                FireChanged();
            }
        }
        public bool Sync
        {
            get
            {
                return _inputControl._Control_Sync;
            }
            set
            {
                FireChanging();
                _inputControl._Control_Sync = value;
                FireChanged();
            }
        }
        public enInputControl_Type Type
        {
            get
            {
                return _inputControl.ControlType;
            }
            set
            {
                FireChanging();
                _inputControl.ControlType = value;
                FireChanged();
            }
        }
        public string Caption
        {
            get { return _inputControl.Field_Caption; }
            set
            {
                FireChanging();
                _inputControl.Field_Caption = value;
                FireChanged();
            }
        }
        public string Value
        {
            get { return _inputControl.Field_Value; }
            set
            {
                FireChanging();
                _inputControl.Field_Value = value;
                FireChanged();
            }
        }
        public string Name
        {
            get { return _inputControl.Name; }
            set
            {
                FireChanging();
                _inputControl.Name = value;
                FireChanged();
            }
        }
        //public DockStyle Dock
        //{
        //    get { return _inputControl.Dock; }
        //    set
        //    {
        //        FireChanging();
        //        _inputControl.Dock = value;
        //        FireChanged();
        //    }
        //}
        public bool DockTop
        {
            get { return Dock == DockStyle.Top; }
            set
            {
                FireChanging();
                if (value) Dock = DockStyle.Top;
                else Dock = DockStyle.None;
                
                FireChanged();
            }
        }

        #region UControl_BaseInterface_Docking in Designer
        // Add this code to the Designer that needs to implement Auto Docking movement of controls

        public DockStyle Dock
        {
            get { return _inputControl.Dock; }
            set
            {
                FireChanging();
                _inputControl.Dock = value;
                FireChanged();
                _designerActionUISvc.Refresh(this.Component);
            }
        }

        public GroupBox Parent_GroupBox
        {
            get { return _inputControl.Parent_GroupBox; }
            set
            {
                FireChanging();
                {
                    _inputControl.Parent_GroupBox = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        // Parent_Panel
        public Panel Parent_Panel
        {
            get { return _inputControl.Parent_Panel; }
            set
            {
                FireChanging();
                {
                    _inputControl.Parent_Panel = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        #endregion

    }
}