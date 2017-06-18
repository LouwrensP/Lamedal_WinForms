using System;
using System.ComponentModel;
using System.Windows.Forms;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.panel
{
    /// <summary>
    /// Manages hotspot images
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("Event_MouseClick")]
    [Description("Control that helps you setup hotspot links from images.")]
    //[Serializable]
    public partial class Panel_Transparent_Manager : UserControl_
    {
        private bool _zLinkAll;
        private PictureBox _ctrlPicture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Panel_Transparent_Manager" /> class.
        /// </summary>
        public Panel_Transparent_Manager()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Fire event after parent is loaded.
        /// </summary>
        protected override void Notify_ParentFormIsLoaded()
         {
             base.Notify_ParentFormIsLoaded();
             if (!Control_IsHostedInDesigner())
             {
                 this.Visible = false;
                 if (_ctrlPicture != null) ZLinkAll = true;   // This will link all events
             }
         }

         #region Events
         /// <summary>
         /// Occurs when [mouse click].
         /// </summary>
         [Category("Blueprint")]
         [Description("Fire when an item in the combobox is clicked")]
         public event EventHandler Event_MouseClick;
         private void MouseClick_EventHandler(object sender, EventArgs e)
         {
             if (Event_MouseClick != null) Event_MouseClick(sender, e);
         }
         #endregion


        #region Properties
        //Ctrl_Picture
         /// <summary>
         /// Gets or sets the picture.
         /// </summary>
         /// <value>
         /// The picture.
         /// </value>
        [Category("Blueprint")]
        [Description("Set the picture control")]
        public PictureBox Ctrl_Picture
        {
            get { return _ctrlPicture; }
            set
            {
                _ctrlPicture = value;
                if (_ctrlPicture != null) ZLinkAll = true;  // Link all hotspots
            }
        }

        #region ZLinkAll
        /// <summary>
        /// Gets or sets a value indicating whether [link all].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ link all]; otherwise, <c>false</c>.
        /// </value>
        [Category("Blueprint")]
        [Description("Link hotspots to picture")]
        public bool ZLinkAll
        {
            get { return _zLinkAll; }
            set
            {
                _zLinkAll = value;
                if (_zLinkAll && _ctrlPicture == null)
                {
                    "You must assign a picture before you can link all controls".zOk();
                    _zLinkAll = false;
                }

                if (_zLinkAll)
                {
                    try
                    {
                        if (ParentForm != null)
                        {
                            listSpots.Items.Clear();

                            // Get all parent controls
                            var listControls = Components_FromParentForm();
                            foreach (Control control in listControls)
                            {
                                if (control is Panel_Transparent) Setup_HotspotControl((Panel_Transparent)control);  // Link the control                                
                            }
                        }
                    }
                    finally
                    {
                        _zLinkAll = false;
                    }
                }
            }
        }

        private void Setup_HotspotControl(Panel_Transparent hotSpot)
        {
            if (hotSpot.Visible)
            {
                if (hotSpot.zPicture == null)
                {
                    if (hotSpot.zValue == "") ("Warning: Hotspot with name '" + hotSpot.Name + "' does not have link value!").zOk();

                    hotSpot.zPicture = Ctrl_Picture;
                }

                hotSpot.zEvent_MouseClick -= HotSpotMouseClick_EventHandler;
                hotSpot.zEvent_MouseClick += HotSpotMouseClick_EventHandler;
                listSpots.Items.Add(hotSpot.zValue);
            }
        }

        private void HotSpotMouseClick_EventHandler(object sender, EventArgs e)
        {
            var hotspot = (Panel_Transparent)sender;
            //hotspot.zTo_Description.Msg_Ok();
            MouseClick_EventHandler(hotspot.zValue, e);   // Fire the event
        }

        #endregion

        #region ctrlListBox
        /// <summary>
        /// Gets the list box.
        /// </summary>
        /// <value>
        /// The list box.
        /// </value>
        [Category("Controls")]
        [Description("ListBox Items")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]   // Used for nested controls
        [NotifyParentProperty(true)]                                                // Notify parent if child has changed
        public ListBox ctrlListBox
        {
            get { return listSpots; }
        }
        #endregion


        #endregion

    }
}
