using Lamedal_UIWinForms.domain.Events;
using Lamedal_UIWinForms.UControl.button;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    partial class Dialog_Memo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private global::System.ComponentModel.IContainer components = null;

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
            this.groupMsg = new System.Windows.Forms.GroupBox();
            this.Lines = new System.Windows.Forms.TextBox();
            this.standardButtons1 = new Button_Standard();
            this.groupMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupMsg
            // 
            this.groupMsg.Controls.Add(this.Lines);
            this.groupMsg.Controls.Add(this.standardButtons1);
            this.groupMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMsg.Location = new System.Drawing.Point(0, 0);
            this.groupMsg.Name = "groupMsg";
            this.groupMsg.Size = new System.Drawing.Size(454, 377);
            this.groupMsg.TabIndex = 3;
            this.groupMsg.TabStop = false;
            this.groupMsg.Text = "The Values";
            // 
            // Lines
            // 
            this.Lines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lines.Location = new System.Drawing.Point(3, 16);
            this.Lines.Multiline = true;
            this.Lines.Name = "Lines";
            this.Lines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Lines.Size = new System.Drawing.Size(448, 328);
            this.Lines.TabIndex = 0;
            // 
            // standardButtons1
            // 
            this.standardButtons1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.standardButtons1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.standardButtons1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.standardButtons1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.standardButtons1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.standardButtons1.CausesValidation = false;
            this.standardButtons1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.standardButtons1.Location = new System.Drawing.Point(3, 344);
            this.standardButtons1.Name = "standardButtons1";
            this.standardButtons1.Size = new System.Drawing.Size(448, 30);
            this.standardButtons1.TabIndex = 2;
            this.standardButtons1.Text_Apply = "&Apply";
            this.standardButtons1.Text_Cancel = "&Cancel";
            this.standardButtons1.Text_Clipboard = "Copy to Clipboard";
            this.standardButtons1.Text_Help = "&Help";
            this.standardButtons1.Text_Ok = "&Ok";
            this.standardButtons1.Text_Reset = false;
            this.standardButtons1.Visible_Apply = false;
            this.standardButtons1.Visible_Cancel = true;
            this.standardButtons1.Visible_Clipboard = true;
            this.standardButtons1.Visible_Help = false;
            this.standardButtons1.Visible_Ok = true;
            this.standardButtons1.Event_OnClick += new System.EventHandler<onStandardButtons_EventArgs>(this.standardButtons1_Event_OnClick);
            // 
            // winDialog_Memo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 377);
            this.Controls.Add(this.groupMsg);
            this.Name = "winDialog_Memo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.groupMsg.ResumeLayout(false);
            this.groupMsg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private global::System.Windows.Forms.GroupBox groupMsg;
        public global::System.Windows.Forms.TextBox Lines;
        private Button_Standard standardButtons1;
    }
}