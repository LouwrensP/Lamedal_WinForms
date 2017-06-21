using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using LamedalCore;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    public sealed partial class FormCreator_SelectClasses_Form : System.Windows.Forms.Form
    {
        private readonly Component _parent;
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private string _className;

        public FormCreator_SelectClasses_Form(Component parent)
        {
            _parent = parent;
            InitializeComponent();
            Setup(parent);
        }

        public string ClassName
        {
            get { return _className; }
        }

        public Dictionary<string, Tuple<Type, Attribute>> TypeAttributeDictionary
        {
            get { return _typeAttributeDictionary; }
        }
        private Dictionary<string, Tuple<Type, Attribute>> _typeAttributeDictionary;

        public void Setup(Component component)
        {
            // Populate the list of classes that can be generated
            Assembly assembly = LamedalCore_.Instance.Types.Assembly.From_Object(component);

            List<string> typeNameList;
            if (IamWindows.libUI.WinForms.FormGenerate.AssemblyTypes(assembly, out typeNameList, out _typeAttributeDictionary))
            {
                typeNameList.zTo_IList(listBox_Classes.Items);
                listBox_Classes.SelectedIndex = 0;
            }
        }

        private void listBox_Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _className = listBox_Classes.Text;
        }
    }
}
