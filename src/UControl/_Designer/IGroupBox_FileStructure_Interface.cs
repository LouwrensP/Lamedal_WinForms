using Lamedal_UIWinForms.Enumerals;

namespace Lamedal_UIWinForms.UControl._Designer
{
    
    public interface IGroupBox_FileStructure_Interface
    {
        /// <summary>
        /// Gets or sets the size of the part.
        /// </summary>
        enPart_Size PartSize { get; set; }

        /// <summary>
        /// Gets or sets the type of the part.
        /// </summary>
        enPart_Type PartType { get; set; }

        /// <summary>
        /// Gets or sets the part summary.
        /// </summary>
        string PartSummary { get; set; }

        ///// <summary>
        ///// Gets or sets the part process.
        ///// </summary>        
        //ListBox.ObjectCollection PartProcess { get; set; }

    }
}
