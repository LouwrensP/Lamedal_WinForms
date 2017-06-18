using Lamedal_UIWinForms.UControl.button;

namespace Lamedal_UIWinForms.UControl.UControlTest
{
    partial class Form_TestWindowsUControls
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
            this.button_Standard1 = new Button_Standard();
            this.button_1 = new Button_();
            this.SuspendLayout();
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
            this.button_Standard1.Location = new System.Drawing.Point(0, 297);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(437, 30);
            this.button_Standard1.TabIndex = 0;
            this.button_Standard1.Text_Apply = "&Apply";
            this.button_Standard1.Text_Cancel = "&Cancel";
            this.button_Standard1.Text_Clipboard = "Copy to Clipboard";
            this.button_Standard1.Text_Help = "&Help";
            this.button_Standard1.Text_Ok = "&Ok";
            this.button_Standard1.Text_Reset = false;
            this.button_Standard1.Visible_Apply = false;
            this.button_Standard1.Visible_Cancel = true;
            this.button_Standard1.Visible_Clipboard = true;
            this.button_Standard1.Visible_Help = false;
            this.button_Standard1.Visible_Ok = true;
            // 
            // button_1
            // 
            this.button_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_1.Location = new System.Drawing.Point(0, 0);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(437, 23);
            this.button_1.TabIndex = 1;
            this.button_1.Text = "sdsds";
            // 
            // Form_TestWindowsUControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 327);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.button_Standard1);
            this.Name = "Form_TestWindowsUControls";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button_Standard button_Standard1;
        private Button_ button_1;
    }
}