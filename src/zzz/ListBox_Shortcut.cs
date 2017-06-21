using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.zzz
{
    public static class ListBox_Shortcut
    {

        /// <summary>
        /// Return the selected items from the list box.
        /// </summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List of string</returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zListBox_SelectedItems(this ListBox listBox)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.SelectedItems(listBox);
        }

        /// <summary>
        /// ListBox Items from enumeral.
        /// </summary>
        /// <param name="listBox">The combo box</param>
        /// <param name="strList">The string list.</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zListBox_Items_FromList(this ListBox listBox, IList<string> strList, int selectedIndex = -1)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.Items_FromList(listBox, strList, selectedIndex);
        }
        /// <summary>Converts the list box items to list of T.</summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List/<T/></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<T> zListBox_AsList<T>(this ListBox listBox)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.AsList<T>(listBox);
        }

        /// <summary>Converts the list box controls ListBox to string list.</summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List/<string/></returns>
        /// <code>CTIN_Transformation;</code>
        public static List<string> zListBox_AsList_Str(this ListBox listBox)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.AsList_Str(listBox);
        }

        /// <summary>Executes the for each item in the ListBox. This method is very effective for batch processes.</summary>
        /// <param name="listBox">The list box</param>
        /// <param name="indexChanged">The index changed</param>
        /// <param name="stop">Stop indicator reference variable</param>
        /// <param name="method">The method invoker</param>
        /// <param name="startIndex">The start index.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zListBox_ExecuteForEachItem(this ListBox listBox, EventHandler indexChanged, ref bool stop, MethodInvoker method = null, int startIndex = 0)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.ExecuteForEachItem(listBox, indexChanged, ref stop, method, startIndex);
        }

        /// <summary>ListBox Items from enumeral.</summary>
        /// <param name="listBox">The combo box</param>
        /// <param name="enumToConvert">Enumeral to converts the</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        /// <code>CTIN_Transformation;</code>
        public static void zListBox_ItemsFromEnumeral(this ListBox listBox, Type enumToConvert, int selectedIndex = -1)
        {
            Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.Items_FromEnumeral(listBox, enumToConvert, selectedIndex);
        }

        /// <summary>
        /// Search for item in ListBox and return the index of the item.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="searchItem">The search item.</param>
        /// <param name="selectTheItem">if set to <c>true</c> [select the item].</param>
        /// <returns></returns>
        /// <code>CTIN_Transformation;</code>
        public static int zListBox_SearchItem(this ListBox listBox, string searchItem, bool selectTheItem = true)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.SearchItem(listBox, searchItem, selectTheItem);
        }

        /// <summary>Function to sets the width of the ListBox so that all the items can fit.</summary>
        /// <param name="listBox">The list box</param>
        /// <param name="form">The form</param>
        /// <returns>int</returns>
        /// <code>CTIN_Transformation;</code>
        public static int zListBox_Width(this ListBox listBox, Form form)
        {
            return Lamedal_WinForms.Instance.libUI.WinForms.Controls.ListBox.Width(listBox, form);
        }
    }
}