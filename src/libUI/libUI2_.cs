using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.libUI.WinForms;

namespace Lamedal_UIWinForms.libUI
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Undefined)]
    public sealed class libUI2_
    {

        #region WinForms
        /// <summary>
        /// Gets the WinForms library methods.
        /// </summary>
        public WinForms_ WinForms
        {
            get { return _WinForms ?? (_WinForms = new WinForms_()); }
        }
        private WinForms_ _WinForms;
        #endregion
        
    }
}
