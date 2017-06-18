using Lamedal_UIWinForms.UControl.button;
using Lamedal_UIWinForms.UControl.panel;
using Lamedal_UIWinForms.UControl._Designer;
using Lamedal_UIWinForms.Events;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    partial class Dialog_Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_Options));
            this.listBox_Items = new System.Windows.Forms.ListBox();
            this.button_Standard1 = new Button_Standard();
            this.panel_1 = new Panel_();
            this.label_1 = new Label_();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Items
            // 
            this.listBox_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Items.FormattingEnabled = true;
            this.listBox_Items.Location = new System.Drawing.Point(86, 30);
            this.listBox_Items.Name = "listBox_Items";
            this.listBox_Items.Size = new System.Drawing.Size(213, 72);
            this.listBox_Items.TabIndex = 2;
            this.listBox_Items.DoubleClick += new System.EventHandler(this.listBox_Items_DoubleClick);
            this.listBox_Items.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox_Items_KeyPress);
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
            this.button_Standard1.Location = new System.Drawing.Point(0, 102);
            this.button_Standard1.Name = "button_Standard1";
            this.button_Standard1.Size = new System.Drawing.Size(299, 30);
            this.button_Standard1.TabIndex = 3;
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
            this.button_Standard1.Event_OnClick += new System.EventHandler<evStandardButtons_EventArgs>(this.button_Standard1_Event_OnClick);
            // 
            // panel_1
            // 
            this.panel_1.Controls.Add(this.label_1);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_1.Location = new System.Drawing.Point(0, 0);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(299, 30);
            this.panel_1.TabIndex = 4;
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_1.Location = new System.Drawing.Point(0, 14);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(265, 16);
            this.label_1.TabIndex = 0;
            this.label_1.Text = "Please choose one of the following options:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 72);
            this.panel1.TabIndex = 5;
            // 
            // Dialog_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 132);
            this.ControlBox = false;
            this.Controls.Add(this.listBox_Items);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_1);
            this.Controls.Add(this.button_Standard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dialog_Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option Selection";
            this.panel_1.ResumeLayout(false);
            this.panel_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Items;
        private Button_Standard button_Standard1;
        private Panel_ panel_1;
        private Label_ label_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}