using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl._Designer;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    sealed partial class FormCreator_SelectClasses_Form
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
            this.listBox_Classes = new ListBox_();
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
            this.button_Standard1.Location = new System.Drawing.Point(0, 232);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(216, 30);
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
            // listBox_Classes
            // 
            this.listBox_Classes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Classes.Location = new System.Drawing.Point(0, 0);
            this.listBox_Classes.Name = "listBox_Classes";
            this.listBox_Classes.Parent_GroupBox = null;
            this.listBox_Classes.Parent_Panel = null;
            this.listBox_Classes.Size = new System.Drawing.Size(216, 225);
            this.listBox_Classes.TabIndex = 1;
            this.listBox_Classes.SelectedIndexChanged += new System.EventHandler(this.listBox_Classes_SelectedIndexChanged);
            // 
            // ClassGenerator_SelectClasses_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 262);
            this.Controls.Add(this.listBox_Classes);
            this.Controls.Add(this.button_Standard1);
            this.Name = "ClassGenerator_SelectClasses_Form";
            this.Text = "SelectClasses";
            this.ResumeLayout(false);

        }

        #endregion

        private Button_Standard button_Standard1;
        private ListBox_ listBox_Classes;
    }
}