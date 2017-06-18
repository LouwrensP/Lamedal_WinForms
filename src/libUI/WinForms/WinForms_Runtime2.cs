using System.Threading;
using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class WinForms_Runtime2 : lib_Runtime
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;

        /// <summary>Determines whether the unique application name is running.</summary>
        /// <param name="mutex">The mutex variable to use</param>
        /// <param name="uniqueAppName">The unique application name</param>
        /// <param name="showMsg">Show msg indicator. Default value = true.</param>
        /// <returns>bool</returns>
        public override bool Application_IsRunning(out Mutex mutex, string uniqueAppName = "", bool showMsg = true)
        {
            if (uniqueAppName == "") uniqueAppName = _lamedWin.libUI.WinForms.Tools.Application_Name();
            var result = base.Application_IsRunning(out mutex, uniqueAppName, showMsg);

            if (result)
            {
                if (showMsg) MessageBox.Show("An instance of the application is already running.");
            }
            return result;
        }

    }
}
