using System.Windows.Forms;
using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl.panel;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    partial class Dialog_InputBox
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
            this.components = new System.ComponentModel.Container();
            this.textboxInput = new TextBox_();
            this.panel_1 = new Panel_();
            this.labelQuestion = new Label_();
            this.button_Standard1 = new Button_Standard();
            this.panel_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textboxInput
            // 
            this.textboxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxInput.Location = new System.Drawing.Point(0, 73);
            this.textboxInput.Multiline = true;
            this.textboxInput.Name = "textboxInput";
            this.textboxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textboxInput.Size = new System.Drawing.Size(411, 205);
            this.textboxInput.TabIndex = 2;
            // 
            // panel_1
            // 
            this.panel_1.Controls.Add(this.labelQuestion);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_1.Location = new System.Drawing.Point(0, 0);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(411, 73);
            this.panel_1.TabIndex = 3;
            // 
            // labelQuestion
            // 
            this.labelQuestion.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelQuestion.Location = new System.Drawing.Point(0, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(408, 73);
            this.labelQuestion.TabIndex = 1;
            this.labelQuestion.Text = "Please enter the value?";
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
            this.button_Standard1.Location = new System.Drawing.Point(0, 278);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(411, 30);
            this.button_Standard1.TabIndex = 0;
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
            // Dialog_InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 308);
            this.Controls.Add(this.textboxInput);
            this.Controls.Add(this.panel_1);
            this.Controls.Add(this.button_Standard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Dialog_InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inputbox";
            this.Load += new System.EventHandler(this.Dialog_Inputbox_Load);
            this.panel_1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button_Standard button_Standard1;
        private UControl._Designer.Label_ labelQuestion;
        private UControl._Designer.TextBox_ textboxInput;
        private UControl.panel.Panel_ panel_1;
        private Button buttonOK;
    }
}