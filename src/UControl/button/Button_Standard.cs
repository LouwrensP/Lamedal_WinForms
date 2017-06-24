using System;
using System.ComponentModel;
using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Enumerals;
using Lamedal_UIWinForms.domain.Events;

namespace Lamedal_UIWinForms.UControl.button
{
    [Description("Standard Buttons Control")]
    [Serializable]
    [DefaultEvent("Event_OnClick")]
    [DefaultProperty("Name")]
    [Designer(typeof(Button_Standard_Designer))]   // Link the designer
    [ToolboxItem(true)]
    public partial class Button_Standard : UserControl_
    {
        public readonly Button_Standard_Class Ctrls;
        private bool _Text_Reset;

        /// <summary>
        /// Initializes a new instance of the &lt;see cref=&quot;Button_Standard&quot;/&gt; class.
        /// </summary>
        public Button_Standard()
        {
            Height = 30;
            Ctrls = new Button_Standard_Class(this);
            Control_Dock(DockStyle.Bottom);

            InitializeComponent(); 
            Ctrls.Hook_Events(OkClick, CancelClick, HelpClick, ApplyClick, ClipboardClick);
        }

        #region properties


        #region Ctrls

        /// <summary>
        /// Gets the ok button control.
        /// </summary>
        [Category("Controls")]
        [Description("Return the Ok Control")]
        public Button Ctrl_OkButton
        {
            get { return Ctrls.btnOk; }
        }

        /// <summary>
        /// Gets the cancel button control.
        /// </summary>
        [Category("Controls")]
        [Description("Return the Cancel Control")]
        public Button Ctrl_CancelButton
        {
            get { return Ctrls.btnCancel; }
        }

        /// <summary>
        /// Gets the apply button control.
        /// </summary>
        [Category("Controls")]
        [Description("Return the Apply Control")]
        public Button Ctrl_ApplyButton
        {
            get { return Ctrls.btnApply; }
        }

        /// <summary>
        /// Gets the help button control.
        /// </summary>
        [Category("Controls")]
        [Description("Return the Help Control")]
        public Button Ctrl_HelpButton
        {
            get { return Ctrls.btnHelp; }
        }

        /// <summary>
        /// Gets the clipboard button control.
        /// </summary>
        [Category("Controls")]
        [Description("Return the Copy2Clipboard Control")]
        public Button Ctrl_ClipboardButton
        {
            get { return Ctrls.btnClipboard; }
        }

        #endregion


        #region Appearance Visible

        /// <summary>
        /// Gets or sets a value to indicate whether ok is visible.
        /// </summary>
        [Category("Appearance")]
        [Description("Set Ok Visible property")]
        public bool Visible_Ok
        {
            get { return Ctrls.Visible_Get(enControl_StandardButtons.Ok); }
            set { Ctrls.Visible_Set(enControl_StandardButtons.Ok, value); }
        }

        /// <summary>
        /// Gets or sets a value to indicate whether cancel is visible.
        /// </summary>
        [Category("Appearance")]
        [Description("Set Cancel Visible property")]
        public bool Visible_Cancel
        {
            get { return Ctrls.Visible_Get(enControl_StandardButtons.Cancel); }
            set { Ctrls.Visible_Set(enControl_StandardButtons.Cancel, value); }
        }

        /// <summary>
        /// Gets or sets a value to indicate whether apply visible.
        /// </summary>
        [Category("Appearance")]
        [Description("Set Apply Visible property")]
        public bool Visible_Apply
        {
            get { return Ctrls.Visible_Get(enControl_StandardButtons.Apply); }
            set { Ctrls.Visible_Set(enControl_StandardButtons.Apply, value); }
        }


        /// <summary>
        /// Gets or sets a value to indicate whether help visible.
        /// </summary>
        [Category("Appearance")]
        [Description("Set Help Visible property")]
        public bool Visible_Help
        {
            get { return Ctrls.Visible_Get(enControl_StandardButtons.Help); }
            set { Ctrls.Visible_Set(enControl_StandardButtons.Help, value); }
        }

