using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.zzz;
using LaMedalPort.UIWindows.libUI.WinForms.UIDesigner;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    public sealed partial class FormCreator_Enumeral_Form : System.Windows.Forms.Form
    {
        private List<Type> _myEnums;
        private IDesignerHost _host;
        private Component _designer;
        private bool _SelectionChangeFlag;
        private stateAssemblyFilters _AssemblyFilters;

        public FormCreator_Enumeral_Form()
        {
            InitializeComponent();
        }

        public void Setup(Component designer, stateAssemblyFilters AssemblyFilters)
        {
            _designer = designer;
            _AssemblyFilters = AssemblyFilters;
            _host = UIDesigner_Service.IDesignerHost_FromComponent(designer);
            if (_host != null)
            {
                // Set event
                UIDesigner_Tools.Host_Controls_SelectionChange(_host, OnselectionChanged);
                this.Closed -= OnFormClosed;
                this.Closed += OnFormClosed;

                this.TopMost = true;
                this.Show();
                500.zExecute_Async(Setup_EnumTypes);
                tabControl1.SelectedIndex = 1;
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            UIDesigner_Tools.Host_Controls_SelectionChange(_host, OnselectionChanged, true);  // Set the events
        }

        private void OnselectionChanged(object sender, EventArgs e)
        {
            // Set the active controlname
            if (_SelectionChangeFlag) return;
            _SelectionChangeFlag = true;

            Control control = UIDesigner_Tools.Host_Controls_SelectedFirst(_host);
            if (control is ComboBox || control is ListBox)
            {
                input_ControlName.Field_Value = control.Name;
                Generate_Code();
            }
            else if (control is Input_Control)
            {
                var inputControl = control as Input_Control;
                var name = inputControl.Name;
                if (inputControl.ControlType == enInputControl_Type.Combobox) input_ControlName.Field_Value = name + ".Ctrl_Combobox";
                else if (inputControl.ControlType == enInputControl_Type.Listbox) input_ControlName.Field_Value = name + ".Ctrl_ListBox"; 
                else "Please change the control type to 'Combobox' or 'Listbox'".zOk();
            }
            Generate_Code();
            _SelectionChangeFlag = false;
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            Setup_EnumTypes();
        }

        private void Setup_EnumTypes()
        {
            try
            {
                //Assembly gets the all from remove system assemblies indicator. Default value = true..
                List<string> assemblyNames;
                List<Assembly> assemblies = UIWindows.Instance.lib.dotNet.Assembly.Get_All(out assemblyNames, true, _AssemblyFilters);
                listBox_DLL.zListBox_Items_FromList(assemblyNames);

                // Show the enumerals
                // ==================
                List<string> typeNames;
                _myEnums = UIWindows.Instance.lib.dotNet.Assembly.Types_Enumerals(assemblies, out typeNames);  //Return enumeral types from the assemblies list.
                listBox_Enums.zListBox_Items_FromList(typeNames);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                exception.zException_Show(action: enExceptionAction.ShowMessage);
            }
        }

        private void listBox_Enums_SelectedIndexChanged(object sender, EventArgs e)
        {
            var enumName = listBox_Enums.Text;
            input_Enum.Field_Value = enumName;

            // Find the type
            Type myEnum = _myEnums.First(x => x.Name == enumName);
            if (myEnum != null) myEnum.zEnum_To_IList(listBox_1.Items);

            Generate_Code();
        }

        private void Generate_Code()
        {
            textBox_Code.Text = "{0}.zSetupEnum<{1}>({1}_Changed);".zFormat(input_ControlName.Field_Value, listBox_Enums.Text);
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            textBox_Code.Text.zClipboard_CopyStrTo();
        }

        private void listBox_DLL_SelectedIndexChanged(object sender, EventArgs e)
        {
            input_DLL.Field_Value = listBox_DLL.Text;
        }
    }
}
