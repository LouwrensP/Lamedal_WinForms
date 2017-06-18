using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class TextBox_Designer : ControlDesigner
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
                    actionLists.Add(new Input_Textbox_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class Input_Textbox_ActionList : DesignerActionList
    {
        #region Init

        private readonly TextBox_ _text;
        private DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Input_Textbox_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public Input_Textbox_ActionList(IComponent component)
            : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._text = component as TextBox_;
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
            items.Add(new DesignerActionPropertyItem("Multiline", "Multiline", "Layout"));
            items.Add(new DesignerActionPropertyItem("Text", "Text", "Layout"));
            items.Add(new DesignerActionPropertyItem("ScrollBars", "ScrollBars", "Layout"));
            items.Add(new DesignerActionPropertyItem("Dock", "Dock", "Layout"));
            items.Add(new DesignerActionHeaderItem("Action"));
            items.Add(new DesignerActionPropertyItem("ContextMenuStrip", "ContextMenuStrip", "Action"));
            return items;
        }
        public bool Multiline
        {
            get { return _text.Multiline; }
            set
            {
                FireChanging();
                _text.Multiline = value;
                FireChanged();
            }
        }
        public string Text
        {
            get { return _text.Text; }
            set
            {
                FireChanging();
                _text.Text = value;
                FireChanged();
            }
        }
        public ScrollBars ScrollBars
        {
            get { return _text.ScrollBars; }
            set
            {
                FireChanging();
                _text.ScrollBars = value;
                FireChanged();
            }
        }
        public ContextMenuStrip ContextMenuStrip
        {
            get { return _text.ContextMenuStrip; }
            set
            {
                FireChanging();
                _text.ContextMenuStrip = value;
                FireChanged();
            }
        }
        public DockStyle Dock
        {
            get { return _text.Dock; }
            set
            {
                FireChanging();
                _text.Dock = value;
                FireChanged();
            }
        }
    }
}