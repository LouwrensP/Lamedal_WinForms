using System;

#if !TEST_OFF // =======================
#endif

namespace Lamedal_UIWinForms.libUI.WinForms.Callback
{
    public sealed class system_Callback_Tests
    {
        private readonly LaMedalPort.UIWindows _uiWindows = LaMedalPort.UIWindows.Instance;   // Instance to UIWindows
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
            Assert.True(_uiWindows.libUI.WinForms.Tools.ThreadIsSTA(false));
        }
#endif

    }
}
