using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using LamedalCore;
using Svg;
//using TheArtOfDev.HtmlRenderer.WinForms;
using Xunit;

namespace Lamedal_UIWinForms.Test.tests
{
    public class Html_Test
    {
        private static readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
        private static readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;  // Load the winforms lib

        [Fact]
        public static void Html_2PngTest()
        {
            var html = _lamed.lib.IO.RW.File_Read2Str(@"c:\badge_linecoverage.html");
            _lamedWin.lib.ConvertHtmlToImage(@"c:\test2.png", html);
            //ConvertHtmlToImage(@"c:\test2.png", html);
        }

        ///// <summary>Converts the HTML to image.</summary>
        ///// <param name="filename">The filename.</param>
        ///// <param name="html">The HTML.</param>
        //public static void ConvertHtmlToImage(string filename = @"C:\Test.png", string html = "<html><body><p><iframe src="http://www.webpage.com" width="400" height="400"></iframe></p></body></html>")
        //{
        //    var m_Bitmap = HtmlRender.RenderToImageGdiPlus(html, 100, 200);
        //    m_Bitmap.Save(filename, ImageFormat.Png);
        //}

        [Fact]
        public static void Html_2PngTest2()
        {

            // Read first frame of gif image
            using (var image = new MagickImage(@"c:\temp\badge_linecoverage.csv"))
            {
                // Save frame as jpg
                image.Write(@"c:\temp\Snakeware.jpg");
            }
        }

        
    }
}
