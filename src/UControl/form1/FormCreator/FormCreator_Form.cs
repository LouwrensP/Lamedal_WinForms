using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.zzz;
using UIDesigner_Component = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Component;
using UIDesigner_Service = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Service;
using UIDesigner_Tools = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Tools;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    public partial class FormCreator_Form : System.Windows.Forms.Form
    {
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly dotNet_ _dotNet = Lamedal_WinForms.Instance.lib.dotNet;

        private FormCreator_ _designer;       // Form designer
        private IDesignerHost _host;            // Form designer 
        private List<System.ComponentModel.Component> _components; // Form components
        private List<Control> _controls;     // Form controls
        private bool _SelectionChangeFlag;   // Selection change flag indicator (this flag is to prevent sircular looping)
        private bool _SetupFlag;
        private System.ComponentModel.Component _ActiveComponent;

        private Dictionary<string, Tuple<Type, Attribute>> _typeAttributeDictionary;  // Classes that can be generated

        public FormCreator_Form()
        {
            InitializeComponent();
        }

        public FormCreator_Form(FormCreator_ designer)
        {
            InitializeComponent();
            Setup(designer);
        }

        public void Setup(FormCreator_ designer)
        {
            _SetupFlag = true;
            _designer = designer;

            // Form Size & Form Panels
            typeof(enFormSize).zEnum_To_IList(comboBox_FormSize.Items);
            //IamWindows.libUI.WinForms.Controls.ComboBox.SearchItem(comboBox_FormSize, designer.FormSize.ToString());

            typeof(enFormPanels).zEnum_To_IList(comboBox_FormPanels.Items);
            IamWindows.libUI.WinForms.Controls.ComboBox.SearchItem(comboBox_FormPanels, designer.Panel_Setup.ToString());

            // Panel setup
            input_Panel1.Field_Value = UIDesigner_Component.Component_AsStr(_designer.Panel_Main, true, true);

            listBox_Components.Items.Clear();
            _host = UIDesigner_Service.IDesignerHost_FromComponent(designer);
            if (_host != null)
            {
                // Set event
                UIDesigner_Tools.Host_Controls_SelectionChange(_host, OnselectionChanged);
                this.Closed -= OnFormClosed;
                this.Closed += OnFormClosed;

                // Find all controls on the form
                _components = UIDesigner_Tools.Host_Components_All(_host);
                _controls = UIDesigner_Tools.Host_Controls_All(_host);
                UIDesigner_Component.ControlNames(_components).zTo_IList(listBox_Components.Items); 

                // Populate the list of classes that can be generated
                Assembly assembly = _dotNet.Assembly.Get_(designer);
                List<string> typeNameList;
                if (IamWindows.libUI.WinForms.FormGenerate.AssemblyTypes(assembly, out typeNameList, out _typeAttributeDictionary))
                {
                    typeNameList.zTo_IList(listBox_Classes.Items);
                    listBox_Classes.SelectedIndex = 0;
                }

                this.TopMost = true;
                this.Show();
            }

            _SetupFlag = false;
        }

        private void comboBox_FormPanels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SetupFlag) return;

            // Convert to enum and set the component
            var formPanels = comboBox_FormPanels.Text;
            _designer.Panel_Setup = formPanels.zEnum_To_EnumValue<enFormPanels>();

            // Get the panels
            var panelName = input_Panel1.Field_Value;
            if (listBox_Components.zListBox_SearchItem(panelName) == -1)
            {
                "Error! No panel selected!".zOk();
                return;
            }
            var panelMain = _ActiveComponent as Panel;
            if (panelMain == null)
            {
                "Error! Active control is not a panel.".zOk();
                return;
            }

            Panel panel1;
            Panel panel2;
            Panel panel3;
            UIDesigner_Generate.Form_PanelSetup(_designer, _designer.Panel_Setup, panelMain, out panel1, out panel2, out panel3);
        }

        private void comboBox_FormSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SetupFlag) return;

            // Convert to enum and set the component
            var formSize = comboBox_FormSize.Text;
            //_designer.FormSize = formSize.zEnum_To_EnumValue<enFormSize>();
            //UIDesigner_Generate.Form_Size(_designer, _designer.FormSize);

        }

        private void input_Panel1_Event_OnActionButtonClick(object sender, evInput_Control_EventArgs e)
        {
            var panel = _ActiveComponent as Panel;
            if (panel == null) return;

            input_Panel1.Field_Value = listBox_Components.Text;
            _designer.Panel_Main = panel;
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            UIDesigner_Tools.Host_Controls_SelectionChange(_host, OnselectionChanged, true);  // Set the events
        }

        private void OnselectionChanged(object sender, EventArgs e)
        {
            if (_SelectionChangeFlag) return;
            _SelectionChangeFlag = true;

            string name = UIDesigner_Tools.Host_Controls_SelectedFirst_AsName(_host, true, true);
            if (name != "") listBox_Components.zListBox_SearchItem(name);
            _SelectionChangeFlag = false;
        }
        private void listBox_Components_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_SelectionChangeFlag) return;

            _SelectionChangeFlag = true;
            try
            {
                _ActiveComponent = UIDesigner_Component.FindComponent(_host,_components, listBox_Components.Text);
            }
            finally
            {
                _SelectionChangeFlag = false;
            }
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            if (input_Panel1.Field_Value == "")
            {
                "You need to setup panel1 before you can generate code!".zOk();
                return;
            }
            try
            {
                // Select the first panel
                var panelName = input_Panel1.Field_Value;
                listBox_Components.zListBox_SearchItem(panelName); // This will select the panel

                Control controlPanel = UIDesigner_Tools.Host_Controls_SelectedFirst(_host);
                var panel = controlPanel as Panel;
                var group = controlPanel as GroupBox;
                var form = controlPanel as System.Windows.Forms.Form;
                if (panel == null && group == null && form == null) "Please select a parent control".zOk();
                else
                {
                    var input = UIDesigner_Tools.Host_Controls_Add2Form <Input_Control>(_host, controlPanel);
                    if (input == null)
                    {
                        "Unable to create control!".zOk();
                        return;
                    }
                    input.Parent = controlPanel;
                    input.Top = 10;
                    input.Left = 10;
                    input.Dock = DockStyle.Top;
                    input.Text = "It works!";
                    input.Field_Caption = "Field Caption:";
                    input.Field_Name = "Field_Name";

                    // Add Event handler
                    // input.Event_OnValueChange
                    IEventBindingService eventBindingService = UIDesigner_Service.IEventBindingService_FromHost(_host);
                    EventDescriptorCollection eventColl = TypeDescriptor.GetEvents(input, new Attribute[0]);
                    if (eventColl != null)
                    {
                        var eventDescriptor = eventColl["Event_OnValueChange"] as EventDescriptor;
                        if (eventDescriptor != null)
                        {
                            PropertyDescriptor propertyDescriptor = eventBindingService.GetEventProperty(eventDescriptor);
                            propertyDescriptor.SetValue(input, "OnValueChangeEvent");
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                exception.Message.zOk();
            }
        }

        // This method creates a Timer component using the  
        // IDesignerHost.CreateComponent method. It also  
        // creates an event handler for the Timer component's 
        // tick event. 
        private void CreateTimer()
        {
            if (_host != null)
            {
                IEventBindingService eventBindingService = UIDesigner_Service.IEventBindingService_FromHost(_host);
                DesignerActionUIService designerActionUIService = UIDesigner_Service.DesignerActionUIService_FromHost(_host);

                //if (this.relatedDesigner.createdTimer == null)
                {
                    // Create and configure the Timer object. 
                    _createdTimer = _host.CreateComponent(typeof(Timer)) as Timer;
                    if (_createdTimer == null) return; // ================================================

                    Timer t = _createdTimer;
                    t.Interval = 1000;
                    t.Enabled = true;

                    EventDescriptorCollection eventColl = TypeDescriptor.GetEvents(t, new Attribute[0]);
                    if (eventColl != null)
                    {
                        var eventDescriptor = eventColl["Tick"] as EventDescriptor;
                        if (eventDescriptor != null)
                        {
                            PropertyDescriptor propertyDescriptor = eventBindingService.GetEventProperty(eventDescriptor);
                            propertyDescriptor.SetValue(t, "timer_Tick");
                        }
                    }

                    designerActionUIService.Refresh(_createdTimer);

                }
            }
        }
        private Timer _createdTimer;

        // This method uses the IEventBindingService.ShowCode 
        // method to start the Code Editor. It places the caret 
        // in the timer_tick method created by the CreateTimer method. 
        private void ShowEventHandlerCode()
        {
            if (_createdTimer == null) return; // ================================================

            Timer timer = _createdTimer;

            if (timer != null)
            {
                EventDescriptorCollection eventColl =
                    TypeDescriptor.GetEvents(timer, new Attribute[0]);
                if (eventColl != null)
                {
                    var eventDescriptor = eventColl["Tick"] as EventDescriptor;
                    if (eventDescriptor != null)
                    {
                        var eventBindingService = UIDesigner_Service.IEventBindingService_FromHost(_host);
                        eventBindingService.ShowCode(timer, eventDescriptor);
                    }
                }
            }
        }

        private void AddCode()
        {
            //Add method "Form1_Load" on Form1
            //---------------------------------------------------------------------------
            var member = new CodeMemberMethod();
            member.Name = "Form1_Load";
            member.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
            member.Parameters.Add(new CodeParameterDeclarationExpression("System.EventArgs", "e"));
            CodeSnippetExpression sn;
            sn = new CodeSnippetExpression("MessageBox.Show(\"Hello world\")");
            member.Statements.Add(sn);
            member.Attributes = MemberAttributes.Private;
            var typedecl = UIDesigner_Service.CodeTypeDeclaration_FromHost(_host);
            typedecl.Members.Add(member);
            //---------------------------------------------------------------------------


        }

        //private void OnValueChangeEvent(object sender, Input_Control_EventArgs e)
        //{
        //    if (_GenerateStartFlag) return;  // Do not pass this point when generating code

        //    IamWindows.libUI.WinForms.FormGenerate.Form_ToObject(e, _sample);
        //    1000.zExecute_Async(RefreshObj, "formRefresh", true);
        //}

        //private void RefreshObj()
        //{
        //    // Update the generated the form from the object.
        //    IamWindows.libUI.WinForms.FormGenerate.Form_FromObject(this, _sample);
        //}

        private void AddCode2()
        {
            CodeTypeDeclaration codeTypeDeclaration = UIDesigner_Service.CodeTypeDeclaration_FromHost(_host);


            // private bool _GenerateStartFlag = false;
            var field1 = new CodeMemberField("bool", "_GenerateStartFlag");
            field1.InitExpression = new CodePrimitiveExpression(false);
            field1.Attributes = MemberAttributes.Private;
            codeTypeDeclaration.Members.Add(field1);

            //// private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
            //var field2 = new CodeMemberField("LaMedalUI_Windows_", "IamWindows");
            //field2.InitExpression = new CodeSnippetExpression("LaMedalUI_Windows_.Instance; // Set reference to Blueprint Windows lib");
            //field2.Attributes = MemberAttributes.Private;
            //codeTypeDeclaration.Members.Add(field2);

            // Add OnValueChangeEvent()
            // ==============================
            var member1 = new CodeMemberMethod();
            var newMethod = true;
            var members = codeTypeDeclaration.Members;
            foreach (var member in members)
            {
                var member01 = member as CodeMemberMethod;
                if (member01 == null) continue;
                if (member01.Name == "OnValueChangeEvent")
                {
                    member1 = member01;
                    newMethod = false;
                    break;
                }
            }
            if (newMethod)
            {
                member1.Name = "OnValueChangeEvent";
                member1.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "sender"));
                member1.Parameters.Add(new CodeParameterDeclarationExpression("Input_Control_EventArgs", "e"));
                member1.Attributes = MemberAttributes.Private;
            }
            var code1 = new CodeSnippetExpression("if (_GenerateStartFlag) return;  // Do not pass this point when generating code");
            var code2 = new CodeSnippetExpression("IamWindows.libUI.WinForms.FormGenerate.Form_ToObject(e, _sample);");
            var code3 = new CodeSnippetExpression("1000.zExecute_Async(RefreshObj, \"formRefresh\", true);");
            member1.Statements.Add(code1);
            member1.Statements.Add(code2);
            member1.Statements.Add(code3);
            codeTypeDeclaration.Members.Add(member1);

            var member2 = new CodeMemberMethod();
            member2.Name = "RefreshObj";
            var code_1 = new CodeSnippetExpression("// Update the generated the form from the object.");
            var code_2 = new CodeSnippetExpression("IamWindows.libUI.WinForms.FormGenerate.Form_FromObject(this, _sample);");
            member2.Statements.Add(code_1);
            member2.Statements.Add(code_2);
            member2.Attributes = MemberAttributes.Private;
            codeTypeDeclaration.Members.Add(member2);

        }

        private void button_Timer_Click(object sender, EventArgs e)
        {
            CreateTimer();
        }

        private void button_Code_Click(object sender, EventArgs e)
        {
            AddCode();
        }

        private void button_Show_Click(object sender, EventArgs e)
        {
            ShowEventHandlerCode();
        }

        private void button_Code2_Click(object sender, EventArgs e)
        {
            AddCode2();
        }

       
        

    }
}
