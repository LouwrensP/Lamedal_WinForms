using System.Drawing;

namespace Lamedal_UIWinForms.libUI.WinForms
{
    /// <code>CTI;</code>
    public sealed class WinForms2_Setting
    {
        /// <summary>
        /// Setups the font from the size setting. Default value = 8..
        /// </summary>
        /// <param name="size">The size setting. Default value = 8.</param>
        /// <param name="name">The name setting. Default value = &quot;Arial&quot;.</param>
        /// <param name="isBold">Is bold indicator. Default value = false.</param>
        /// <returns>Font</returns>
        public Font Font_Setup(int size = 8, string name = "Arial", bool isBold = false)
        {
            var style = (isBold) ? FontStyle.Bold : FontStyle.Regular;
            var font = new Font(name, size, style);
            return font;
        }

        /// <summary>
        /// Function to set default color when the back color is not set.
        /// </summary>
        /// <param name="backColor">The back color</param>
        /// <param name="defaultColor">The default color</param>
        /// <returns>Color</returns>
        public Color DefaultColor(Color? backColor, Color defaultColor)
        {
            Color backColor1;
            if (backColor == null) backColor1 = defaultColor;
            else backColor1 = (Color)backColor;
            return backColor1;
        }
    }
}
