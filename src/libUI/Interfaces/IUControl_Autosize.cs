using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.Interfaces
{
    /// <summary>
    /// Add extra designers to controls to setup auto sizing
    /// </summary>
    interface IUControl_Autosize
    {
        bool AutoSize { get; set; }
        AutoSizeMode AutoSizeMode { get; set; }
    }

}
