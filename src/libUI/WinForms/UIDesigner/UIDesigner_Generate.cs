using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public static class UIDesigner_Generate
    {

        /// <summary>
        /// Remove all controls from the main panel and rebuild all.
        /// </summary>
        /// <param name="designer">The designer</param>
        /// <param name="panelMain">The panel main</param>
        /// <param name="clearAll">if set to <c>true</c> [clear all].</param>
        public static void Form_PanelClear(Component designer, Panel panelMain, bool clearAll = false)
        {
            IDesignerHost host = UIDesigner_Service.IDesignerHost_FromComponent(designer);
            if (panelMain == null) clearAll = true; 
            if (host == null)
            {
                panelMain.Controls.Clear(); // It was called from runtime
            }
            else
            {
                List<Control> controls = (clearAll) ? UIDesigner_Tools.Host_Controls_All(host) : panelMain.Controls.Cast<Control>().ToList();
                foreach (Control control in controls)
                {
                    if (control is Form) continue;
                    host.DestroyComponent(control);
                }
            }
        }

        /// <summary>
        /// Panels generates the form.
        /// </summary>
        /// <param name="designer">The designer</param>
        /// <param name="panels">The e form panels</param>
        /// <param name="panelMain">The panel main</param>
        /// <param name="panel1">Return the panel1</param>
        /// <param name="panel2">Return the panel to</param>
        /// <param name="panel3">Return the panel3</param>
        /// <param name="showMsg">if set to <c>true</c> [show MSG].</param>
        public static void Form_PanelSetup(Component designer, enFormPanels panels, Panel panelMain, 
            out Panel panel1, out Panel panel2, out Panel panel3, bool showMsg = true)
        {
            panel1 = null; panel2 = null; panel3 = null;

            if (panels == enFormPanels.Custom) return;  // Do nothing

            if (showMsg)
            {
                string warningMsg = "The form will be cleared of all controls and rebuild! Continue?";
                if (warningMsg.zDialog().MessageBox_YesNo() == false) return;
            }

            IDesignerHost host = UIDesigner_Service.IDesignerHost_FromComponent(designer);
            Form form = null;
            if (host == null)
            {
                if (panelMain == null) return;
                form = panelMain.FindForm();
            }
            else form = UIDesigner_Tools.Host_Controls_Form(host);
            if (form == null)
            {
                "Error! Unable to identify main form!".zOk();
                return;
            }

            int value, formWidth;
            if (panels.zValue_AsInt(out value, out formWidth) == false)
            {
                // enumValue_Attribute not setup
                ("Error! enumValue_Attribute not setup for '{0}'".zFormat(panels.ToString())).zOk();
                return;
            }

            if (form.Width > formWidth || form.Width < formWidth - 50) form.Width = formWidth;

            // Remove all controls from the main panel and rebuild all
            Form_PanelClear(designer, panelMain, false);

            // Build the new panels
            if (panels == enFormPanels.OnePanel) panel1 = Create_Panel(host, panelMain, DockStyle.Fill);
            else if (panels == enFormPanels.TwoPanels)
            {
                panel1 = Create_Panel(host, panelMain, DockStyle.Left);
                panel2 = Create_Panel(host, panelMain, DockStyle.Fill);
            }
            else if (panels == enFormPanels.TreePanels)
            {
                panel1 = Create_Panel(host, panelMain, DockStyle.Left);
                panel2 = Create_Panel(host, panelMain, DockStyle.Left);
                panel3 = Create_Panel(host, panelMain, DockStyle.Fill);
            }
            else if (panels == enFormPanels.Custom)
            {
                // Do Nothing
            }
        }

        /// <summary>
        /// Setups the form.
        /// </summary>
        /// <param name="designer">The designer.</param>
        /// <param name="formSize">Size of the form.</param>
        /// <param name="panelMain">The panel main.</param>
        public static void Form_Size(Component designer, enFormSize formSize, Panel panelMain = null)
        {
            IDesignerHost host = UIDesigner_Service.IDesignerHost_FromComponent(designer);
            Form form = null;
            if (host == null)
            {
                if (panelMain == null)
                {
                    "Error! Main panel can not be null.".zOk();
                    return;
                } 
                form = panelMain.FindForm();
            }
            else form = UIDesigner_Tools.Host_Controls_Form(host);
            if (form == null)
            {
                "Error! Unable to identify main form!".zOk();
                return;
            }

            // Setup the form sizes
            int value, formHeight;
            if (formSize.zValue_AsInt(out value, out formHeight) == false)
            {
                // enumValue_Attribute not setup
                ("Error! enumValue_Attribute not setup for '{0}'".zFormat(formSize.ToString())).zOk();
                return;
            }
            if (form.Height > formHeight || form.Height < formHeight - 50) form.Height = formHeight;
        }

        /// <summary>
        /// Creates input control for the form.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="parentPanel">The panel</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldCaption">The field caption.</param>
        /// <param name="fieldType">Type of the field.</param>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="OnInputValueChangeEvent">The on value change.</param>
        /// <returns>
        /// Input_Control
        /// </returns>
        public static Input_Control Create_Input(IDesignerHost host, Panel parentPanel,
                    string fieldName = "FieldName1", string fieldCaption = "Caption1", Type fieldType = null, string fieldValue = "",
                    EventHandler<evInput_Control_EventArgs> OnInputValueChangeEvent = null)
        {
            if (fieldType == null) fieldType = typeof(string);

            Input_Control input;
            if (host == null)
                 input = Lamedal_WinForms.Instance.libUI.WinForms.Controls.Create.Add2Form<Input_Control>(parentPanel); // Normal runtime
            else input = UIDesigner_Tools.Host_Controls_Add2Form<Input_Control>(host, parentPanel);

            input.BringToFront();
            //input.zControl_MoveToContainer(parentPanel);
            input.Dock = DockStyle.Top;

            input.Field_Name = fieldName;
            input.Field_Caption = fieldCaption;
            input.Field_Value = fieldValue;

            if (fieldType == typeof(bool)) input.ControlType = enInputControl_Type.Checkbox1;   // Checkbox
            if (fieldType == typeof(DateTime)) input.ControlType = enInputControl_Type.DateTime;  // DateTime
            if (LamedalCore_.Instance.Types.Enum.IsEnumerable(fieldType))
            {
                // ComboBox
                input.ControlType = enInputControl_Type.Combobox;
                fieldType.zEnum_To_IList(input.Ctrl_Combobox.Items);
                input.Ctrl_Combobox.Text = fieldValue;
            }

            if (host == null)
            {
                if (OnInputValueChangeEvent != null) input.Event_OnValueChange += OnInputValueChangeEvent;

            } else
            {
                // Add the event
                var eventName = "Event_OnValueChange";
                var eventMethodName = "Model_OnFormValueChangeEvent";
                //eventMethodName = OnInputValueChangeEvent.GetType().Name;    // This method needs to be tested
                Create_Event(host, input, eventName, eventMethodName);
            }
            return input;
        }

        private static void Create_Event(IDesignerHost host, Input_Control input, string eventName, string eventMethodName)
        {
            IEventBindingService eventBindingService = UIDesigner_Service.IEventBindingService_FromHost(host);
            EventDescriptorCollection eventColl = TypeDescriptor.GetEvents(input, new Attribute[0]);
            if (eventColl != null)
            {
                var eventDescriptor = eventColl[eventName] as EventDescriptor;
                if (eventDescriptor != null)
                {
                    PropertyDescriptor propertyDescriptor = eventBindingService.GetEventProperty(eventDescriptor);
                    propertyDescriptor.SetValue(input, eventMethodName);
                }
            }
        }


        /// <summary>
        /// Creates panel for the form.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="mainPanel">The main panel</param>
        /// <param name="dock">The dock style</param>
        /// <returns>Panel</returns>
        public static Panel Create_Panel(IDesignerHost host, Panel mainPanel, DockStyle dock)
        {
            Panel panel1;
            if (host == null)
                panel1 = new Panel();
            else panel1 = UIDesigner_Tools.Host_Controls_Add2Form<Panel>(host);

            panel1.Parent = mainPanel;
            panel1.Width = 260;
            //panel1.Left = mainPanel.Width - 10;
            panel1.BringToFront();
            panel1.BorderStyle = BorderStyle.FixedSingle;
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.Control.MoveToContainer(panel1, mainPanel);
            panel1.Dock = dock;
            return panel1;
        }

    }
}
