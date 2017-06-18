using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.libUI.WinForms.UIDesigner
{
    public sealed class UIDesigner_Tools
    {
        /// <summary>Indicates that a comonents value has changed.</summary>
        public static void Change_End(DesignerActionList designer)
        {
            IComponentChangeService service = UIDesigner_Service.IComponentChangeService_FromActionList(designer);
            if (service != null) service.OnComponentChanged(designer, null, null, null);
        }

        /// <summary>Indicates that a comonents value is in the process of changing.</summary>
        public static void Change_Begin(DesignerActionList designer)
        {
            IComponentChangeService service = UIDesigner_Service.IComponentChangeService_FromActionList(designer);
            if (service != null) service.OnComponentChanging(designer, null);
        }

        /// <summary>Add a new control to the form.</summary>
        public static T Host_Controls_Add2Form<T>(IDesignerHost host, Control parent = null)
        {
            if (host == null) return default(T);

            using (DesignerTransaction Transaction = host.CreateTransaction("Host_Controls_Add2Form() - add control to form"))
            {
                IComponent newComponent = host.CreateComponent(typeof(T));
                var newControl = newComponent as Control;
                if (newControl != null)
                {
                    if (newControl is ContextMenuStrip == false)  
                    {
                        if (parent == null) parent = host.RootComponent as Control;
                        newControl.Parent = parent;
                        //newControl.Text = Text != null ? Text : newControl.Name;
                        newControl.BringToFront();
                    }
                }
                Transaction.Commit();

                var newControl2 = (T) Convert.ChangeType(newControl, typeof (T));
                return newControl2;
            }
        }

        /// <summary>
        /// Removes controls of type T from the form.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host">The idesigner host</param>
        /// <param name="showWarning">if set to <c>true</c> [show warning].</param>
        /// <param name="findTag">The find tag.</param>
        public static void Host_Controls_Remove<T>(IDesignerHost host, bool showWarning = false, string findTag = "") where T : Control
        {
            var controls = Host_Controls_All<T>(host);
            if (showWarning && controls.Count > 0)
            {
                var msg = "This will remove " + typeof(T).ToString() + ". Continue?";
                if (MessageBox_YesNo(msg) == false) return;

            }
            foreach (var control in controls)
            {
                if (typeof(T) == typeof(ToolStrip) && control is StatusStrip) continue;  // StatusStrip inherit from ToolStrip
                if (findTag != "")
                {
                    var value = "";
                    if (control.Tag != null) value = control.Tag.ToString();
                    if (value != findTag) continue;
                }
                host.DestroyComponent(control);
            }
        }

        /// <summary>
        /// Removes controls of type T from the form.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host">The idesigner host</param>
        /// <param name="showWarning">if set to <c>true</c> [show warning].</param>
        public static void Host_Components_Remove<T>(IDesignerHost host, bool showWarning = false) where T : Component
        {
            var components = Host_Controls_All<T>(host);
            if (showWarning && components.Count > 0)
            {
                var msg = "This will remove " + typeof(T).ToString() + ". Continue?";
                if (MessageBox_YesNo(msg) == false) return;

            }
            foreach (var component in components)
            {
                host.DestroyComponent(component);
            }
        }

        /// <summary>
        /// Create or remove one instance of a control of a specific type in the designer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host">The designer host</param>
        /// <param name="form">The form</param>
        /// <param name="createControl">Create control indicator. true value will create the control and false value will remove it</param>
        /// <param name="control">Return the control</param>
        /// <param name="showRemoveWarning">if set to <c>true</c> [show warning].</param>
        /// <param name="findTag">The find tag.</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool Control_Setup1<T>(IDesignerHost host, Form form, bool createControl, out T control, bool showRemoveWarning = true, string findTag = "") where T : Control
        {
            // Create and destroy controls
            control = null;
            if (host == null) return false;
            if (form == null) return false;
            var controls = Host_Controls_All<T>(host);
            if (createControl)
            {
                if (controls.Count > 0)
                {
                    if (findTag == "") control = controls[0];  // Assume the first control found is the correct one
                    else
                    {
                        // Find the specific tag value for the control
                        foreach (T control1 in controls)
                        {
                            var value = "";
                            if (control1.Tag != null) value = control1.Tag.ToString();
                            if (value == findTag)
                            {
                                control = control1;
                                break;
                            }
                        }
                    }
                    if (typeof(T) == typeof(ToolStrip) && control is StatusStrip) control = null; // StatusStrip enherit from ToolStrip => make sure we are not dealing with parent

                    if (control != null)
                    {
                        return false; // This control already exists -> return
                    }
                }
            }

            if (createControl)
            {
                // Create the control
                control = Host_Controls_Add2Form<T>(host, form);
                return true;
            }
            else
            {
                // Remove the control
                Host_Controls_Remove<T>(host, showRemoveWarning, findTag);
                return false;
            }
        }

        /// <summary>
        /// Create or remove one instance of a component of a specific type in the designer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host">The designer host</param>
        /// <param name="form">The form</param>
        /// <param name="createComponent">Create control indicator. true value will create the control and false value will remove it</param>
        /// <param name="component">Return the control</param>
        /// <param name="showWarning">if set to <c>true</c> [show warning].</param>
        /// <returns>
        /// bool
        /// </returns>
        public static bool Component_Setup1<T>(IDesignerHost host, Form form, bool createComponent, out T component, bool showWarning = true) where T : Component
        {
            // Create and destroy controls
            component = null;
            if (host == null) return false;
            if (form == null) return false;
            var components = Host_Controls_All<T>(host);
            if (createComponent && components.Count > 0) return false;  // This control already exists

            if (createComponent)
            {
                // Create the control
                component = Host_Controls_Add2Form<T>(host, form);
                return true;
            }
            else
            {
                // Remove the control
                var msg = "This will remove " + typeof (T).ToString() + ". Continue?";
                if (MessageBox_YesNo(msg) == false) return false;

                Host_Components_Remove<T>(host, showWarning); // Remove the component
                return false;
            }
        }

        /// <summary>
        /// Yes / No MessageBox
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        private static bool MessageBox_YesNo(string msg, string title = "")
        {
            return (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

       
        /// <summary>Return the selected controls.</summary>
        public static List<Component> Host_Components_All(IDesignerHost host)
        {
            if (host == null) return null;
            IContainer container = host.Container;

            // Add each component's type name and name to the list box. 
            return container.Components.OfType<Component>().ToList();
        }

        /// <summary>Return all the controls.</summary>
        public static List<Control> Host_Controls_All(IDesignerHost host)
        {
            if (host == null) return null;
            IContainer container = host.Container;

            // Add each component's type name and name to the list box. 
            return container.Components.OfType<Control>().ToList();
        }

        /// <summary>Return all the controls.</summary>
        public static List<T> Host_Controls_All<T>(IDesignerHost host)
        {
            if (host == null) return null;
            IContainer container = host.Container;
            return Host_Controls_All<T>(container);
        }

        public static List<T> Host_Controls_All<T>(IContainer container)
        {
            // Add each component's type name and name to the list box. 
            return container.Components.OfType<T>().ToList();
        }


        public static Form Host_Controls_Form(IDesignerHost host)
        {
            if (host == null) return null;

            var form = host.RootComponent as Form;
            return form;
        }

        /// <summary>Return the selected controls.</summary>
        public static List<Control> Host_Controls_Selected(IDesignerHost host)
        {
            if (host == null) return null;

            ISelectionService selectionService = UIDesigner_Service.ISelectionService_FromHost(host);
            return selectionService.GetSelectedComponents().OfType<Control>().ToList();
        }

        /// <summary>Return the selected controls.</summary>
        public static void Host_Controls_SelectionChange(IDesignerHost host, EventHandler selectionChanged, bool remove = false)
        {
            if (host == null) return;

            ISelectionService selService = UIDesigner_Service.ISelectionService_FromHost(host);
            selService.SelectionChanged -= selectionChanged;
            if (remove == false) selService.SelectionChanged += selectionChanged;
        }

        /// <summary>Return the first active control.</summary>
        public static Control Host_Controls_SelectedFirst(IDesignerHost host)
        {
            if (host == null) return null;

            List<Control> controls = Host_Controls_Selected(host);
            if (controls.Count > 0) return controls[0];

            return null;
        }

        /// <summary>Return the first active control.</summary>
        public static string Host_Controls_SelectedFirst_AsName(IDesignerHost host,bool addType = false, bool filterOutComponents = false)
        {
            var control = Host_Controls_SelectedFirst(host);
            string name = UIDesigner_Component.Component_AsStr(control, addType, filterOutComponents);
            return name;

        }
        /// <summary>Set the selected controls.</summary>
        public static void Host_Controls_SelectedSet(IDesignerHost host, List<Control> controls)
        {
            if (host == null) return;

            ISelectionService selService = UIDesigner_Service.ISelectionService_FromHost(host);
            selService.SetSelectedComponents(controls);
        }

        /// <summary>Set the selected controls.</summary>
        public static void Host_Controls_SelectedSet1(IDesignerHost host, Component control)
        {
            if (host == null) return;

            ISelectionService selService = UIDesigner_Service.ISelectionService_FromHost(host);
            var controls = new List<Component>();
            controls.Add(control);
            selService.SetSelectedComponents(controls);
        }
    }
}
