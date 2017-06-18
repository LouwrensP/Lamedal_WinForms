using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;
using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.zzz;
using UIDesigner_Service = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Service;
using UIDesigner_Tools = LaMedalPort.UIWindows.libUI.WinForms.UIDesigner.UIDesigner_Tools;

namespace Lamedal_UIWinForms.UControl.form1
{
    [Description("Set Windows Properties")]
    [Serializable]
    //DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(FormControls_Designer))]   // Link the designer
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Component))]
    public class FormControls_ : Form_
    {
        private bool _FormControls_StartupFlag = true;

        #region properties
        [Category("\tControls")]
        [Description("Add control of standard buttons to the form")]
        public bool Controls_StandardButtons
        {
            get { return _Controls_StandardButtons; }
            set
            {
                _Controls_StandardButtons = value;
                Setup_StandardButtons(value);
            }
        }
        private bool _Controls_StandardButtons;

        [Category("\tControls")]
        [Description("Add control of tooltips to the form")]
        public bool Controls_Tooltips
        {
            get { return _Controls_Tooltips; }
            set
            {
                _Controls_Tooltips = value;
                Setup_ToolTips(value);
            }
        }
        private bool _Controls_Tooltips;

        [Category("\tControls")]
        [Description("Add status strip control to the form")]
        public bool Controls_StatusStrip
        {
            get { return _Controls_StatusStrip; }
            set
            {
                _Controls_StatusStrip = value;
                Setup_StatusStrip(value);
            }
        }
        private bool _Controls_StatusStrip;

        [Category("\tControls")]
        [Description("Add tool strip control to the form")]
        public bool Controls_ToolStrip
        {
            get { return _Controls_ToolStrip; }
            set
            {
                _Controls_ToolStrip = value;
                Setup_ToolStrip(value);
            }
        }
        private bool _Controls_ToolStrip;

        [Category("\tControls")]
        [Description("Add ContextMenuStrip control to the form")]
        public bool Controls_ContextMenuStrip
        {
            get { return _Controls_ContextMenuStrip; }
            set
            {
                _Controls_ContextMenuStrip = value;
                Setup_ContextMenuStrip(value);
            }
        }
        private bool _Controls_ContextMenuStrip;

        [Category("\tControls")]
        [Description("Add Toolbar panel to the form")]
        public bool Controls_ToolbarPanel
        {
            get { return _Controls_ToolbarPanel; }
            set
            {
                _Controls_ToolbarPanel = value;
                Setup_ToolbarPanel(value);
            }
        }
        private bool _Controls_ToolbarPanel;

        #region properties - Panels

        [Category("\tControls")]
        [Description("Define the main panel. (Controls will be generated within the main panel)")]
        public Panel Panel_Main
        {
            get { return _panelMain; }
            set { _panelMain = value; }
        }
        private Panel _panelMain;

        [Category("\tControls")]
        [Description("The 1st panel.")]
        public Panel Panel_1
        {
            get { return _panel1; }
        }
        private Panel _panel1;

        [Category("\tControls")]
        [Description("The 2nd panel.")]
        public Panel Panel_2
        {
            get { return _panel2; }
        }
        private Panel _panel2;

        [Category("\tControls")]
        [Description("The 3rd panel.")]
        public Panel Panel_3
        {
            get { return _panel3; }
        }
        private Panel _panel3;

        [Category("\tControls")]
        [Description("Set the form panels.")]
        public enFormPanels Panel_Setup
        {
            get { return _panelSetup; }
            set
            {
                _panelSetup = value;
                Setup_Panels();
            }
        }
        private enFormPanels _panelSetup = enFormPanels.Custom;

        #endregion


        public bool Reset
        {
            get { return _reset; }
            set
            {
                _reset = value;
                if (value)
                {
                    Setup_Reset();
                    _reset = false;
                }
            }
        }
        private bool _reset;

        #endregion

        protected override void Setup_()
        {
            base.Setup_();
            _FormControls_StartupFlag = false;
            if (_formHost == null) return;

            if (_panelMain == null)
            {
                // If there is only 1 panel -> assume it is the main panel
                var panels = UIDesigner_Tools.Host_Controls_All<Panel>(_formHost);
                if (panels.Count == 0) Setup_PanelMain();
                //if (panels.Count == 1)
                //{
                //    _panelMain = panels[0];  // We cannot assume this to be true. 
                //}
                else
                {
                    foreach (Panel panel in panels)
                    {
                        if (panel.Tag.zObject().AsStr() == "MainPanel")
                        {
                            _panelMain = panel;
                            break;
                        }
                    }
                }
            }
        }

        private bool IsNotSave()
        {
            // Code can only execute in design time after setup code has completed!
            if (DesignMode == false) return true;
            if (_FormControls_StartupFlag) return true;
            if (_formName == null) return true;
            if (_formHost == null) return true;

            return false;
        }

        private void Setup_Reset()
        {
            if (IsNotSave()) return;
            if ("This will remove all controls. Continue?".zDialog().MessageBox_YesNo() == false) return;

            UIDesigner_Generate.Form_PanelClear(this, Panel_Main, true);
            _panelMain = null;
            if ("Rebuild the main form?".zDialog().MessageBox_YesNo() == true) Setup_();
        }

        private void Setup_PanelMain()
        {
            if (IsNotSave()) return;
            // Create the main panel
            var panel = UIDesigner_Tools.Host_Controls_Add2Form<Panel>(_formHost, _formName);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Dock = DockStyle.Fill;
            panel.Tag = "MainPanel";
            _panelMain = panel;
        }

        private void Setup_Panels()
        {
            if (IsNotSave()) return;
            if (_panelMain == null)
            {
                // Lets try to get the main panel
                "No Main Panel assigned.".zOk();
                _formHost = UIDesigner_Service.IDesignerHost_FromComponent(this);
                var panels = UIDesigner_Tools.Host_Controls_All<Panel>(_formHost);
                foreach (Panel panel in panels)
                {
                    if (panel.Tag.ToString() == "MainPanel") _panelMain = panel;
                }
                if (panels.Count == 0) Setup_PanelMain();

                if (_panelMain == null)
                {
                    "Cannot change panels if Panel_Main is not assigned!".zOk();
                    return;
                }
            }
            UIDesigner_Generate.Form_PanelSetup(this, Panel_Setup, Panel_Main, out _panel1, out _panel2, out _panel3);
        }

        private void Setup_StandardButtons(bool createControl)
        {
            if (IsNotSave()) return;
            Button_Standard button;
            if (UIDesigner_Tools.Control_Setup1(_formHost, _formName, createControl, out button))
            {
                button.Visible_Cancel = true;
                button.Dock = DockStyle.Bottom;
            }
        }

        private void Setup_ContextMenuStrip(bool createControl)
        {
            if (IsNotSave()) return;
            if (createControl && "This will create a new ContextMenuStrip. Continue?".zDialog().MessageBox_YesNo() == false) return;

            ContextMenuStrip menuStrip;
            if (UIDesigner_Tools.Component_Setup1(_formHost, _formName, createControl, out menuStrip))
            {
                _formName.ContextMenuStrip = menuStrip;
            }
        }

        private void Setup_StatusStrip(bool createControl)
        {
            if (IsNotSave()) return;
            StatusStrip statusStrip;
            if (UIDesigner_Tools.Control_Setup1(_formHost, _formName, createControl, out statusStrip))
            {
                statusStrip.Dock = DockStyle.Bottom;
                statusStrip.SendToBack();
            }
        }

        private void Setup_ToolTips(bool createControl)
        {
            if (IsNotSave()) return;
            ToolTip tooltip;
            UIDesigner_Tools.Component_Setup1(_formHost, _formName, createControl, out tooltip);
        }

        private void Setup_ToolStrip(bool createControl)
        {
            if (IsNotSave()) return;
            ToolStrip toolStrip;
            if (UIDesigner_Tools.Control_Setup1 <ToolStrip>(_formHost, _formName, createControl, out toolStrip))
            {
                toolStrip.Dock = DockStyle.Top;
                toolStrip.SendToBack();
            }
        }

        private void Setup_ToolbarPanel(bool createControl)
        {
            if (IsNotSave()) return;
            Panel panel;
            if (UIDesigner_Tools.Control_Setup1<Panel>(_formHost, _formName, createControl, out panel, true, "Toolbar_Panel"))
            {
                // There will be more than one panel. Mark the Toolbar panel with "Toolbar_Panel" in the tag property
                panel.Height = 32;
                panel.Tag = "Toolbar_Panel";
                panel.Dock = DockStyle.Top;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.SendToBack();
            }
        }

    }
}
