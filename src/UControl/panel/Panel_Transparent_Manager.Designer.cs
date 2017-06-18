namespace Lamedal_UIWinForms.UControl.panel
{
    partial class Panel_Transparent_Manager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new global::System.Windows.Forms.Label();
            this.listSpots = new global::System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new global::System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new global::System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HotSpots:";
            // 
            // listSpots
            // 
            this.listSpots.Dock = global::System.Windows.Forms.DockStyle.Right;
            this.listSpots.FormattingEnabled = true;
            this.listSpots.Location = new global::System.Drawing.Point(74, 0);
            this.listSpots.Name = "listSpots";
            this.listSpots.Size = new global::System.Drawing.Size(128, 108);
            this.listSpots.TabIndex = 1;
            // 
            // zWinHotspot_Manager
            // 
            this.AutoScaleDimensions = new global::System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listSpots);
            this.Controls.Add(this.label1);
            this.Name = "zWinHotspot_Manager";
            this.Size = new global::System.Drawing.Size(202, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::System.Windows.Forms.Label label1;
        private global::System.Windows.Forms.ListBox listSpots;
    }
}
