using System.Threading;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <code>CTI;</code>
    public sealed class WinForms2_SendKeys
    {
        /// <summary>
        ///  Try to save the visual studio solution
        /// </summary>
        public void VisualStudio_SaveAllDocs()
        {
            SendKeys.Send("%{Tab}");  // Ctrl+Tab
            Thread.Sleep(200);
            SendKeys.Send("%f");  // Alt+f
            Thread.Sleep(100);
            SendKeys.Send("l");
            SendKeys.Send("%{Tab}");  // Ctrl+Tab
        }
    }
}
