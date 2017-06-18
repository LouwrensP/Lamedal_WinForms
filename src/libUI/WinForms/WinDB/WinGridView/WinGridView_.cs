namespace Lamedal_UIWinForms.libUI.WinForms.WinDB.WinGridView
{
    /// <code>CTI_Link;</code>
    public sealed class WinGridView_
    {

        public WinGridView_Columns Columns
        {
            get { return _GridView_Columns ?? (_GridView_Columns = new WinGridView_Columns()); }
        }
        private WinGridView_Columns _GridView_Columns;

        public WinGridView_Rows Rows
        {
            get { return _GridView_Rows ?? (_GridView_Rows = new WinGridView_Rows(this)); }
        }
        private WinGridView_Rows _GridView_Rows;

        #region Setup
        /// <summary>
        /// Gets the Setup library methods.
        /// </summary>
        public WinGridView_Setup Setup
        {
            get { return _Setup ?? (_Setup = new WinGridView_Setup()); }
        }
        private WinGridView_Setup _Setup;
        #endregion

    }
}
