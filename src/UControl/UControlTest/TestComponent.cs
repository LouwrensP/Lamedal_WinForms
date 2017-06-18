using System;
using System.ComponentModel;

namespace Lamedal_UIWinForms.UControl.UControlTest
{
    [Description("Add button to Designer")]
    [Serializable]
    //DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("AddButton")]
    [ToolboxItem(false)]
    [Designer(typeof(TestComponent_Designer))]   // Link the designer
    public partial class TestComponent : Component
    {

        public TestComponent()
        {
            InitializeComponent();
        }

        public TestComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool AddButton
        {
            get { return _AddButton; }
            set
            {
                _AddButton = value;
                if (value)
                {
                    // Do the Action

                    _AddButton = false;
                }
            }
        }
        private bool _AddButton;

    }
}
