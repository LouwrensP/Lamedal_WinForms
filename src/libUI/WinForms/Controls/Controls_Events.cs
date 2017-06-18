using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    /// <code CTI_Timestamp="2015/05/27" DefaultType="Events" CTI_Status="Unchecked;" CTI_DefaultGroup="Events" Group="Events">IgnoreGroup;CTI;</code>
    public sealed class Controls_Events
    {
        /// <summary>
        /// Determines whether the specified e (event argument) is a ENTER key.
        /// </summary>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public bool IsEnter(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                return true;
            }
            return false;
        }
    }
}
