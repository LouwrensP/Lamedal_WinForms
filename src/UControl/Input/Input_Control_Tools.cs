using System;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;

namespace Lamedal_UIWinForms.UControl.Input
{
    /// <summary>
    /// Methods to create different controls
    /// </summary>
    public static class Input_Control_Tools
    {
        /// <summary>
        /// Determines whether the active type is a checkbox.
        /// </summary>
        /// <returns></returns>
        public static bool IsCheckbox(enControl_InputType type)
        {
            var isCheckbox = (type == enControl_InputType.Checkbox1 ||
                              type == enControl_InputType.Checkbox2 ||
                              type == enControl_InputType.Checkbox3);
            return isCheckbox;
        }

        /// <summary>
        /// Determines whether the active type is a checkbox.
        /// </summary>
        /// <returns></returns>
        public static bool IsRadioButton(enControl_InputType type)
        {
            var isRadioButton = (type == enControl_InputType.RadioButton2 ||
                                 type == enControl_InputType.RadioButton3 ||
                                 type == enControl_InputType.RadioButton4);
            return isRadioButton;
        }

        /// <summary>
        /// Determines whether the active type is button.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <returns></returns>
        public static bool IsButton(enControl_InputType controlType)
        {
            var isButton = (controlType == enControl_InputType.Button1 ||
                            controlType == enControl_InputType.Button2 ||
                            controlType == enControl_InputType.Button3);
            return isButton;
        }

        public static void Create_Button1(Panel pnlLabel, ref Button btnValue1, EventHandler Click)
        {
            // 
            // btnValue1
            // 
            if (btnValue1 == null)
            {
                btnValue1 = new Button();
                btnValue1.Name = "btnValue1";
                btnValue1.Dock = DockStyle.Fill;
                btnValue1.TabIndex = 3;
                btnValue1.Text = "Action Button";
                btnValue1.UseVisualStyleBackColor = true;
                btnValue1.Click += Click;
                //button4.Click += button4_Click;

                pnlLabel.Controls.Add(btnValue1);

            }
            btnValue1.Visible = false;
        }

        public static void Create_Button2(Panel pnlText, ref Button btnValue2, EventHandler Click)
        {
            // 
            // btnValue2
            // 
            if (btnValue2 == null)
            {
                btnValue2 = new Button();
                btnValue2.Name = "btnValue2";
                btnValue2.Dock = DockStyle.Fill;
                btnValue2.TabIndex = 3;
                btnValue2.Text = "Action Button2";
                btnValue2.UseVisualStyleBackColor = true;
                btnValue2.Click += Click;
                //btnValue2.Click += button4_Click;

                pnlText.Controls.Add(btnValue2);
            }
            btnValue2.Visible = false;
        }

        public static void Create_Checkbox(Panel pnlLabel, ref CheckBox chkValue, string text, EventHandler CheckedChanged)
        {
            // 
            // chkValue
            // 
            if (chkValue == null)
            {
                chkValue = new CheckBox();
                chkValue.AutoSize = true;
                chkValue.Dock = DockStyle.Left;
                chkValue.Location = new Point(0, 0);
                chkValue.Name = "chkValue1";
                chkValue.TabIndex = 0;
                chkValue.Text = text;
                chkValue.CheckedChanged += CheckedChanged;
                //chkValue1.UseVisualStyleBackColor = true;
                pnlLabel.Controls.Add(chkValue);

            }
            chkValue.Visible = false;
        }

        public static void Create_Combobox(Panel pnlText, ref ComboBox cboValue, EventHandler SelectedIndexChanged)
        {
            // 
            // cboValue
            // 
            if (cboValue == null)
            {
                cboValue = new ComboBox();
                cboValue.BackColor = Color.White;
                cboValue.Dock = DockStyle.Fill;
                cboValue.Location = new Point(0, 20);
                cboValue.Name = "cboValue";
                cboValue.Size = new Size(412, 2);
                cboValue.TabIndex = 2;
                cboValue.SelectedIndexChanged += SelectedIndexChanged;
                pnlText.Controls.Add(cboValue);
            }
            cboValue.Visible = false;
        }

