using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    public sealed class Controls_ListBox
    {

        /// <summary>
        /// Search for item in ListBox and return the index of the item.
        /// </summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="searchItem">The search item.</param>
        /// <param name="selectTheItem">if set to <c>true</c> [select the item].</param>
        /// <returns></returns>
        public int SearchItem(ListBox listBox, string searchItem, bool selectTheItem = true)
        {
            listBox.SelectedIndex = -1;
            for (int ii = 0; ii < listBox.Items.Count; ii++)
            {
                string item = listBox.Items[ii].ToString();
                if (item == searchItem)
                {
                    if (selectTheItem)
                    {
                        listBox.Focus();
                        listBox.SelectedIndex = ii;
                    }
                    return ii;
                }
            }
            return -1;
        }

        /// <summary>
        /// Return the selected items from the list box.
        /// </summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List of string</returns>
        public List<string> SelectedItems(ListBox listBox)
        {
            var result = new List<string>();
            for (int ii = 0; ii < listBox.Items.Count; ii++)
            {
                // Determine if the item is selected. 
                if (listBox.GetSelected(ii))
                {
                    string project = listBox.Items[ii].ToString();
                    result.Add(project);
                }
            }
            return result;
        }

        /// <summary>Converts the list box items to list of T.</summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List/<T/></returns>
        public List<T> AsList<T>(ListBox listBox)
        {
            return listBox.Items.OfType<T>().ToList();
        }

        /// <summary>Converts the list box controls ListBox to string list.</summary>
        /// <param name="listBox">The list box</param>
        /// <returns>List/<string/></returns>
        public List<string> AsList_Str(ListBox listBox)
        {
            return AsList<string>(listBox);
        }

        /// <summary>Function to sets the width of the ListBox so that all the items can fit.</summary>
        /// <param name="listBox">The list box</param>
        /// <param name="form">The form</param>
        /// <returns>int</returns>
        public int Width(ListBox listBox, Form form)
        {
            Graphics graphics = listBox.CreateGraphics();
            int itemLength = 0;
            for (int ii = 0; ii < listBox.Items.Count; ii++)
            {
                int tempLength =
                    Convert.ToInt32((graphics.MeasureString(listBox.Items[ii].ToString(), listBox.Font)).Width);
                if (tempLength > itemLength) itemLength = tempLength;
            }
            listBox.Width = itemLength;
            graphics.Dispose();

            // If the listbox is docked -> you need to set the form width
            var newWidth = itemLength - listBox.Width;
            if (newWidth > 0) form.Width += newWidth;
            return itemLength;
        }

        /// <summary>Executes the for each item in the ListBox. This method is very effective for batch processes.</summary>
        /// <param name="listBox">The list box</param>
        /// <param name="indexChanged">The index changed</param>
        /// <param name="stop">Stop indicator reference variable</param>
        /// <param name="method">The method invoker</param>
        /// <param name="startIndex">The start index.</param>
        public void ExecuteForEachItem(ListBox listBox, EventHandler indexChanged, ref bool stop,
            MethodInvoker method = null, int startIndex = 0)
        {
            //stop = false;   // This must be set in the parent control
            var total = listBox.Items.Count;
            try
            {
                for (int ii = startIndex; ii < total; ii++)
                {
                    listBox.SelectedIndex = ii;
                    if (stop) return;               // There might be other events linked to the listbox on the listbox that give error and want to stop the loop. This check for that condition.
                    1.zDoEvents();
                    indexChanged(null, null);
                    1.zDoEvents();
                    if (method != null) method();
                    if (stop) return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>ListBox Items from enumeral.</summary>
        /// <param name="listBox">The combo box</param>
        /// <param name="enumToConvert">Enumeral to converts the</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        public void Items_FromEnumeral(ListBox listBox, Type enumToConvert, int selectedIndex = -1)
        {
            LamedalCore_.Instance.Types.Enum.enum_2IList(listBox.Items, enumToConvert);
            if (selectedIndex != -1) listBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// ListBox Items from enumeral.
        /// </summary>
        /// <param name="listBox">The combo box</param>
        /// <param name="strList">The string list.</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        public void Items_FromList(ListBox listBox, List<string> strList, int selectedIndex = -1)
        {
            strList.zTo_IList(listBox.Items);
            if (selectedIndex != -1) listBox.SelectedIndex = selectedIndex;
        }
    }
}
