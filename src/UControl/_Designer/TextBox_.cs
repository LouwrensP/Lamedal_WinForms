using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [Description("TextBox Control")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(TextBox_Designer))]   // Link the designer   
    [Docking(DockingBehavior.Ask)]
    [ToolboxBitmap(typeof(TextBox))]
    public class TextBox_ : TextBox
    {
    }
}
