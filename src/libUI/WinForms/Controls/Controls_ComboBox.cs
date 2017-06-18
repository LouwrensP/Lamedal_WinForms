using System;
using System.Windows.Forms;
using LamedalCore;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    /// <code CTI_Timestamp="2015/02/18" CTI_Status="Unchecked;">IgnoreGroup;CTI;</code>
    public sealed class Controls_ComboBox
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>ComboBox Items from enumeral.</summary>
        /// <param name="comboBox">The combo box</param>
        /// <param name="enumToConvert">Enumeral to converts the</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        /// <code>CTIM_Generation;</code>
        public void ComboBoxFromEnum(Type enumToConvert, ComboBox comboBox, int selectedIndex = -1)
        {
            //=================
            // Generated @ 2015/02/19
            // Generated from 'BlueprintUI.Windows.UI.Controls.Items_FromEnumeral'() -> the parameter order was changed to ensure better MTIN results after transformations.
            ItemsFromEnumeral(comboBox, enumToConvert, selectedIndex);
        }

        /// <summary>ComboBox Items from enumeral.</summary>
        /// <param name="comboBox">The combo box</param>
        /// <param name="enumToConvert">Enumeral to converts the</param>
        /// <param name="selectedIndex">The selected index setting. Default value = -1.</param>
        /// <code GenerateParameter1="enumToConvert" GenerateMethodName="ComboBoxFromEnum"></code>
        public void ItemsFromEnumeral(ComboBox comboBox, Type enumToConvert, int selectedIndex = -1)
        {
            _lamed.Types.Enum.enum_2IList(comboBox.Items, enumToConvert);
            if (selectedIndex != -1) comboBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Search for item in ListBox and return the index of the item.
        /// </summary>
        /// <param name="combo">The list box.</param>
        /// <param name="searchItem">The search item.</param>
        /// <param name="selectTheItem">if set to <c>true</c> [select the item].</param>
        /// <returns></returns>
        public int SearchItem(ComboBox combo, string searchItem, bool selectTheItem = true)
        {
            combo.SelectedIndex = -1;
            for (int ii = 0; ii < combo.Items.Count; ii++)
            {
                string item = combo.Items[ii].ToString();
                if (item == searchItem)
                {
                    if (selectTheItem)
                    {
                        combo.Focus();
                        combo.SelectedIndex = ii;
                    }
                    return ii;
                }
            }
            return -1;
        }
    }
}
