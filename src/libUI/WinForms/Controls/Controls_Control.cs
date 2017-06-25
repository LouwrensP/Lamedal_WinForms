using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LamedalCore;
using LamedalCore.zz;
using Lamedal_UIWinForms.zzz;

namespace Lamedal_UIWinForms.libUI.WinForms.Controls
{
    /// <code CTI_Timestamp="2015/05/27" CTI_Status="Unchecked;">CTI;</code>
    public sealed class Controls_Control
    {
        private readonly Lamedal_WinForms _lamedWin = Lamedal_WinForms.Instance;
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>
        /// Send text followed by the 'Enter' key to the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="text">The text.</param>
        public void ENTERtext(Control control, string text)
        {
            control.Text = text;
            ENTER(control);
        }

        /// <summary>
        /// Send 'Enter' to the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void ENTER(Control control)
        {
            control.Focus();
            SendKeys.Send("{ENTER}");
        }

        /// <summary>
        /// Command to add the component.
        /// </summary>
        /// <param name="control">The component.</param>
        /// <param name="controlName">Name of the component.</param>
        /// <param name="controlCaption">The component caption.</param>
        /// <param name="dockStyle">The dock style.</param>
        /// <param name="parentControl">The parent component.</param>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public Control AddControl(Control control, string controlName, string controlCaption = "?",
            DockStyle dockStyle = DockStyle.None, Control parentControl = null, int width = 0)
        {
            if (parentControl != null)
            {
                control.Parent = parentControl;
                control.Dock = dockStyle;
                control.BringToFront();
            }

            if (controlCaption == "?") controlCaption = controlName;

            control.Name = controlName;
            control.Text = controlCaption;
            if (width != 0) control.Width = width;

            return control;
        }


        /// <summary>
        /// Finds the components on the control that is of the specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentControl">The parent control</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>
        /// List<T />
        /// </returns>
        public List<T> FindComponents<T>(Control parentControl, bool recursive = true)
        {
            var result = new List<T>();
            var components = FindComponents(parentControl, recursive, typeof(T));
            foreach (Component component in components)
            {
                var newO = _lamed.Types.Object.CastTo<T>(component);
                result.Add(newO);
            }
            return result;
        }
        /// <summary>
        /// Create List&lt;Component&gt; from child components.
        /// </summary>
        /// <param name="parentControl">The component.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="filterForTypes">The types.</param>
        /// <returns>
        /// List&lt;Component&gt;
        /// </returns>
        public List<Component> FindComponents(Control parentControl, bool recursive = true, params Type[] filterForTypes)
        {
            return FindComponents(parentControl.Controls, recursive, filterForTypes);
        }

        /// <summary>
        /// Create List&lt;Component&gt; from child components.
        /// </summary>
        /// <param name="parentControls">The controls.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <param name="filterForTypes">The types.</param>
        /// <returns>
        /// List&lt;Component&gt;
        /// </returns>
        public List<Component> FindComponents(IList parentControls, bool recursive = true,  params Type[] filterForTypes)
        {
            // post - Child components are filtered on types.
            // post - if no types are specified -> all child controls will be returned.
            // note - For each component's children, its children is searched recursively. 
            var result = new List<Component>();
            foreach (Control control in parentControls)
            {
                if (IsType(control, filterForTypes)) result.Add(control);

                if (recursive)
                {
                    List<Component> SubControls = FindComponents(control.Controls, recursive, filterForTypes);
                        // Do this recursively
                    result.AddRange(SubControls);
                }
            }
            return result;
        }

        /// <summary>
        /// Determines whether the specified component's type is in array of types (or interfaces).
        /// </summary>
        /// <param name="control">The component.</param>
        /// <param name="typesToTest">The types.</param>
        /// <returns></returns>
        public bool IsType(Control control, params Type[] typesToTest)
        {
            // note - The type can be an interface
            // post - if no types are provided -> result is true
            if (typesToTest.Length == 0) return true;

            var controlType = control.GetType();
            foreach (Type type in typesToTest)
            {
                if (controlType.GetInterfaces().Contains(type)) return true;
                if (controlType == type) return true;
            }
            return false;
        }

