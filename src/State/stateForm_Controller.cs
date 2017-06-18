using System.Windows.Forms;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.State
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_StateController)]
    public static class stateForm_Controller
    {

        /// <summary>Return the form state information.</summary>
        /// <param name="form">The form</param>
        /// <returns>stateForm</returns>
        public static stateForm zzState(this Form form)
        {
            return form.zObject().State_Get<stateForm>();
        }
    }
}
