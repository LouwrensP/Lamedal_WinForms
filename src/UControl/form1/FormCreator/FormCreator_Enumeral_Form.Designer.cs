using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.UControl.panel;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    sealed partial class FormCreator_Enumeral_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox_4 = new GroupBox_();
            this.textBox_Code = new TextBox_();
            this.groupBox_3 = new GroupBox_();
            this.listBox_1 = new ListBox_();
            this.groupBox_2 = new GroupBox_();
            this.input_ControlName = new Input_Control();
            this.listBox_Enums = new ListBox_();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.input_Enum = new Input_Control();
            this.panel_1 = new Panel_();
            this.button_Test = new Button_();
            this.button_Generate = new Button_();
            this.input_DLL = new Input_Control();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox_DLL = new ListBox_();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.groupBox_4.SuspendLayout();
            this.groupBox_3.SuspendLayout();
            this.groupBox_2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(243, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 342);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // groupBox_4
            // 
            this.groupBox_4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_4.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_4.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_4.CausesValidation = false;
            this.groupBox_4.Controls.Add(this.textBox_Code);
            this.groupBox_4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_4.Location = new System.Drawing.Point(246, 318);
            this.groupBox_4.Name = "groupBox_4";
            this.groupBox_4.Parent_GroupBox = null;
            this.groupBox_4.Parent_Panel = null;
            this.groupBox_4.Size = new System.Drawing.Size(475, 80);
            this.groupBox_4.TabIndex = 5;
            this.groupBox_4.TabStop = false;
            this.groupBox_4.Text = "Copy this code into the Form Startup event.";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Code.Location = new System.Drawing.Point(3, 16);
            this.textBox_Code.Multiline = true;
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Code.Size = new System.Drawing.Size(469, 61);
            this.textBox_Code.TabIndex = 0;
            // 
            // groupBox_3
            // 
            this.groupBox_3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_3.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_3.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_3.CausesValidation = false;
            this.groupBox_3.Controls.Add(this.listBox_1);
            this.groupBox_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_3.Location = new System.Drawing.Point(246, 56);
            this.groupBox_3.Name = "groupBox_3";
            this.groupBox_3.Parent_GroupBox = null;
            this.groupBox_3.Parent_Panel = null;
            this.groupBox_3.Size = new System.Drawing.Size(475, 262);
            this.groupBox_3.TabIndex = 3;
            this.groupBox_3.TabStop = false;
            this.groupBox_3.Text = "ListBox Sample";
            // 
            // listBox_1
            // 
            this.listBox_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_1.Location = new System.Drawing.Point(3, 16);
            this.listBox_1.Name = "listBox_1";
            this.listBox_1.Parent_GroupBox = this.groupBox_3;
            this.listBox_1.Parent_Panel = null;
            this.listBox_1.Size = new System.Drawing.Size(469, 238);
            this.listBox_1.TabIndex = 0;
            // 
            // groupBox_2
            // 
            this.groupBox_2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_2.CausesValidation = false;
            this.groupBox_2.Controls.Add(this.input_ControlName);
            this.groupBox_2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_2.Location = new System.Drawing.Point(243, 0);
            this.groupBox_2.Name = "groupBox_2";
            this.groupBox_2.Parent_GroupBox = null;
            this.groupBox_2.Parent_Panel = null;
            this.groupBox_2.Size = new System.Drawing.Size(478, 56);
            this.groupBox_2.TabIndex = 2;
            this.groupBox_2.TabStop = false;
            this.groupBox_2.Text = "Source Control Name:";
            // 
            // input_ControlName
            // 
            this.input_ControlName._Control_Action = false;
            this.input_ControlName._Control_Centre = 80;
            this.input_ControlName._Control_Rows = 1;
            this.input_ControlName._Control_Sync = false;
            this.input_ControlName.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.input_ControlName.Action_AutoSave = false;
            this.input_ControlName.Action_Button = false;
            this.input_ControlName.Action_Custom = enControl_InputCustomAction.None;
            this.input_ControlName.Action_EnterButton = null;
            this.input_ControlName.Action_Text = "..";
            this.input_ControlName.Action_Width = 30;
            this.input_ControlName.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.input_ControlName.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.input_ControlName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.input_ControlName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.input_ControlName.Border = false;
            this.input_ControlName.Border_Color = System.Drawing.Color.Red;
            this.input_ControlName.Border_Width = 2;
            this.input_ControlName.CausesValidation = false;
            this.input_ControlName.Combo_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.input_ControlName.ControlType = enControl_InputType.Edit;
            this.input_ControlName.Dock = System.Windows.Forms.DockStyle.Left;
            this.input_ControlName.Edit_Mask = null;
            this.input_ControlName.Edit_PasswordChar = '\0';
            this.input_ControlName.EnableSet_Control = null;
            this.input_ControlName.EnableSet_Index = 1;
            this.input_ControlName.Field_Caption = "ControlName:";
            this.input_ControlName.Field_Caption2 = "FieldName2";
            this.input_ControlName.Field_Caption3 = "FieldName3";
            this.input_ControlName.Field_Caption4 = "FieldName4";
            this.input_ControlName.Field_Description = null;
            this.input_ControlName.Field_Name = null;
            this.input_ControlName.Field_Value = "control1?";
            this.input_ControlName.Field_Value1 = false;
            this.input_ControlName.Field_Value2 = false;
            this.input_ControlName.Field_Value3 = false;
            this.input_ControlName.Filter_Control = null;
            this.input_ControlName.Filter_FieldName = null;
            this.input_ControlName.Filter_FieldName2 = null;
            this.input_ControlName.Filter_TableName = null;
            this.input_ControlName.Filter_Value = null;
            this.input_ControlName.Filter_Value2 = null;
            this.input_ControlName.Location = new System.Drawing.Point(3, 16);
            this.input_ControlName.Lookup_IDName = null;
            this.input_ControlName.Lookup_ValueName = null;
            this.input_ControlName.Name = "input_ControlName";
            this.input_ControlName.Parent_GroupBox = this.groupBox_2;
            this.input_ControlName.Parent_Panel = null;
            this.input_ControlName.Path_Filter = "*.*";
            this.input_ControlName.Path_FilterName = "All Files";
            this.input_ControlName.Size = new System.Drawing.Size(243, 37);
            this.input_ControlName.TabIndex = 0;
            this.input_ControlName.ValueSet_Control = null;
            this.input_ControlName.VisibleSet_Control = null;
            this.input_ControlName.VisibleSet_Index = 1;
            // 
            // listBox_Enums
            // 
            this.listBox_Enums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Enums.Location = new System.Drawing.Point(3, 3);
            this.listBox_Enums.Name = "listBox_Enums";
            this.listBox_Enums.Parent_GroupBox = null;
            this.listBox_Enums.Parent_Panel = this.tabPage2;
            this.listBox_Enums.Size = new System.Drawing.Size(229, 355);
            this.listBox_Enums.TabIndex = 0;
            this.listBox_Enums.SelectedIndexChanged += new System.EventHandler(this.listBox_Enums_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_Enums);
            this.tabPage2.Controls.Add(this.input_Enum);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(235, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Enumerals";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // input_Enum
            // 
            this.input_Enum._Control_Action = false;
            this.input_Enum._Control_Centre = 80;
            this.input_Enum._Control_Rows = 1;
            this.input_Enum._Control_Sync = false;
            this.input_Enum.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.input_Enum.Action_AutoSave = false;
            this.input_Enum.Action_Button = false;
            this.input_Enum.Action_Custom = enControl_InputCustomAction.None;
            this.input_Enum.Action_EnterButton = null;
            this.input_Enum.Action_Text = "..";
            this.input_Enum.Action_Width = 30;
            this.input_Enum.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.input_Enum.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.input_Enum.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.input_Enum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.input_Enum.Border = false;
            this.input_Enum.Border_Color = System.Drawing.Color.Red;
            this.input_Enum.Border_Width = 2;
            this.input_Enum.CausesValidation = false;
            this.input_Enum.Combo_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.input_Enum.ControlType = enControl_InputType.Edit;
            this.input_Enum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.input_Enum.Edit_Mask = null;
            this.input_Enum.Edit_PasswordChar = '\0';
            this.input_Enum.EnableSet_Control = null;
            this.input_Enum.EnableSet_Index = 1;
            this.input_Enum.Field_Caption = "Enum:";
            this.input_Enum.Field_Caption2 = "FieldName2";
            this.input_Enum.Field_Caption3 = "FieldName3";
            this.input_Enum.Field_Caption4 = "FieldName4";
            this.input_Enum.Field_Description = null;
            this.input_Enum.Field_Name = null;
            this.input_Enum.Field_Value = "";
            this.input_Enum.Field_Value1 = false;
            this.input_Enum.Field_Value2 = false;
            this.input_Enum.Field_Value3 = false;
            this.input_Enum.Filter_Control = null;
            this.input_Enum.Filter_FieldName = null;
            this.input_Enum.Filter_FieldName2 = null;
            this.input_Enum.Filter_TableName = null;
            this.input_Enum.Filter_Value = null;
            this.input_Enum.Filter_Value2 = null;
            this.input_Enum.Location = new System.Drawing.Point(3, 368);
            this.input_Enum.Lookup_IDName = null;
            this.input_Enum.Lookup_ValueName = null;
            this.input_Enum.Name = "input_Enum";
            this.input_Enum.Parent_GroupBox = null;
            this.input_Enum.Parent_Panel = this.tabPage2;
            this.input_Enum.Path_Filter = "*.*";
            this.input_Enum.Path_FilterName = "All Files";
            this.input_Enum.Size = new System.Drawing.Size(229, 33);
            this.input_Enum.TabIndex = 1;
            this.input_Enum.ValueSet_Control = null;
            this.input_Enum.VisibleSet_Control = null;
            this.input_Enum.VisibleSet_Index = 1;
            // 
            // panel_1
            // 
            this.panel_1.Controls.Add(this.button_Test);
            this.panel_1.Controls.Add(this.button_Generate);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_1.Location = new System.Drawing.Point(243, 398);
            this.panel_1.Name = "panel_1";
            this.panel_1.Parent_GroupBox = null;
            this.panel_1.Parent_Panel = null;
            this.panel_1.Size = new System.Drawing.Size(478, 32);
            this.panel_1.TabIndex = 0;
            // 
            // button_Test
            // 
            this.button_Test.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Test.Location = new System.Drawing.Point(403, 0);
            this.button_Test.Name = "button_Test";
            this.button_Test.Parent_GroupBox = null;
            this.button_Test.Parent_Panel = this.panel_1;
            this.button_Test.Size = new System.Drawing.Size(75, 32);
            this.button_Test.TabIndex = 1;
            this.button_Test.Text = "&Copy code";
            this.toolTip1.SetToolTip(this.button_Test, "Copy this code to the Windows Clipboard");
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // button_Generate
            // 
            this.button_Generate.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Generate.Location = new System.Drawing.Point(0, 0);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Parent_GroupBox = null;
            this.button_Generate.Parent_Panel = this.panel_1;
            this.button_Generate.Size = new System.Drawing.Size(101, 32);
            this.button_Generate.TabIndex = 1;
            this.button_Generate.Text = "Load enumerals";
            this.toolTip1.SetToolTip(this.button_Generate, "Load all the enumeral types");
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // input_DLL
            // 
            this.input_DLL._Control_Action = false;
            this.input_DLL._Control_Centre = 80;
            this.input_DLL._Control_Rows = 1;
            this.input_DLL._Control_Sync = false;
            this.input_DLL.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.input_DLL.Action_AutoSave = false;
            this.input_DLL.Action_Button = false;
            this.input_DLL.Action_Custom = enControl_InputCustomAction.None;
            this.input_DLL.Action_EnterButton = null;
            this.input_DLL.Action_Text = "..";
            this.input_DLL.Action_Width = 30;
            this.input_DLL.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.input_DLL.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.input_DLL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.input_DLL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.input_DLL.Border = false;
            this.input_DLL.Border_Color = System.Drawing.Color.Red;
            this.input_DLL.Border_Width = 2;
            this.input_DLL.CausesValidation = false;
            this.input_DLL.Combo_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.input_DLL.ControlType = enControl_InputType.Edit;
            this.input_DLL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.input_DLL.Edit_Mask = null;
            this.input_DLL.Edit_PasswordChar = '\0';
            this.input_DLL.EnableSet_Control = null;
            this.input_DLL.EnableSet_Index = 1;
            this.input_DLL.Field_Caption = "DLL:";
            this.input_DLL.Field_Caption2 = "FieldName2";
            this.input_DLL.Field_Caption3 = "FieldName3";
            this.input_DLL.Field_Caption4 = "FieldName4";
            this.input_DLL.Field_Description = null;
            this.input_DLL.Field_Name = null;
            this.input_DLL.Field_Value = "";
            this.input_DLL.Field_Value1 = false;
            this.input_DLL.Field_Value2 = false;
            this.input_DLL.Field_Value3 = false;
            this.input_DLL.Filter_Control = null;
            this.input_DLL.Filter_FieldName = null;
            this.input_DLL.Filter_FieldName2 = null;
            this.input_DLL.Filter_TableName = null;
            this.input_DLL.Filter_Value = null;
            this.input_DLL.Filter_Value2 = null;
            this.input_DLL.Location = new System.Drawing.Point(3, 363);
            this.input_DLL.Lookup_IDName = null;
            this.input_DLL.Lookup_ValueName = null;
            this.input_DLL.Name = "input_DLL";
            this.input_DLL.Parent_GroupBox = null;
            this.input_DLL.Parent_Panel = this.tabPage1;
            this.input_DLL.Path_Filter = "*.*";
            this.input_DLL.Path_FilterName = "All Files";
            this.input_DLL.Size = new System.Drawing.Size(229, 38);
            this.input_DLL.TabIndex = 2;
            this.input_DLL.ValueSet_Control = null;
            this.input_DLL.VisibleSet_Control = null;
            this.input_DLL.VisibleSet_Index = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_DLL);
            this.tabPage1.Controls.Add(this.input_DLL);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(235, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DLL\'s";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox_DLL
            // 
            this.listBox_DLL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_DLL.Location = new System.Drawing.Point(3, 3);
            this.listBox_DLL.Name = "listBox_DLL";
            this.listBox_DLL.Parent_GroupBox = null;
            this.listBox_DLL.Parent_Panel = this.tabPage1;
            this.listBox_DLL.Size = new System.Drawing.Size(229, 355);
            this.listBox_DLL.TabIndex = 0;
            this.listBox_DLL.SelectedIndexChanged += new System.EventHandler(this.listBox_DLL_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 430);
            this.tabControl1.TabIndex = 6;
            // 
            // FormCreator_Enumeral_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 430);
            this.Controls.Add(this.groupBox_3);
            this.Controls.Add(this.groupBox_4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox_2);
            this.Controls.Add(this.panel_1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormCreator_Enumeral_Form";
            this.Text = "Form_Enumerals";
            this.groupBox_4.ResumeLayout(false);
            this.groupBox_4.PerformLayout();
            this.groupBox_3.ResumeLayout(false);
            this.groupBox_2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel_1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel_ panel_1;
        private Button_ button_Generate;
        private ListBox_ listBox_Enums;
        private GroupBox_ groupBox_2;
        private GroupBox_ groupBox_3;
        private ListBox_ listBox_1;
        private Button_ button_Test;
        private Input_Control input_DLL;
        private System.Windows.Forms.Splitter splitter1;
        private GroupBox_ groupBox_4;
        private TextBox_ textBox_Code;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ListBox_ listBox_DLL;
        private Input_Control input_ControlName;
        private Input_Control input_Enum;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}