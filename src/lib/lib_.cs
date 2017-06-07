using System.Drawing.Imaging;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace Lamedal_UIWinForms.lib
{
    public sealed class lib_
    {
        /// <summary>Converts the HTML to image.</summary>
        /// <param name="filename">The filename.</param>
        /// <param name="html">The HTML.</param>
        public void ConvertHtmlToImage(string filename = @"C:\Test.png", string html = "<html><body><p>This is a shitty html code</p></body>")
        {
            var m_Bitmap = HtmlRender.RenderToImage(html, 100, 200);
            m_Bitmap.Save(filename, ImageFormat.Png);
        }
    }
}
