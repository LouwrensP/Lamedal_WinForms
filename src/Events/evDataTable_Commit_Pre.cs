using System.Data;

namespace Lamedal_UIWinForms.Events
{
    /// <summary>
    /// Returns false if failed
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="table">The dataTable that needs to be updated</param>
    /// <param name="reason">Problems that might occure returned in this message</param>
    /// <returns></returns>
    public delegate bool evDataTable_Commit_Pre(object sender, DataTable table, out string reason);
}
