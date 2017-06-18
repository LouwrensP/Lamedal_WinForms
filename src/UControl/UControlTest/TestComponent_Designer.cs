using System.ComponentModel;
using System.ComponentModel.Design;
using LaMedalPort.UIWindows.libUI.WinForms.UIDesigner;

namespace Lamedal_UIWinForms.UControl.UControlTest
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public sealed class TestComponent_Designer : ComponentDesigner
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
                    actionLists.Add(new TestComponent_ActionList(Component));
                }
                return actionLists;
            }
        }
    }

    /// <summary>
    /// the control with the smart tag list.
    /// </summary>
    public class TestComponent_ActionList : DesignerActionList
    {
        #region Init

        private readonly TestComponent _Control;
        private readonly DesignerActionUIService _designerActionUIService;

        public TestComponent_ActionList(IComponent component) : base(component)
        {
            // Cache a reference to DesignerActionUIService, so the DesigneractionList can be refreshed.
            this._Control = component as TestComponent;
            this._designerActionUIService = UIDesigner_Service.DesignerActionUIService_FromActionList(this);
        }

        #endregion

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Testing"));
            items.Add(new DesignerActionPropertyItem("AddButton", "Add Button:", "Testing"));
            return items;
        }

        public bool AddButton
        {
            get { return _Control.AddButton; }
            set
            {
                UIDesigner_Tools.Change_Begin(this);
                _Control.AddButton = value;

                IDesignerHost host = UIDesigner_Service.IDesignerHost_FromActionList(this);
                if (host != null)
                {
                    // ==============================================================
                    //var total = host.Container.Components.Count;
                    //total.ToString().zOk();

                    // ==============================================================
                    //var btn = DesignerTools.AddControlToForm(host, typeof (Button));
                    //btn.Top = 10;
                    //btn.Left = 10;
                    //btn.Text = "It works!";

                    // ==============================================================
                    //var controls = DesignerTools.Host_Components_All(host);
                    //var selected = new List<Control>();
                    //foreach (Control control in controls)
                    //{
                    //    var text = control.Text;
                    //    //text.zOk();
                    //    if (text == "It works!")
                    //    {
                    //        control.Text = "Two in a row!";
                    //        selected.Add(control);
                    //    }
                    //}
                    //DesignerTools.Host_Controls_SelectedSet(host, selected);

                    //// ===================================================================
                    //Control control = UIDesigner_Tools.Host_Controls_SelectedFirst(host);
                    //control.Text.zOk();
                    //var button = control as Button;
                    //if (button == null) "No Button".zOk();
                    //button.Text.zOk();
                    //if (control.BackgroundImage == null) "Null!".zOk();
                    //control.BackgroundImage = ToolAction.actionBuildHammer;  // ((System.Drawing.Image)(resources.GetObject("button_AAA.BackgroundImage")));
                }

                UIDesigner_Tools.Change_End(this);
            }
        }
    }
}