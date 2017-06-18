using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.lib.system
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Link)]
    public class system_
    {

        #region Registry
        /// <summary>
        /// Gets the Registry library methods.
        /// </summary>
        public system_Registry Registry
        {
            get { return _Registry ?? (_Registry = new system_Registry()); }
        }
        private system_Registry _Registry;
        #endregion

    }
}
