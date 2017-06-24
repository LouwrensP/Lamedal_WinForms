using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.domain.Events;
using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl.Input;
using Lamedal_UIWinForms.UControl.panel;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    partial class FormCreator_Form
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
            this.panel_Body = new Panel_();
            this.button_Show = new Button_();
            this.button_Code2 = new Button_();
            this.button_Code = new Button_();
            this.button_Timer = new Button_();
            this.button_Generate = new Button_();
            this.groupBox_3 = new GroupBox_();
            this.listBox_Classes = new ListBox_();
            this.groupBox_2 = new GroupBox_();
            this.listBox_Components = new ListBox_();
            this.groupBox_1 = new GroupBox_();
            this.comboBox_FormPanels = new ComboBox_();
            this.comboBox_FormSize = new ComboBox_();
            this.input_Panel1 = new Input_Control();
            this.panel_Body.SuspendLayout();
            this.groupBox_3.SuspendLayout();
            this.groupBox_2.SuspendLayout();
            this.groupBox_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Body
            // 
            this.panel_Body.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Body.Controls.Add(this.button_Show);
            this.panel_Body.Controls.Add(this.button_Code2);
            this.panel_Body.Controls.Add(this.button_Code);
            this.panel_Body.Controls.Add(this.button_Timer);
            this.panel_Body.Controls.Add(this.button_Generate);
            this.panel_Body.Controls.Add(this.groupBox_3);
            this.panel_Body.Controls.Add(this.groupBox_2);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 52);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Parent_GroupBox = null;
            this.panel_Body.Parent_Panel = null;
            this.panel_Body.Size = new System.Drawing.Size(619, 222);
            this.panel_Body.TabIndex = 3;
            // 
            // button_Show
            // 
            this.button_Show.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Show.Location = new System.Drawing.Point(482, 103);
            this.button_Show.Name = "button_Show";
            this.button_Show.Parent_GroupBox = null;
            this.button_Show.Parent_Panel = this.panel_Body;
            this.button_Show.Size = new System.Drawing.Size(135, 23);
            this.button_Show.TabIndex = 5;
            this.button_Show.Text = "Show";
            this.button_Show.Click += new System.EventHandler(this.button_Show_Click);
            // 
            // button_Code2
            // 
            this.button_Code2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Code2.Location = new System.Drawing.Point(482, 126);
            this.button_Code2.Name = "button_Code2";
            this.button_Code2.Parent_GroupBox = null;
            this.button_Code2.Parent_Panel = this.panel_Body;
            this.button_Code2.Size = new System.Drawing.Size(135, 23);
            this.button_Code2.TabIndex = 6;
            this.button_Code2.Text = "Code 4";
            this.button_Code2.Click += new System.EventHandler(this.button_Code2_Click);
            // 
            // button_Code
            // 
            this.button_Code.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Code.Location = new System.Drawing.Point(482, 149);
            this.button_Code.Name = "button_Code";
            this.button_Code.Parent_GroupBox = null;
            this.button_Code.Parent_Panel = this.panel_Body;
            this.button_Code.Size = new System.Drawing.Size(135, 23);
            this.button_Code.TabIndex = 4;
            this.button_Code.Text = "Code1";
            this.button_Code.Click += new System.EventHandler(this.button_Code_Click);
            // 
            // button_Timer
            // 
            this.button_Timer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Timer.Location = new System.Drawing.Point(482, 172);
            this.button_Timer.Name = "button_Timer";
            this.button_Timer.Parent_GroupBox = null;
            this.button_Timer.Parent_Panel = this.panel_Body;
            this.button_Timer.Size = new System.Drawing.Size(135, 23);
            this.button_Timer.TabIndex = 3;
            this.button_Timer.Text = "Timer";
            this.button_Timer.Click += new System.EventHandler(this.button_Timer_Click);
            // 
            // button_Generate
            // 
            this.button_Generate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Generate.Location = new System.Drawing.Point(482, 195);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Parent_GroupBox = null;
            this.button_Generate.Parent_Panel = this.panel_Body;
            this.button_Generate.Size = new System.Drawing.Size(135, 25);
            this.button_Generate.TabIndex = 2;
            this.button_Generate.Text = "Generate 2";
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // groupBox_3
            // 
            this.groupBox_3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_3.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_3.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_3.CausesValidation = false;
            this.groupBox_3.Controls.Add(this.listBox_Classes);
            this.groupBox_3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_3.Location = new System.Drawing.Point(241, 0);
            this.groupBox_3.Name = "groupBox_3";
            this.groupBox_3.Parent_GroupBox = null;
            this.groupBox_3.Parent_Panel = this.panel_Body;
            this.groupBox_3.Size = new System.Drawing.Size(241, 220);
            this.groupBox_3.TabIndex = 1;
            this.groupBox_3.TabStop = false;
            this.groupBox_3.Text = "Generate Class";
            // 
            // listBox_Classes
            // 
            this.listBox_Classes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Classes.Location = new System.Drawing.Point(3, 16);
            this.listBox_Classes.Name = "listBox_Classes";
            this.listBox_Classes.Parent_GroupBox = this.groupBox_3;
            this.listBox_Classes.Parent_Panel = null;
            this.listBox_Classes.Size = new System.Drawing.Size(235, 199);
            this.listBox_Classes.TabIndex = 0;
            // 
            // groupBox_2
            // 
            this.groupBox_2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_2.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_2.CausesValidation = false;
            this.groupBox_2.Controls.Add(this.listBox_Components);
            this.groupBox_2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_2.Location = new System.Drawing.Point(0, 0);
            this.groupBox_2.Name = "groupBox_2";
            this.groupBox_2.Parent_GroupBox = null;
            this.groupBox_2.Parent_Panel = this.panel_Body;
            this.groupBox_2.Size = new System.Drawing.Size(241, 220);
            this.groupBox_2.TabIndex = 1;
            this.groupBox_2.TabStop = false;
            this.groupBox_2.Text = "Controls";
            // 
            // listBox_Components
            // 
            this.listBox_Components.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Components.Location = new System.Drawing.Point(3, 16);
            this.listBox_Components.Name = "listBox_Components";
            this.listBox_Components.Parent_GroupBox = this.groupBox_2;
            this.listBox_Components.Parent_Panel = null;
            this.listBox_Components.Size = new System.Drawing.Size(235, 199);
            this.listBox_Components.TabIndex = 0;
            this.listBox_Components.SelectedIndexChanged += new System.EventHandler(this.listBox_Components_SelectedIndexChanged);
            // 
            // groupBox_1
            // 
            this.groupBox_1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_1.CausesValidation = false;
            this.groupBox_1.Controls.Add(this.comboBox_FormPanels);
            this.groupBox_1.Controls.Add(this.comboBox_FormSize);
            this.groupBox_1.Controls.Add(this.input_Panel1);
            this.groupBox_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_1.Location = new System.Drawing.Point(0, 0);
            this.groupBox_1.Name = "groupBox_1";
            this.groupBox_1.Parent_GroupBox = null;
            this.groupBox_1.Parent_Panel = null;
            this.groupBox_1.Size = new System.Drawing.Size(619, 52);
            this.groupBox_1.TabIndex = 0;
            this.groupBox_1.TabStop = false;
            this.groupBox_1.Text = "Panels";
            // 
            // comboBox_FormPanels
            // 
            this.comboBox_FormPanels.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox_FormPanels.Location = new System.Drawing.Point(400, 16);
            this.comboBox_FormPanels.Name = "comboBox_FormPanels";
            this.comboBox_FormPanels.Size = new System.Drawing.Size(158, 21);
            this.comboBox_FormPanels.TabIndex = 2;
            this.comboBox_FormPanels.SelectedIndexChanged += new System.EventHandler(this.comboBox_FormPanels_SelectedIndexChanged);
            // 
            // comboBox_FormSize
            // 
            this.comboBox_FormSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox_FormSize.Location = new System.Drawing.Point(242, 16);
            this.comboBox_FormSize.Name = "comboBox_FormSize";
            this.comboBox_FormSize.Size = new System.Drawing.Size(158, 21);
            this.comboBox_FormSize.TabIndex = 1;
            this.comboBox_FormSize.SelectedIndexChanged += new System.EventHandler(this.comboBox_FormSize_SelectedIndexChanged);
            // 
            // input_Panel1
            // 
            this.input_Panel1._Control_Action = true;
            this.input_Panel1._Control_Centre = 80;
            this.input_Panel1._Control_Rows = 1;
            this.input_Panel1._Control_Sync = false;
            this.input_Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.input_Panel1.Action_AutoSave = false;
            this.input_Panel1.Action_Button = true;
            this.input_Panel1.Action_Custom = enControl_InputCustomAction.None;
            this.input_Panel1.Action_EnterButton = null;
            this.input_Panel1.Action_Text = "..";
            this.input_Panel1.Action_Width = 30;
            this.input_Panel1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.input_Panel1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.input_Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.input_Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.input_Panel1.Border = false;
            this.input_Panel1.Border_Color = System.Drawing.Color.Red;
            this.input_Panel1.Border_Width = 2;
            this.input_Panel1.CausesValidation = false;
            this.input_Panel1.Combo_DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.input_Panel1.ControlType = enControl_InputType.Edit;
            this.input_Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.input_Panel1.Edit_Mask = null;
            this.input_Panel1.Edit_PasswordChar = '\0';
            this.input_Panel1.EnableSet_Control = null;
            this.input_Panel1.EnableSet_Index = 1;
            this.input_Panel1.Field_Caption = "Panel:";
            this.input_Panel1.Field_Caption2 = "Test2";
            this.input_Panel1.Field_Caption3 = "Test3";
            this.input_Panel1.Field_Caption4 = "Test4";
            this.input_Panel1.Field_Name = null;
            this.input_Panel1.Field_Value = "";
            this.input_Panel1.Field_Value1 = false;
            this.input_Panel1.Field_Value2 = false;
            this.input_Panel1.Field_Value3 = false;
            this.input_Panel1.Filter_Control = null;
            this.input_Panel1.Filter_FieldName = null;
            this.input_Panel1.Filter_FieldName2 = null;
            this.input_Panel1.Filter_TableName = null;
            this.input_Panel1.Filter_Value = null;
            this.input_Panel1.Filter_Value2 = null;
            this.input_Panel1.Location = new System.Drawing.Point(3, 16);
            this.input_Panel1.Lookup_IDName = null;
            this.input_Panel1.Lookup_ValueName = null;
            this.input_Panel1.Name = "input_Panel1";
            this.input_Panel1.Parent_GroupBox = this.groupBox_1;
            this.input_Panel1.Parent_Panel = null;
            this.input_Panel1.Path_Filter = "*.*";
            this.input_Panel1.Path_FilterName = "All Files";
            this.input_Panel1.Size = new System.Drawing.Size(239, 33);
            this.input_Panel1.TabIndex = 0;
            this.input_Panel1.ValueSet_Control = null;
            this.input_Panel1.VisibleSet_Control = null;
            this.input_Panel1.VisibleSet_Index = 1;
            this.input_Panel1.Event_OnActionButtonClick += new System.EventHandler<onInputControl_EventArgs>(this.input_Panel1_Event_OnActionButtonClick);
            // 
            // ClassGenerator_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 274);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.groupBox_1);
            this.Name = "ClassGenerator_Form";
            this.Text = "ClassGenerator_Form";
            this.panel_Body.ResumeLayout(false);
            this.groupBox_3.ResumeLayout(false);
            this.groupBox_2.ResumeLayout(false);
            this.groupBox_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox_ groupBox_1;
        private Input_Control input_Panel1;
        private GroupBox_ groupBox_2;
        private ListBox_ listBox_Components;
        private Panel_ panel_Body;
        private Button_ button_Generate;
        private GroupBox_ groupBox_3;
        private ListBox_ listBox_Classes;
        private Button_ button_Timer;
        private Button_ button_Code;
        private Button_ button_Show;
        private Button_ button_Code2;
        private ComboBox_ comboBox_FormSize;
        private ComboBox_ comboBox_FormPanels;
    }
}