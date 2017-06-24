using System;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.Input
{
    /// <summary>
    /// Setup the different input controls
    /// </summary>
    public sealed partial class Input_Control_Controller
    {
        private readonly Lamedal_WinForms IamWindows = Lamedal_WinForms.Instance; // Set reference to Blueprint Windows lib
        private readonly Input_Control _inputControl;
        private enControl_InputType _ControlType;
        private bool _border;
        private Color _borderColor = Color.Red;

        public Input_Control_Controller(Input_Control inputControl)
        {
            _inputControl = inputControl;
            Input_Control_Initialize();
            Event_Hookup();
        }

        #region Fields & Properties

        public int Columns = 3;
        public int LabelWidth = 80;

        public bool Border
        {
            get { return _border; }
            set
            {
                _border = value;
                OnPaint_Border1(value);
            }
        }

        public Color Border_Color
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                pnlBorder.Invalidate();
            }
        }

        public int Border_Width
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                pnlBorder.Invalidate();
            }
        }

        #endregion

        private void OnPaint_Border(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(_borderColor), _borderWidth), e.ClipRectangle);
        }
        public void OnPaint_Border1(bool on = true, bool doubleBorder = false)
        {
            if (on)
            {
                // Border 1
                pnlBorder.Paint -= OnPaint_Border;
                pnlBorder.Paint += OnPaint_Border;
                pnlBorder.Invalidate();
                if (doubleBorder) OnPaint_Border2(true);
            }
            else
            {
                // Border off
                pnlBorder.Paint -= OnPaint_Border;
                pnlBorder.Invalidate();
            }
        }
        public void OnPaint_Border2(bool on = true)
        {
            if (on)
            {
                // Border 2
                IamWindows.libUI.WinForms.Controls.Control.BorderColour(pnlBorder2, Color.Red);
            }
            else pnlBorder2.Invalidate();
        }

        public void Control_Refresh()
        {
            Control_Type(_ControlType, 1, pAction_Button);
        }
        public string Control_Caption
        {
            get { return _Control_Caption; }
            set
            {
                _Control_Caption = value;
                Control_Refresh();
            }
        }
        private string _Control_Caption = "FieldName";

        public string Control_Caption2
        {
            get { return _Control_Caption2; }
            set
            {
                _Control_Caption2 = value;
                Control_Refresh();
            }
        }
        private string _Control_Caption2 = "FieldName2";

        public string Control_Caption3
        {
            get { return _Control_Caption3; }
            set
            {
                _Control_Caption3 = value;
                Control_Refresh();
            }
        }
        private string _Control_Caption3 = "FieldName3";

        public string Control_Caption4
        {
            get { return _Control_Caption4; }
            set
            {
                _Control_Caption4 = value;
                Control_Refresh();
            }
        }
        private string _Control_Caption4 = "FieldName4";

        public void Control_Rows(int rows = 1)
        {
            // Set the control height
            Rows = rows;
            pnlBorder.Height = (rows * 20) + 15;
        }
        public void Control_Columns(enControl_InputWidth size)
        {
            Control_Columns(Columns, size);
        }
        public void Control_Columns(int columns = 2, enControl_InputWidth size = enControl_InputWidth.Normal)
        {
            if (size == enControl_InputWidth.Centre) columns = 2;

            if (columns == 1)
            {
                pnlLabel.Dock = DockStyle.Fill;
                pnlButton.Visible = false;
                pnlText.Visible = false;
            }
            if (columns == 2)
            {
                pnlLabel.Dock = DockStyle.Left;
                pnlText.Visible = true;
                pnlButton.Visible = false;
            }
            if (columns == 3)
            {
                pnlLabel.Dock = DockStyle.Left;
                pnlText.Visible = true;
                pnlButton.Visible = true;
            }

            if (size == enControl_InputWidth.Normal)
            {
                pnlText.Dock = DockStyle.Fill;
                pnlLabel.Size = new System.Drawing.Size(LabelWidth, 22);
                pnlButton.Size = new System.Drawing.Size(30, 22);
                pnlText.Size = new System.Drawing.Size(412, 22);
            }
            if (size == enControl_InputWidth.Thirds)
            {
                pnlText.Dock = DockStyle.Fill;
                pnlLabel.Size = new System.Drawing.Size(_inputControl.Width / 3 - 2, 22);
                pnlButton.Size = new System.Drawing.Size(_inputControl.Width / 3 - 2, 22);
                //pnlText.Size = new System.Drawing.Size(Width / 3 - 2, 22);

            }
            if (size == enControl_InputWidth.Centre)
            {
                pnlLabel.Size = new System.Drawing.Size(_inputControl.Width / 2 - 2, 22);
                pnlText.Dock = DockStyle.Fill;
            }
            Columns = columns;
        }

        public void Button_Action(bool on = true)
        {
            if (on)
            {
                // Action On
                pnlButton.Visible = true;
                pnlButton.Width = 30;
                btnAction.Text = "..";
                btnAction.Click -= Handle_Button_Click;
                btnAction.Click += Handle_Button_Click;
            }
            else pnlButton.Visible = false;
        }
        public void Button_Action_Big(string text = "Action", EventHandler actionMethod = null)
        {
            // Big Action
            pnlButton.Visible = true;
            pnlButton.Width = 100;
            btnAction.Text = text;
            if (actionMethod != null)
            {
                btnAction.Click += actionMethod;
                btnAction.Click -= actionMethod;
            }
        }

        internal void Button_DefaultAction_Handle(object sender, EventArgs e)
        {
            // Default actions
            if (txtValue != null && txtValue.Visible) txtValue.Text = txtValue.Text.zDialog().Memo("Edit the text");
            if (txtValueMasked != null && txtValueMasked.Visible) txtValueMasked.Text = txtValueMasked.Text.zDialog().Memo("Edit the text");

            // Combo & Listbox
            if (cboValue != null && cboValue.Visible)
            {
                var str = cboValue.Items.zTo_Str("".NL());
                str = str.zDialog().Memo("Edit the Items");
                var sArray = str.zConvert_Array_FromStr("".NL());
                sArray.zTo_IList(cboValue.Items);
            }
            if (lstValue != null && lstValue.Visible)
            {
                var str = lstValue.Items.zTo_Str("".NL());
                str = str.zDialog().Memo("Edit the Items");
                var sArray = str.zConvert_Array_FromStr("".NL());
                sArray.zTo_IList(lstValue.Items);
            }
        }
    }
}
