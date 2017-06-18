using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    public sealed class Controls_ListView
    {

        /// <summary>
        /// Create ListView from image list.
        /// </summary>
        /// <param name="listView">The list view</param>
        /// <param name="imageList">The image list</param>
        /// <param name="view">The view setting. Default value = View.LargeIcon.</param>
        public void ListView_FromImageList(ListView listView, ImageList imageList, View view = View.LargeIcon)
        {
            listView.View = view; //View.LargeIcon;  View.Icon16;  View.Details;
            listView.LargeImageList = imageList;
            listView.SmallImageList = imageList;
            listView.Items.Clear();
            for (int ii = 0; ii < imageList.Images.Count; ii++)
            {
                ListView_FromImageList(listView, imageList, ii);
            }
        }

        /// <summary>
        /// Create ListView from image list.
        /// </summary>
        /// <param name="listView">The list view</param>
        /// <param name="imageList">The image list</param>
        /// <param name="index">The index</param>
        public static void ListView_FromImageList(ListView listView, ImageList imageList, int index)
        {
            var item1 = new ListViewItem();
            item1.ImageIndex = index;
            item1.Text = "" + imageList.Images.Keys[index];
            listView.Items.Add(item1);
        }

    }
}
