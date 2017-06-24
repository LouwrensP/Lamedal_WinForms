using System.Windows.Forms;
using Lamedal_UIWinForms.domain.Events;

namespace Lamedal_UIWinForms.UControl.form1.FormCreator
{
    public static class FormCreator_Enumeral_2Control_Controller
    {
        public static void zSetupEnum<T>(this ListBox listbox, evEnum2Control_Changed<T> onListChanged)
        {
            FormCreator_Enumeral_2Control<T>.ListBox_Setup(listbox, onListChanged);
        }

        public static void zSetupEnum<T>(this ComboBox combobox, evEnum2Control_Changed<T> onListChanged)
        {
            FormCreator_Enumeral_2Control<T>.ComboBox_Setup(combobox, onListChanged);
        }
    }
}