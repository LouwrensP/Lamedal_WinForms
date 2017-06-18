namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public sealed class UIDesigner_
    {

        #region Menu
        /// <summary>
        /// Gets the Menu library methods.
        /// </summary>
        public UIDesigner_Menu Menu
        {
            get { return _Menu ?? (_Menu = new UIDesigner_Menu()); }
        }
        private UIDesigner_Menu _Menu;
        #endregion


        #region Service
        /// <summary>
        /// Gets the Service library methods.
        /// </summary>
        public UIDesigner_Service Service
        {
            get { return _Service ?? (_Service = new UIDesigner_Service()); }
        }
        private UIDesigner_Service _Service;
        #endregion


        #region Tools
        /// <summary>
        /// Gets the Tools library methods.
        /// </summary>
        public UIDesigner_Tools Tools
        {
            get { return _Tools ?? (_Tools = new UIDesigner_Tools()); }
        }
        private UIDesigner_Tools _Tools;
        #endregion

    }
}