        [Category("Appearance")]
        [Description("Set Copy2Clipboard Visible property")]
        public bool Visible_Clipboard
        {
            get { return Ctrls.Visible_Get(enControl_StandardButtons.Copy2Clipboard); }
            set { Ctrls.Visible_Set(enControl_StandardButtons.Copy2Clipboard, value); }
        }
        #endregion


        #region Text

        /// <summary>
        /// Gets or sets a value to indicate whether reset text.
        /// </summary>
        [Category("\tText")]
        [Description("Reset Text properties")]
        public bool Text_Reset
        {
            get { return _Text_Reset; }
            set
            {
                _Text_Reset = value;
                if (_Text_Reset) Ctrls.Text_Set();
                _Text_Reset = false;
            }
        }

        /// <summary>
        /// Gets or sets the ok text value.
        /// </summary>
        [Category("\tText")]
        [Description("Gets or sets the ok text value.")]
        public string Text_Ok
        {
            get { return Ctrls.Text_Get(enControl_StandardButtons.Ok); }
            set { Ctrls.Text_Set(ok: value); }
        }

        /// <summary>
        /// Gets or sets the apply text value.
        /// </summary>
        [Category("\tText")]
        [Description("Set Apply Text property")]
        public string Text_Apply
        {
            get { return Ctrls.Text_Get(enControl_StandardButtons.Apply); }
            set { Ctrls.Text_Set(apply: value); }
        }
        /// <summary>
        /// Gets or sets the cancel text value.
        /// </summary>
        [Category("\tText")]
        [Description("Set Copy2Clipboard Text property")]
        public string Text_Cancel
        {
            get { return Ctrls.Text_Get(enControl_StandardButtons.Cancel); }
            set { Ctrls.Text_Set(cancel: value); }
        }

        /// <summary>
        /// Gets or sets the clipboard text value.
        /// </summary>
        [Category("\tText")]
        [Description("Set Copy2Clipboard Text property")]
        public string Text_Clipboard
        {
            get { return Ctrls.Text_Get(enControl_StandardButtons.Copy2Clipboard); }
            set { Ctrls.Text_Set(clipboard: value); }
        }

        /// <summary>
        /// Gets or sets the help text value.
        /// </summary>
        [Category("\tText")]
        [Description("Set Help Text property")]
        public string Text_Help
        {
            get { return Ctrls.Text_Get(enControl_StandardButtons.Help); }
            set { Ctrls.Text_Set(help: value); }
        }

        #endregion

        #endregion


        #region Events
        [Category("Blueprint")]
        [Description("Fire when key is pressed")]
        public event EventHandler<onStandardButtons_EventArgs> Event_OnClick;

        private void OkClick(object sender, EventArgs e)
        {
            if (Event_OnClick != null) 
                Event_OnClick(sender, new onStandardButtons_EventArgs(enControl_StandardButtons.Ok));
        }
        private void ApplyClick(object sender, EventArgs e)
        {
            if (Event_OnClick != null) 
                Event_OnClick(sender, new onStandardButtons_EventArgs(enControl_StandardButtons.Apply));
        }
        private void HelpClick(object sender, EventArgs e)
        {
            if (Event_OnClick != null) 
                Event_OnClick(sender, new onStandardButtons_EventArgs(enControl_StandardButtons.Help));
        }
        private void CancelClick(object sender, EventArgs e)
        {
            if (Event_OnClick != null) 
                Event_OnClick(sender, new onStandardButtons_EventArgs(enControl_StandardButtons.Cancel));
        }
        private void ClipboardClick(object sender, EventArgs e)
        {
            if (Event_OnClick != null)
                Event_OnClick(sender, new onStandardButtons_EventArgs(enControl_StandardButtons.Copy2Clipboard));
        }
        #endregion

    }
}
