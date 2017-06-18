using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lamedal_UIWinForms.UControl.panel
{
    [System.Security.Permissions.PermissionSet
    (System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class Panel_DesignerContainer : ScrollableControlDesigner
    {
        // Border
        protected override Control GetParentForComponent(IComponent component)
        {
            // When a control is parented, tell the parent is the GroupBox, not the control itself,
            // This can be used to change the parent to a sub control
            var cc = (Control)Control;
            return cc;
        }
        protected override void OnPaintAdornments(PaintEventArgs p)
        {
            // Get the user control that we're designing.
            var _panel = (Control)base.Component as Panel;

            // As you mentioned, no reason to draw this border unless the
            // BorderStyle property is set to "None"
            if (_panel == null) this.DrawBorder(p.Graphics); 
            else if (_panel.BorderStyle == BorderStyle.None)  this.DrawBorder(p.Graphics);

            // Call the base class.
            base.OnPaintAdornments(p);
        }
        protected void DrawBorder(Graphics g)
        {
            // Get the user control that we're designing.
            var component = (Control)base.Component;

            // Ensure that the user control we're designing exists and is visible.
            if ((component != null) && component.Visible)
            {
                // Draw the dashed border around the perimeter of its client area.
                using (Pen borderPen = this.BorderPen)
                {
                    Rectangle clientRect = this.Control.ClientRectangle;
                    clientRect.Width--;
                    clientRect.Height--;
                    g.DrawRectangle(borderPen, clientRect);
                }
            }
        }
        private Pen BorderPen
        {
            get
            {
                // Create a Pen object with a color that can be seen on top of
                // the control's background.
                return new Pen((this.Control.BackColor.GetBrightness() < 0.5) ?
                                ControlPaint.Light(this.Control.BackColor)
                                : ControlPaint.Dark(this.Control.BackColor)) { DashStyle = DashStyle.Dash };
            }
        }

        // Hide properties
        protected override void PreFilterProperties(IDictionary properties)
        {
            // Hide "AutoSize", "AutoSizeMode" properties
            base.PreFilterProperties(properties);

            string[] propertiesToHide = { "MinimumSize", "MaximumSize" };

            foreach (string propname in propertiesToHide)
            {
                var prop = (PropertyDescriptor)properties[propname];
                if (prop != null)
                {
                    AttributeCollection runtimeAttributes = prop.Attributes;
                    // make a copy of the original attributes 
                    // but make room for one extra attribute
                    var attrs = new Attribute[runtimeAttributes.Count + 1];
                    runtimeAttributes.CopyTo(attrs, 0);
                    attrs[runtimeAttributes.Count] = new BrowsableAttribute(false);
                    prop = TypeDescriptor.CreateProperty(this.GetType(), propname, prop.PropertyType, attrs);
                    properties[propname] = prop;
                }
            }
        }
    }
}
