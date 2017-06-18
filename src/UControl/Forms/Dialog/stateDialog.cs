using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

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
        public readonly enIOFileType FilterType;
        /// <summary>
        /// The dialog type
        /// </summary>
        public readonly enFileDialogType DialogType;

        /// <summary>
        /// Initializes a new instance of the <see cref="stateDialog"/> class.
        /// </summary>
        /// <param name="dialogType">Type of the dialog.</param>
        /// <param name="filterType">Type of the filter.</param>
        public stateDialog(enFileDialogType dialogType = enFileDialogType.FileOpen, enIOFileType filterType = enIOFileType.All)
        {
            DialogType = dialogType;
            FilterType = filterType;
        }
    }
}
