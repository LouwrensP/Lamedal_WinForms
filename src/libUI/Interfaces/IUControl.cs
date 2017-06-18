using System.Drawing;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.Interfaces
{
    /// <summary>
    /// Add basic designer to controls
    /// </summary>
    public interface IUControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"/> associated with this control.
        /// </summary>
        ContextMenuStrip ContextMenuStrip { get; set; }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        string Text { get; set; }

        #region Position

        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        AnchorStyles Anchor { get; set; }

        
        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        int Left { get; set; }

        /// <summary>
        /// Gets or sets the distance, in pixels, between the top edge of the control and the top edge of its container's client area.
        /// </summary>
        int Top { get; set; }

        //int Right { get; set; }
        #endregion

        #region Draw
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        /// 
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        Font Font { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        bool Visible { get; set; }
        #endregion

        #endregion


        /// <summary>
        /// Brings the control to the front of the z-order.
        /// </summary>
        void BringToFront();

        /// <summary>
        /// Sends the control to the back of the z-order.
        /// </summary>
        void SendToBack();
    }
}
