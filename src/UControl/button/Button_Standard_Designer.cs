using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lamedal_UIWinForms.UControl.button
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class Button_Standard_Designer : ControlDesigner
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
                    actionLists.Add(new StandardButtons_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class StandardButtons_ActionList : DesignerActionList
    {
        #region Init

        private readonly Button_Standard _buttons;
        private DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardButtons_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public StandardButtons_ActionList(IComponent component)
            : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._buttons = component as Button_Standard;
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
            items.Add(new DesignerActionHeaderItem("Sync"));
            items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Sync"));
            items.Add(new DesignerActionHeaderItem("Layout"));
            items.Add(new DesignerActionPropertyItem("Ok", "Ok", "Layout"));
            items.Add(new DesignerActionPropertyItem("Cancel", "Cancel", "Layout"));
            items.Add(new DesignerActionPropertyItem("Apply", "Apply", "Layout"));
            items.Add(new DesignerActionPropertyItem("Help", "Help", "Layout"));
            items.Add(new DesignerActionPropertyItem("Clipboard", "Clipboard", "Layout"));
            return items;
        }
        public bool Ok
        {
            get
            {
                return _buttons.Visible_Ok;
            }
            set
            {
                FireChanging();
                _buttons.Visible_Ok = value;
                FireChanged();
            }
        }
        public bool Cancel
        {
            get
            {
                return _buttons.Visible_Cancel;
            }
            set
            {
                FireChanging();
                _buttons.Visible_Cancel = value;
                FireChanged();
            }
        }
        public bool Apply
        {
            get
            {
                return _buttons.Visible_Apply;
            }
            set
            {
                FireChanging();
                _buttons.Visible_Apply = value;
                FireChanged();
            }
        }
        public bool Help
        {
            get
            {
                return _buttons.Visible_Help;
            }
            set
            {
                FireChanging();
                _buttons.Visible_Help = value;
                FireChanged();
            }
        }
        public bool Clipboard
        {
            get
            {
                return _buttons.Visible_Clipboard;
            }
            set
            {
                FireChanging();
                _buttons.Visible_Clipboard = value;
                FireChanged();
            }
        }
        public DockStyle Dock
        {
            get { return _buttons.Dock; }
            set
            {
                FireChanging();
                _buttons.Dock = value;
                FireChanged();
            }
        }
    }
}