        public void Dock(Control control, DockStyle dockStyle = DockStyle.None, params Type[] filterForParentTypes)
        {
            if (dockStyle == DockStyle.None) return;  // Optimization

            if (IsType(control.Parent, filterForParentTypes))
            {
                if (control.Dock == DockStyle.None) control.Dock = dockStyle;
            }
        }

        /// <summary>
        /// Determines whether the component is hosted in the designer.
        /// </summary>
        /// <param name="control">The component.</param>
        /// <returns><c>true</c> if is hosted in designer, <c>false</c> otherwise.</returns>
        public bool IsHostedInDesigner(Control control)
        {
            while (control != null)
            {
                if (control.Site != null && control.Site.DesignMode) return true;
                control = control.Parent;
            }
            return false;
        }

        /// <summary>
        /// Add a colour border around the component.
        /// </summary>
        /// <param name="Control">The component.</param>
        /// <param name="Colour">The colour.</param>
        /// <param name="inflate">if set to <c>true</c> [inflate].</param>
        public void BorderColour(Control Control, Color? Colour = null, bool inflate = true)
        {
            Color colour = (Colour == null) ? Control.Parent.BackColor : (Color)Colour;

            using (Graphics g = Control.Parent.CreateGraphics())
            {
                Rectangle rect = Control.Bounds;
                if (inflate) rect.Inflate(1, 1);
                ControlPaint.DrawBorder(g, rect, colour, ButtonBorderStyle.Solid);
            }
            Control.Refresh();
        }

        /// <summary>
        /// Move to group box method.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="moveToGroupBox">The move to group box</param>
        /// <param name="errorIfOtherControls">if set to <c>true</c> [error if other controls].</param>
        public void MoveToContainer(Control sender, GroupBox moveToGroupBox, bool errorIfOtherControls = false)
        {
            MoveToContainer(sender, (Control)moveToGroupBox, errorIfOtherControls);
        }

        /// <summary>
        /// Move to group box method.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="moveToPanel">The move to group box</param>
        /// <param name="errorIfOtherControls">if set to <c>true</c> [error if other controls].</param>
        public void MoveToContainer(Control sender, Panel moveToPanel, bool errorIfOtherControls = false)
        {
            MoveToContainer(sender, (Control)moveToPanel, errorIfOtherControls);
        }

        /// <summary>
        /// Move to group box method.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="moveToContainer">The move to container.</param>
        /// <param name="errorIfOtherControls">if set to <c>true</c> [error if other controls].</param>
        private void MoveToContainer(Control sender, Control moveToContainer, bool errorIfOtherControls = false)
        {
            // This method is private to so that the moveToContainer types can be filtered with overload methods - do not make it public (rather add an overload method)
            if (moveToContainer == null) return;
            if (moveToContainer.Parent == null) return;
            if ((moveToContainer is Panel || moveToContainer is GroupBox) == false)
            {
                "Error: The contrainer to move the control to, must be a Panel or a Group!".zOk();
                return;
            }

            if (_lamedWin.libUI.WinForms.Controls.Control.IsHostedInDesigner(sender) == false) return;

            if (moveToContainer.Controls.Count != 0 && errorIfOtherControls)
            {
                var ex = new InvalidOperationException("Error! There are other controls on groupBox '" + moveToContainer.ToString() + "'!");
                ex.zLogLibraryMsg();
                throw ex;
            }
            moveToContainer.Controls.Add(sender);

            sender.BringToFront();
            if (sender.Dock == DockStyle.None) _lamedWin.libUI.WinForms.Controls.Control.Dock(sender, DockStyle.Top);
        }


    }
}
