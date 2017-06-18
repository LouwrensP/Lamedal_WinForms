namespace Lamedal_UIWinForms.libUI.WinForms.Callback
{
    sealed partial class system_Callback_TestsForm
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
            this.chkReset = new System.Windows.Forms.CheckBox();
            this.btnAsync = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkReset
            // 
            this.chkReset.AutoSize = true;
            this.chkReset.Location = new System.Drawing.Point(30, 79);
            this.chkReset.Name = "chkReset";
            this.chkReset.Size = new System.Drawing.Size(54, 17);
            this.chkReset.TabIndex = 13;
            this.chkReset.Text = "Reset";
            this.chkReset.UseVisualStyleBackColor = true;
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(27, 49);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(100, 23);
            this.btnAsync.TabIndex = 12;
            this.btnAsync.Text = "Async Methods";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(27, 23);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 11;
            this.txtCount.Text = "1";
            // 
            // Fend_Callback_MethodTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 161);
            this.Controls.Add(this.chkReset);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.txtCount);
            this.Name = "Fend_Callback_MethodTests";
            this.Text = "Fend_Callback_MethodTests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkReset;
        private System.Windows.Forms.Button btnAsync;
        internal System.Windows.Forms.TextBox txtCount;
    }
}