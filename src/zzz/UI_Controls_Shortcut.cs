using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.zzz
{
    public static class UI_Controls_Shortcut
    {
        /// <summary>
        /// Creates the TextBox text values from the list.
        /// </summary>
        /// <param name="textBox">The text box</param>
        /// <param name="fromList">The from list</param>
        /// <code>CTIN_Transformation;</code>
        public static void zFromList(this TextBox textBox, IList fromList)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.TextBox.FromList(textBox, fromList);
        }


        /// <summary>
        /// Converts the TextBox values to list.
        /// </summary>
        /// <param name="textBox">The text box</param>
        /// <param name="toList">The to list</param>
        /// <code>CTIN_Transformation;</code>
        public static void zToList(this TextBox textBox, IList toList)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.TextBox.ToList(textBox, toList);
        }

        /// <summary>
        /// Converts the TextBox values to list.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zToList(this TextBox textBox)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.TextBox.ToList(textBox);
        }

    }
}
