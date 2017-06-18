using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl.panel
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class Panel_Designer : Panel_DesignerContainer // ParentControlDesigner
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
                    actionLists.Add(new Input_Panel_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class Input_Panel_ActionList : DesignerActionList
    {
        #region Init
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly Panel_ _panel;
        private readonly DesignerActionUIService _designerActionUISvc;
        private readonly IComponent _Component;

        /// <summary>
        /// Initializes a new instance of the <see cref="Input_Panel_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public Input_Panel_ActionList(IComponent component): base(component)
        {
            _Component = component;

            this._panel = component as Panel_;
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
            //items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Layout"));
            items.Add(new DesignerActionPropertyItem("BorderStyle", "BorderStyle", "Layout"));
            items.Add(new DesignerActionPropertyItem("AutoScroll", "AutoScroll", "Layout"));
            items.Add(new DesignerActionPropertyItem("Anchor", "Anchor", "Layout"));

            items.Add(new DesignerActionHeaderItem("Action"));
            items.Add(new DesignerActionPropertyItem("ContextMenuStrip", "ContextMenuStrip", "Action"));

            IamWindows.UIDesigner.Menu.Designer_AutoSize_Setup(items, _Component);  // Auto size items

            IamWindows.UIDesigner.Menu.Designer_Docking_Setup(items, _Component);  // Docking menu items

            return items;
        }

        #region UControl_BaseInterface_Docking
        public DockStyle Dock
        {
            get { return _panel.Dock; }
            set
            {
                FireChanging();
                _panel.Dock = value;
                FireChanged();
                _designerActionUISvc.Refresh(this.Component);
            }
        }

        public GroupBox Parent_GroupBox
        {
            get { return _panel.Parent_GroupBox; }
            set
            {
                FireChanging();
                {
                    _panel.Parent_GroupBox = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }

        // Parent_Panel
        public Panel Parent_Panel
        {
            get { return _panel.Parent_Panel; }
            set
            {
                FireChanging();
                {
                    _panel.Parent_Panel = value;
                    _designerActionUISvc.Refresh(this.Component);
                }
                FireChanged();
            }
        }
        #endregion


        // Past the following code into the designer
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

        public AnchorStyles Anchor
        {
            get { return _panel.Anchor; }
            set
            {
                FireChanging();
                _panel.Anchor = value;
                FireChanged();
            }
        }
        public bool AutoScroll
        {
            get { return _panel.AutoScroll; }
            set
            {
                FireChanging();
                _panel.AutoScroll = value;
                FireChanged();
            }
        }
        
        public BorderStyle BorderStyle
        {
            get { return _panel.BorderStyle; }
            set
            {
                FireChanging();
                _panel.BorderStyle = value;
                FireChanged();
            }
        }
        public ContextMenuStrip ContextMenuStrip
        {
            get { return _panel.ContextMenuStrip; }
            set
            {
                FireChanging();
                _panel.ContextMenuStrip = value;
                FireChanged();
            }
        }
    }
}