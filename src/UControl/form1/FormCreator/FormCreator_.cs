using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;
using Lamedal_UIWinForms.zzz;
using UIDesigner_Service = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Service;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    [ToolboxItem(false)]  // Toolbox item is marked false because you must inherid from this component
    [Description("Add Input Control on the form")]
    [DefaultProperty("Generator_FormTestSetup")]
    [Designer(typeof(FormCreator_Designer))]
    public partial class FormCreator_ : FormControls_
    {
        #region Init

        private readonly Lamedal_WinForms _lamedalWin = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib

        private IDesignerHost _host;
        private bool _FormCreator_StartupFlag = true;
        
        #endregion

        #region Properties

        //[Category("\tClass Generator")]
        //[Description("Generator Test and Setup Form")]
        //public bool Generator_FormTestSetup
        //{
        //    get { return _generatorFormTestSetup; }
        //    set
        //    {
        //        _generatorFormTestSetup = value;
        //        if (value)
        //        {
        //            // Do the action here
        //            _formGenerate = new FormCreator_Form(this);
        //            _generatorFormTestSetup = false;
        //        }
        //    }
        //}
        //private bool _generatorFormTestSetup;
        //private FormCreator_Form _formGenerate;

        [Category("\tClass Generator")]
        [Description("Generator Form for enumerals.")]
        public bool Generator_Enumeral_FormSetup
        {
            get { return _generatorEnumeralFormSetup; }
            set
            {
                _generatorEnumeralFormSetup = value;
                if (value)
                {
                    // Do the action here
                    Enumeral_FormSetup();
                    _generatorEnumeralFormSetup = false;
                }
            }
        }
        private bool _generatorEnumeralFormSetup;
        private FormCreator_Enumeral_Form _FormEnumeral;

        [Category("\tClass Generator")]
        [Description("Class that will be generated.")]
        public string Generator_Class
        {
            get { return _generatorClass; }
            set { _generatorClass = value; }
        }
        private string _generatorClass;

        [Category("\tClass Generator")]
        [Description("Class to generate Setup Form")]
        public bool Generator_ClassSetup
        {
            get { return _generatorClassSetup; }
            set
            {
                _generatorClassSetup = value;
                if (value)
                {
                    Setup_ClassGenerate();
                    _generatorClassSetup = false;
                }
            }
        }
        private bool _generatorClassSetup;
        private FormCreator_SelectClasses_Form _frmClassGenerateSetup;

        [Category("\tClass Generator")]
        [Description("Generate the code for the class on the form")]
        public bool Generator_zGo
        {
            get { return _Go; }
            set
            {
                _Go = value;
                if (value)
                {
                    Setup_Go();
                    _Go = false;
                }
            }
        }
        private bool _Go;

        public stateAssemblyFilters AssemblyFilters = null;
        #endregion

        protected override void Setup_()
        {
            base.Setup_();
            _FormCreator_StartupFlag = false;
            if (_formHost == null) return;
        }

        private void Enumeral_FormSetup()
        {
            _FormEnumeral = new FormCreator_Enumeral_Form();
            _FormEnumeral.TopMost = true;
            _FormEnumeral.Setup(this, AssemblyFilters);
        }

        private void Setup_ClassGenerate(bool showDialog = true)
        {
            if (_FormCreator_StartupFlag) return;   // Prevent actions during construction
            _frmClassGenerateSetup = new FormCreator_SelectClasses_Form(this);
            if (showDialog)
            {
                // Select the class to generate
                if (_frmClassGenerateSetup.ShowDialog() == DialogResult.OK)
                {
                    Generator_Class = _frmClassGenerateSetup.ClassName;
                    // Set the form Text
                    Tuple<Type, Attribute> typeAttribute;
                    if (ClassTypeDef(this, out typeAttribute))
                    {
                        var tableDef = typeAttribute.Item2 as propertyTable_Attribute;
                        if (tableDef != null && tableDef.Caption != "") _formName.Text = tableDef.Caption;
                    }
                }
            }
        }

        private void Setup_Go(bool showMsg = true)
        {
            if (_FormCreator_StartupFlag) return;   // Prevent actions during construction

            if (Generator_Class.zIsNullOrEmpty())
            {
                "Error! No class was specified for generation.".zOk();
                return;
            }

            if (Panel_Main == null)
            {
                "Error! Cannot generate form if Panel_Main is not assigned!".zOk();
                return;
            }

            if (Panel_1 == null)
            {
                ("Error! Cannot generate controls if Panel_1 is unknown.".NL() + " (Set the 'Panel_Setup' property)").zOk();
                return;
            }

            // Final Check
            // =================================================================================
            var msg = "This will generate the class '{0}'. Continue...".zFormat(_generatorClass);
            if (msg.zDialog().MessageBox_YesNo() == false)  return;
            // =================================================================================

            #region Back-end
            // ==================
            // Backend generation
            // ==================
            if (_host == null) _host = UIDesigner_Service.IDesignerHost_FromComponent(this);
            CodeTypeDeclaration codeBackend = UIDesigner_Service.CodeTypeDeclaration_FromHost(_host);
            if (codeBackend == null)
            {
                "Error! Can not generate backend because a CodeTypeDeclaration service was not available.".zOk();
                return;
            }

            CodeMemberMethod method1;
            if (UIDesigner_Code.Method_Find(codeBackend, out method1, "Model_Setup", true, MemberAttributes.Public) == false)
            {
                UIDesigner_Code.Method_AddParameter(method1, Generator_Class, "model");

                UIDesigner_Code.Method_AddCode(method1, "// Todo: Create the following fields in the form ");
                UIDesigner_Code.Method_AddCode(method1, "// private readonly UIWindows _lamedalWin = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib");
                UIDesigner_Code.Method_AddCode(method1, "// private " + Generator_Class + " _model;");
                UIDesigner_Code.Method_AddCode(method1, "_model = model;");
                codeBackend.Members.Add(method1);
            }
            
            CodeMemberMethod method2;
            if (UIDesigner_Code.Method_Find(codeBackend, out method2, "Model_RefreshForm", true, MemberAttributes.Public) == false)
            {
                UIDesigner_Code.Method_AddCode(method2, "// Update the form from the object.");
                UIDesigner_Code.Method_AddCode(method2, "_lamedalWin.libUI.WinForms.FormGenerate.Form_FromObject(this, _model);");
                codeBackend.Members.Add(method2);
            }
            // private void Model_OnFormValueChangeEvent(object sender, evInput_Control_EventArgs e)
            CodeMemberMethod method3;
            if (UIDesigner_Code.Method_Find(codeBackend, out method3, "Model_OnFormValueChangeEvent") == false)
            {
                UIDesigner_Code.Method_AddParameter(method3, "System.Object", "sender");
                UIDesigner_Code.Method_AddParameter(method3, "evInput_Control_EventArgs", "e");

                codeBackend.Members.Add(method3);
            }
            // ReAdd the code as expression
            UIDesigner_Code.Method_AddCode(method3, "// When the value on the form is updted -> sync changes to the object.", true);
            UIDesigner_Code.Method_AddCode(method3, "// Wait 1 second then sync from the object back to the form. (This ensure that the object is the master of the data", true);
            UIDesigner_Code.Method_AddCode(method3, "_lamedalWin.libUI.WinForms.FormGenerate.Form_ToObject(e, _model)", true);
            UIDesigner_Code.Method_AddCode(method3, "1000.zExecute_Async(Model_RefreshForm, \"formRefresh\", true)", true);

            #endregion
            
            #region Front-end
           
            // ======================
            // Generate the front-end
            // ======================
            // Find the type to generate
            Tuple<Type, Attribute> typeAttribute;
            if (ClassTypeDef(this, out typeAttribute))
            {
                //UIDesigner_Generate.Form_PanelSetup(this, Panel_Setup, Panel_Main, out _panel1, out _panel2, out _panel3, showMsg);   // Reset the panels
                _lamedalWin.libUI.WinForms.FormGenerate.Generate_Controls(_host, typeAttribute.Item1, (propertyTable_Attribute) typeAttribute.Item2, Panel_1, Panel_2, Panel_3, null);  // Generate the controls
            }
            else "Error! No fields were marked with the propertyField_Attribute".zOk();

            #endregion

            "Finish generating form. Please remove the generator component.".zOk();
        }

        private bool ClassTypeDef(object sender, out Tuple<Type, Attribute> classTypeAttribute)
        {
            classTypeAttribute = null;
            Assembly assembly = Lamedal_WinForms.Instance.lib.dotNet.Assembly.Get_(sender);
            Dictionary<string, Tuple<Type, Attribute>> typeAttributeDictionary;
            if (_lamedalWin.libUI.WinForms.FormGenerate.AssemblyTypes(assembly, out typeAttributeDictionary) == false)
            {
                "Error! Type '{0}' not found.".zFormat(Generator_Class).zOk();
                return false;
            }

            // Find the type to generate
            if (typeAttributeDictionary.TryGetValue(Generator_Class, out classTypeAttribute)) return true;
            return false;
        }
    }
}
