using System;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.Callback
{
    public sealed partial class system_Callback_TestsForm : Form
    {
        public system_Callback_TestsForm()
        {
            InitializeComponent();
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            test_AsnycMethods();
        }

        public void test_AsnycMethods()
        {
            // Call myMethod 100 times
            var name = (chkReset.Checked) ? "uniqueName" : ""; 
            for (int ii = 0; ii < 100; ii++)
            {
                100.zExecute_Async(myMethod, name);    
            }
        }

        private void myMethod()
        {
            int total = Int(txtCount.Text);
            txtCount.Text = Str(total + 1);
        }

        /// <summary>
        /// Function to return string  from the int value.
        /// </summary>
        /// <param name="intValue">The int value</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillchar">The fillchar setting. Default value = &apos;0&apos;.</param>
        /// <param name="zeroValue">The ero value setting. Default value = &quot;0&quot;.</param>
        /// <returns>string</returns>
        [Pure]
        public string Str(int intValue, int minWidth = 0, char fillchar = '0', string zeroValue = "0")
        {
            string result = intValue.ToString();
            Str(ref result, minWidth, fillchar, zeroValue);
            return result;
        }

        /// <summary>
        /// Format the string to number value.
        /// </summary>
        /// <param name="result">The result reference variable</param>
        /// <param name="minWidth">The minimum width setting. Default value = 0.</param>
        /// <param name="fillChar">The fill character setting. Default value = &apos;0&apos;.</param>
        /// <param name="zeroValue">The ero value setting. Default value = &quot;0&quot;.</param>
        public void Str(ref string result, int minWidth = 0, char fillChar = '0', string zeroValue = "0")
        {
            if (minWidth != 0) result = result.PadLeft(minWidth, fillChar); // Add the fill char
            if (zeroValue != "0" && result == "0") result = result.Replace("0", zeroValue); // Define the 0 char
        }

        /// <summary>
        /// Function to return int  from the string value.
        /// </summary>
        /// <param name="strValue">The string value</param>
        /// <param name="nullValue">The null value setting. Default value = 0.</param>
        /// <returns>int</returns>
        [Pure]
        public int Int(string strValue, int nullValue = 0)
        {
            int iValue;
            bool result = int.TryParse(strValue, out iValue);
            if (!result)
            {
                double dValue;
                result = double.TryParse(strValue, out dValue);
                if (result) iValue = (int)(dValue + 0.5);
            }

            return result ? iValue : nullValue;
        }
    }
}
