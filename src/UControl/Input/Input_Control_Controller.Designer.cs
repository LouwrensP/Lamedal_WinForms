using System;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.domain.Events;

namespace Lamedal_UIWinForms.UControl.Input
{
    /// <code>CTI;</code>
    public sealed partial class Input_Control_Controller
    {
        #region Controls
        // Panels
        public Panel pnlBorder;
        private Panel pnlBorder2;
        internal Panel pnlButton;
        private Panel pnlText;
        internal Panel pnlLabel;

        // Controls
        internal TextBox txtValue;
        internal MaskedTextBox txtValueMasked;
        public ComboBox cboValue;
        public ListBox lstValue;
        internal Label lblName;
        public Button btnValue1;
        public Button btnValue2;
        internal Button btnAction;
        public Button Action_Button_Enter = null;
        internal CheckBox chkValue1;
        internal CheckBox chkValue2;
        internal CheckBox chkValue3;
        internal RadioButton rdoValue1;
        internal RadioButton rdoValue2;
        internal RadioButton rdoValue3;
        internal RadioButton rdoValue4;
        public DateTimePicker dtpValue;
        public int Rows = 1;
        private int _borderWidth = 2;

        public bool pAction_Button;   // If true -> Show the action button

        #endregion

        #region Events
        public event EventHandler<onInputControl_EventArgs> Event_OnValueChange;
        public event EventHandler<onInputControl_EventArgs> Event_OnEnterPressed;
        public event EventHandler<onInputControl_EventArgs> Event_OnActionButtonClick;

        #region Event Methods

        public void Value_Set(int version, bool newValue)
        {
            switch (version)
            {
                case 1: if (chkValue1 != null) chkValue1.Checked = newValue; break;
                case 2: if (chkValue2 != null) chkValue2.Checked = newValue; break;
                case 3: if (chkValue3 != null) chkValue3.Checked = newValue; break;
            }
        }

        public void Value_Set(object newValue)
        {
            try
            {
                int value;
                switch (_ControlType)
                {
                    case enControl_InputType.Edit:
                        txtValue.Text = newValue.zObject().AsStr();
                        break;
                    case enControl_InputType.Edit_Masked:
                        txtValueMasked.Text = newValue.zObject().AsStr();
                        break;
                    case enControl_InputType.DateTime:
                        dtpValue.Value = newValue.zObject().AsDateTime();
                        break;
                    case enControl_InputType.Checkbox1:
                    case enControl_InputType.Checkbox2:
                    case enControl_InputType.Checkbox3:
                        chkValue1.Checked = newValue.zObject().AsBool();
                        break;
                    case enControl_InputType.RadioButton2:
                        value = newValue.zObject().AsInt();
                        if (value == 1) rdoValue1.Checked = true;
                        else if (value == 2) rdoValue2.Checked = true;
                        break;
                    case enControl_InputType.RadioButton3:
                        value = newValue.zObject().AsInt();
                        if (value == 1) rdoValue1.Checked = true;
                        else if (value == 2) rdoValue2.Checked = true;
                        else if (value == 3) rdoValue3.Checked = true;
                        break;
                    case enControl_InputType.RadioButton4:
                        value = newValue.zObject().AsInt();
                        if (value == 1) rdoValue1.Checked = true;
                        else if (value == 2) rdoValue2.Checked = true;
                        else if (value == 3) rdoValue3.Checked = true;
                        else if (value == 4) rdoValue4.Checked = true;
                        break;
                    case enControl_InputType.Combobox:
                        var valueStr = newValue.zObject().AsStr();
                        if (valueStr.zIsNullOrEmpty() == false)
                        {
                            IamWindows.libUI.WinForms.Controls.ComboBox.SearchItem(cboValue, valueStr);
                        }
                        else
                        {
                            var iValue = newValue.zObject().AsInt(-1);
                            if (iValue == -1) cboValue.Text = newValue.zObject().AsStr();
                            else cboValue.SelectedValue = iValue; // Set the value  
                        }
                        break;
                    case enControl_InputType.Listbox:
                        lstValue.SelectedIndex = newValue.zObject().AsInt();
                        break;
                }
            }
            catch (Exception ex)
            {
                // Get the calling method and provide more context to the error
                var msg = Lamedal_WinForms.Instance.lib.dotNet.Stacktrace.Method_Stacktrace_AsStr(false, "Value_Set");
                throw new Exception(msg, ex); 
            }
        }
        /// <summary>
        /// Return the current Value.
        /// </summary>
        /// <returns></returns>
        public string Value_Get()
        {
            Control ctrl;
            onInputControl_EventArgs args;
            return Value_Get(out ctrl, out args).zObject().AsStr();
        }

