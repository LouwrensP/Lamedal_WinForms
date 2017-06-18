using Lamedal_UIWinForms.libUI.WinForms.Controls.Charts;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    public sealed class Controls_
    {

        #region Charts
        /// <summary>
        /// Gets the Chart library methods.
        /// </summary>
        public Charts_ Charts
        {
            get { return _Chart ?? (_Chart = new Charts_()); }
        }
        private Charts_ _Chart;
        #endregion


        #region ComboBox
        /// <summary>
        /// Gets the ComboBox library methods.
        /// </summary>
        public Controls_ComboBox ComboBox
        {
            get { return _ComboBox ?? (_ComboBox = new Controls_ComboBox()); }
        }
        private Controls_ComboBox _ComboBox;
        #endregion


        #region Control
        /// <summary>
        /// Gets the Control library methods.
        /// </summary>
        public Controls_Control Control
        {
            get { return _Control ?? (_Control = new Controls_Control()); }
        }
        private Controls_Control _Control;
        #endregion


        #region Create
        /// <summary>
        /// Gets the Create library methods.
        /// </summary>
        public Controls_Create Create
        {
            get { return _Create ?? (_Create = new Controls_Create()); }
        }
        private Controls_Create _Create;
        #endregion


        #region Events
        /// <summary>
        /// Gets the Events library methods.
        /// </summary>
        public Controls_Events Events
        {
            get { return _Events ?? (_Events = new Controls_Events()); }
        }
        private Controls_Events _Events;
        #endregion


        #region ListBox
        /// <summary>
        /// Gets the ListBox library methods.
        /// </summary>
        public Controls_ListBox ListBox
        {
            get { return _ListBox ?? (_ListBox = new Controls_ListBox()); }
        }
        private Controls_ListBox _ListBox;
        #endregion


        #region ListView
        /// <summary>
        /// Gets the ListView library methods.
        /// </summary>
        public Controls_ListView ListView
        {
            get { return _ListView ?? (_ListView = new Controls_ListView()); }
        }
        private Controls_ListView _ListView;
        #endregion


        #region Other
        /// <summary>
        /// Gets the Other library methods.
        /// </summary>
        public Controls_Other Other
        {
            get { return _Other ?? (_Other = new Controls_Other()); }
        }
        private Controls_Other _Other;
        #endregion


        #region TextBox
        /// <summary>
        /// Gets the TextBox library methods.
        /// </summary>
        public Controls_TextBox TextBox
        {
            get { return _TextBox ?? (_TextBox = new Controls_TextBox()); }
        }
        private Controls_TextBox _TextBox;
        #endregion

    }
}
