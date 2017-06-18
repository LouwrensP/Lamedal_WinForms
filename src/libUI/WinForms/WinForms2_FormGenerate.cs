using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.libUI.Interfaces;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;
using Lamedal_UIWinForms.State;
using Lamedal_UIWinForms.UControl.Forms.Dialog;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <code CTI_Timestamp="2015/07/20" CTI_DefaultGroup="Setup" Group="FormGenerate" CTI_Status="Unchecked;" DefaultType="Form">CTI;</code>
    public sealed class WinForms2_FormGenerate
    {
        private readonly dotNet_ _dotNet = LaMedalPort.UIWindows.Instance.lib.dotNet;
        private readonly LaMedalPort.UIWindows IamWindows = LaMedalPort.UIWindows.Instance;

         // Set reference to Blueprint Windows lib
        /// <summary>
        /// Searches the assembly for types that can be code generated.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="typeAttributeDictionary">The type attribute dictionary</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool AssemblyTypes(Assembly assembly, out Dictionary<string, Tuple<Type, Attribute>> typeAttributeDictionary)
        {
            List<string> typeNameList;
            return AssemblyTypes(assembly, out typeNameList, out typeAttributeDictionary);
        }

        /// <summary>
        /// Searches the assembly for types that can be code generated.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="typeNameList">Return the type name list</param>
        /// <param name="typeAttributeDictionary">The type attribute dictionary</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool AssemblyTypes(Assembly assembly, out List<string> typeNameList, out Dictionary<string, Tuple<Type, Attribute>> typeAttributeDictionary)
        {
            return _dotNet.Assembly.Types(assembly, out typeNameList, out typeAttributeDictionary, filterForThisAttribute: typeof(propertyTable_Attribute));
        }

        /// <summary>
        /// Update the generated form from the object.
        /// </summary>
        /// <param name="form">The form</param>
        /// <param name="Object">The object</param>
        /// <param name="fieldName">Name of the field.</param>
        public void Form_FromObject(Form form, IObjectModel Object, string fieldName = "")
        {
            if (Object == null)
            {
                "Error! The object can not be null!".zException_Show();
                return;
            }

            var type = Object.GetType();
            var controls = IamWindows.libUI.WinForms.Controls.Control.FindComponents<IUControl_ObjectModel>(form);
            List<IUControl_ObjectModel> controlFields;
            if (fieldName == "") controlFields = controls.Where(x => x.Field_Name != null).ToList();
            else controlFields = controls.Where(x => x.Field_Name == fieldName).ToList();

            FieldInfo[] fields = LamedalCore_.Instance.Types.Class.ClassInfo.Fields_AsFieldInfo(type);
            PropertyInfo[] properties = LamedalCore_.Instance.Types.Class.ClassInfo.Properties_AsPropertyInfo(type);

            foreach (IUControl_ObjectModel control in controlFields)
            {
                // Find the field or the property form the object and
                // get the value
                // =================================================
                object value = null;
                fieldName = control.Field_Name;
                FieldInfo field = fields.FirstOrDefault(x => x.Name == fieldName);
                if (field != null) value = field.GetValue(Object);
                else
                {
                    PropertyInfo property = properties.FirstOrDefault(x => x.Name == fieldName);
                    if (property == null)
                    {
                        var errMsg =
                            "Error! Unable to find form control in the model for field name '{0}'.".zFormat(fieldName);
                        errMsg.zException_Show(action: enExceptionAction.ShowMessage);
                        return;
                    }
                    value = property.GetValue(Object, null);
                }


                // Assign the value to the control on the form
                // ===========================================
                //var test = value == null;
                //if (test == false) test = value is string;

                if (control is ListBox /*&& test == false*/ )
                {
                    var listbox = control as ListBox;
                    if (value == null) listbox.Items.Clear();
                    else
                    {
                        var listValues = (IList)value;
                        if (listbox.Items.Count != listValues.Count) listbox.Items.zFrom_IList(listValues);                        
                    }
                }
                else
                {
                    string fieldValue = value.zObject().AsStr();
                    control.Field_Value = fieldValue;
                }
            }
        }

        /// <summary>
        /// Converts the generated form to object.
        /// </summary>
        /// <param name="e">The input event arguments control</param>
        /// <param name="Object">The object</param>
        public void Form_ToObject(evInput_Control_EventArgs e, IObjectModel Object)
        {
            // Value on the form has changed -> update the object
            Input_Control input = e.Control_;
            string fieldName = input.Field_Name;
            string fieldValue = input.Field_Value;
            FieldInfo fieldInfo = Object.GetType().GetField(fieldName);
            Type fieldType = fieldInfo.FieldType;

            object value;
            if (fieldValue.zIsNullOrEmpty()) value = LaMedalPort.UIWindows.Instance.Types.Generic.DefaultValue(fieldType);
            else value = LaMedalPort.UIWindows.Instance.Types.Generic.Convert(fieldValue, fieldType);
            fieldInfo.SetValue(Object, value);
        }

        /// <summary>Generates the controls on the designer panels.</summary>
        /// <param name="designer">The designer</param>
        /// <param name="classType">The class type</param>
        /// <param name="classAttribute">The class attributeuteibute</param>
        /// <param name="panel1">The panel1</param>
        /// <param name="panel2">The panel to setting. Default value = null.</param>
        /// <param name="panel3">The panel3 setting. Default value = null.</param>
        /// <param name="onValueChange">The on valueue change setting. Default value = null.</param>
        /// <returns>The height of the form should be</returns>
        public int Generate_Controls(IDesignerHost designer, Type classType, propertyTable_Attribute classAttribute, Panel panel1, Panel panel2 = null, Panel panel3 = null, EventHandler<evInput_Control_EventArgs> onValueChange = null)
        {
            Panel panel = null;
            if (panel1 == null)
            {
                "Error! Cannot generate controls if Panel_1 is unknown.".zOk();
                return 0;
            }

            // Find decorated properties for the class that is to be generated
            bool class_GenerateAllFields = (classAttribute == null) ? true : classAttribute.GenerateAllFields;

            // For class type, get all fields that was marked with propertyField_Attribute
            Input_Control input = null;
            List<Tuple<FieldInfo, Attribute>> fields = _dotNet.ClassAttribute.Field_FindAttributes(classType, typeof(propertyField_Attribute), class_GenerateAllFields);
            dynamic defaultO = UIDesigner_Form.Create(classType);
            foreach (Tuple<FieldInfo, Attribute> field in fields)
            {
                // ===================================
                // Read all the definition information
                // ===================================
                FieldInfo fieldInfo = field.Item1;
                object value = fieldInfo.GetValue(defaultO);
                string fieldValue = value.zObject().AsStr();
                string fieldName = fieldInfo.Name;

                var fieldDefinition = field.Item2 as propertyField_Attribute;
                if (fieldDefinition == null)
                {
                    if (class_GenerateAllFields) fieldDefinition = new propertyField_Attribute();
                    else
                    {
                        "Error! Field '{0}' does not have attribute propertyField_Attribute.".zFormat(fieldName).zOk();
                        continue;  // <========================================================================================
                    }
                }
                if (fieldDefinition.IsVisible == false) continue;  // <=================================================

                string fieldCaption = fieldDefinition.Caption;
                if (fieldCaption == "") fieldCaption = fieldName;
                Type fieldType = fieldInfo.FieldType;
                string fieldDescription = fieldDefinition.Description;
                bool fieldIsPassword = fieldDefinition.IsPassword;
                bool fieldIsRequired = fieldDefinition.IsRequired;
                int fieldValueMax = fieldDefinition.ValueMax;
                int fieldValueMin = fieldDefinition.ValueMin;
                int fieldLengthMax = fieldDefinition.LengthMax;
                int fieldLengthMin = fieldDefinition.LengthMin;

                // Create the form for capturing values
                if (panel == null) panel = panel1;
                input = UIDesigner_Generate.Create_Input(designer, panel, fieldName, fieldCaption, fieldType, fieldValue, onValueChange);
                // Set the panel
                if (panel == panel3) panel = panel1;
                else if (panel == panel2)
                {
                    if (panel3 == null)
                        panel = panel1;
                    else panel = panel3;

                }
                else if (panel == panel1)
                {
                    if (panel2 != null) panel = panel2;
                }


                if (input != null)
                {
                    input.Field_Description = fieldDescription;
                }
            }

            if (input != null) return input.Top + input.Height + 80;
            return 0;
        }

        public Form Form_Generate(object classObject, EventHandler<evInput_Control_EventArgs> onValueChange = null, enFormPanels panels = enFormPanels.OnePanel)
        {
            var model = classObject as IObjectModel;
            return Form_Generate(model, onValueChange: onValueChange, panels: panels);
        }

        /// <summary>Generates the controls on the designer panels.</summary>
        /// <param name="classObject">The class objectect</param>
        /// <param name="onValueChange">The on valueue change setting. Default value = null.</param>
        /// <param name="panels">The panels setting. Default value = OnePanel.</param>
        /// <returns>Form</returns>
        public Form Form_Generate(IObjectModel classObject, EventHandler<evInput_Control_EventArgs> onValueChange = null, enFormPanels panels = enFormPanels.OnePanel)
        {
            propertyTable_Attribute attribute;
            classObject.GetType().zAttribute_Find(out attribute);
            if (attribute != null) panels = attribute.FormPanels;


            if (panels == enFormPanels.OnePanel)   // Create form with 1 panel
            {
                var frmDialog1 = new Form_ClassDialog1();
                if (Generate_Controls(frmDialog1, classObject, frmDialog1.panel2, onValueChange: onValueChange)) return frmDialog1;
            }
            if (panels == enFormPanels.TwoPanels)  // Create form with 2 panels
            {
                var frmDialog2 = new Form_ClassDialog2();
                if (Generate_Controls(frmDialog2, classObject, frmDialog2.panel2, frmDialog2.panel3, onValueChange: onValueChange)) return frmDialog2;
            }
            if (panels == enFormPanels.TreePanels)   // Create form with 3 panels
            {
                var frmDialog3 = new Form_ClassDialog3();
                if (Generate_Controls(frmDialog3, classObject, frmDialog3.panel2, frmDialog3.panel3, frmDialog3.panel4, onValueChange)) return frmDialog3;
            }

            return null;
        }

        /// <summary>Generates the controls on the designer panels.</summary>
        /// <param name="form">The form</param>
        /// <param name="classObject">The class objectect</param>
        /// <param name="panel1">The panel1</param>
        /// <param name="panel2">The panel to setting. Default value = null.</param>
        /// <param name="panel3">The panel3 setting. Default value = null.</param>
        /// <param name="onValueChange">The on valueue change setting. Default value = null.</param>
        /// <returns>bool</returns>
        public bool Generate_Controls(Form form, IObjectModel classObject, Panel panel1, Panel panel2 = null, Panel panel3 = null,EventHandler<evInput_Control_EventArgs> onValueChange = null)
        {
            var type = classObject.GetType();
            propertyTable_Attribute attribute;
            type.zAttribute_Find(out attribute);

            stateForm state = form.zzState();
            state.onValueChange = onValueChange;
            state.FormObjectModel = classObject;
            state.DoEventsFlag = false;

            IDesignerHost host = UIDesigner_Service.IDesignerHost_FromForm(form);
            int height = LaMedalPort.UIWindows.Instance.libUI.WinForms.FormGenerate.Generate_Controls(host, type, attribute, panel1, panel2, panel3, OnValueChangeEvent);
            form.Height = height;
            if (attribute != null)
            {
                if (attribute.Caption != "") form.Text = attribute.Caption;
            }

            state.DoEventsFlag = true;
            return true;
        }

        /// <summary>
        /// Setups the model and Form fields.
        /// </summary>
        /// <param name="form">The form</param>
        /// <param name="model">The IO bject model</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="control">The object model iucontrol</param>
        /// <param name="id">The identifier setting. Default value = -1.</param>
        /// <code>CTIM_Generation;</code>
        public void ModelField(IObjectModel model, Form form, string fieldName, IUControl_ObjectModel control, int id = -1)
        {
            //=================
            // Generated @ 2015/07/20
            // Generated from 'BlueprintUI.Windows.libUI.WinForms.ModelField'() -> the parameter order was changed to ensure better MTIN results after transformations.
            ModelField(form, model, fieldName, control, id);
        }

        /// <summary>
        /// Setups the model and Form fields.
        /// </summary>
        /// <param name="form">The form</param>
        /// <param name="model">The IO bject model</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="control">The object model iucontrol</param>
        /// <param name="id">The identifier setting. Default value = -1.</param>
        /// <code GenerateParameter1="model"></code>
        public void ModelField(Form form, IObjectModel model, string fieldName, IUControl_ObjectModel control, int id = -1)
        {
            // Double check value before assignment!
            // =====================================
            var type = model.GetType();
            propertyField_Attribute[] fieldDefinition = null;

            FieldInfo fieldInfo1 = type.GetField(fieldName);
            if (fieldInfo1 != null) fieldDefinition = (propertyField_Attribute[])fieldInfo1.GetCustomAttributes(typeof(propertyField_Attribute), false);
            else
            {
                PropertyInfo propertyInfo = type.GetProperty(fieldName);
                if (propertyInfo != null) fieldDefinition = (propertyField_Attribute[])propertyInfo.GetCustomAttributes(typeof(propertyField_Attribute), false);
            }

            if (fieldDefinition == null)
            {
                var errMsg = "Error! Field '{0}.{1}' does not exist!".zFormat(type.ToString(), fieldName);
                errMsg.zException_Show(action: enExceptionAction.ShowMessage);
                return;
            }

            // Check the ID value
            // ==================
            var fieldId = fieldDefinition.Length > 0 ? fieldDefinition[0].Id : -1;
            if (id != -1)
            {
                if (id != fieldId)
                {
                    var msg = "Error in object mapping!".NL() + "Field '{0}.{1}'".zFormat(type.ToString(), fieldName).NL() +
                              "{0} id = {1} (and not {2} as expected)".zFormat(fieldName, fieldId, id);
                    msg.zException_Show(action: enExceptionAction.ShowMessage);
                    return;
                }
            }

            control.Field_Name = fieldName;   // Map the field;

            // Update the field value on the form
            LaMedalPort.UIWindows.Instance.libUI.WinForms.FormGenerate.Form_FromObject(form, model, fieldName);  // Sync form

        }

        /// <summary>
        /// Resets every value in the model to default values.
        /// </summary>
        /// <param name="Object">The object</param>
        public void ModelReset(IObjectModel Object)
        {
            var type = Object.GetType();

            // Set the fields
            FieldInfo[] fields = LaMedalPort.UIWindows.Instance.Types.Generic.Class_Fields(type);
            foreach (FieldInfo field in fields)
            {
                object value = LaMedalPort.UIWindows.Instance.Types.Generic.DefaultValue(type);
                field.SetValue(Object, value);
            }

            // Set the properties
            PropertyInfo[] properties = LaMedalPort.UIWindows.Instance.Types.Generic.Class_Properties(type);
            foreach (PropertyInfo property in properties)
            {
                object value = LaMedalPort.UIWindows.Instance.Types.Generic.DefaultValue(type);
                var setter = property.GetSetMethod();
                if (setter != null) property.SetValue(Object, value, null);
            }

        }
        private void OnValueChangeEvent(object sender, evInput_Control_EventArgs e)
        {
            // Update the object from when the form values change
            Form frm = e.Control_.ParentForm;
            stateForm state = frm.zzState();
            if (state.DoEventsFlag == false) return;   // Events were stopped -> Exit <=========================================================

            IObjectModel classObject = state.FormObjectModel;
            if (state.onValueChange != null) state.onValueChange(sender, e);  // Notify the client that the value has changed

            LaMedalPort.UIWindows.Instance.libUI.WinForms.FormGenerate.Form_ToObject(e, classObject);  // Update the object in memory
            500.zExecute_Async(() => SyncFormAndObject(frm), "formRefresh", true);  // Sync the object back to the form in 1 sec
        }

        private void SyncFormAndObject(Form form)
        {
            //Update the generated the form from the object.
            stateForm state = form.zzState();
            state.DoEventsFlag = false;   // Stop events while we update things
            IObjectModel classObject = state.FormObjectModel;
            try
            {
                LaMedalPort.UIWindows.Instance.libUI.WinForms.FormGenerate.Form_FromObject(form, classObject);
            }
            finally { state.DoEventsFlag = true; }  // Activate the events again
        }
    }
}
