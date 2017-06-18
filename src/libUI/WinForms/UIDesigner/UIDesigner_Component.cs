using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    /// <code>CTI;</code>
    public static class UIDesigner_Component
    {
        /// <summary>
        /// Converts the component to string.
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="addType">Add type indicator. Default value = false.</param>
        /// <param name="filterOutComponents">Filter out components indicator. Default value = false.</param>
        /// <returns>
        /// string
        /// </returns>
        public static string Component_AsStr(Component component, bool addType = false, bool filterOutComponents = false)
        {
            string typeName = "";
            var control = component as Control;
            if (filterOutComponents && control == null) return "";

            if (control != null)
            {
                if (addType) typeName = (control is Form) ? "Form: " : "Control: ";
                return typeName + control.Name;
            }

            //int split = ToString().IndexOf(' ');
            //return ToString().Substring(0, split);   // Component name in designtime
            return component.ToString();
        }

        /// <summary>
        /// Control names form from the components list.
        /// </summary>
        /// <param name="components">The components list</param>
        /// <param name="names">The names.</param>
        /// <param name="filterName">Name of the filter.</param>
        /// <returns>
        /// List<string />
        /// </returns>
        public static Component ControlNames(List<Component> components, out List<string> names, string filterName = "")
        {
            Component component1 = null;
            names = new List<string>();
            foreach (Component component in components)
            {
                string name = Component_AsStr(component, true, true);
                if (name == "") continue;

                names.Add(name);

                if (filterName != "")
                {
                    if (name == filterName) component1 = component;
                }
            }
            return component1;
        }

        /// <summary>
        /// Control names form from the components list.
        /// </summary>
        /// <param name="components">The components list</param>
        /// <param name="filterName">Name of the filter.</param>
        /// <returns>
        /// List<string/>
        /// </returns>
        public static Component ControlNames(List<Component> components, string filterName)
        {
            List<string> names;
            return ControlNames(components, out names, filterName);
        }

        /// <summary>
        /// Control names form from the components list.
        /// </summary>
        /// <param name="components">The components list</param>
        /// <returns>
        /// List<string />
        /// </returns>
        public static List<string> ControlNames(List<Component> components)
        {
            List<string> names;
            ControlNames(components, out names);
            return names;
        }

        /// <summary>
        /// Change selection form designer.
        /// </summary>
        /// <param name="host">The idesigner host</param>
        /// <param name="components">The components list</param>
        /// <param name="selectedControlName">The selected control name</param>
        /// <param name="selectComponent">if set to <c>true</c> [select component].</param>
        /// <returns></returns>
        public static Component FindComponent(IDesignerHost host, List<Component> components, string selectedControlName, bool selectComponent = true)
        {
            if (components == null) components = UIDesigner_Tools.Host_Components_All(host);
            Component control1 = ControlNames(components, selectedControlName);
            if (control1 != null && selectComponent) UIDesigner_Tools.Host_Controls_SelectedSet1(host, control1);
            return control1;
        }
    }
}
