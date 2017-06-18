﻿using System;
using Lamedal_UIWinForms.Enumerals;
using Lamedal_UIWinForms.UControl.Input;

namespace Lamedal_UIWinForms.Events
{
    //[Serializable]
    //public delegate void InputControl_EventHandler(object sender, InputControl_EventArgs e);

    public sealed class evInput_Control_EventArgs : EventArgs
    {
        public Input_Control Control_;
        public enInputControl_Type ControlType;
        public object Value;
        public bool Value1;
        public bool Value2;
        public bool Value3;
        public string Text;

        /// <summary>
        /// Initializes a new instance of the <see cref="evInput_Control_EventArgs" /> class.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="value">The value.</param>
        /// <param name="text">The text.</param>
        /// <param name="value1">if set to <c>true</c> [value1].</param>
        /// <param name="value2">if set to <c>true</c> [value2].</param>
        /// <param name="value3">if set to <c>true</c> [value3].</param>
        public evInput_Control_EventArgs(enInputControl_Type controlType, object value, string text = "", bool value1 = false, bool value2 = false, bool value3 = false)
        {
            ControlType = controlType;
            Value = value;
            Text = text;

            // Chkbox Values
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
    }
}
