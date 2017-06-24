using System;
using Lamedal_UIWinForms.domain.Enumerals;

namespace Lamedal_UIWinForms.domain.Events
{
    /// <summary>
    /// Button Event Arguments
    /// </summary>
    public class onStandardButtons_EventArgs : EventArgs
    {
        public enControl_StandardButtons Button_Type;

        public onStandardButtons_EventArgs(enControl_StandardButtons type = enControl_StandardButtons.Ok)
        {
            Button_Type = type;
        }
    }
}