        /// <summary>
        /// Return the current Value.
        /// </summary>
        /// <returns></returns>
        public bool Value_Get(int version)
        {
            Control ctrl;
            onInputControl_EventArgs args;
            Value_Get(out ctrl, out args);
            switch (version)
            {
                case 1: return args.Value1;
                case 2: return args.Value2;
                case 3: return args.Value3;
                default: throw new ArgumentException("Error! Undefined version!", nameof(version));
            }
        }
        /// <summary>
        /// Return the current Value.
        /// </summary>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="args">The <see cref="onInputControl_EventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public object Value_Get(out Control ctrl, out onInputControl_EventArgs args)
        {
            object value = null;
            bool value1 = false;
            bool value2 = false;
            bool value3 = false;
            string text = "";
            ctrl = null;
            switch (_ControlType)
            {
                case enControl_InputType.Edit:
                    ctrl = txtValue;
                    value = txtValue.Text;
                    break;
                case enControl_InputType.Edit_Masked:
                    ctrl = txtValueMasked;
                    value = txtValueMasked.Text;
                    break;
                case enControl_InputType.DateTime:
                    ctrl = dtpValue;
                    value = dtpValue.Value;
                    break;
                case enControl_InputType.Checkbox1:
                    ctrl = chkValue1;
                    value = chkValue1.Checked;
                    if (chkValue1.Checked) text = chkValue1.Text;
                    break;
                case enControl_InputType.Checkbox2:
                    ctrl = chkValue2;
                    value1 = chkValue1.Checked;
                    value2 = chkValue2.Checked;
                    if (chkValue1.Checked) text += chkValue1.Text + ", ";
                    if (chkValue2.Checked) text += chkValue2.Text;
                    break;
                case enControl_InputType.Checkbox3:
                    ctrl = chkValue3;
                    value1 = chkValue1.Checked;
                    value2 = chkValue2.Checked;
                    value3 = chkValue3.Checked;
                    if (chkValue1.Checked) text += chkValue1.Text + ", ";
                    if (chkValue2.Checked) text += chkValue2.Text + ", ";
                    if (chkValue3.Checked) text += chkValue3.Text;
                    break;
                case enControl_InputType.RadioButton2:
                    value = rdoValue1.Checked ? 1 : 2;
                    text = rdoValue1.Checked ? rdoValue1.Text : rdoValue2.Text;
                    ctrl = value.zObject().AsInt() == 1 ? rdoValue1 : rdoValue2;
                    break;
                case enControl_InputType.RadioButton3:
                    value = rdoValue1.Checked ? 1 : rdoValue2.Checked ? 2 : 3;
                    text = rdoValue1.Checked ? rdoValue1.Text : rdoValue2.Checked ? rdoValue2.Text : rdoValue3.Text;
                    ctrl = value.zObject().AsInt() == 1 ? rdoValue1 : value.zObject().AsInt() == 2 ? rdoValue2 : rdoValue3;
                    break;
                case enControl_InputType.RadioButton4:
                    value = rdoValue1.Checked ? 1 : rdoValue2.Checked ? 2 : rdoValue3.Checked ? 3 : 4;
                    text = rdoValue1.Checked ? rdoValue1.Text : rdoValue2.Checked ? rdoValue2.Text : rdoValue3.AutoCheck ? rdoValue3.Text : rdoValue4.Text;
                    ctrl = value.zObject().AsInt() == 1 ? rdoValue1 : value.zObject().AsInt() == 2 ? rdoValue2 : value.zObject().AsInt() == 3 ? rdoValue3 : rdoValue4;
                    break;
                case enControl_InputType.Combobox:
                    ctrl = cboValue;
                    value = cboValue.SelectedIndex;
                    text = cboValue.Text;
                    break;
                case enControl_InputType.Listbox:
                    ctrl = lstValue;
                    value = lstValue.SelectedIndex;
                    text = lstValue.Text;
                    break;
                case enControl_InputType.Button1:
                    ctrl = btnValue1;
                    value = btnValue1.Text;
                    break;
                case enControl_InputType.Button2:
                case enControl_InputType.Button3:
                    ctrl = btnAction;
                    value = btnAction.Text;
                    break;
                default:
                    var msg = "Control Type '" + _ControlType + "'not defined yet in Input_Control_Class.Value_Get()!";
                    throw new ArgumentException(msg, nameof(_ControlType));
            }
            args = new onInputControl_EventArgs(_ControlType, value, text, value1, value2, value3);
            return value;
        }
        private void Event_Hookup()
        {
            // OnEnter
            txtValue.KeyPress += Handle_KeyPress;

            // Action Button
            btnAction.Click -= Handle_Button_Click;
            btnAction.Click += Handle_Button_Click;
        }
        private void Handle_Button_Click(object sender, EventArgs e)
        {
            // Test for button types
            // Fire Event
            Control ctrl;
            onInputControl_EventArgs args;
            Value_Get(out ctrl, out args);
            Event_OnActionButtonClick(ctrl, args);
        }