        public static void Create_DateTimePicker(Panel pnlText, ref DateTimePicker dtpValue, EventHandler ValueChanged)
        {
            // 
            // dtpValue
            // 
            if (dtpValue == null)
            {
                dtpValue = new DateTimePicker();
                dtpValue.BackColor = Color.White;
                dtpValue.Dock = DockStyle.Fill;
                dtpValue.Location = new Point(0, 20);
                dtpValue.Name = "dtpValue";
                dtpValue.Size = new Size(412, 2);
                dtpValue.TabIndex = 2;
                dtpValue.ValueChanged += ValueChanged;
                pnlText.Controls.Add(dtpValue);
            }
            dtpValue.Visible = false;
        }

        public static void Create_Listbox(Panel pnlText, ref ListBox lstValue, EventHandler SelectedIndexChanged)
        {
            // 
            // lstValue
            // 
            if (lstValue == null)
            {
                lstValue = new ListBox();
                lstValue.BackColor = Color.White;
                lstValue.Dock = DockStyle.Fill;
                lstValue.Location = new Point(0, 20);
                lstValue.Name = "lstValue";
                lstValue.Size = new Size(412, 2);
                lstValue.TabIndex = 2;
                lstValue.SelectedIndexChanged += SelectedIndexChanged;
                pnlText.Controls.Add(lstValue);
            }
            lstValue.Visible = false;
        }

        public static void Create_RadioButton(Panel pnlLabel, ref RadioButton rdoValue, string text, EventHandler CheckedChanged)
        {
            // 
            // chkValue
            // 
            if (rdoValue == null)
            {
                rdoValue = new RadioButton();
                rdoValue.AutoSize = true;
                rdoValue.Dock = DockStyle.Left;
                rdoValue.Location = new Point(0, 0);
                //rdoValue.Name = "chkValue1";
                rdoValue.TabIndex = 0;
                rdoValue.Text = text;
                //rdoValue.CheckedChanged -= CheckedChanged;
                //rdoValue.CheckedChanged += CheckedChanged;
                rdoValue.Click += CheckedChanged;
                //chkValue1.UseVisualStyleBackColor = true;
                pnlLabel.Controls.Add(rdoValue);

            }
            rdoValue.Visible = false;
        }

        public static void Create_TextBox(Panel pnlText, ref TextBox txtValue, EventHandler TextChanged, KeyPressEventHandler KeyPress)
        {
            // 
            // txtValue
            // 
            if (txtValue == null)
            {
                txtValue = new TextBox();

                txtValue.BackColor = Color.White;
                txtValue.Dock = DockStyle.Fill;
                txtValue.Location = new Point(0, 20);
                txtValue.Multiline = true;
                txtValue.Name = "txtValue";
                txtValue.Size = new Size(412, 20);
                txtValue.TabIndex = 2;
                txtValue.TextChanged += TextChanged;
                txtValue.KeyPress += KeyPress;
                pnlText.Controls.Add(txtValue);
            }
            txtValue.Visible = false;
        }

        public static void Create_TextboxMasked(Panel pnlText, ref MaskedTextBox txtValueMasked, EventHandler TextChanged, KeyPressEventHandler KeyPress)
        {
            // 
            // txtValueMasked
            // 
            if (txtValueMasked == null)
            {
                txtValueMasked = new MaskedTextBox();

                txtValueMasked.Dock = DockStyle.Top;
                txtValueMasked.Location = new Point(0, 0);
                txtValueMasked.Mask = "(999) 000-0000";
                txtValueMasked.Name = "txtValueMasked";
                txtValueMasked.Size = new Size(412, 20);
                txtValueMasked.TabIndex = 4;
                txtValueMasked.TextChanged += TextChanged;
                txtValueMasked.KeyPress += KeyPress;
                pnlText.Controls.Add(txtValueMasked);
            }
            txtValueMasked.Visible = false;
        }
    }
}