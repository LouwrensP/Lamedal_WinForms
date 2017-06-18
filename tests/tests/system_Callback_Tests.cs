using System;
using Lamedal_UIWinForms.libUI.WinForms.Callback;
using Xunit;

#if !TEST_OFF // =======================
#endif

namespace Lamedal_UIWinForms.Test.tests
{
    public sealed class system_Callback_Tests
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib
        readonly system_Callback_TestsForm form = new system_Callback_TestsForm();

#if !TEST_OFF // =======================
        [Fact]
        public void ExecuteTests()
        {
            // This test is also visible - Show the form and execute the button code

            form.Show();
            form.test_AsnycMethods();
            form.Close();
        }

        [Fact]
        [STAThread]
        public void A_TestIfThreadIsSTA()
        {
            // Is threading to STA
            Assert.True(_lamedWin.libUI.WinForms.Tools.ThreadIsSTA(false));
        }
#endif

    }
}
