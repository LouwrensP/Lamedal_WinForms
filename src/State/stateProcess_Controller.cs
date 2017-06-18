using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.State
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_StateController)]
    public static class stateProcess_Controller
    {
        public static stateProcess zzState(this Process process)
        {
            return process.zObject().State_Get<stateProcess>();
        }
    }
}
