using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl.form1;
using Lamedal_UIWinForms.Enumerals;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    partial class Form_ClassDialog2
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
            this.formControls_1 = new FormControls_();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Standard1 = new Button_Standard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formControls_1
            // 
            this.formControls_1.Controls_ContextMenuStrip = false;
            this.formControls_1.Controls_StandardButtons = true;
            this.formControls_1.Controls_StatusStrip = false;
            this.formControls_1.Controls_ToolbarPanel = false;
            this.formControls_1.Controls_ToolStrip = false;
            this.formControls_1.Controls_Tooltips = false;
            this.formControls_1.Form_ContextMenuStrip = null;
            this.formControls_1.Form_Name = this;
            this.formControls_1.Form_Size = enFormSize.Manual;
            this.formControls_1.Form_StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.formControls_1.Form_Text = "Class Dialog";
            this.formControls_1.Form_TopMost = false;
            this.formControls_1.Panel_Main = this.panel1;
            this.formControls_1.Panel_Setup = enFormPanels.TwoPanels;
            this.formControls_1.Reset = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 262);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "MainPanel";
            // 
            // button_Standard1
            // 
            this.button_Standard1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button_Standard1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.button_Standard1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.button_Standard1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Standard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Standard1.CausesValidation = false;
            this.button_Standard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Standard1.Location = new System.Drawing.Point(0, 232);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(509, 30);
            this.button_Standard1.TabIndex = 1;
            this.button_Standard1.Text_Apply = "&Apply";
            this.button_Standard1.Text_Cancel = "&Cancel";
            this.button_Standard1.Text_Clipboard = "Copy to Clipboard";
            this.button_Standard1.Text_Help = "&Help";
            this.button_Standard1.Text_Ok = "&Ok";
            this.button_Standard1.Text_Reset = false;
            this.button_Standard1.Visible_Apply = false;
            this.button_Standard1.Visible_Cancel = true;
            this.button_Standard1.Visible_Clipboard = false;
            this.button_Standard1.Visible_Help = false;
            this.button_Standard1.Visible_Ok = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 260);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(260, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 260);
            this.panel3.TabIndex = 2;
            // 
            // Form_ClassDialog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 262);
            this.Controls.Add(this.button_Standard1);
            this.Controls.Add(this.panel1);
            this.Name = "Form_ClassDialog2";
            this.Text = "Class Dialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FormControls_ formControls_1;
        private System.Windows.Forms.Panel panel1;
        private UControl.button.Button_Standard button_Standard1;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel panel2;
    }
}