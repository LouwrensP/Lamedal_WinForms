using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.libUI.Interfaces;
using Lamedal_UIWinForms.UControl.panel;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class GroupBox_Designer : Panel_DesignerContainer
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
                    actionLists.Add(new GroupBox_Designer_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class GroupBox_Designer_ActionList : DesignerActionList
    {
        #region Init
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly GroupBox_ _groupBox;
        private readonly DesignerActionUIService _designerActionUISvc;
        private readonly IComponent _Component;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBox_Designer_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public GroupBox_Designer_ActionList(IComponent component) : base(component)
        {
            _Component = component;

            this._groupBox = component as GroupBox_;
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
            items.Add(new DesignerActionPropertyItem("Text", "Text", "Layout"));
            items.Add(new DesignerActionPropertyItem("RightToLeft", "RightToLeft", "Layout"));
            items.Add(new DesignerActionPropertyItem("Anchor", "Anchor", "Layout"));
            items.Add(new DesignerActionHeaderItem("Action"));
            items.Add(new DesignerActionPropertyItem("ContextMenuStrip", "ContextMenuStrip", "Action"));

            IamWindows.UIDesigner.Menu.Designer_Docking_Setup(items, _Component);  // Docking menu items
            IamWindows.UIDesigner.Menu.Designer_AutoSize_Setup(items, _Component);  // Auto size items (Remember to paste properties)
            IamWindows.UIDesigner.Menu.Designer_GroupBox_FileStructure_Setup(items, _Component);   // Custom menu items

            return items;
        }

        #region UControl_BaseInterface_Docking
        public DockStyle Dock
        {
            get { return _groupBox.Dock; }
            set
            {
                FireChanging();
                _groupBox.Dock = value;
                FireChanged();
                _designerActionUISvc.Refresh(this.Component);
            }
        }

        public GroupBox Parent_GroupBox
        {
            get { return _groupBox.Parent_GroupBox; }
            set
            {
                FireChanging();
                {
                    _groupBox.Parent_GroupBox = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        // Parent_Panel
        public Panel Parent_Panel
        {
            get { return _groupBox.Parent_Panel; }
            set
            {
                FireChanging();
                {
                    _groupBox.Parent_Panel = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }
        #endregion

        #region GroupBox_FileStructure_Interface
        public enControl_PartSize PartSize
        {
            get
            {
                return ((IGroupBox_FileStructure_Interface)_Component).PartSize;
            }
            set
            {
                FireChanging();
                ((IGroupBox_FileStructure_Interface)_Component).PartSize = value;
                FireChanged();
            }
        }

        public enControl_PartType PartType
        {
            get
            {
                return ((IGroupBox_FileStructure_Interface)_Component).PartType;
            }
            set
            {
                FireChanging();
                ((IGroupBox_FileStructure_Interface)_Component).PartType = value;
                FireChanged();
            }
        }

        public string PartSummary
        {
            get
            {
                return ((IGroupBox_FileStructure_Interface)_Component).PartSummary;
            }
            set
            {
                FireChanging();
                ((IGroupBox_FileStructure_Interface)_Component).PartSummary = value;
                FireChanged();
            }
        }

        #endregion

        // Past the following code into the designer and uncomment
        #region UControl_BaseInterface_Autosize

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

        #region UControl_BaseInterface
        public AnchorStyles Anchor
        {
            get { return _groupBox.Anchor; }
            set
            {
                FireChanging();
                _groupBox.Anchor = value;
                FireChanged();
            }
        }
        
        public string Text
        {
            get { return _groupBox.Text; }
            set
            {
                FireChanging();
                _groupBox.Text = value;
                FireChanged();
            }
        }
        public RightToLeft RightToLeft
        {
            get { return _groupBox.RightToLeft; }
            set
            {
                FireChanging();
                _groupBox.RightToLeft = value;
                FireChanged();
            }
        }

        
        public ContextMenuStrip ContextMenuStrip
        {
            get { return _groupBox.ContextMenuStrip; }
            set
            {
                FireChanging();
                _groupBox.ContextMenuStrip = value;
                FireChanged();
            }
        }
        #endregion


    }
}