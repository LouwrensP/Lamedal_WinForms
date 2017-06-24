using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.lib.dotNet
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Link)]
    public sealed class dotNet_
    {

        #region Assembly
        /// <summary>
        /// Gets the Assembly_Get library methods.
        /// </summary>
        public dotNet_Assembly Assembly
        {
            get { return _Assembly ?? (_Assembly = new dotNet_Assembly()); }
        }
        private dotNet_Assembly _Assembly;
        #endregion

        #region Exceptions
        /// <summary>
        /// Helps with stack trace of methods. 
        /// </summary>
        public dotNet_Stacktrace Stacktrace
        {
            get { return _Stacktrace ?? (_Stacktrace = new dotNet_Stacktrace()); }
        }
        private dotNet_Stacktrace _Stacktrace;
        #endregion

        #region Resources
        /// <summary>
        /// Gets the Resources library methods.
        /// </summary>
        public dotNet_Resources Resources
        {
            get { return _Resources ?? (_Resources = new dotNet_Resources()); }
        }
        private dotNet_Resources _Resources;
        #endregion
    }
}
