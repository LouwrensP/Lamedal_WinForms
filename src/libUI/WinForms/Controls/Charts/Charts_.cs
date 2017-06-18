namespace Lamedal_UIWinForms.libUI.WinForms.Controls.Charts
{
    /// <code>CTI;</code>
    public sealed class Charts_
    {

        #region Mouse
        /// <summary>
        /// Gets the Mouse library methods.
        /// </summary>
        public Charts_Mouse Mouse
        {
            get { return _Mouse ?? (_Mouse = new Charts_Mouse()); }
        }
        private Charts_Mouse _Mouse;
        #endregion


        #region Setup
        /// <summary>
        /// Gets the Setup library methods.
        /// </summary>
        public Charts_Setup Setup
        {
            get { return _Setup ?? (_Setup = new Charts_Setup()); }
        }
        private Charts_Setup _Setup;
        #endregion

    }
}
