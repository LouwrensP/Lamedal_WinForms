using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.Events;

namespace Lamedal_UIWinForms.State
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class stateForm
    {
        public IObjectModel FormObjectModel;
        public EventHandler<evInput_Control_EventArgs> onValueChange;
        public bool DoEventsFlag = false;   // if true -> execute the events
    }
}
