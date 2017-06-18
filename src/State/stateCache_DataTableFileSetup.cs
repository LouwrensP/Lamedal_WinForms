using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace Lamedal_UIWinForms.State
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    public sealed class stateCache_DataTableFileSetup
    {
        // File properties
        public string File_Name = "";
        public bool File_IsCompressed;
        public bool File_SaveItOnValueChange;

        /// <summary>
        /// Initializes a new instance of the <see cref="stateCache_DataTableFileSetup"/> class.
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="compress">Compress indicator</param>
        /// <param name="saveOnChange">Save on change indicator</param>
        public stateCache_DataTableFileSetup(string filename, bool compress, bool saveOnChange)
        {
            Setup(filename, compress, saveOnChange);
        }

        /// <summary>
        /// Setups the specified filename for the cache. This can also be used for update purposes
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="compress">if set to <c>true</c> [compress].</param>
        /// <param name="saveOnChange">if set to <c>true</c> [save on change].</param>
        public void Setup(string filename, bool compress, bool saveOnChange)
        {
            File_Name = filename;
            File_IsCompressed = compress;
            File_SaveItOnValueChange = saveOnChange;
        }
    }
}
