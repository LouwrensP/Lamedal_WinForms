using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    public sealed class Controls_TextBox
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Creates the TextBox text values from the list.
        /// </summary>
        /// <param name="textBox">The text box</param>
        /// <param name="fromList">The from list</param>
        public void FromList(TextBox textBox, IList fromList)
        {
            string listStr = _lamed.Types.String.List.ToString(fromList,"".NL());
            textBox.Text = listStr;
        }

        /// <summary>
        /// Converts the TextBox values to list.
        /// </summary>
        /// <param name="textBox">The text box</param>
        /// <param name="toList">The to list</param>
        public void ToList(TextBox textBox, IList toList)
        {
            _lamed.Types.List.Action.Copy_To(textBox.Lines, toList);
        }

        /// <summary>
        /// Converts the TextBox values to list.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <returns></returns>
        public List<string> ToList(TextBox textBox)
        {
            var result = new List<string>();
            ToList(textBox, result);
            return result;
        }

    }
}
