using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LamedalCore;
using Lamedal_UIWinForms.Test.tests;

namespace Lamedal_UIWinForms.Test
{
    public partial class Form1 : Form
    {
        private static readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var html = _lamed.lib.IO.RW.File_Read2Str(@"c:\badge_linecoverage.html");
            //webBrowser1.Navigate(@"https://ci.appveyor.com/api/projects/perezLamed/lamedalcore/artifacts/dotCover/badge_linecoverage.svg");
            webBrowser1.Navigate(new Uri(@"c:\badge_linecoverage.html"));
        }
    }
}
