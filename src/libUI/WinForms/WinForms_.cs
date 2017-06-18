using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.libUI.WinForms.Callback;
using Lamedal_UIWinForms.libUI.WinForms.Controls;
using Lamedal_UIWinForms.libUI.WinForms.WinDB;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Undefined)]
    public sealed class WinForms_
    {

        #region Callback
        /// <summary>
        /// Gets the Callback library methods.
        /// </summary>
        public Callback_ Callback
        {
            get { return _WinCallback ?? (_WinCallback = new Callback_()); }
        }
        private Callback_ _WinCallback;
        #endregion


        #region Dialog_Simple
        /// <summary>
        /// Gets the Dialog_Simple library methods.
        /// </summary>
        public WinForms_Dialog_Simple Dialog_Simple
        {
            get { return _Dialog_Simple ?? (_Dialog_Simple = new WinForms_Dialog_Simple()); }
        }
        private WinForms_Dialog_Simple _Dialog_Simple;
        #endregion


        #region Idle
        /// <summary>
        /// Gets the Idle library methods.
        /// </summary>
        public WinForms_Idle Idle
        {
            get { return _Idle ?? (_Idle = new WinForms_Idle()); }
        }
        private WinForms_Idle _Idle;
        #endregion


        #region Tools
        /// <summary>
        /// Gets the Tools library methods.
        /// </summary>
        public WinForms_Tools Tools
        {
            get { return _Tools ?? (_Tools = new WinForms_Tools()); }
        }
        private WinForms_Tools _Tools;
        #endregion


        #region MindMap
        /// <summary>
        /// Gets the MindMap library methods.
        /// </summary>
        public WinForms_MindMap MindMap
        {
            get { return _MindMap ?? (_MindMap = new WinForms_MindMap()); }
        }
        private WinForms_MindMap _MindMap;
        #endregion

        #region DB
        /// <summary>
        /// Gets the DB library methods.
        /// </summary>
        public WinDB_ DB
        {
            get { return _DB ?? (_DB = new WinDB_()); }
        }
        private WinDB_ _DB;
        #endregion


        #region Console
        /// <summary>
        /// Gets the Console library methods.
        /// </summary>
        public WinForms2_Console Console
        {
            get { return _Console ?? (_Console = new WinForms2_Console()); }
        }
        private WinForms2_Console _Console;
        #endregion


        #region Controls
        /// <summary>
        /// Gets the Controls library methods.
        /// </summary>
        public Controls_ Controls
        {
            get { return _Controls ?? (_Controls = new Controls_()); }
        }
        private Controls_ _Controls;
        #endregion


        #region Dialogs
        /// <summary>
        /// Gets the Dialogs library methods.
        /// </summary>
        public WinForms2_Dialogs Dialogs
        {
            get { return _Dialogs ?? (_Dialogs = new WinForms2_Dialogs()); }
        }
        private WinForms2_Dialogs _Dialogs;
        #endregion


        #region Form
        /// <summary>
        /// Gets the Forms library methods.
        /// </summary>
        public WinForms2_Form Form
        {
            get { return UI_Form ?? (UI_Form = new WinForms2_Form()); }
        }
        private WinForms2_Form UI_Form;
        #endregion


        #region FormGenerate
        /// <summary>
        /// Gets the FormGenerate library methods.
        /// </summary>
        public WinForms2_FormGenerate FormGenerate
        {
            get { return _FormGenerate ?? (_FormGenerate = new WinForms2_FormGenerate()); }
        }
        private WinForms2_FormGenerate _FormGenerate;
        #endregion


        #region Screen
        /// <summary>
        /// Gets the Screen library methods.
        /// </summary>
        public WinForms2_Screen Screen
        {
            get { return _Screen ?? (_Screen = new WinForms2_Screen()); }
        }
        private WinForms2_Screen _Screen;
        #endregion


        #region SendKeys
        /// <summary>
        /// Gets the SendKeys library methods.
        /// </summary>
        public WinForms2_SendKeys SendKeys
        {
            get { return _SendKeys ?? (_SendKeys = new WinForms2_SendKeys()); }
        }
        private WinForms2_SendKeys _SendKeys;
        #endregion


        #region Setting
        /// <summary>
        /// Gets the Setting library methods.
        /// </summary>
        public WinForms2_Setting Setting
        {
            get { return _Setting ?? (_Setting = new WinForms2_Setting()); }
        }
        private WinForms2_Setting _Setting;
        #endregion

    }
}