        private void Handle_OnValueChange(object sender, EventArgs e)
        {
            // Value changed
            if (Event_OnValueChange != null)
            {
                // Fire Event
                Control ctrl;
                onInputControl_EventArgs args;
                Value_Get(out ctrl, out args);
                Event_OnValueChange(ctrl, args);
            }
        }
        private void Handle_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                // Fire Event
                Control ctrl;
                onInputControl_EventArgs args;
                Value_Get(out ctrl, out args);
                Event_OnEnterPressed(ctrl, args);

                // Perform the action button click
                if (Action_Button_Enter != null) Action_Button_Enter.PerformClick();
            }
        }

        #endregion

        #endregion

        public void Input_Control_Initialize()
        {
            #region Init
            pnlBorder2 = new System.Windows.Forms.Panel();
            pnlText = new System.Windows.Forms.Panel();
            pnlButton = new System.Windows.Forms.Panel();
            pnlLabel = new Panel();
            btnAction = new System.Windows.Forms.Button();
            lblName = new System.Windows.Forms.Label();
            pnlBorder = new System.Windows.Forms.Panel();
            pnlBorder2.SuspendLayout();
            pnlText.SuspendLayout();
            pnlButton.SuspendLayout();
            pnlLabel.SuspendLayout();
            pnlBorder.SuspendLayout();
            _inputControl.SuspendLayout();
            #endregion
            // 
            #region pnlBorder2
            // 
            pnlBorder2.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            pnlBorder2.BorderStyle = BorderStyle.FixedSingle;
            pnlBorder2.Controls.Add(pnlText);
            pnlBorder2.Controls.Add(pnlButton);
            pnlBorder2.Controls.Add(pnlLabel);
            pnlBorder2.Location = new System.Drawing.Point(5, 6);
            pnlBorder2.Name = "pnlBorder2";
            pnlBorder2.Size = new System.Drawing.Size(544, 24);
            pnlBorder2.TabIndex = 3;
            pnlBorder2.BorderStyle = BorderStyle.None;
            #endregion
            // 
            #region pnlText
            //             
            pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlText.Location = new System.Drawing.Point(100, 0);
            pnlText.Name = "pnlText";
            pnlText.Size = new System.Drawing.Size(412, 22);
            pnlText.TabIndex = 5;
            #endregion
            // 
            #region pnlLabel
            //             
            pnlLabel.Dock = System.Windows.Forms.DockStyle.Left;
            pnlLabel.Location = new System.Drawing.Point(100, 0);
            pnlLabel.Controls.Add(lblName);
            pnlLabel.Name = "pnlLabel";
            pnlLabel.Size = new System.Drawing.Size(100, 22);
            pnlLabel.TabIndex = 5;
            #endregion
            // 
            #region pnlButton
            // 
            pnlButton.Controls.Add(btnAction);
            pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
            pnlButton.Location = new System.Drawing.Point(512, 0);
            pnlButton.Name = "pnlButton";
            pnlButton.Size = new System.Drawing.Size(30, 22);
            pnlButton.TabIndex = 3;
            #endregion
            // 
            #region btnAction
            // 
            btnAction.Dock = System.Windows.Forms.DockStyle.Top;
            btnAction.Location = new System.Drawing.Point(0, 0);
            btnAction.Name = "btnAction";
            btnAction.Size = new System.Drawing.Size(30, 23);
            btnAction.TabIndex = 1;
            btnAction.Text = "..";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click -= Handle_Button_Click;
            btnAction.Click += Handle_Button_Click;
            #endregion
            // 
            #region lblName
            // 
            lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblName.Location = new System.Drawing.Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(100, 22);
            lblName.TabIndex = 0;
            lblName.Text = _Control_Caption;
            lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            #endregion
            // 
            #region pnlBorder
            // 
            pnlBorder.Controls.Add(pnlBorder2);
            pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBorder.Location = new System.Drawing.Point(0, 0);
            pnlBorder.Name = "pnlBorder";
            pnlBorder.Size = new System.Drawing.Size(552, 35);
            pnlBorder.TabIndex = 4;
            pnlBorder.BorderStyle = BorderStyle.None;
            #endregion
            // 
            #region Form1
            // 
            _inputControl.Controls.Add(pnlBorder);
            pnlBorder2.ResumeLayout(false);
            pnlText.ResumeLayout(false);
            pnlText.PerformLayout();
            pnlLabel.ResumeLayout();
            pnlLabel.PerformLayout();
            pnlButton.ResumeLayout(false);
            pnlBorder.ResumeLayout(false);
            _inputControl.ResumeLayout(false);
            #endregion
            Control_Type();
        }

        public void Control_Type(enControl_InputType type = enControl_InputType.Edit, int rows = 1, bool actionButton = false)
        {
            #region Reset previous settings
            pAction_Button = actionButton;
            lblName.Visible = true;
            if (actionButton) Control_Columns(3);
            else Control_Columns();

            if (type == enControl_InputType.Listbox) if (rows < 3) rows = 3;  // Listbox must be at least 3 rows

            Control_Rows(rows);           // Set the hight

            if (txtValue != null) txtValue.Visible = false;
            if (txtValueMasked != null) txtValueMasked.Visible = false;
            if (cboValue != null) cboValue.Visible = false;
            if (lstValue != null) lstValue.Visible = false;
            if (dtpValue != null) dtpValue.Visible = false;
            if (btnAction != null) btnAction.Text = "..";
            if (btnValue1 != null) btnValue1.Visible = false;
            if (btnValue2 != null) btnValue2.Visible = false;
            if (chkValue1 != null) chkValue1.Visible = false;
            if (chkValue2 != null) chkValue2.Visible = false;
            if (chkValue3 != null) chkValue3.Visible = false;
            if (rdoValue1 != null) rdoValue1.Visible = false;
            if (rdoValue2 != null) rdoValue2.Visible = false;
            if (rdoValue3 != null) rdoValue3.Visible = false;
            if (rdoValue4 != null) rdoValue4.Visible = false;
            lblName.Text = Control_Caption;
            #endregion

            // Edit
            if (type == enControl_InputType.Edit)
            {
                Input_Control_Tools.Create_TextBox(pnlText, ref txtValue, Handle_OnValueChange, Handle_KeyPress);
                txtValue.Visible = true;
                if (_ControlType == enControl_InputType.Edit_Masked) txtValue.Text = txtValueMasked.Text;
            }

            // Edit_Masked
            if (type == enControl_InputType.Edit_Masked)
            {
                Input_Control_Tools.Create_TextboxMasked(pnlText, ref txtValueMasked, Handle_OnValueChange, Handle_KeyPress);
                txtValueMasked.Visible = true;
                if (_ControlType == enControl_InputType.Edit) txtValueMasked.Text = txtValue.Text;
            }

            // Combobox
            if (type == enControl_InputType.Combobox)
            {
                Input_Control_Tools.Create_Combobox(pnlText, ref cboValue, Handle_OnValueChange);
                cboValue.Visible = true;
                if (_ControlType == enControl_InputType.Listbox) lstValue.Items.zTo_IList(cboValue.Items); //cboValue.Items.zFrom_List(lstValue.Items, true);
            }

            // Listbox
            if (type == enControl_InputType.Listbox)
            {
                Input_Control_Tools.Create_Listbox(pnlText, ref lstValue, Handle_OnValueChange);
                lstValue.Visible = true;
                if (_ControlType == enControl_InputType.Combobox) cboValue.Items.zTo_IList(lstValue.Items); //lstValue.Items.zFrom_List(cboValue.Items, true);
            }

            // DateTime
            if (type == enControl_InputType.DateTime)
            {
                Input_Control_Tools.Create_DateTimePicker(pnlText, ref dtpValue, Handle_OnValueChange);
                dtpValue.Visible = true;
            }

            #region Button
            if (type == enControl_InputType.Button1 || type == enControl_InputType.Button2 || type == enControl_InputType.Button3)
            {
                Input_Control_Tools.Create_Button1(pnlLabel, ref btnValue1, Handle_Button_Click);
                btnValue1.Text = _Control_Caption;
                Control_Columns(1);
                //pnlLabel.Visible =
                pnlLabel.Dock = DockStyle.Fill;
                lblName.Visible = false;
                btnValue1.Visible = true;
                // Button2
                if (type == enControl_InputType.Button2 || type == enControl_InputType.Button3)
                {
                    Input_Control_Tools.Create_Button2(pnlText, ref btnValue2, Handle_Button_Click);
                    btnValue2.Text = _Control_Caption2;
                    Control_Columns(2, enControl_InputWidth.Centre);
                    if (actionButton) pnlButton.Visible = true;
                    lblName.Visible = false;
                    btnValue2.Visible = true;
                }

                // Button3
                if (type == enControl_InputType.Button3)
                {
                    Control_Columns(3, enControl_InputWidth.Thirds);
                    btnAction.Text = _Control_Caption3;
                    pnlButton.Visible = true;
                    lblName.Visible = false;
                    btnAction.Visible = true;
                }
            }
            #endregion

            #region Checkbox
            if (type == enControl_InputType.Checkbox1 || type == enControl_InputType.Checkbox2 || type == enControl_InputType.Checkbox3)
            {
                Input_Control_Tools.Create_Checkbox(pnlLabel, ref chkValue1, _Control_Caption, Handle_OnValueChange);
                chkValue1.Text = _Control_Caption;
                chkValue1.Name = "chkValue1";
                Control_Columns(1);
                pnlLabel.Dock = DockStyle.Fill;
                lblName.Visible = false;
                chkValue1.Visible = true;
                if (type == enControl_InputType.Checkbox2 || type == enControl_InputType.Checkbox3)
                {
                    Input_Control_Tools.Create_Checkbox(pnlLabel, ref chkValue2, _Control_Caption2, Handle_OnValueChange);
                    chkValue2.Text = _Control_Caption2;
                    chkValue2.Name = "chkValue2";
                    chkValue2.Visible = true;
                }
                if (type == enControl_InputType.Checkbox3)
                {
                    Input_Control_Tools.Create_Checkbox(pnlLabel, ref chkValue3, _Control_Caption3, Handle_OnValueChange);
                    chkValue2.Text = _Control_Caption2;
                    chkValue3.Text = _Control_Caption3;
                    chkValue3.Name = "chkValue3";
                    chkValue3.Visible = true;

                }
                chkValue1.SendToBack();
                if (chkValue3 != null) chkValue3.BringToFront();
                if (actionButton) pnlButton.Visible = true;
            }
            #endregion

            #region RadioButton
            if (type == enControl_InputType.RadioButton2 || type == enControl_InputType.RadioButton3 || type == enControl_InputType.RadioButton4)
            {
                Input_Control_Tools.Create_RadioButton(pnlLabel, ref rdoValue1, _Control_Caption, Handle_OnValueChange);
                Input_Control_Tools.Create_RadioButton(pnlLabel, ref rdoValue2, _Control_Caption2, Handle_OnValueChange);

                Control_Columns(1);
                pnlLabel.Dock = DockStyle.Fill;
                lblName.Visible = false;
                rdoValue1.Text = _Control_Caption;
                rdoValue2.Text = _Control_Caption2;
                rdoValue1.Visible = true;
                rdoValue2.Visible = true;
                rdoValue1.Name = "rdoValue1";
                rdoValue2.Name = "rdoValue2";

                rdoValue1.SendToBack();
                if (type == enControl_InputType.RadioButton3 || type == enControl_InputType.RadioButton4)
                {
                    Input_Control_Tools.Create_RadioButton(pnlLabel, ref rdoValue3, _Control_Caption3, Handle_OnValueChange);
                    rdoValue3.Text = _Control_Caption3;
                    rdoValue3.Visible = true;
                    rdoValue3.Name = "rdoValue3";
                    rdoValue3.BringToFront();
                }
                if (type == enControl_InputType.RadioButton4)
                {
                    Input_Control_Tools.Create_RadioButton(pnlLabel, ref rdoValue4, _Control_Caption4, Handle_OnValueChange);
                    rdoValue4.Text = _Control_Caption4;
                    rdoValue4.Visible = true;
                    rdoValue4.Name = "rdoValue4";
                    rdoValue4.BringToFront();
                }
                if (actionButton) pnlButton.Visible = true;
            }
            #endregion

            pnlBorder.Invalidate();
            _ControlType = type;
        }
    }
}
