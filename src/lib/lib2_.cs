using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.IO;
using Lamedal_UIWinForms.lib.dotNet;
using Lamedal_UIWinForms.lib.system;

namespace Lamedal_UIWinForms.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Undefined)]
    public sealed class lib2_
    {
        #region dotNet
        /// <summary>
        /// Gets the dotNet library methods.
        /// </summary>
        public dotNet_ dotNet
        {
            get { return _dotNet ?? (_dotNet = new dotNet_()); }
        }
        private dotNet_ _dotNet;
        #endregion

        #region system
        /// <summary>
        /// Gets the system library methods.
        /// </summary>
        public system_ system
        {
            get { return _system ?? (_system = new system_()); }
        }
        private system_ _system;
        #endregion


    }
}
