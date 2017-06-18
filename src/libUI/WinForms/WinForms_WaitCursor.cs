using System;
using System.Windows.Forms;
using Lamedal_UIWinForms.UControl.Forms.Dialog;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <summary>
    /// Methods to show a waiting cursor
    /// </summary>
    public sealed class WinForms_WaitCursor : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinForms_WaitCursor" /> class.
        /// </summary>
        /// <param name="newCursor">The new cursor.</param>
        public WinForms_WaitCursor(Cursor newCursor = null)
        {
            Setup_Cursor(newCursor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinForms_WaitCursor"/> class.
        /// </summary>
        /// <param name="frmProgress">The FRM progress.</param>
        /// <param name="newCursor">The new cursor.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public WinForms_WaitCursor(Progress_WaitCursor_Form frmProgress, Cursor newCursor = null)
        {
            Setup_Cursor(newCursor);
            frmProgress.Setup();
        }

        /// <summary>
        /// Cursor setups the cursor progress.
        /// </summary>
        /// <param name="newCursor">The new cursor setting. Default value = null.</param>
        private static void Setup_Cursor(Cursor newCursor = null)
        {
            if (newCursor == null) newCursor = Cursors.WaitCursor;  // Setup the hourglass cursor
            Cursor.Current = newCursor;
        }

        #region Dispose
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WinForms_WaitCursor"/> class.
        /// </summary>
        ~WinForms_WaitCursor()
        {
            Dispose();
        }
        #endregion
    }
}
