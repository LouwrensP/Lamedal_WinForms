using System;
using Lamedal_UIWinForms.Enumerals;

namespace Lamedal_UIWinForms.Events
{
    /// <summary>
    /// Button Event Arguments
    /// </summary>
    public class evStandardButtons_EventArgs : EventArgs
    {
        public enStandardButtons Button_Type;

        public evStandardButtons_EventArgs(enStandardButtons type = enStandardButtons.Ok)
        {
            Button_Type = type;
        }
    }
}