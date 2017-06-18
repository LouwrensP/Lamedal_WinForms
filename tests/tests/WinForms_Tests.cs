using System;
using Xunit;

namespace Lamedal_UIWinForms.Test.tests
{
    public sealed class WinForms_Tests
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib

        [Fact]
        [STAThread]
        public void Clipboard_CopyStrTo_Test()
        {
            var test = "This is a test string";
            _lamedWin.libUI.WinForms.Tools.Clipboard_CopyStrTo(test);
            var test2 = _lamedWin.libUI.WinForms.Tools.Clipboard_GetStrFrom();
            Assert.Equal(test, test2);
        }
    }
}