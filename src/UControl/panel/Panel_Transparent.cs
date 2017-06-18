using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.UControl.panel
{
    /// <summary>
    /// Transparent Panel.
    /// </summary>
    [Designer(typeof(Panel_Designer))]   // Link the designer   
    [Docking(DockingBehavior.Ask)]
    public sealed class Panel_Transparent : System.Windows.Forms.Panel
    {
        private PictureBox _zPicture;
        private int _Left;
        private int _Top;
        private bool _zTransparent = true;
        private bool _zCentre;

        /// <summary>
        /// Initializes a new instance of the <see cref="Panel_Transparent"/> class.
        /// </summary>
        public Panel_Transparent()
        {
            this.Cursor = Cursors.Hand;
            MouseClick += MouseClick_EventHandler;
        }

        #region properties
        //Ctrl_Picture
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        [Category("Blueprint")]
        [Description("Set the picture control")]
        public PictureBox zPicture
        {
            get { return _zPicture; }
            set
            {
                _zPicture = value;
                if (_zPicture != null)
                {
                    _Left = _zPicture.Left;
                    _Top = _zPicture.Top;
                    _zPicture.Move -= PictureMove;
                    _zPicture.Move += PictureMove;
                }
                //this.ForeColor = zColors[0];
            }
        }

        //ZTransparent
        /// <summary>
        /// Gets or sets a value indicating whether [ transparent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ transparent]; otherwise, <c>false</c>.
        /// </value>
        [Category("Blueprint")]
        [Description("Set the Transparency")]
        public bool ZTransparent
        {
            get { return _zTransparent; }
            set
            {
                _zTransparent = value;
                Invalidate();
                Refresh();
            }
        }

        //zCentre
        /// <summary>
        /// Gets or sets a value indicating whether [centre].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [centre]; otherwise, <c>false</c>.
        /// </value>
        [Category("Blueprint")]
        [Description("Set Centre of the picture control")]
        public bool ZCentre
        {
            get { return _zCentre; }
            set
            {
                _zCentre = value;
                if (_zCentre)
                {
                    Centre_Picture();
                    _zCentre = false;
                }
            }
        }

        //zTo_Description
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [Category("Blueprint"), Description("Set Centre of the picture control")]
        public string zValue { get; set; }

        private Form ParentForm
        {
            get 
            {
                var aParent = this.Parent;
                while (aParent.Parent != null && !(aParent is Form))
                {
                    aParent = this.Parent;
                }
                if (aParent is Form) return aParent as Form;
                else return null;
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// Occurs when [event_ mouse click].
        /// </summary>
        [Category("Blueprint")]
        [Description("Fire when an item in the combobox is clicked")]
        public event EventHandler zEvent_MouseClick;
        private void MouseClick_EventHandler(object sender, EventArgs e)
        {
            if (zEvent_MouseClick != null) zEvent_MouseClick(sender, e);
        }
        #endregion


        #region Private
        private void PictureMove(object sender, EventArgs e)
        {
            // Resize this as well
            this.Left = this.Left - (_Left - _zPicture.Left);
            _Left = _zPicture.Left;

            this.Top = this.Top - (_Top - _zPicture.Top);
            _Top = _zPicture.Top;
            _zPicture.Refresh();
        }

        /// <summary>
        /// Centre the picture.
        /// </summary>
        public void Centre_Picture()
        {
            if (_zPicture == null) return;
            var aParent = this.ParentForm;
            if (aParent == null) return;

            var formCentre = aParent.Width / 2;
            var picCentre = _zPicture.Width / 2;
            _zPicture.Left = formCentre - picCentre;

            var formMiddle = aParent.Height / 2;
            var picHeight = _zPicture.Height / 2;
            _zPicture.Top = formMiddle - picHeight;
        }


        #endregion

        #region Set Transparent

        /// <summary>
        /// Gets CreateParams.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020;             // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        /// <summary>
        /// The on paint background.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background.
            if (!_zTransparent) base.OnPaintBackground(e);
        }
        #endregion

    }    
}
