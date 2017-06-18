using System;
using System.Data;

namespace Lamedal_UIWinForms.Events
{
    /// <summary>
    /// This event should fire after the submit to DB has failed.  The idea is to take the user on his word and just commit the data.  If the DB 
    /// constraints do not allow the data to be entered, we look at reasons why.
    /// </summary>
    /// <param name="sender">The sender will be the grid (Infragistics or DevX) that the data tabel is linked to</param>
    /// <param name="table">The data table trying to submit the data</param>
    /// <param name="ex">The exception thrown during the update</param>
    /// <param name="reason">Str containing the reasons why the Commit failed</param>
    /// <returns></returns>
    public delegate bool evDataTable_Commit_PostError(object sender, DataTable table, Exception ex, out string reason);
}
