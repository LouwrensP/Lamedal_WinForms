using Lamedal_UIWinForms.libUI.WinForms.WinDB.WinGridView;

namespace Lamedal_UIWinForms.libUI.WinForms.WinDB
{
    /// <code>CTI_Link;</code>
    public sealed class WinDB_
    {

        #region GridView
        /// <summary>
        /// Gets the GridView library methods.
        /// </summary>
        public WinGridView_ GridView
        {
            get { return _GridView ?? (_GridView = new WinGridView_()); }
        }
        private WinGridView_ _GridView;
        #endregion

    }
}
