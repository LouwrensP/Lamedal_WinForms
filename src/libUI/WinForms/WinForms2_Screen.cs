using System.Drawing;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <code>CTI;</code>
    public sealed class WinForms2_Screen
    {
        /// <summary>
        /// Make a copy of the Screens.
        /// </summary>
        /// <returns></returns>
        public Image Copy()
        {
            Image result = null;
            SendKeys.SendWait("{PRTSC 2}");
            var data = Clipboard.GetDataObject();
            if (data == null) return null;

            if (data.GetDataPresent(typeof(Bitmap)))
            {
                result = data.GetData(typeof(Bitmap)) as Bitmap;
            }
            return result;
        }

    }
}
