using Lamedal_UIWinForms.libUI.Win32;

namespace Lamedal_UIWinForms.Enumerals
{
    /// <summary>
    /// icon sizes
    /// </summary>
    public enum enIconShell32Sizes : uint
    {
        /// <summary>(16x16) icon.</summary>
        Icon16 = shell32.shell32_IconHandle | shell32.shell32_SmallIconHandle,

        /// <summary>(32x32) icon.</summary>
        Icon32 = shell32.shell32_IconHandle | shell32.shell32_LargeIconHandle
    }
}