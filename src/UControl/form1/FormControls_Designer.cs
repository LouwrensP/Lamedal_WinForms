using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;
using LaMedalPort.UIWindows.libUI.WinForms.UIDesigner;

namespace Lamedal_UIWinForms.UControl.form1
{

    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class FormControls_Designer : ComponentDesigner
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
                    actionLists.Add(new FormControls_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class FormControls_ActionList : Form_Setup_ActionList
    {
        #region Init

        private readonly FormControls_ _form;
        private readonly DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form_Setup_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public FormControls_ActionList(IComponent component) : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._form = component as FormControls_;
            this._designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;

        }

        #endregion

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = base.GetSortedActionItems();
            //var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Form Controls"));
            items.Add(new DesignerActionPropertyItem("Panel_Main", "Main Panel:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Panel_Setup", "Panel Setup:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_StandardButtons", "Standard Buttons:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_Tooltips", "Tool Tips:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_StatusStrip", "StatusStrip:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_ToolStrip", "Tool Strip:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_ToolbarPanel", "Toolbar Panel:", "Form Controls"));
            items.Add(new DesignerActionPropertyItem("Controls_ContextMenuStrip", "Context Menu Strip:", "Form Controls"));
            return items;
        }

        public Panel Panel_Main
        {
            get { return _form.Panel_Main; }
        }

        public enForm_Panels Panel_Setup
        {
            get { return _form.Panel_Setup; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Panel_Setup = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_ToolbarPanel
        {
            get { return _form.Controls_ToolbarPanel; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_ToolbarPanel = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_StandardButtons
        {
            get { return _form.Controls_StandardButtons; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_StandardButtons = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_Tooltips
        {
            get { return _form.Controls_Tooltips; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_Tooltips = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_StatusStrip
        {
            get { return _form.Controls_StatusStrip; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_StatusStrip = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_ToolStrip
        {
            get { return _form.Controls_ToolStrip; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_ToolStrip = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Controls_ContextMenuStrip
        {
            get { return _form.Controls_ContextMenuStrip; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Controls_ContextMenuStrip = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
    }
}
