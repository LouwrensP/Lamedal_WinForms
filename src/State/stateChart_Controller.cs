using System.Windows.Forms.DataVisualization.Charting;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.State
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_StateController)]
    public static class stateChart_Controller
    {
        public static stateChart zzState(this Chart chart)
        {
            return chart.zObject().State_Get<stateChart>();
        }
    }
}