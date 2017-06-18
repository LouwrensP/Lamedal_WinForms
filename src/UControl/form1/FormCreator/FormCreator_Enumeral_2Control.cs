using System;
using System.Windows.Forms;
using LamedalCore.zz;
using Lamedal_UIWinForms.Events;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    /// <code>CTI;</code>
    public static class FormCreator_Enumeral_2Control<T>  
    {
        private static evEnum2Control_Changed<T> _ListChanged;

        public static void ListBox_Setup(ListBox listbox, evEnum2Control_Changed<T> onListChanged)
        {
            typeof(T).zEnum_To_IList(listbox.Items);
            Setup_Event(onListChanged);
            listbox.SelectedIndexChanged -= ListBox_SelectedIndexChanged;
            listbox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
        }

        public static void ComboBox_Setup(ComboBox combobox, evEnum2Control_Changed<T> onListChanged)
        {
            typeof(T).zEnum_To_IList(combobox.Items);
            Setup_Event(onListChanged);
            combobox.SelectedIndexChanged -= ListBox_SelectedIndexChanged;
            combobox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
        }

        private static void Setup_Event(evEnum2Control_Changed<T> onListChanged)
        {
            if (onListChanged != null)
            {
                _ListChanged -= onListChanged;
                _ListChanged += onListChanged;
            }
        }

        private static void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = "";
            var combo = sender as ComboBox;
            var listbox = sender as ListBox;
            if (listbox != null)
            {
                value = listbox.Text;
                if (value == "") return;
            } 
            else if (combo != null)
            {
                value = combo.Text;
                if (value == "") return;
            }
            else
            {
                ("Error: Control '{0}' not supported!".zFormat(sender.ToString())).zOk();
                return;
            }

            var enumValue = value.zEnum_To_EnumValue<T>();
            if (_ListChanged != null) _ListChanged(sender, e, (T)enumValue);
        }
    }
}
