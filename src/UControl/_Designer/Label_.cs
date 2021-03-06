﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Lamedal_UIWinForms.libUI.Interfaces;

namespace Lamedal_UIWinForms.UControl._Designer
{
    [Description("This control show a label")]
    [Serializable]
    //[DefaultEvent("Event_OnValueChange")]
    [DefaultProperty("Name")]
    [Designer(typeof(UControl_Interface_Designer))] // Link the designer   
    [Docking(DockingBehavior.Ask)] // Dock in parent control
    [ToolboxBitmap(typeof(Label))]
    public sealed class Label_ : Label, IUControl
    {

    }
}
