using System.Windows.Forms;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    sealed partial class Progress_WaitCursor_Form
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
            this.label_Message = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel_1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Message
            // 
            this.label_Message.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Message.Location = new System.Drawing.Point(0, 0);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(114, 13);
            this.label_Message.TabIndex = 0;
            this.label_Message.Text = "Please wait working...";
            this.label_Message.UseWaitCursor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(114, 31);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 100;
            // 
            // panel_1
            // 
            this.panel_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_1.Controls.Add(this.label_Message);
            this.panel_1.Controls.Add(this.progressBar1);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_1.Location = new System.Drawing.Point(0, 0);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(116, 33);
            this.panel_1.TabIndex = 2;
            this.panel_1.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Progress_WaitCursor_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 33);
            this.ControlBox = false;
            this.Controls.Add(this.panel_1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Progress_WaitCursor_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress_WaitCursor_Form";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.panel_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_Message;
        private ProgressBar progressBar1;
        private Panel panel_1;
        private System.Windows.Forms.Timer timer1;
    }
}