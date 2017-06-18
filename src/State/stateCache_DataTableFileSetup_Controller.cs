using System.Data;
using LamedalCore.zz;

namespace Lamedal_UIWinForms.State
{
    public static class stateCache_DataTableFileSetup_Controller
    {
        /// <summary>
        /// Function to return the state for the data table.
        /// </summary>
        /// <param name="dataTable">The data table</param>
        /// <returns>
        /// State_Table
        /// </returns>
        public static stateCache_DataTableFileSetup zStateCache(this DataTable dataTable)
        {
            return dataTable.zObject().State_Get<stateCache_DataTableFileSetup>();
        }
    }
}
