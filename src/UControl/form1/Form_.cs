using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.libUI.WinForms.UIDesigner;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.form1
{
    [Description("Set Windows Properties")]
    [Serializable]
    //DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(Forms_Designer))]   // Link the designer
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Component))]
    public partial class Form_ : Component
    {
        #region Init

        protected Form _formName;
        private bool _formTopMost;
        private FormStartPosition _formStartPosition;
        //private string _formText;
        protected IDesignerHost _formHost;
        protected List<Control> _formControls;
        protected bool _Form_Startup = true;

        /// <summary>
        /// Initializes a new instance of the &lt;see cref=&quot;Form_&quot;/&gt; class.
        /// </summary>
        public Form_()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Initializes a new instance of the &lt;see cref=&quot;Form_&quot;/&gt; class.
        /// </summary>
        /// <param name="container">the container</param>
        public Form_(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Setup();
        }

        #endregion

        #region properties
        [Category("\tApplication")]
        [Description("Parent Form")]
        public Form Form_Name
        {
            get { return _formName; }
            set
            {
                _formName = value;
                if (value == null) return;

                _formTopMost = _formName.TopMost;
                _formStartPosition = _formName.StartPosition;
                //_formText = _formName.Text;
                //_Parent_Form.Shown += _Parent_Form_Shown;   // Do someting when the control is shown
            }
        }
        [Category("\tLayout")]
        [Description("Form start position")]
        public FormStartPosition Form_StartPosition
        {
            get { return _formStartPosition; }
            set
            {
                _formStartPosition = value;
                Refresh_Windows();
            }
        }
        [Category("\tLayout")]
        [Description("Form text")]
        public string Form_Text
        {
            get {
                return _formName == null ? null : _formName.Text;
            }
            set
            {
                if (_formName == null) return;
                _formName.Text = value;
            }
        }
        [Category("\tLayout")]
        [Description("Form ContextMenuStrip position")]
        public ContextMenuStrip Form_ContextMenuStrip
        {
            get
            {
                if (_formName == null) return null;
                return _formName.ContextMenuStrip;
            }
            set
            {
                if (_formName == null) return;
                _formName.ContextMenuStrip = value;
            }
        }
        [Category("\tLayout")]
        [Description("Form TopMost position")]
        public bool Form_TopMost
        {
            get { return _formTopMost; }
            set
            {
                _formTopMost = value;
                Refresh_Windows();
            }
        }

        [Category("\tLayout")]
        [Description("Form Size")]
        public enFormSize Form_Size
        {
            get { return _FormSize; }
            set
            {
                _FormSize = value;
                Setup_FormSize();
            }
        }
        private enFormSize _FormSize = enFormSize.Manual;

        #endregion

        #region Methods

        private void Setup()
        {
            2000.zExecute_Async(Setup_MainForm);
        }

        protected void Setup_MainForm()
        {
            _formHost = UIDesigner_Service.IDesignerHost_FromComponent(this);
            _formName = UIDesigner_Form.Form_Main(this);
            if (_formName == null) return;  // If we do not know what the form name is -> we cannot go past this point.

            try
            {
                if (_formHost != null)
                {
                    // Basic setup of the form
                    _formControls = UIDesigner_Tools.Host_Controls_All(_formHost);
                    Setup_();
                }

            }
            catch (Exception ex)
            {
                _Form_Startup = false;
                throw;
            }
            _Form_Startup = false;

        }

        protected virtual void Setup_()
        {
            // Use this method to create controls on startup.

        }

        /// <summary>
        /// The windows refresh command.
        /// </summary>
        private void Refresh_Windows()
        {
            if (DesignMode == false) return;
            if (_formName == null)
            {
                //"Please set the parent form for Container_Windows!".OkMsg();
                return;
            }
            _formName.TopMost = _formTopMost;
            _formName.StartPosition = _formStartPosition; // Form_StartPosition.CenterScreen;
        }

        private void Setup_FormSize()
        {
            if (_Form_Startup) return;   // Prevent actions during construction
            if (Form_Size == enFormSize.Manual) return;
            if (_formName == null) return;

            UIDesigner_Generate.Form_Size(this, Form_Size);
        }
        #endregion

    }
}
