using System.ComponentModel;
using System.ComponentModel.Design;
using LaMedalPort.UIWindows.libUI.WinForms.UIDesigner;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FormCreator_Designer : ComponentDesigner
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
                    actionLists.Add(new FormClassDesigner_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public sealed class FormClassDesigner_ActionList : FormControls_ActionList
    {
        #region Init

        private readonly FormCreator_ _Control;
        private readonly DesignerActionUIService _designerActionUIService;

        public FormClassDesigner_ActionList(IComponent component)
            : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._Control = component as FormCreator_;
            this._designerActionUIService = UIDesigner_Service.DesignerActionUIService_FromActionList(this);
        }

        #endregion

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = base.GetSortedActionItems();
            //var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Generator"));
            items.Add(new DesignerActionPropertyItem("Generator_Enumeral_FormSetup", "Enumeral Setup:", "Generator"));
            items.Add(new DesignerActionPropertyItem("Generator_ClassSetup", "Class Setup:", "Generator"));
            items.Add(new DesignerActionPropertyItem("Generator_Class", "Class:", "Generator"));
            items.Add(new DesignerActionPropertyItem("Generator_zGo", "Go:", "Generator"));
            return items;
        }

        //public bool Generator_FormTestSetup
        //{
        //    get { return _Control.Generator_FormTestSetup; }
        //    set
        //    {
        //        UIDesigner_Tools.Change_Begin(this);
        //        _Control.Generator_FormTestSetup = value;
        //        UIDesigner_Tools.Change_End(this);
        //    }
        //}

        public bool Generator_Enumeral_FormSetup
        {
            get { return _Control.Generator_Enumeral_FormSetup; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _Control.Generator_Enumeral_FormSetup = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Generator_ClassSetup
        {
            get { return _Control.Generator_ClassSetup; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _Control.Generator_ClassSetup = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public string Generator_Class
        {
            get { return _Control.Generator_Class; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _Control.Generator_Class = value;
                UIDesigner_Tools.Change_End(this);
            }
        }

        public bool Generator_zGo
        {
            get { return _Control.Generator_zGo; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _Control.Generator_zGo = value;
                UIDesigner_Tools.Change_End(this);
            }
        }
    }
}