using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Lamedal_UIWinForms.Enumerals;
using LaMedalPort.UIWindows.libUI.WinForms.UIDesigner;

namespace Lamedal_UIWinForms.UControl.form1
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class Forms_Designer : ComponentDesigner
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
                    actionLists.Add(new Form_Setup_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class Form_Setup_ActionList : DesignerActionList
    {
        #region Init

        private readonly Form_ _form;
        private readonly DesignerActionUIService _designerActionUISvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form_Setup_ActionList" /> class. The constructor associates the control with the smart tag list.
        /// </summary>
        /// <param name="component">The component.</param>
        public Form_Setup_ActionList(IComponent component)
            : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._form = component as Form_;
            this._designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
            
        }

        #endregion
        #region Private

     

        #endregion

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_Name", "Form:", "Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_Text", "Text:", "Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_StartPosition", "Start Position:", "Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_TopMost", "TopMost:", "Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_Size", "Size:", "Form Layout"));
            items.Add(new DesignerActionPropertyItem("Form_ContextMenuStrip", "ContextMenuStrip:", "Form Layout"));
            return items;
        }
        public Form Form_Name
        {
            get { return _form.Form_Name; }
            //set
            //{
            //    UIDesigner_Tools.Change_Begin(this);
            //    _form.Form_Name = value;
            //    _designerActionUISvc.Refresh(this.Component);
            //    UIDesigner_Tools.Change_End(this);
            //}
        }
        public string Form_Text
        {
            get { return _form.Form_Text; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Form_Text = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
        public FormStartPosition Form_StartPosition
        {
            get { return _form.Form_StartPosition; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Form_StartPosition = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
        public ContextMenuStrip Form_ContextMenuStrip
        {
            get { return _form.Form_ContextMenuStrip; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Form_ContextMenuStrip = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
        public bool Form_TopMost
        {
            get { return _form.Form_TopMost; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Form_TopMost = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public enFormSize Form_Size
        {
            get { return _form.Form_Size; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _form.Form_Size = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
    }
}