using System.Windows.Forms;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    /// <code CTI_Timestamp="2015/07/18" Group="Other" CTI_Status="Unchecked;">IgnoreGroup;CTI;</code>
    public sealed class Controls_Other
    {

        /// <summary>
        /// Setups the status text.
        /// </summary>
        /// <param name="statusLabel">The tool strip status label</param>
        /// <param name="newStatus">The new status setting. Default value = &quot;&quot;.</param>
        public void StatusLabel_SetLabel(ToolStripStatusLabel statusLabel, string newStatus = "Ready")
        {
            statusLabel.Text = newStatus;
            1.zDoEvents();
        }

    }
}
