using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    partial class Form_Progress
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
            this.listItems = new System.Windows.Forms.CheckedListBox();
            this.groupBox_1 = new GroupBox_();
            this.button_Standard1 = new Button_Standard();
            this.groupBox_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listItems
            // 
            this.listItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listItems.FormattingEnabled = true;
            this.listItems.Location = new System.Drawing.Point(3, 16);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(297, 249);
            this.listItems.TabIndex = 0;
            // 
            // groupBox_1
            // 
            this.groupBox_1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox_1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.groupBox_1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.groupBox_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox_1.CausesValidation = false;
            this.groupBox_1.Controls.Add(this.listItems);
            this.groupBox_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_1.Location = new System.Drawing.Point(0, 0);
            this.groupBox_1.Name = "groupBox_1";
            this.groupBox_1.Parent_GroupBox = null;
            this.groupBox_1.Parent_Panel = null;
            this.groupBox_1.Size = new System.Drawing.Size(303, 268);
            this.groupBox_1.TabIndex = 1;
            this.groupBox_1.TabStop = false;
            this.groupBox_1.Text = "Items";
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
            this.button_Standard1.Location = new System.Drawing.Point(0, 238);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(303, 30);
            this.button_Standard1.TabIndex = 2;
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
            this.button_Standard1.Visible_Ok = false;
            // 
            // Form_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 268);
            this.Controls.Add(this.button_Standard1);
            this.Controls.Add(this.groupBox_1);
            this.Name = "Form_Progress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Progress";
            this.groupBox_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckedListBox listItems;
        private GroupBox_ groupBox_1;
        private Button_Standard button_Standard1;
    }
}