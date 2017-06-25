using System;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.domain.Enumerals;

namespace Lamedal_UIWinForms.UControl.button
{
    

    public class Button_Standard_Class
    {
        private Panel pnlBorder;
        public Button btnOk;
        public Button btnCancel;
        public Button btnApply;
        public Button btnHelp;
        public Button btnClipboard;
        private readonly Control _Ctrl;   // Parent Control

        public Button_Standard_Class(Control ctrl)
        {
            _Ctrl = ctrl;
            FormStandardButtons_OnPaint();
        }

        /// <summary>
        /// Hook up the events.
        /// </summary>
        /// <param name="OkClick">The ok click.</param>
        /// <param name="CancelClick">The cancel click.</param>
        /// <param name="HelpClick">The help click.</param>
        /// <param name="ApplyClick">The apply click.</param>
        /// <param name="Copy2Clipboard">The copy2 clipboard.</param>
        public void Hook_Events(EventHandler OkClick = null, EventHandler CancelClick = null,
            EventHandler HelpClick = null, EventHandler ApplyClick = null, EventHandler Copy2Clipboard = null)
        {
            if (OkClick != null)
            {
                btnOk.Click -= OkClick;
                btnOk.Click += OkClick;
            }
            if (CancelClick != null)
            {
                btnCancel.Click -= CancelClick;
                btnCancel.Click += CancelClick;
            }
            if (HelpClick != null)
            {
                btnHelp.Click -= HelpClick;
                btnHelp.Click += HelpClick;
            }
            if (ApplyClick != null)
            {
                btnApply.Click -= ApplyClick;
                btnApply.Click += ApplyClick;
            }
            if (Copy2Clipboard != null)
            {
                btnClipboard.Click -= Copy2Clipboard;
                btnClipboard.Click += Copy2Clipboard;
            }
        }

        public string Text_Get(enControl_StandardButtons button)
        {
            switch (button)
            {
                case enControl_StandardButtons.Ok: return btnOk.Text;
                case enControl_StandardButtons.Cancel: return btnCancel.Text;
                case enControl_StandardButtons.Apply: return btnApply.Text;
                case enControl_StandardButtons.Help: return btnHelp.Text;
                case enControl_StandardButtons.Copy2Clipboard: return btnClipboard.Text;
                default: throw new ArgumentException("Undefined enumerable!", nameof(button)); 
            }
        }

        public void Text_Set(string ok = "&Ok", string cancel = "&Cancel", string apply = "&Apply",
                string help = "&Help", string clipboard = "Copy to Clipboard")
        {
            this.btnOk.Text = ok;
            this.btnCancel.Text = cancel;
            this.btnApply.Text = apply;
            this.btnHelp.Text = help;
            this.btnClipboard.Text = clipboard;
        }

        /// <summary>
        /// Return the Visible property value.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns></returns>
        public bool Visible_Get(enControl_StandardButtons button)
        {
            switch (button)
            {
                case enControl_StandardButtons.Ok: return btnOk.Visible;
                case enControl_StandardButtons.Cancel: return btnCancel.Visible;
                case enControl_StandardButtons.Apply: return btnApply.Visible;
                case enControl_StandardButtons.Help: return btnHelp.Visible;
                case enControl_StandardButtons.Copy2Clipboard: return btnClipboard.Visible;
                default: throw new ArgumentException("Undefined enumerable!", nameof(button));

            }            
        }

        /// <summary>
        /// Set the button Visible.
        /// </summary>
        /// <param name="button">The button.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void Visible_Set(enControl_StandardButtons button, bool value)
        {
            switch (button)
            {
                case enControl_StandardButtons.Ok: btnOk.Visible = value; break;
                case enControl_StandardButtons.Cancel: btnCancel.Visible = value; break;
                case enControl_StandardButtons.Apply: btnApply.Visible = value; break;
                case enControl_StandardButtons.Help: btnHelp.Visible = value; break;
                case enControl_StandardButtons.Copy2Clipboard: btnClipboard.Visible = value; break;
                default: throw new ArgumentException("Undefined enumerable!", nameof(button));
            }
        }

        private void FormStandardButtons_OnPaint()
        {
            this.pnlBorder = new Panel();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.btnApply = new Button();
            this.btnHelp = new Button();
            btnClipboard = new Button();

            this.pnlBorder.SuspendLayout();
            _Ctrl.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BorderStyle = BorderStyle.FixedSingle;
            this.pnlBorder.Controls.Add(this.btnOk);
            this.pnlBorder.Controls.Add(this.btnCancel);
            this.pnlBorder.Controls.Add(this.btnApply);
            this.pnlBorder.Controls.Add(this.btnHelp);
            this.pnlBorder.Controls.Add(this.btnClipboard);
            this.pnlBorder.Dock = DockStyle.Bottom;
            this.pnlBorder.Location = new Point(0, 171);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new Size(417, 30);
            this.pnlBorder.TabIndex = 26;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Dock = DockStyle.Right;
            this.btnOk.Location = new Point(213, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(43, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Dock = DockStyle.Right;
            this.btnCancel.Location = new Point(256, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(53, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnApply
            // 
            this.btnApply.AutoSize = true;
            this.btnApply.DialogResult = DialogResult.Retry;
            this.btnApply.Dock = DockStyle.Right;
            this.btnApply.Location = new Point(309, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new Size(53, 28);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.AutoSize = true;
            this.btnHelp.Dock = DockStyle.Right;
            this.btnHelp.Location = new Point(362, 0);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new Size(53, 28);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Visible = false;
            // 
            // btnClipboard
            // 
            this.btnClipboard.AutoSize = true;
            this.btnClipboard.Dock = DockStyle.Left;
            this.btnClipboard.Location = new Point(10, 0);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new Size(53, 28);
            this.btnClipboard.TabIndex = 2;
            this.btnClipboard.Text = "Copy to Clipboard";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Visible = false;
            // 
            // Form3
            // 
            _Ctrl.Controls.Add(this.pnlBorder);
            this.pnlBorder.ResumeLayout(false);
            this.pnlBorder.PerformLayout();
            _Ctrl.ResumeLayout(false);
        }

    }
}
