using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Lamedal_UIWinForms.domain.Enumerals;

namespace Lamedal_UIWinForms.UControl.Forms.Dialog
{
    /// <summary>
    /// Save the state of the Dialog
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class stateDialog
    {
        /// <summary>
        /// The filter type
        /// </summary>
        public readonly enDialog_FileIOType FilterType;
        /// <summary>
        /// The dialog type
        /// </summary>
        public readonly enDialog_FileIO DialogType;

        /// <summary>
        /// Initializes a new instance of the <see cref="stateDialog"/> class.
        /// </summary>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <param name="filterType">Type of the filter.</param>
        public stateDialog(enDialog_FileIO dialogType = enDialog_FileIO.FileOpen, enDialog_FileIOType filterType = enDialog_FileIOType.All)
        {
            DialogType = dialogType;
            FilterType = filterType;
        }
    }
}
